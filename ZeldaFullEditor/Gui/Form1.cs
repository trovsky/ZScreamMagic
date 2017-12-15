﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;

namespace ZeldaFullEditor
{

    public partial class zscreamForm : Form
    {
        public zscreamForm()
        {
            InitializeComponent();
        }

        PaletteViewer paletteViewer;

        private void Form1_Load(object sender, EventArgs e)
        {
            actionsListbox.DisplayMember = "Name";
            palettePicturebox.Image = new Bitmap(256, 340);
            paletteViewer = new PaletteViewer(palettePicturebox);
        }




        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save Functions
            //Expand ROM to 2MB
            if (anychange == true)
            {
                DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    all_rooms[room.index] = room;
                }
            }





            Save save = new Save(all_rooms);
            //save.saveRoomsHeaders();
            //save.saveallChests();
            //save.saveallSprites();
            save.saveAllObjects();



            FileStream fs = new FileStream(openRomFileDialog.FileName, FileMode.Open, FileAccess.Write);
            fs.Write(ROM.DATA, 0, 0x200000);
            fs.Close();
        }


        public void initChestGfx()
        {
            for(int i = 0;i<75;i++)
            {
                GFX.chestitems_bitmap[i] = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                GFX.begin_draw(GFX.chestitems_bitmap[i], 16, 16);
                new Chest(0, 0, (byte)i, false, true).ItemsDraw((byte)i, 0, 0);
                GFX.end_draw(GFX.chestitems_bitmap[i]);


            }

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRomFileDialog.ShowDialog();
        }
        Room room;
        bool header = false;
        Room[] all_rooms = new Room[296];
        private void openRomFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            byte[] tempRom;
            FileStream fs = new FileStream(openRomFileDialog.FileName, FileMode.Open, FileAccess.Read);
            tempRom = new byte[fs.Length];
            fs.Read(tempRom, 0, (int)fs.Length);
            fs.Close();

            if (tempRom.Length == 0x100200)
            {
                ROM.DATA = new byte[0x100000];
                Array.Copy(tempRom, 0x200, ROM.DATA, 0x00, 0x100000);
                header = true;
            }
            else
            {
                ROM.DATA = new byte[tempRom.Length];
                tempRom.CopyTo(ROM.DATA, 0x0);
            }
            checkFileSupport();


        }

        public void checkFileSupport()
        {
            string title = getHeaderTitle();
            if (title == "VTC")
            {
                Constants.Init_Jp(true); //VT
                load_default_room();
            }
            else if (title == "ZEL")
            {
                Constants.Init_Jp(); //JP
                load_default_room();
            }
            else if (title == "THE")
            {
                //US
                load_default_room();
            }
            else
            {
                //Constants.Init_Jp(true); //VT
                ROM.DATA = null;
                MessageBox.Show("Sorry that ROM is not supported :(", "Error");
                //load_default_room();
            }
        }

        public string getHeaderTitle()
        {
            string title = "";
            for (int i = 0; i < 3; i++)
            {
                title += (char)ROM.DATA[0x07FC0 + i];
            }
            return title;
        }

        short[][] dungeons_rooms = new short[15][];
        public void loadRoomList()
        {
            dungeons_rooms[0] = new short[] { 1, 2, 17, 18, 32, 33, 34, 48, 50, 64, 65, 66, 80, 81, 82, 85, 96, 97, 98, 112, 113, 114, 128, 129, 130, 176, 192, 208, 224 };
            dungeons_rooms[1] = new short[] { 137, 153, 168, 169, 170, 184, 185, 186, 200, 201, 216, 217, 218 };
            dungeons_rooms[2] = new short[] { 51, 67, 83, 99, 115, 116, 117, 131, 132, 133 };
            dungeons_rooms[3] = new short[] { 7, 23, 39, 49, 119, 135, 167 };
            dungeons_rooms[4] = new short[] { 9, 10, 11, 25, 26, 27, 42, 43, 58, 59, 74, 75, 90, 106 };
            dungeons_rooms[5] = new short[] { 6, 22, 38, 40, 52, 53, 54, 55, 56, 70, 84, 102, 118 };
            dungeons_rooms[6] = new short[] { 68, 69, 100, 101, 171, 172, 187, 188, 203, 204, 219, 220 };
            dungeons_rooms[7] = new short[] { 41, 57, 73, 86, 87, 88, 89, 103, 104 };
            dungeons_rooms[8] = new short[] { 14, 30, 31, 46, 62, 63, 78, 79, 94, 95, 110, 126, 127, 142, 158, 159, 174, 175, 190, 191, 206, 222 };
            dungeons_rooms[9] = new short[] { 144, 145, 146, 147, 151, 152, 160, 161, 162, 163, 177, 178, 179, 193, 194, 195, 209, 210 };
            dungeons_rooms[10] = new short[] { 4, 19, 20, 21, 35, 36, 164, 180, 181, 182, 183, 196, 197, 198, 199, 213, 214 };
            dungeons_rooms[11] = new short[] { 12, 13, 28, 29, 61, 76, 77, 91, 92, 93, 107, 108, 109, 123, 124, 125, 139, 140, 141, 149, 150, 155, 156, 157, 165, 166 };
            dungeons_rooms[12] = new short[] { 0, 3, 8, 16, 24, 44, 47, 60, 223, 225, 226, 227, 228, 229, 230, 231, 232, 234, 235, 237, 238, 239, 240, 241, 248, 249, 250, 251, 253, 254, 255, 266, 267, 268, 269, 270, 274, 275, 276, 277, 278, 279, 283, 286, 288, 291, 292, 293, 294, 295 };
            dungeons_rooms[13] = new short[] { 242, 243, 244, 245, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 271, 272, 273, 280, 281, 282, 284, 285, 287 };
            dungeons_rooms[14] = new short[] { 5, 15, 37, 45, 71, 72, 105, 111, 120, 121, 122, 134, 136, 138, 143, 148, 154, 173, 189, 202, 205, 207, 211, 212, 215, 221, 233, 236, 246, 247, 252 };
            if (radioButton2.Checked == true)
            {
                roomListBox.Items.Clear();
                if (comboBox1.SelectedIndex != -1)
                {
                    foreach (short rid in dungeons_rooms[comboBox1.SelectedIndex])
                    {
                        roomListBox.Items.Add(new ListRoomName(rid, "[" + rid + "] " + room_names.room_name[rid]));
                    }
                }
            }
            else
            {
                roomListBox.Items.Clear();

                for (int i = 0; i < 296; i++)
                {
                    roomListBox.Items.Add(new ListRoomName(i, "[" + i + "] " + room_names.room_name[i]));
                }

                roomListBox.SelectedIndex = 260;
            }


        }

        public void load_default_room()
        {
            tabControl1.Enabled = true;

            byte[] bpp3data = Compression.DecompressTiles(); //decompress almost all the gfx from the game
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data); //transform them into 4bpp

            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i)); // create all rooms
            }

            roomListBox.Items.Clear();
            roomListBox.ValueMember = "Name";
            Room_Name room_names = new Room_Name();
            loadRoomList();
            initChestGfx();
            for (int i = 0; i < 75; i++)
            {
                chestpicker.listView1.Items.Add(ChestItems_Name.name[i]);
                chestpicker.listView1.Items[i].ImageIndex = i;
            }
            chestpicker.chestItemsImagesList.Images.AddRange(GFX.chestitems_bitmap);
            chestpicker.listView1.LargeImageList = chestpicker.chestItemsImagesList;


            objectSelector.room = all_rooms[260];
            room.bg2 = Background2.Normal;
            objectSelector.createObjects();

            roomListBox.SelectedIndex = 260;//set start room on link's house
            paletteViewer.update();

            bg3modeButton.Enabled = true;
            bg2modeButton.Enabled = true;
            bg1modeButton.Enabled = true;
            allbgsButton.Enabled = true;
            chestmodeButton.Enabled = true;
            saveButton.Enabled = true;
            blockmodeButton.Enabled = true;
            torchmodeButton.Enabled = true;
            spritemodeButton.Enabled = true;
            potmodeButton.Enabled = true;
            doormodeButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            foreach(object ti in editToolStripMenuItem.DropDownItems)
            {
                if (ti is ToolStripDropDownItem)
                {
                    (ti as ToolStripDropDownItem).Enabled = true;
                }
            }


            /*toolStrip1.Items[0].Enabled = true;
            toolStrip1.Items[1].Enabled = true;
            toolStrip1.Items[9].Enabled = true;
            toolStrip1.Items[6].Enabled = true;
            toolStrip1.Items[12].Enabled = true;
            toolStrip1.Items[13].Enabled = true;
            toolStrip1.Items[14].Enabled = true;*/

            project_loaded = true;
            updateTimer.Enabled = true;
            pictureBox1.Image = roomBitmap;
            g = Graphics.FromImage(roomBitmap);
            need_refresh = true;

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //Not sure if i'll use that or not maybe for animation?

            drawRoom();

        }

        //Mouse selection system

        bool found = false;
        bool mouse_down = false;
        int mx = 0;
        int my = 0;
        int last_mx = 0;
        int last_my = 0;
        int dragx = 0;
        int dragy = 0;
        int move_x = 0;
        int move_y = 0;
        bool selection_moving = false;
        bool selection_resize = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mouse_down == false)
                {
                    if (resizing != ObjectResize.None)
                    {
                        selection_resize = true;
                        mouse_down = true;
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        (room.selectedObject[0] as Room_Object).oldSize = (room.selectedObject[0] as Room_Object).size;
                        (room.selectedObject[0] as Room_Object).savedSize = (room.selectedObject[0] as Room_Object).size;
                        return;
                    }
                    found = false;
                    if (spritemodeButton.Checked)
                    {
                        dragx = ((e.X) / 16);
                        dragy = ((e.Y) / 16);
                        if (room.selectedObject.Count == 1)
                        {
                            room.selectedObject.Clear();
                        }
                        foreach (Sprite spr in room.sprites)
                        {
                            if (isMouseCollidingWith(spr, e))
                            {
                                if (spr.selected == false)
                                {
                                    room.selectedObject.Add(spr);
                                    spr.selected = true;
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any sprites to click on so just clear the selection
                        {
                            room.selectedObject.Clear();
                        }
                    }
                    else if (potmodeButton.Checked)
                    {
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        if (room.selectedObject.Count == 1)
                        {
                            foreach (Object o in room.pot_items)
                            {
                                (o as PotItem).selected = false;
                            }
                            room.selectedObject.Clear();
                        }
                        foreach (PotItem item in room.pot_items)
                        {
                            if (isMouseCollidingWith(item, e))
                            {
                                if (item.selected == false)
                                {
                                    room.selectedObject.Add(item);
                                    item.selected = true;
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any items to click on so just clear the selection
                        {
                            room.selectedObject.Clear();
                        }
                    }
                    else if (selectedLayer >= 0)
                    {

                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        bool already_in = false;
                        Room_Object objectFound = null;
                        found = false;
                        for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                        {
                            Room_Object obj = room.tilesObjects[i];
                            if (isMouseCollidingWith(obj,e))
                            {
                                if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr)
                                {
                                    if (room.selectedObject.Count == 0)
                                    {
                                        room.selectedObject.Add(obj);
                                    }
                                    else //there's already objects selected
                                    {
                                        //check if the object we found is already in selected object if so do nothing
                                        //otherwise clear objects and select the new one
                                        foreach(Room_Object o in room.selectedObject)
                                        {
                                            if (o == obj)
                                            {
                                                objectFound = o;
                                                already_in = true;
                                                break;
                                            }
                                        }
                                        if (already_in == false)
                                        {
                                            //objectToRemove
                                            if (ModifierKeys == Keys.Shift)
                                            {
                                                room.selectedObject.Add(obj);
                                            }
                                            else
                                            {
                                                room.selectedObject.Clear();
                                                room.selectedObject.Add(obj);
                                            }
                                        }
                                        else //if item is already in but we hold control then remove it instead
                                        {
                                            if (ModifierKeys == Keys.Control)
                                            {
                                                room.selectedObject.Remove(objectFound);
                                            }
                                        }
                                    }
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any Tiles to click on so just clear the selection
                        {
                            room.selectedObject.Clear();
                        }
                    }
                    //drawRoom(); //Redraw the room
                    mouse_down = true;
                    move_x = 0;
                    move_y = 0;
                    mx = dragx;
                    my = dragy;
                }

            }
        }
        bool project_loaded = false;
        bool need_refresh = false;
        ObjectResize resizing;
        int move_x_last = 0;
        int move_y_last = 0;
        public enum ObjectResize
        {
            None, Left, Right, Up, Down, UpLeft, UpRight, DownLeft, DownRight
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (project_loaded == true)
            {
                //Cursor.Current = Cursors.Default;
                if (room.selectedObject.Count == 1)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        int rightBorder = ((room.selectedObject[0] as Room_Object).x * 8) + (room.selectedObject[0] as Room_Object).width;
                        int bottomBorder = ((room.selectedObject[0] as Room_Object).y * 8) + (room.selectedObject[0] as Room_Object).height;
                        int leftBorder = ((room.selectedObject[0] as Room_Object).x * 8);
                        int topBorder = ((room.selectedObject[0] as Room_Object).y * 8);

                        if (mouse_down == false)
                        {
                            resizing = ObjectResize.None;
                            if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //right
                                e.Y >= topBorder + 2 && e.Y <= bottomBorder - 2)
                            {
                                Cursor.Current = Cursors.SizeWE;
                                resizing = ObjectResize.Right;

                            }
                            else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //left
                                e.Y >= topBorder + 2 && e.Y <= bottomBorder - 2)
                            {
                                Cursor.Current = Cursors.SizeWE;
                                resizing = ObjectResize.Left;
                            }
                            else if (e.X >= (leftBorder + 4) && e.X <= (rightBorder - 4) && //up
                                e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                            {
                                Cursor.Current = Cursors.SizeNS;
                                resizing = ObjectResize.Up;
                            }
                            else if (e.X >= (leftBorder + 4) && e.X <= (rightBorder - 4) && //down
                                e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                            {
                                Cursor.Current = Cursors.SizeNS;
                                resizing = ObjectResize.Down;
                            }
                            else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //diagonal up left
                                e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                            {
                                Cursor.Current = Cursors.SizeNWSE;
                                resizing = ObjectResize.UpLeft;
                            }
                            else if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //diagonal bottom right
                                e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                            {
                                Cursor.Current = Cursors.SizeNWSE;
                                resizing = ObjectResize.DownRight;
                            }
                            else if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //diagonal up right
                                e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                            {
                                Cursor.Current = Cursors.SizeNESW;
                                resizing = ObjectResize.UpRight;
                            }
                            else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //diagonal bottom left
                                e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                            {
                                Cursor.Current = Cursors.SizeNESW;
                                resizing = ObjectResize.DownLeft;
                            }
                        }
                        else
                        {
                            if (resizing != ObjectResize.None)
                            {
                                if (resizing == ObjectResize.Right)
                                {
                                    Cursor.Current = Cursors.SizeWE;
                                    dragx = (room.selectedObject[0] as Room_Object).x;
                                }
                                else if (resizing == ObjectResize.Left)
                                {
                                    Cursor.Current = Cursors.SizeWE;
                                    dragx = (room.selectedObject[0] as Room_Object).x;
                                }
                            }
                        }
                    }
                }

                if (mouse_down)
                {

                    selection_moving = false;
                    if (spritemodeButton.Checked)
                    {
                        mx = ((e.X) / 16);
                        my = ((e.Y) / 16);
                    }
                    else if (potmodeButton.Checked)
                    {
                        mx = ((e.X) / 8);
                        my = ((e.Y) / 8);
                    }
                    else if (selectedLayer >= 0)
                    {
                        mx = ((e.X) / 8);
                        my = ((e.Y) / 8);
                    }

                    move_x = mx - dragx; //number of tiles mouse is compared to starting drag point X
                    move_y = my - dragy; //number of tiles mouse is compared to starting drag point Y

                    if (selection_resize == false)
                    {
                        if (mx != last_mx || my != last_my)
                        {
                            need_refresh = true;
                        }
                        if (room.selectedObject.Count > 0)
                        {
                            if (mx != last_mx || my != last_my)
                            {

                                move_objects();
                                //drawRoom(); //update room draw
                                anychange = true; //will prompt <room has changed> dialog
                                last_mx = mx;
                                last_my = my;
                                selection_moving = true;


                            }
                        }

                    }
                    else
                    {
                        resizing_objects();
                    }

                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selection_resize = false;

                if (mouse_down == true)
                {
                    anychange = true;
                    selection_moving = false;
                    mouse_down = false;
                    need_refresh = true;
                    if (room.selectedObject.Count == 0) //if we don't have any objects select we select what is in the rectangle
                    {
                        getObjectsRectangle();
                    }
                    else
                    {
                        setObjectsPosition();
                    }

                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                nothingselectedcontextMenu.Items[0].Enabled = true;
                singleselectedcontextMenu.Items[0].Enabled = true;
                groupselectedcontextMenu.Items[0].Enabled = true;
                string nname = "Unknown";
                if (selectedLayer >= 0)
                {
                    nname = "Object";
                    if (selectedLayer == 3)
                    {
                        nothingselectedcontextMenu.Items[0].Enabled = false;
                        singleselectedcontextMenu.Items[0].Enabled = false;
                        groupselectedcontextMenu.Items[0].Enabled = false;
                    }
                }
                else if (spritemodeButton.Checked == true)
                {
                    nname = "Sprite";
                }
                else if (chestmodeButton.Checked == true)
                {
                    nname = "Chest Item";
                }
                else if (potmodeButton.Checked == true)
                {
                    nname = "Pot Item";
                }
                nothingselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                singleselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                groupselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                if (room.selectedObject.Count == 0)
                {
                    nothingselectedcontextMenu.Show(Cursor.Position);
                }
                else if (room.selectedObject.Count == 1)
                {
                    singleselectedcontextMenu.Show(Cursor.Position);
                }
                else if (room.selectedObject.Count > 1)
                {
                    groupselectedcontextMenu.Show(Cursor.Position);
                }
            }

        }

        public void resizing_objects()
        {
            if (mx != last_mx || my != last_my)
            {
                anychange = true; //will prompt room has changed dialog
                last_mx = mx;
                last_my = my;
                need_refresh = true;
                Room_Object obj = (room.selectedObject[0] as Room_Object);
                //move_x = nbr of tiles the mouse moved x axis from drag
                //move_y = nbr of tiles the mouse moved y axis from drag
                if (resizing == ObjectResize.Right)
                {
                    if ((obj.id >= 0x00 && obj.id <= 0x5F) || (obj.id >= 0xA0 && obj.id <= 0xBF)) //horizontally scrollable
                    {
                        byte w = obj.base_width;
                        if (obj.special_zero_size != 0)
                        {
                            w = 0;
                        }
                        if (move_x > w - 1)
                        {
                            obj.size = (byte)((move_x - w) / obj.scroll_x);

                            if ((obj.size >= 15))
                            {
                                if (obj.special_zero_size != 0)
                                {
                                    obj.size = 0;
                                }
                                else
                                {
                                    obj.size = 15;
                                }
                            }
                            else if (obj.size <= 0)
                            {
                                if (obj.special_zero_size != 0)
                                {
                                    obj.size = 1;
                                }
                                else
                                {
                                    obj.size = 0;
                                    obj.DrawOnBitmap();
                                }
                            }

                            if (obj.oldSize != obj.size)
                            {
                                obj.resetSize();
                                obj.DrawOnBitmap();
                                obj.oldSize = obj.size;
                            }
                        }
                        else if (move_x < obj.base_width)
                        {
                            if (obj.special_zero_size != 0)
                            {
                                obj.size = 1;
                            }
                            else
                            {
                                obj.size = 0;
                                obj.DrawOnBitmap();
                            }
                        }
                    }

                }

            }
        }



        private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GotoRoom formGoto = new GotoRoom();
            if (formGoto.ShowDialog() == DialogResult.OK)
            {
                room = new Room(formGoto.selectedRoom);
                //drawRoom();
            }
        }
        int lastRoom = 260;
        bool anychange = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_room();

        }

        public void clear_room()
        {
            if (room != null)
            {
                redoRooms.Clear();
                actionsListbox.Items.Clear();
                room.selectedObject.Clear();
            }
        }

        public void change_room()
        {
            need_refresh = true;
            room_loaded = false;
            if (anychange)
            {
                if (roomListBox.SelectedIndex != lastRoom)
                {
                    DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {

                        //save here
                        clear_room();
                        save_room(lastRoom);
                        room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                        room.reloadGfx();
                        //room.update(false);

                        //drawRoom();
                        lastRoom = roomListBox.SelectedIndex;
                        anychange = false;

                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        roomListBox.SelectedIndex = lastRoom;
                    }
                    else
                    {
                        clear_room();
                        room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                        room.reloadGfx();

                        lastRoom = roomListBox.SelectedIndex;
                        anychange = false;
                    }
                }
            }
            else
            {
                clear_room();
                room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                room.reloadGfx();

                lastRoom = roomListBox.SelectedIndex;
            }
            paletteViewer.update();
            floor1UpDown.Value = room.floor1;
            floor2UpDown.Value = room.floor2;
            roomgfxUpDown.Value = room.blockset;
            paletteUpDown.Value = room.palette;
            //objectSelector.room = room;
            undoRooms.Clear();
            redoRooms.Clear();
            room_loaded = true;

        }

        public void save_room(int roomId)
        {
            all_rooms[roomId] = room;
        }

        Graphics g;
        Bitmap roomBitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        Bitmap overlayBitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public void drawRoom()
        {
            
            if (room.needGfxRefresh)
            {
                //objectSelector.room = room;
                //objectSelector.setupObjects();
                room.needGfxRefresh = false;
            }

            if (need_refresh)
            {
                if (undoRooms.Count > 0)
                {
                    undoButton.Enabled = true;
                }
                else
                {
                    undoButton.Enabled = false;
                }
                if (redoRooms.Count > 0)
                {
                    redoButton.Enabled = true;
                }
                else
                {
                    redoButton.Enabled = false;
                }


                //draw floor
                using (Graphics gg = Graphics.FromImage(GFX.bg1_bitmap))
                {

                    gg.DrawImage(GFX.bgr_bitmap, 0, 0); //floor 1

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if (o.layer == 0 || o.allBgs == true)
                        {
                            gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                        }
                    }

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if (o.layer == 2)
                        {
                            gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                        }
                    }
                }

                using (Graphics gg = Graphics.FromImage(GFX.bg2_bitmap))
                {
                    gg.DrawImage(GFX.floor2_bitmap, 0, 0);

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr)
                        {
                            if (o.layer == 1 || o.allBgs)
                            {
                                gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                            }
                        }
                    }
                }

                g.Clear(Color.Black);
                GFX.bg2_bitmap.MakeTransparent(Color.Fuchsia);
                GFX.bg1_bitmap.MakeTransparent(Color.Fuchsia);
                if (room.bg2 == Background2.OnTop || room.bg2 == Background2.Transparent)
                {
                    
                    if (showBG1ToolStripMenuItem.Checked)
                    {
                        g.DrawImage(GFX.bg1_bitmap, 0, 0);
                    }
                    if (showBG2ToolStripMenuItem.Checked)
                    {
                        g.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                }
                else// if (room.bg2 == Background2.Normal || room.bg2 == Background2.Parallax)
                {
                    if (showBG2ToolStripMenuItem.Checked)
                    {
                        g.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                    if (showBG1ToolStripMenuItem.Checked)
                    {
                        g.DrawImage(GFX.bg1_bitmap, 0, 0);
                    }

                }



                if (showGridToolStripMenuItem.Checked)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        g.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * 16, 0, x * 16, 512);
                    }
                    for (int y = 0; y < 32; y++)
                    {
                        g.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * 16, 512, y * 16);
                    }
                }
                if (room.chest_list.Count > 0)
                {
                    int chest_count = 0;
                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if (((o as Room_Object).options & ObjectOption.Chest) == ObjectOption.Chest)
                        {
                            if (room.chest_list.Count > chest_count)
                            {
                            room.chest_list[chest_count].x = (o as Room_Object).nx;
                            room.chest_list[chest_count].y = (o as Room_Object).ny;
                            }
                            chest_count++;
                        }
                    }
                    foreach (Chest c in room.chest_list)
                    {
                        if (c.item < 75)
                        {
                            g.DrawImage(GFX.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
                        }
                    }
                }


            }



            if (mouse_down)
            {
                int rx = dragx;
                int ry = dragy;
                if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                if (move_y < 0) { Math.Abs(ry = dragy + move_y); }


                if (room.selectedObject.Count == 0)
                {
                    if (spritemodeButton.Checked)
                    {
                        g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16));
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8));
                    }
                }


                foreach (Object o in room.selectedObject)
                {
                    if (o is Sprite)
                    {
                        g.DrawRectangle(Pens.LimeGreen, (o as Sprite).boundingbox);
                    }
                    else if (o is PotItem)
                    {
                        g.DrawRectangle(Pens.LimeGreen, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                    }
                    else if (o is Room_Object)
                    {
                        g.DrawRectangle(Pens.LimeGreen, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                    }
                }
            }


            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    g.DrawRectangle(Pens.Green, (o as Sprite).boundingbox);
                }
                else if (o is PotItem)
                {
                    g.DrawRectangle(Pens.Green, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                }
                else if (o is Room_Object)
                {
                    g.DrawRectangle(Pens.Green, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                }
            }
            DrawTestTexts();
            pictureBox1.Refresh();

            /*GFX.begin_draw(roomBitmap);
            room.drawSprites();
            room.drawPotsItems();
            GFX.end_draw(roomBitmap);*/
            need_refresh = false;

        }

        public void DrawTestTexts()
        {
            // g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            /*FontFamily[] ff = new FontFamily[10] { new FontFamily("Consolas"), new FontFamily("Arial"), new FontFamily("Calibri"), new FontFamily("Comic Sans MS"), new FontFamily("Candara"), new FontFamily("Courier New"), new FontFamily("Constantia"), new FontFamily("Segoe UI"), new FontFamily("Arial Black"), new FontFamily("Corbel") };
            for (int i = 0;i<10;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GraphicsPath gpath = new GraphicsPath();
                    gpath.AddString("Test Font", ff[i], 1, 12, new Point(32 + (j*64), 32 + (i * 24)), StringFormat.GenericDefault);
                    Pen pen = new Pen(Color.FromArgb(30, 30, 30), j);
                    g.DrawPath(pen, gpath);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                    g.FillPath(brush, gpath);
                }
            }*/
            g.SmoothingMode = SmoothingMode.Default;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
        }

        /*public void DrawStairsId()
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            foreach (StaircaseRoom r in room.staircaseRooms)
            {
                GraphicsPath gpath = new GraphicsPath();
                gpath.AddString(r.name, new FontFamily("Consolas"), 1, 12, new Point(r.x * 8, r.y * 8), StringFormat.GenericDefault);
                Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                g.DrawPath(pen, gpath);
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                g.FillPath(brush, gpath);
            }
        }*/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }


        Room_Name room_names = new Room_Name();
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = radioButton2.Checked;
            loadRoomList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomListBox.Items.Clear();
            loadRoomList();
        }
        int selectedLayer = -1;
        public void update_modes_buttons(object sender, EventArgs e)
        {
            for (int i = 6; i < 16; i++)
            {
                (toolStrip1.Items[i] as ToolStripButton).Checked = false;
            }
            (sender as ToolStripButton).Checked = true;
            room.selectedObject.Clear();

            if (allbgsButton.Checked)
            {
                selectedLayer = 3;
            }
            else if (bg1modeButton.Checked)
            {
                selectedLayer = 0;
            }
            else if (bg2modeButton.Checked)
            {
                selectedLayer = 1;
            }
            else if (bg3modeButton.Checked)
            {
                selectedLayer = 2;
            }
            else
            {
                selectedLayer = -1;
            }
            //room.update();
            need_refresh = true;
            drawRoom();
        }

        public Bitmap[] sprites_bitmap = new Bitmap[0xF3];
        public Bitmap[] chest_items_bitmap = new Bitmap[176];
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToUse howBox = new HowToUse();
            howBox.ShowDialog();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (spritemodeButton.Checked)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Sprite)
                    {
                        PickSprite spritepicker = new PickSprite();
                        for (int i = 0; i < 0xF3; i++)
                        {
                            sprites_bitmap[i] = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GFX.begin_draw(sprites_bitmap[i], 32, 32);
                            new Sprite(room, (byte)i, 0, 0, Sprites_Names.name[i], 0, 0, 0).Draw(true);
                            GFX.end_draw(sprites_bitmap[i]);

                            spritepicker.listView1.Items.Add(Sprites_Names.name[i]);
                            spritepicker.listView1.Items[i].ImageIndex = i;
                        }
                        //spritepicker.listView1.LargeImageList = new ImageList();
                        // spritepicker.listView1.LargeImageList
                        spriteImageList.Images.Clear();
                        spriteImageList.Images.AddRange(sprites_bitmap);
                        spritepicker.listView1.LargeImageList = spriteImageList;
                        //recreate all sprites images


                        if (spritepicker.ShowDialog() == DialogResult.OK)
                        {
                            List<Object> parameters = new List<Object>();
                            List<Sprite> changed_sprites = new List<Sprite>();
                            List<int> old_id = new List<int>();
                            foreach (Object o in room.selectedObject)
                            {
                                changed_sprites.Add((o as Sprite));
                                old_id.Add((o as Sprite).id);
                                (o as Sprite).id = (byte)spritepicker.listView1.SelectedIndices[0];
                                (o as Sprite).updateBBox();
                            }
                            parameters.Add(changed_sprites.ToArray());
                            parameters.Add(old_id.ToArray());
                            actionsListbox.Items.Add(new DoAction(ActionType.Change, parameters.ToArray()));
                            room.update();
                            drawRoom();

                        }
                    }

                }
                else
                {
                    PickSprite spritepicker = new PickSprite();
                    for (int i = 0; i < 0xF3; i++)
                    {
                        sprites_bitmap[i] = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GFX.begin_draw(sprites_bitmap[i], 32, 32);
                        new Sprite(room, (byte)i, 0, 0, Sprites_Names.name[i], 0, 0, 0).Draw(true);
                        GFX.end_draw(sprites_bitmap[i]);

                        spritepicker.listView1.Items.Add(Sprites_Names.name[i]);
                        spritepicker.listView1.Items[i].ImageIndex = i;
                    }
                    //spritepicker.listView1.LargeImageList = new ImageList();
                    // spritepicker.listView1.LargeImageList
                    spriteImageList.Images.Clear();
                    spriteImageList.Images.AddRange(sprites_bitmap);
                    spritepicker.listView1.LargeImageList = spriteImageList;

                    if (spritepicker.ShowDialog() == DialogResult.OK)
                    {
                        List<Object> parameters = new List<Object>();
                        List<Sprite> new_sprite = new List<Sprite>();
                        List<int> old_id = new List<int>();
                        Sprite o = new Sprite(room, (byte)spritepicker.listView1.SelectedIndices[0], (byte)mx, (byte)my, Sprites_Names.name[spritepicker.listView1.SelectedIndices[0]], 0, 0, 0);
                        new_sprite.Add((o as Sprite));
                        parameters.Add(new_sprite.ToArray());
                        room.sprites.Add(o);
                        actionsListbox.Items.Add(new DoAction(ActionType.Add, parameters.ToArray()));

                        //room.update();
                        drawRoom();

                    }
                }
            }
            else if (chestmodeButton.Checked)
            {
                Chest chestToRemove = null;
                bool foundChest = false;
                foreach (Chest c in room.chest_list)
                {
                    if (e.X >= (c.x * 8) && e.X <= (c.x * 8) + 16 &&
                        e.Y >= ((c.y-2) * 8) && e.Y <= ((c.y-2) * 8) + 16)
                    {
                        chestpicker.button3.Enabled = true;
                        DialogResult result = chestpicker.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //change chest item
                            c.item = (byte)chestpicker.listView1.SelectedIndices[0];

                        }
                        else if (result == DialogResult.No)
                        {
                            chestToRemove = c;
                        }
                        foundChest = true;
                        break;
                    }
                }
                if (foundChest == false)
                {
                    chestpicker.button3.Enabled = false;
                    DialogResult result = chestpicker.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //change chest item
                        Chest c = new Chest((byte)(e.X/8), (byte)(e.Y/8), (byte)chestpicker.listView1.SelectedIndices[0], false, false);
                        room.chest_list.Add(c);
                    }
                }

                if (chestToRemove != null)
                {
                    room.chest_list.Remove(chestToRemove);
                }
                need_refresh = true;
                anychange = true;
            }
            else if (selectedLayer >= 0 && selectedLayer < 3)
            {
                if (objectSelector.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem selectedItem = (ListViewItem)(objectSelector.tileobjectsListview.SelectedItems[0]);
                    Room_Object ro = room.addObject((short)selectedItem.Tag, (byte)mx, (byte)my, 0, (byte)selectedLayer);
                    anychange = true;
                    need_refresh = true;
                }
            }
        }
        PickObject objectSelector = new PickObject();
        PickChestItem chestpicker = new PickChestItem();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            foreach (Object o in room.selectedObject)
            {
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((o as Room_Object));
                }
            }
            resizing = ObjectResize.None;
            selection_resize = false;
            redoRooms.Clear();
            room.selectedObject.Clear();
            need_refresh = true;
        }
        List<Room> undoRooms = new List<Room>();
        List<Room> redoRooms = new List<Room>();
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selection_moving = false;
            selection_resize = false;
            room.selectedObject.Clear();
            if (undoRooms.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                redoRooms.Add(r);
                room = (Room)(undoRooms[undoRooms.Count - 1] as Room);

                foreach (Room_Object o in room.tilesObjects)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                    o.size = o.savedSize;
                }
                foreach (Sprite o in room.sprites)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }
                foreach (PotItem o in room.pot_items)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }

                room.reloadGfx();
                need_refresh = true;

                undoRooms.RemoveAt(undoRooms.Count - 1);

            }

            //room.update();


        }

        public void clearUselessRoomStuff(Room r)
        {
            foreach (Object o in r.tilesObjects)
            {
                (o as Room_Object).bitmap = null;
            }

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoRooms.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                undoRooms.Add(r);
                room = (redoRooms[redoRooms.Count - 1] as Room);
                foreach (Room_Object o in room.tilesObjects)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                    o.size = o.savedSize;
                }
                foreach (Sprite o in room.sprites)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }
                foreach (PotItem o in room.pot_items)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }

                room.reloadGfx();
                need_refresh = true;
                redoRooms.RemoveAt(redoRooms.Count - 1);
            }
            room.selectedObject.Clear();

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Sprite spr in room.sprites)
            {
                room.selectedObject.Add(spr);
            }
            // room.update();
            drawRoom();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clipboard.Clear();
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            List<SaveObject> odata = new List<SaveObject>();
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                }

            }
            Clipboard.SetData("ObjectZ", odata);

            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    room.sprites.Remove((Sprite)o);
                }
                if (o is PotItem)
                {
                    room.pot_items.Remove((PotItem)o);
                }
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((Room_Object)o);
                }
            }
            room.selectedObject.Clear();
            need_refresh = true;
            redoRooms.Clear();
            /*
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);*/

        }



        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<SaveObject> data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
            if (data.Count > 0)
            {
                int most_x = 512;
                int most_y = 512;
                foreach (SaveObject o in data)
                {
                    if (data.Count > 0)
                    {
                        if (o.x < most_x)
                        {
                            most_x = o.x;
                        }
                        if (o.y < most_y)
                        {
                            most_y = o.y;
                        }
                    }
                    else
                    {
                        most_x = 0;
                        most_y = 0;
                    }
                }
                room.selectedObject.Clear();

                foreach (SaveObject o in data)
                {
                    if (o.type == typeof(Sprite))
                    {
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), Sprites_Names.name[o.id], o.overlord, o.subtype, o.layer));
                        room.sprites.Add(spr);
                        room.selectedObject.Add(spr);
                    }
                    else if (o.type == typeof(Room_Object))
                    {
                        Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);
                        if (ro != null)
                        {
                            ro.setRoom(room);
                            ro.options = (ObjectOption)o.options;
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);
                        }
                    }
                }

                dragx = 0;
                dragy = 0;
                mouse_down = true;
                need_refresh = true;
                room.reloadGfx();
            }


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            List<SaveObject> odata = new List<SaveObject>();
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                }
            }
            Clipboard.SetData("ObjectZ", odata);

        }
        bool room_loaded = false;
        private void floor1UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (room_loaded)
            {
                room.floor1 = (byte)floor1UpDown.Value;
                room.floor2 = (byte)floor2UpDown.Value;
                //room.spriteset = (byte)SpritesetcomboBox.SelectedIndex;
                room.palette = (byte)paletteUpDown.Value;
                room.blockset = (byte)roomgfxUpDown.Value;
                need_refresh = true;
                room.reloadGfx();
                drawRoom();
                anychange = true;
            }
        }


        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDoubleclick(e, colorDialog1))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paletteViewer.randomizePalette(room.palette);
            room.reloadGfx(true);
            need_refresh = true;
        }

        public bool isMouseCollidingWith(Object o, MouseEventArgs e)
        {
            if (o is Sprite)
            {
                if (e.X >= (o as Sprite).boundingbox.X && e.X <= (o as Sprite).boundingbox.X + (o as Sprite).boundingbox.Width &&
                e.Y >= (o as Sprite).boundingbox.Y && e.Y <= (o as Sprite).boundingbox.Y + (o as Sprite).boundingbox.Height)
                {
                    return true;
                }
            }
            else if (o is PotItem)
            {
                if (e.X >= ((o as PotItem).x * 8) && e.X <= ((o as PotItem).x * 8) + 16 &&
                    e.Y >= ((o as PotItem).y * 8) && e.Y <= ((o as PotItem).y * 8) + 16)
                {
                    return true;
                }
            }
            else if (o is Room_Object)
            {
                if (e.X >= ((o as Room_Object).x * 8) && e.X <= (((o as Room_Object).x) * 8) + (o as Room_Object).width &&
                e.Y >= (((o as Room_Object).y + (o as Room_Object).drawYFix) * 8) && e.Y <= ((((o as Room_Object).y + (o as Room_Object).drawYFix)) * 8) + (o as Room_Object).height)
                {
                    return true;
                }
            }
            return false;
        }

        public void getObjectsRectangle()
        {
            if (room.selectedObject.Count == 0)
            {
                if (spritemodeButton.Checked) //we're looking for sprites
                {
                    foreach (Sprite spr in room.sprites)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
                        {
                            room.selectedObject.Add(spr);
                        }
                    }
                }
                else if (potmodeButton.Checked)//we're looking for pot items
                {
                    foreach (PotItem item in room.pot_items)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if ((new Rectangle(item.x * 8, item.y * 8, 16, 16)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            room.selectedObject.Add(item);
                        }
                    }
                }
                else if (selectedLayer >= 0)//we're looking for tiles
                {

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if ((new Rectangle((o as Room_Object).x * 8, ((o as Room_Object).y + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Door) != ObjectOption.Door)
                            {
                                if (selectedLayer == 3)
                                {
                                    room.selectedObject.Add(o);
                                }
                                else
                                {
                                    if (selectedLayer == o.layer)
                                    {
                                        room.selectedObject.Add(o);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {


                }
            }

        }

        public void setObjectsPosition()
        {
            if (room.selectedObject.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                undoRooms.Add(r);

                if (spritemodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Sprite).x = (o as Sprite).nx;
                        (o as Sprite).y = (o as Sprite).ny;
                    }
                }
                else if (potmodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as PotItem).x = (o as PotItem).nx;
                        (o as PotItem).y = (o as PotItem).ny;
                    }
                }
                else if (selectedLayer >= 0)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                        (o as Room_Object).savedSize = (o as Room_Object).size;
                        (o as Room_Object).oldSize = (o as Room_Object).size;
                    }
                }
                need_refresh = true;
                redoRooms.Clear();
            }
        }

        public void move_objects()
        {
            byte chest_count = 0;
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    (o as Sprite).nx = (byte)((o as Sprite).x + move_x);
                    (o as Sprite).ny = (byte)((o as Sprite).y + move_y);
                }
                else if (o is PotItem)
                {
                    (o as PotItem).nx = (byte)((o as PotItem).x + move_x);
                    (o as PotItem).ny = (byte)((o as PotItem).y + move_y);
                }
                else if (o is Room_Object)
                {
                    (o as Room_Object).nx = (byte)((o as Room_Object).x + move_x);
                    (o as Room_Object).ny = (byte)((o as Room_Object).y + move_y);
                }
            }



        }

        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            need_refresh = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[16 * 16 * 3];
            FileStream fs = new FileStream("generatedPalette.pal", FileMode.OpenOrCreate, FileAccess.Write);
            int i = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (x < 8)
                    {
                        data[i] = GFX.spritesPalettes[x, y].R;
                        data[i + 1] = GFX.spritesPalettes[x, y].G;
                        data[i + 2] = GFX.spritesPalettes[x, y].B;
                    }
                    else
                    {
                        data[i] = 0x00;
                        data[i + 1] = 0x00;
                        data[i + 2] = 0x00;
                    }
                    i += 3;
                }
            }
            fs.Write(data, 0, data.Length);
            fs.Close();
        }



        private void saveLayoutButton_Click(object sender, EventArgs e)
        {
            saveLayout();
        }

        public void saveLayout(bool clipboard = true)
        {

            List<SaveObject> data = new List<SaveObject>();
            if (clipboard == true)
            {
                data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
            }
            else
            {
                foreach (Object o in room.selectedObject)
                {
                    if (selectedLayer >= 0)
                    {
                        data.Add(new SaveObject((Room_Object)o));
                    }
                    else if (spritemodeButton.Checked)
                    {
                        data.Add(new SaveObject((Sprite)o));
                    }
                    else if (potmodeButton.Checked)
                    {
                        data.Add(new SaveObject((PotItem)o));
                    }
                }
                //reset it to clipboard yes
            }
            if (data != null)
            {
                if (data.Count > 0)
                {
                    //Name that layout
                    string name = "Room_Object";
                    if (data[0].type == typeof(Room_Object))
                    {
                        name = "Room_Object";
                    }
                    string f = Interaction.InputBox("Name of the new layout", "Name?", "Layout00");
                    if (f != "")
                    {
                        BinaryWriter bw = new BinaryWriter(new FileStream("Layout\\" + f, FileMode.OpenOrCreate, FileAccess.Write));
                        bw.Write((string)(name));
                        foreach (SaveObject o in data)
                        {
                            o.saveToFile(bw);
                        }
                        bw.Close();
                    }
                }
            }
        }


        RoomLayout layoutForm = new RoomLayout();

        public Bitmap drawCustomLayout(Rectangle rect)
        {
            Bitmap b = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(b))
            {

            }


            return b;
        }

        private void loadlayoutButton_Click(object sender, EventArgs e)
        {

            /*string[] files;
            foreach (string s in Directory.EnumerateDirectories("Layout\\"))
            {
                files = Directory.EnumerateFiles(s+"\\");
            }*/
            /*string[] files = Directory.EnumerateFiles("Layout\\Quadrants\\").ToArray();
            foreach(string f in files)
            {

            }

            layoutForm.ShowDialog();
            */
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            allbgsButton.Checked = true;
            update_modes_buttons(allbgsButton, e);
            string f = Interaction.InputBox("Name of the layout to load", "Name?", "Layout00");
            BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

            string type = br.ReadString();
            List<SaveObject> data = new List<SaveObject>();
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                data.Add(new SaveObject(br, typeof(Room_Object)));
            }

            if (data.Count > 0)
            {
                int most_x = 512;
                int most_y = 512;
                foreach (SaveObject o in data)
                {
                    if (data.Count > 0)
                    {
                        if (o.x < most_x)
                        {
                            most_x = o.x;
                        }
                        if (o.y < most_y)
                        {
                            most_y = o.y;
                        }
                    }
                    else
                    {
                        most_x = 0;
                        most_y = 0;
                    }
                }
                room.selectedObject.Clear();

                foreach (SaveObject o in data)
                {
                    if (o.type == typeof(Sprite))
                    {
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), Sprites_Names.name[o.id], o.overlord, o.subtype, o.layer));
                        room.sprites.Add(spr);
                        room.selectedObject.Add(spr);
                    }
                    else if (o.type == typeof(Room_Object))
                    {
                        Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);
                        if (ro != null)
                        {
                            ro.setRoom(room);
                            ro.options = o.options;
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);
                        }
                    }
                }

                dragx = 0;
                dragy = 0;
                mouse_down = true;
                need_refresh = true;
                room.reloadGfx();
            }
            
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {

                            if (o == room.tilesObjects[i])
                            {
                                room.tilesObjects.RemoveAt(i);
                                room.tilesObjects.Add(o);
                                break;
                            }
                        }
                    }
                }
                need_refresh = true;
                
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            saveLayout(false);
        }
    }

    public class ListRoomName
    {
        public string Name { get; set; }
        public int id;

        public ListRoomName(int id,string name)
        {
            this.id = id;
            this.Name = name;
        }
        
    }

    [Serializable]
    public class SaveObject
    {
        public byte x { get; set; }
        public byte y { get; set; }
        public byte layer { get; set; }
        public byte subtype { get; set; }
        public byte overlord { get; set; }
        public byte id { get; set; }
        public short tid { get; set; }
        public byte size { get; set; }
        public ObjectOption options { get; set; }

        public Type type;
        public SaveObject(Sprite sprite) //Sprite Format
        {
            this.x = sprite.x;
            this.y = sprite.y;
            this.id = sprite.id;
            this.layer = sprite.layer;
            this.subtype = sprite.subtype;
            this.overlord = sprite.overlord;
            type = typeof(Sprite);
        }

        public SaveObject(Room_Object o) //Room_Object
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = o.layer;
            this.size = o.size;
            this.options = o.options;
            type = typeof(Room_Object);
        }

        public SaveObject(PotItem o) //Pot Item
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = o.layer;
            type = typeof(PotItem);
        }

        public void saveToFile(BinaryWriter bw)
        {
            if (type == typeof(Room_Object))
            {
                bw.Write(tid);
                bw.Write(x);
                bw.Write(y);
                bw.Write(layer);
                bw.Write(size);
                bw.Write((byte)options);
            }
        }

        public SaveObject(BinaryReader br,Type type) // from file
        {

            tid = br.ReadInt16();
            x = br.ReadByte();
            y = br.ReadByte();
            layer = br.ReadByte();
            size = br.ReadByte();
            options = (ObjectOption)br.ReadByte();
            this.type = type;
        }

    }
}
