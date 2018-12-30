namespace Manifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePeople = new System.Windows.Forms.TabPage();
            this.groupBoxPersonDetails = new System.Windows.Forms.GroupBox();
            this.buttonDeletePerson = new System.Windows.Forms.Button();
            this.buttonEditPerson = new System.Windows.Forms.Button();
            this.buttonAddNewPerson = new System.Windows.Forms.Button();
            this.buttonSearchPeople = new System.Windows.Forms.Button();
            this.textBoxSearchPeople = new System.Windows.Forms.TextBox();
            this.listBoxPeople = new System.Windows.Forms.ListBox();
            this.tabPageAircraft = new System.Windows.Forms.TabPage();
            this.listBoxAircraft = new System.Windows.Forms.ListBox();
            this.buttonDeleteAircraft = new System.Windows.Forms.Button();
            this.buttonEditAircraft = new System.Windows.Forms.Button();
            this.buttonAddAircraft = new System.Windows.Forms.Button();
            this.tabPageLoads = new System.Windows.Forms.TabPage();
            this.buttonAddFunJumper = new System.Windows.Forms.Button();
            this.textBoxManNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddTandem = new System.Windows.Forms.Button();
            this.buttonCompleteLoad = new System.Windows.Forms.Button();
            this.buttonNewLoad = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelLoads = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxLoadAircraft = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePeople.SuspendLayout();
            this.tabPageAircraft.SuspendLayout();
            this.tabPageLoads.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1600, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(179, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePeople);
            this.tabControl.Controls.Add(this.tabPageAircraft);
            this.tabControl.Controls.Add(this.tabPageLoads);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 44);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1600, 821);
            this.tabControl.TabIndex = 1;
            // 
            // tabPagePeople
            // 
            this.tabPagePeople.Controls.Add(this.groupBoxPersonDetails);
            this.tabPagePeople.Controls.Add(this.buttonDeletePerson);
            this.tabPagePeople.Controls.Add(this.buttonEditPerson);
            this.tabPagePeople.Controls.Add(this.buttonAddNewPerson);
            this.tabPagePeople.Controls.Add(this.buttonSearchPeople);
            this.tabPagePeople.Controls.Add(this.textBoxSearchPeople);
            this.tabPagePeople.Controls.Add(this.listBoxPeople);
            this.tabPagePeople.Location = new System.Drawing.Point(8, 39);
            this.tabPagePeople.Margin = new System.Windows.Forms.Padding(6);
            this.tabPagePeople.Name = "tabPagePeople";
            this.tabPagePeople.Padding = new System.Windows.Forms.Padding(6);
            this.tabPagePeople.Size = new System.Drawing.Size(1584, 774);
            this.tabPagePeople.TabIndex = 0;
            this.tabPagePeople.Text = "     People     ";
            this.tabPagePeople.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonDetails
            // 
            this.groupBoxPersonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPersonDetails.Location = new System.Drawing.Point(523, 137);
            this.groupBoxPersonDetails.Name = "groupBoxPersonDetails";
            this.groupBoxPersonDetails.Size = new System.Drawing.Size(958, 579);
            this.groupBoxPersonDetails.TabIndex = 6;
            this.groupBoxPersonDetails.TabStop = false;
            this.groupBoxPersonDetails.Text = "Person Details";
            // 
            // buttonDeletePerson
            // 
            this.buttonDeletePerson.Location = new System.Drawing.Point(523, 73);
            this.buttonDeletePerson.Name = "buttonDeletePerson";
            this.buttonDeletePerson.Size = new System.Drawing.Size(218, 43);
            this.buttonDeletePerson.TabIndex = 5;
            this.buttonDeletePerson.Text = "Delete person";
            this.buttonDeletePerson.UseVisualStyleBackColor = true;
            // 
            // buttonEditPerson
            // 
            this.buttonEditPerson.Location = new System.Drawing.Point(262, 71);
            this.buttonEditPerson.Name = "buttonEditPerson";
            this.buttonEditPerson.Size = new System.Drawing.Size(218, 45);
            this.buttonEditPerson.TabIndex = 4;
            this.buttonEditPerson.Text = "Edit person";
            this.buttonEditPerson.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewPerson
            // 
            this.buttonAddNewPerson.Location = new System.Drawing.Point(12, 72);
            this.buttonAddNewPerson.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddNewPerson.Name = "buttonAddNewPerson";
            this.buttonAddNewPerson.Size = new System.Drawing.Size(218, 44);
            this.buttonAddNewPerson.TabIndex = 3;
            this.buttonAddNewPerson.Text = "Add new person";
            this.buttonAddNewPerson.UseVisualStyleBackColor = true;
            this.buttonAddNewPerson.Click += new System.EventHandler(this.buttonAddNewPerson_Click);
            // 
            // buttonSearchPeople
            // 
            this.buttonSearchPeople.Location = new System.Drawing.Point(430, 8);
            this.buttonSearchPeople.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSearchPeople.Name = "buttonSearchPeople";
            this.buttonSearchPeople.Size = new System.Drawing.Size(194, 44);
            this.buttonSearchPeople.TabIndex = 2;
            this.buttonSearchPeople.Text = "Search People";
            this.buttonSearchPeople.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchPeople
            // 
            this.textBoxSearchPeople.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearchPeople.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSearchPeople.Name = "textBoxSearchPeople";
            this.textBoxSearchPeople.Size = new System.Drawing.Size(402, 31);
            this.textBoxSearchPeople.TabIndex = 1;
            // 
            // listBoxPeople
            // 
            this.listBoxPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPeople.FormattingEnabled = true;
            this.listBoxPeople.ItemHeight = 25;
            this.listBoxPeople.Location = new System.Drawing.Point(12, 137);
            this.listBoxPeople.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxPeople.MultiColumn = true;
            this.listBoxPeople.Name = "listBoxPeople";
            this.listBoxPeople.Size = new System.Drawing.Size(485, 579);
            this.listBoxPeople.TabIndex = 0;
            this.listBoxPeople.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tabPageAircraft
            // 
            this.tabPageAircraft.Controls.Add(this.listBoxAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonDeleteAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonEditAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonAddAircraft);
            this.tabPageAircraft.Location = new System.Drawing.Point(8, 39);
            this.tabPageAircraft.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageAircraft.Name = "tabPageAircraft";
            this.tabPageAircraft.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageAircraft.Size = new System.Drawing.Size(1584, 774);
            this.tabPageAircraft.TabIndex = 1;
            this.tabPageAircraft.Text = "     Aircraft     ";
            this.tabPageAircraft.UseVisualStyleBackColor = true;
            // 
            // listBoxAircraft
            // 
            this.listBoxAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxAircraft.FormattingEnabled = true;
            this.listBoxAircraft.ItemHeight = 25;
            this.listBoxAircraft.Items.AddRange(new object[] {
            "King Air - 14 slots",
            "Helicopter - 1 slot",
            "Bi-plane - 1 slot"});
            this.listBoxAircraft.Location = new System.Drawing.Point(30, 111);
            this.listBoxAircraft.Name = "listBoxAircraft";
            this.listBoxAircraft.Size = new System.Drawing.Size(572, 579);
            this.listBoxAircraft.TabIndex = 3;
            this.listBoxAircraft.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // buttonDeleteAircraft
            // 
            this.buttonDeleteAircraft.Location = new System.Drawing.Point(408, 36);
            this.buttonDeleteAircraft.Name = "buttonDeleteAircraft";
            this.buttonDeleteAircraft.Size = new System.Drawing.Size(164, 47);
            this.buttonDeleteAircraft.TabIndex = 2;
            this.buttonDeleteAircraft.Text = "Delete Aircraft";
            this.buttonDeleteAircraft.UseVisualStyleBackColor = true;
            // 
            // buttonEditAircraft
            // 
            this.buttonEditAircraft.Location = new System.Drawing.Point(232, 36);
            this.buttonEditAircraft.Name = "buttonEditAircraft";
            this.buttonEditAircraft.Size = new System.Drawing.Size(152, 47);
            this.buttonEditAircraft.TabIndex = 1;
            this.buttonEditAircraft.Text = "Edit Aircraft";
            this.buttonEditAircraft.UseVisualStyleBackColor = true;
            // 
            // buttonAddAircraft
            // 
            this.buttonAddAircraft.Location = new System.Drawing.Point(54, 36);
            this.buttonAddAircraft.Name = "buttonAddAircraft";
            this.buttonAddAircraft.Size = new System.Drawing.Size(154, 47);
            this.buttonAddAircraft.TabIndex = 0;
            this.buttonAddAircraft.Text = "Add Aircraft";
            this.buttonAddAircraft.UseVisualStyleBackColor = true;
            // 
            // tabPageLoads
            // 
            this.tabPageLoads.Controls.Add(this.comboBoxLoadAircraft);
            this.tabPageLoads.Controls.Add(this.panelLoads);
            this.tabPageLoads.Controls.Add(this.buttonAddFunJumper);
            this.tabPageLoads.Controls.Add(this.textBoxManNum);
            this.tabPageLoads.Controls.Add(this.label1);
            this.tabPageLoads.Controls.Add(this.buttonAddTandem);
            this.tabPageLoads.Controls.Add(this.buttonCompleteLoad);
            this.tabPageLoads.Controls.Add(this.buttonNewLoad);
            this.tabPageLoads.Location = new System.Drawing.Point(8, 39);
            this.tabPageLoads.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageLoads.Name = "tabPageLoads";
            this.tabPageLoads.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageLoads.Size = new System.Drawing.Size(1584, 774);
            this.tabPageLoads.TabIndex = 2;
            this.tabPageLoads.Text = "     Loads     ";
            this.tabPageLoads.UseVisualStyleBackColor = true;
            // 
            // buttonAddFunJumper
            // 
            this.buttonAddFunJumper.Location = new System.Drawing.Point(1351, 29);
            this.buttonAddFunJumper.Name = "buttonAddFunJumper";
            this.buttonAddFunJumper.Size = new System.Drawing.Size(187, 41);
            this.buttonAddFunJumper.TabIndex = 9;
            this.buttonAddFunJumper.Text = "Add Fun Jumper";
            this.buttonAddFunJumper.UseVisualStyleBackColor = true;
            // 
            // textBoxManNum
            // 
            this.textBoxManNum.Location = new System.Drawing.Point(1236, 34);
            this.textBoxManNum.Name = "textBoxManNum";
            this.textBoxManNum.Size = new System.Drawing.Size(100, 31);
            this.textBoxManNum.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1117, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manifest #";
            // 
            // buttonAddTandem
            // 
            this.buttonAddTandem.Location = new System.Drawing.Point(863, 29);
            this.buttonAddTandem.Name = "buttonAddTandem";
            this.buttonAddTandem.Size = new System.Drawing.Size(166, 41);
            this.buttonAddTandem.TabIndex = 6;
            this.buttonAddTandem.Text = "Add Tandem";
            this.buttonAddTandem.UseVisualStyleBackColor = true;
            this.buttonAddTandem.Click += new System.EventHandler(this.buttonAddTandem_Click);
            // 
            // buttonCompleteLoad
            // 
            this.buttonCompleteLoad.Location = new System.Drawing.Point(513, 29);
            this.buttonCompleteLoad.Name = "buttonCompleteLoad";
            this.buttonCompleteLoad.Size = new System.Drawing.Size(166, 41);
            this.buttonCompleteLoad.TabIndex = 2;
            this.buttonCompleteLoad.Text = "Complete Load";
            this.buttonCompleteLoad.UseVisualStyleBackColor = true;
            // 
            // buttonNewLoad
            // 
            this.buttonNewLoad.Location = new System.Drawing.Point(366, 29);
            this.buttonNewLoad.Name = "buttonNewLoad";
            this.buttonNewLoad.Size = new System.Drawing.Size(141, 41);
            this.buttonNewLoad.TabIndex = 0;
            this.buttonNewLoad.Text = "New Load";
            this.buttonNewLoad.UseVisualStyleBackColor = true;
            this.buttonNewLoad.Click += new System.EventHandler(this.buttonNewLoad_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 828);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1600, 37);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(412, 32);
            this.toolStripStatusLabel1.Text = "West Tennessee Skydiving - Manifest";
            // 
            // panelLoads
            // 
            this.panelLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoads.AutoScroll = true;
            this.panelLoads.Location = new System.Drawing.Point(21, 87);
            this.panelLoads.Name = "panelLoads";
            this.panelLoads.Size = new System.Drawing.Size(1527, 623);
            this.panelLoads.TabIndex = 10;
            this.panelLoads.WrapContents = false;
            // 
            // comboBoxLoadAircraft
            // 
            this.comboBoxLoadAircraft.FormattingEnabled = true;
            this.comboBoxLoadAircraft.Items.AddRange(new object[] {
            "King Air"});
            this.comboBoxLoadAircraft.Location = new System.Drawing.Point(21, 29);
            this.comboBoxLoadAircraft.Name = "comboBoxLoadAircraft";
            this.comboBoxLoadAircraft.Size = new System.Drawing.Size(324, 33);
            this.comboBoxLoadAircraft.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1626, 936);
            this.Name = "Form1";
            this.Text = "West Tennessee Skydiving";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePeople.ResumeLayout(false);
            this.tabPagePeople.PerformLayout();
            this.tabPageAircraft.ResumeLayout(false);
            this.tabPageLoads.ResumeLayout(false);
            this.tabPageLoads.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePeople;
        private System.Windows.Forms.TabPage tabPageAircraft;
        private System.Windows.Forms.TabPage tabPageLoads;
        private System.Windows.Forms.Button buttonSearchPeople;
        private System.Windows.Forms.TextBox textBoxSearchPeople;
        private System.Windows.Forms.ListBox listBoxPeople;
        private System.Windows.Forms.Button buttonAddNewPerson;
        private System.Windows.Forms.Button buttonDeletePerson;
        private System.Windows.Forms.Button buttonEditPerson;
        private System.Windows.Forms.ListBox listBoxAircraft;
        private System.Windows.Forms.Button buttonDeleteAircraft;
        private System.Windows.Forms.Button buttonEditAircraft;
        private System.Windows.Forms.Button buttonAddAircraft;
        private System.Windows.Forms.Button buttonCompleteLoad;
        private System.Windows.Forms.Button buttonNewLoad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxPersonDetails;
        private System.Windows.Forms.Button buttonAddFunJumper;
        private System.Windows.Forms.TextBox textBoxManNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddTandem;
        private System.Windows.Forms.FlowLayoutPanel panelLoads;
        private System.Windows.Forms.ComboBox comboBoxLoadAircraft;
    }
}

