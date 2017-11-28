﻿namespace ZeldaFullEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textChestItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textPotItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.actionsListbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bg1modeButton = new System.Windows.Forms.ToolStripButton();
            this.bg2modeButton = new System.Windows.Forms.ToolStripButton();
            this.bg3modeButton = new System.Windows.Forms.ToolStripButton();
            this.spritemodeButton = new System.Windows.Forms.ToolStripButton();
            this.blockmodeButton = new System.Windows.Forms.ToolStripButton();
            this.torchmodeButton = new System.Windows.Forms.ToolStripButton();
            this.chestmodeButton = new System.Windows.Forms.ToolStripButton();
            this.potmodeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoRoomToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // gotoRoomToolStripMenuItem
            // 
            this.gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
            this.gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.gotoRoomToolStripMenuItem.Text = "Goto Room";
            this.gotoRoomToolStripMenuItem.Click += new System.EventHandler(this.gotoRoomToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textSpriteToolStripMenuItem,
            this.textChestItemToolStripMenuItem,
            this.textPotItemToolStripMenuItem,
            this.showGridToolStripMenuItem,
            this.showBG2ToolStripMenuItem,
            this.showBG1ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // textSpriteToolStripMenuItem
            // 
            this.textSpriteToolStripMenuItem.Name = "textSpriteToolStripMenuItem";
            this.textSpriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textSpriteToolStripMenuItem.Text = "Text Sprite";
            // 
            // textChestItemToolStripMenuItem
            // 
            this.textChestItemToolStripMenuItem.Name = "textChestItemToolStripMenuItem";
            this.textChestItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textChestItemToolStripMenuItem.Text = "Text ChestItem";
            // 
            // textPotItemToolStripMenuItem
            // 
            this.textPotItemToolStripMenuItem.Name = "textPotItemToolStripMenuItem";
            this.textPotItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textPotItemToolStripMenuItem.Text = "Text PotItem";
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            // 
            // showBG2ToolStripMenuItem
            // 
            this.showBG2ToolStripMenuItem.Checked = true;
            this.showBG2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG2ToolStripMenuItem.Name = "showBG2ToolStripMenuItem";
            this.showBG2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showBG2ToolStripMenuItem.Text = "Show BG2";
            // 
            // showBG1ToolStripMenuItem
            // 
            this.showBG1ToolStripMenuItem.Checked = true;
            this.showBG1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG1ToolStripMenuItem.Name = "showBG1ToolStripMenuItem";
            this.showBG1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showBG1ToolStripMenuItem.Text = "Show BG1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.howToUseToolStripMenuItem.Text = "How to Use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openRomFileDialog
            // 
            this.openRomFileDialog.FileName = "Zelda 3 ROM";
            this.openRomFileDialog.Filter = "SNES Rom (*.sfc)|*.sfc|All Files (*.*)|*.*";
            this.openRomFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openRomFileDialog_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // roomListBox
            // 
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.Location = new System.Drawing.Point(530, 76);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(289, 329);
            this.roomListBox.TabIndex = 2;
            this.roomListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 2;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(530, 53);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(572, 53);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "By Dungeons :";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hyrule Castle",
            "Eastern Palace",
            "Desert Palace",
            "Hera Tower",
            "Palace of Darkness",
            "Swamp Palace",
            "Thieves Town",
            "Skull Woods",
            "Ice Palace",
            "Misery Mire",
            "Turtle Rock",
            "Ganon Tower",
            "Caves",
            "House",
            "Empty"});
            this.comboBox1.Location = new System.Drawing.Point(668, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Hyrule Castle";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // actionsListbox
            // 
            this.actionsListbox.FormattingEnabled = true;
            this.actionsListbox.Location = new System.Drawing.Point(530, 431);
            this.actionsListbox.Name = "actionsListbox";
            this.actionsListbox.Size = new System.Drawing.Size(289, 134);
            this.actionsListbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "List of actions (Debug purpose) : ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.bg1modeButton,
            this.bg2modeButton,
            this.bg3modeButton,
            this.spritemodeButton,
            this.blockmodeButton,
            this.torchmodeButton,
            this.chestmodeButton,
            this.potmodeButton,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Open ROM";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Save ROM";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Undo";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Redo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bg1modeButton
            // 
            this.bg1modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg1modeButton.Enabled = false;
            this.bg1modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg1modeButton.Image")));
            this.bg1modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg1modeButton.Name = "bg1modeButton";
            this.bg1modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg1modeButton.Text = "Layer 1";
            this.bg1modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // bg2modeButton
            // 
            this.bg2modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg2modeButton.Enabled = false;
            this.bg2modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg2modeButton.Image")));
            this.bg2modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg2modeButton.Name = "bg2modeButton";
            this.bg2modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg2modeButton.Text = "Layer 2";
            this.bg2modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // bg3modeButton
            // 
            this.bg3modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg3modeButton.Enabled = false;
            this.bg3modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg3modeButton.Image")));
            this.bg3modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg3modeButton.Name = "bg3modeButton";
            this.bg3modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg3modeButton.Text = "Layer 3";
            this.bg3modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // spritemodeButton
            // 
            this.spritemodeButton.Checked = true;
            this.spritemodeButton.CheckOnClick = true;
            this.spritemodeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spritemodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.spritemodeButton.Image = ((System.Drawing.Image)(resources.GetObject("spritemodeButton.Image")));
            this.spritemodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spritemodeButton.Name = "spritemodeButton";
            this.spritemodeButton.Size = new System.Drawing.Size(23, 22);
            this.spritemodeButton.Text = "toolStripButton8";
            this.spritemodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // blockmodeButton
            // 
            this.blockmodeButton.CheckOnClick = true;
            this.blockmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.blockmodeButton.Enabled = false;
            this.blockmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("blockmodeButton.Image")));
            this.blockmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blockmodeButton.Name = "blockmodeButton";
            this.blockmodeButton.Size = new System.Drawing.Size(23, 22);
            this.blockmodeButton.Text = "Block Mode";
            this.blockmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // torchmodeButton
            // 
            this.torchmodeButton.CheckOnClick = true;
            this.torchmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.torchmodeButton.Enabled = false;
            this.torchmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("torchmodeButton.Image")));
            this.torchmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.torchmodeButton.Name = "torchmodeButton";
            this.torchmodeButton.Size = new System.Drawing.Size(23, 22);
            this.torchmodeButton.Text = "Torch Mode";
            this.torchmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // chestmodeButton
            // 
            this.chestmodeButton.CheckOnClick = true;
            this.chestmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chestmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("chestmodeButton.Image")));
            this.chestmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chestmodeButton.Name = "chestmodeButton";
            this.chestmodeButton.Size = new System.Drawing.Size(23, 22);
            this.chestmodeButton.Text = "Chest Mode";
            this.chestmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // potmodeButton
            // 
            this.potmodeButton.CheckOnClick = true;
            this.potmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.potmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("potmodeButton.Image")));
            this.potmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.potmodeButton.Name = "potmodeButton";
            this.potmodeButton.Size = new System.Drawing.Size(23, 22);
            this.potmodeButton.Text = "Pots Item Mode";
            this.potmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // spriteImageList
            // 
            this.spriteImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.spriteImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.spriteImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 579);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionsListbox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.roomListBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ZScream Magic";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openRomFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolStripMenuItem gotoRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textChestItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textPotItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG1ToolStripMenuItem;
        private System.Windows.Forms.ListBox actionsListbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bg1modeButton;
        private System.Windows.Forms.ToolStripButton bg2modeButton;
        private System.Windows.Forms.ToolStripButton bg3modeButton;
        private System.Windows.Forms.ToolStripButton spritemodeButton;
        private System.Windows.Forms.ToolStripButton blockmodeButton;
        private System.Windows.Forms.ToolStripButton torchmodeButton;
        private System.Windows.Forms.ToolStripButton chestmodeButton;
        private System.Windows.Forms.ToolStripButton potmodeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ImageList spriteImageList;
    }
}

