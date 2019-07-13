namespace Manifest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePeople = new System.Windows.Forms.TabPage();
            this.groupBoxPersonDetails = new System.Windows.Forms.GroupBox();
            this.labelEditDetails = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxCoach = new System.Windows.Forms.CheckBox();
            this.checkBoxAFF = new System.Windows.Forms.CheckBox();
            this.checkBoxTI = new System.Windows.Forms.CheckBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelManifestNumber = new System.Windows.Forms.Label();
            this.buttonSavePerson = new System.Windows.Forms.Button();
            this.textBoxManifestNumber = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.buttonDeletePerson = new System.Windows.Forms.Button();
            this.buttonEditPerson = new System.Windows.Forms.Button();
            this.buttonAddNewPerson = new System.Windows.Forms.Button();
            this.buttonSearchPeople = new System.Windows.Forms.Button();
            this.textBoxSearchPeople = new System.Windows.Forms.TextBox();
            this.listBoxPeople = new System.Windows.Forms.ListBox();
            this.tabPageAircraft = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCancelAircraft = new System.Windows.Forms.Button();
            this.buttonSaveAircraft = new System.Windows.Forms.Button();
            this.buttonAddAircraftSubmit = new System.Windows.Forms.Button();
            this.textBoxAircraftName = new System.Windows.Forms.TextBox();
            this.numericUpDownMaxJumpers = new System.Windows.Forms.NumericUpDown();
            this.labelMaxJumpers = new System.Windows.Forms.Label();
            this.labelAircraftName = new System.Windows.Forms.Label();
            this.labelEditDetailsAircraft = new System.Windows.Forms.Label();
            this.listBoxAircraft = new System.Windows.Forms.ListBox();
            this.buttonDeleteAircraft = new System.Windows.Forms.Button();
            this.buttonEditAircraft = new System.Windows.Forms.Button();
            this.buttonAddAircraft = new System.Windows.Forms.Button();
            this.tabPageLoads = new System.Windows.Forms.TabPage();
            this.labelSelectedLoad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeletePersonFromLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLoadAircraft = new System.Windows.Forms.ComboBox();
            this.panelLoads = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddFunJumper = new System.Windows.Forms.Button();
            this.textBoxManNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddTandem = new System.Windows.Forms.Button();
            this.buttonCompleteLoad = new System.Windows.Forms.Button();
            this.buttonNewLoad = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePeople.SuspendLayout();
            this.groupBoxPersonDetails.SuspendLayout();
            this.tabPageAircraft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxJumpers)).BeginInit();
            this.tabPageLoads.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePeople);
            this.tabControl.Controls.Add(this.tabPageAircraft);
            this.tabControl.Controls.Add(this.tabPageLoads);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(805, 442);
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
            this.tabPagePeople.Location = new System.Drawing.Point(4, 22);
            this.tabPagePeople.Name = "tabPagePeople";
            this.tabPagePeople.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePeople.Size = new System.Drawing.Size(797, 416);
            this.tabPagePeople.TabIndex = 0;
            this.tabPagePeople.Text = "Fun Jumpers & Staff  ";
            this.tabPagePeople.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonDetails
            // 
            this.groupBoxPersonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPersonDetails.Controls.Add(this.labelEditDetails);
            this.groupBoxPersonDetails.Controls.Add(this.buttonCancel);
            this.groupBoxPersonDetails.Controls.Add(this.buttonAddPerson);
            this.groupBoxPersonDetails.Controls.Add(this.checkBoxVideo);
            this.groupBoxPersonDetails.Controls.Add(this.checkBoxCoach);
            this.groupBoxPersonDetails.Controls.Add(this.checkBoxAFF);
            this.groupBoxPersonDetails.Controls.Add(this.checkBoxTI);
            this.groupBoxPersonDetails.Controls.Add(this.labelLastName);
            this.groupBoxPersonDetails.Controls.Add(this.labelFirstName);
            this.groupBoxPersonDetails.Controls.Add(this.labelManifestNumber);
            this.groupBoxPersonDetails.Controls.Add(this.buttonSavePerson);
            this.groupBoxPersonDetails.Controls.Add(this.textBoxManifestNumber);
            this.groupBoxPersonDetails.Controls.Add(this.textBoxLastName);
            this.groupBoxPersonDetails.Controls.Add(this.textBoxFirstName);
            this.groupBoxPersonDetails.Location = new System.Drawing.Point(262, 71);
            this.groupBoxPersonDetails.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPersonDetails.Name = "groupBoxPersonDetails";
            this.groupBoxPersonDetails.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPersonDetails.Size = new System.Drawing.Size(484, 317);
            this.groupBoxPersonDetails.TabIndex = 6;
            this.groupBoxPersonDetails.TabStop = false;
            this.groupBoxPersonDetails.Text = "Person Details";
            // 
            // labelEditDetails
            // 
            this.labelEditDetails.AutoSize = true;
            this.labelEditDetails.Location = new System.Drawing.Point(28, 31);
            this.labelEditDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEditDetails.Name = "labelEditDetails";
            this.labelEditDetails.Size = new System.Drawing.Size(87, 13);
            this.labelEditDetails.TabIndex = 24;
            this.labelEditDetails.Text = "Editing details for";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(121, 212);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 24);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.Location = new System.Drawing.Point(121, 157);
            this.buttonAddPerson.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(86, 24);
            this.buttonAddPerson.TabIndex = 22;
            this.buttonAddPerson.Text = "Add";
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.ButtonAddPerson_Click);
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Location = new System.Drawing.Point(258, 149);
            this.checkBoxVideo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(89, 17);
            this.checkBoxVideo.TabIndex = 21;
            this.checkBoxVideo.Text = "Videographer";
            this.checkBoxVideo.UseVisualStyleBackColor = true;
            // 
            // checkBoxCoach
            // 
            this.checkBoxCoach.AutoSize = true;
            this.checkBoxCoach.Location = new System.Drawing.Point(258, 122);
            this.checkBoxCoach.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCoach.Name = "checkBoxCoach";
            this.checkBoxCoach.Size = new System.Drawing.Size(57, 17);
            this.checkBoxCoach.TabIndex = 20;
            this.checkBoxCoach.Text = "Coach";
            this.checkBoxCoach.UseVisualStyleBackColor = true;
            // 
            // checkBoxAFF
            // 
            this.checkBoxAFF.AutoSize = true;
            this.checkBoxAFF.Location = new System.Drawing.Point(258, 96);
            this.checkBoxAFF.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAFF.Name = "checkBoxAFF";
            this.checkBoxAFF.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAFF.TabIndex = 19;
            this.checkBoxAFF.Text = "AFF Instructor";
            this.checkBoxAFF.UseVisualStyleBackColor = true;
            // 
            // checkBoxTI
            // 
            this.checkBoxTI.AutoSize = true;
            this.checkBoxTI.Location = new System.Drawing.Point(258, 69);
            this.checkBoxTI.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTI.Name = "checkBoxTI";
            this.checkBoxTI.Size = new System.Drawing.Size(112, 17);
            this.checkBoxTI.TabIndex = 18;
            this.checkBoxTI.Text = "Tandem Instructor";
            this.checkBoxTI.UseVisualStyleBackColor = true;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(28, 125);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(58, 13);
            this.labelLastName.TabIndex = 17;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(30, 99);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelFirstName.TabIndex = 16;
            this.labelFirstName.Text = "First Name";
            // 
            // labelManifestNumber
            // 
            this.labelManifestNumber.AutoSize = true;
            this.labelManifestNumber.Location = new System.Drawing.Point(30, 71);
            this.labelManifestNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManifestNumber.Name = "labelManifestNumber";
            this.labelManifestNumber.Size = new System.Drawing.Size(57, 13);
            this.labelManifestNumber.TabIndex = 15;
            this.labelManifestNumber.Text = "Manifest #";
            // 
            // buttonSavePerson
            // 
            this.buttonSavePerson.Location = new System.Drawing.Point(121, 185);
            this.buttonSavePerson.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSavePerson.Name = "buttonSavePerson";
            this.buttonSavePerson.Size = new System.Drawing.Size(86, 24);
            this.buttonSavePerson.TabIndex = 14;
            this.buttonSavePerson.Text = "Save";
            this.buttonSavePerson.UseVisualStyleBackColor = true;
            this.buttonSavePerson.Click += new System.EventHandler(this.ButtonSavePerson_Click);
            // 
            // textBoxManifestNumber
            // 
            this.textBoxManifestNumber.Location = new System.Drawing.Point(94, 69);
            this.textBoxManifestNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManifestNumber.Name = "textBoxManifestNumber";
            this.textBoxManifestNumber.Size = new System.Drawing.Size(52, 20);
            this.textBoxManifestNumber.TabIndex = 11;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(94, 122);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(116, 20);
            this.textBoxLastName.TabIndex = 13;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(94, 96);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(116, 20);
            this.textBoxFirstName.TabIndex = 12;
            // 
            // buttonDeletePerson
            // 
            this.buttonDeletePerson.Location = new System.Drawing.Point(262, 38);
            this.buttonDeletePerson.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeletePerson.Name = "buttonDeletePerson";
            this.buttonDeletePerson.Size = new System.Drawing.Size(109, 22);
            this.buttonDeletePerson.TabIndex = 5;
            this.buttonDeletePerson.Text = "Delete person";
            this.buttonDeletePerson.UseVisualStyleBackColor = true;
            this.buttonDeletePerson.Click += new System.EventHandler(this.ButtonDeletePerson_Click);
            // 
            // buttonEditPerson
            // 
            this.buttonEditPerson.Location = new System.Drawing.Point(131, 37);
            this.buttonEditPerson.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditPerson.Name = "buttonEditPerson";
            this.buttonEditPerson.Size = new System.Drawing.Size(109, 23);
            this.buttonEditPerson.TabIndex = 4;
            this.buttonEditPerson.Text = "Edit person";
            this.buttonEditPerson.UseVisualStyleBackColor = true;
            this.buttonEditPerson.Click += new System.EventHandler(this.ButtonEditPerson_Click);
            // 
            // buttonAddNewPerson
            // 
            this.buttonAddNewPerson.Location = new System.Drawing.Point(6, 37);
            this.buttonAddNewPerson.Name = "buttonAddNewPerson";
            this.buttonAddNewPerson.Size = new System.Drawing.Size(109, 23);
            this.buttonAddNewPerson.TabIndex = 3;
            this.buttonAddNewPerson.Text = "Add new person";
            this.buttonAddNewPerson.UseVisualStyleBackColor = true;
            this.buttonAddNewPerson.Click += new System.EventHandler(this.ButtonAddNewPerson_Click);
            // 
            // buttonSearchPeople
            // 
            this.buttonSearchPeople.Location = new System.Drawing.Point(215, 4);
            this.buttonSearchPeople.Name = "buttonSearchPeople";
            this.buttonSearchPeople.Size = new System.Drawing.Size(97, 23);
            this.buttonSearchPeople.TabIndex = 2;
            this.buttonSearchPeople.Text = "Search People";
            this.buttonSearchPeople.UseVisualStyleBackColor = true;
            this.buttonSearchPeople.Click += new System.EventHandler(this.ButtonSearchPeople_Click);
            // 
            // textBoxSearchPeople
            // 
            this.textBoxSearchPeople.Location = new System.Drawing.Point(6, 6);
            this.textBoxSearchPeople.Name = "textBoxSearchPeople";
            this.textBoxSearchPeople.Size = new System.Drawing.Size(203, 20);
            this.textBoxSearchPeople.TabIndex = 1;
            this.textBoxSearchPeople.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchPeople_KeyDown);
            // 
            // listBoxPeople
            // 
            this.listBoxPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPeople.FormattingEnabled = true;
            this.listBoxPeople.Location = new System.Drawing.Point(6, 71);
            this.listBoxPeople.MultiColumn = true;
            this.listBoxPeople.Name = "listBoxPeople";
            this.listBoxPeople.Size = new System.Drawing.Size(244, 316);
            this.listBoxPeople.TabIndex = 0;
            // 
            // tabPageAircraft
            // 
            this.tabPageAircraft.Controls.Add(this.groupBox1);
            this.tabPageAircraft.Controls.Add(this.listBoxAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonDeleteAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonEditAircraft);
            this.tabPageAircraft.Controls.Add(this.buttonAddAircraft);
            this.tabPageAircraft.Location = new System.Drawing.Point(4, 22);
            this.tabPageAircraft.Name = "tabPageAircraft";
            this.tabPageAircraft.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAircraft.Size = new System.Drawing.Size(797, 416);
            this.tabPageAircraft.TabIndex = 1;
            this.tabPageAircraft.Text = "     Aircraft     ";
            this.tabPageAircraft.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonCancelAircraft);
            this.groupBox1.Controls.Add(this.buttonSaveAircraft);
            this.groupBox1.Controls.Add(this.buttonAddAircraftSubmit);
            this.groupBox1.Controls.Add(this.textBoxAircraftName);
            this.groupBox1.Controls.Add(this.numericUpDownMaxJumpers);
            this.groupBox1.Controls.Add(this.labelMaxJumpers);
            this.groupBox1.Controls.Add(this.labelAircraftName);
            this.groupBox1.Controls.Add(this.labelEditDetailsAircraft);
            this.groupBox1.Location = new System.Drawing.Point(316, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(466, 301);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aircraft details";
            // 
            // buttonCancelAircraft
            // 
            this.buttonCancelAircraft.Location = new System.Drawing.Point(94, 178);
            this.buttonCancelAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelAircraft.Name = "buttonCancelAircraft";
            this.buttonCancelAircraft.Size = new System.Drawing.Size(64, 22);
            this.buttonCancelAircraft.TabIndex = 7;
            this.buttonCancelAircraft.Text = "Cancel";
            this.buttonCancelAircraft.UseVisualStyleBackColor = true;
            this.buttonCancelAircraft.Click += new System.EventHandler(this.ButtonCancelAircraft_Click);
            // 
            // buttonSaveAircraft
            // 
            this.buttonSaveAircraft.Location = new System.Drawing.Point(94, 152);
            this.buttonSaveAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveAircraft.Name = "buttonSaveAircraft";
            this.buttonSaveAircraft.Size = new System.Drawing.Size(64, 22);
            this.buttonSaveAircraft.TabIndex = 6;
            this.buttonSaveAircraft.Text = "Save";
            this.buttonSaveAircraft.UseVisualStyleBackColor = true;
            this.buttonSaveAircraft.Click += new System.EventHandler(this.ButtonSaveAircraft_Click);
            // 
            // buttonAddAircraftSubmit
            // 
            this.buttonAddAircraftSubmit.Location = new System.Drawing.Point(94, 127);
            this.buttonAddAircraftSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddAircraftSubmit.Name = "buttonAddAircraftSubmit";
            this.buttonAddAircraftSubmit.Size = new System.Drawing.Size(64, 22);
            this.buttonAddAircraftSubmit.TabIndex = 5;
            this.buttonAddAircraftSubmit.Text = "Add";
            this.buttonAddAircraftSubmit.UseVisualStyleBackColor = true;
            this.buttonAddAircraftSubmit.Click += new System.EventHandler(this.ButtonAddAircraftSubmit_Click);
            // 
            // textBoxAircraftName
            // 
            this.textBoxAircraftName.Location = new System.Drawing.Point(72, 60);
            this.textBoxAircraftName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAircraftName.Name = "textBoxAircraftName";
            this.textBoxAircraftName.Size = new System.Drawing.Size(145, 20);
            this.textBoxAircraftName.TabIndex = 4;
            // 
            // numericUpDownMaxJumpers
            // 
            this.numericUpDownMaxJumpers.Location = new System.Drawing.Point(98, 89);
            this.numericUpDownMaxJumpers.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxJumpers.Name = "numericUpDownMaxJumpers";
            this.numericUpDownMaxJumpers.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownMaxJumpers.TabIndex = 3;
            // 
            // labelMaxJumpers
            // 
            this.labelMaxJumpers.AutoSize = true;
            this.labelMaxJumpers.Location = new System.Drawing.Point(28, 89);
            this.labelMaxJumpers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxJumpers.Name = "labelMaxJumpers";
            this.labelMaxJumpers.Size = new System.Drawing.Size(66, 13);
            this.labelMaxJumpers.TabIndex = 2;
            this.labelMaxJumpers.Text = "Max jumpers";
            // 
            // labelAircraftName
            // 
            this.labelAircraftName.AutoSize = true;
            this.labelAircraftName.Location = new System.Drawing.Point(28, 63);
            this.labelAircraftName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAircraftName.Name = "labelAircraftName";
            this.labelAircraftName.Size = new System.Drawing.Size(35, 13);
            this.labelAircraftName.TabIndex = 1;
            this.labelAircraftName.Text = "Name";
            // 
            // labelEditDetailsAircraft
            // 
            this.labelEditDetailsAircraft.AutoSize = true;
            this.labelEditDetailsAircraft.Location = new System.Drawing.Point(28, 32);
            this.labelEditDetailsAircraft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEditDetailsAircraft.Name = "labelEditDetailsAircraft";
            this.labelEditDetailsAircraft.Size = new System.Drawing.Size(90, 13);
            this.labelEditDetailsAircraft.TabIndex = 0;
            this.labelEditDetailsAircraft.Text = "Editing details for ";
            // 
            // listBoxAircraft
            // 
            this.listBoxAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxAircraft.FormattingEnabled = true;
            this.listBoxAircraft.Location = new System.Drawing.Point(15, 58);
            this.listBoxAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAircraft.Name = "listBoxAircraft";
            this.listBoxAircraft.Size = new System.Drawing.Size(288, 303);
            this.listBoxAircraft.TabIndex = 3;
            // 
            // buttonDeleteAircraft
            // 
            this.buttonDeleteAircraft.Location = new System.Drawing.Point(204, 19);
            this.buttonDeleteAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteAircraft.Name = "buttonDeleteAircraft";
            this.buttonDeleteAircraft.Size = new System.Drawing.Size(82, 24);
            this.buttonDeleteAircraft.TabIndex = 2;
            this.buttonDeleteAircraft.Text = "Delete Aircraft";
            this.buttonDeleteAircraft.UseVisualStyleBackColor = true;
            this.buttonDeleteAircraft.Click += new System.EventHandler(this.ButtonDeleteAircraft_Click);
            // 
            // buttonEditAircraft
            // 
            this.buttonEditAircraft.Location = new System.Drawing.Point(116, 19);
            this.buttonEditAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditAircraft.Name = "buttonEditAircraft";
            this.buttonEditAircraft.Size = new System.Drawing.Size(76, 24);
            this.buttonEditAircraft.TabIndex = 1;
            this.buttonEditAircraft.Text = "Edit Aircraft";
            this.buttonEditAircraft.UseVisualStyleBackColor = true;
            this.buttonEditAircraft.Click += new System.EventHandler(this.ButtonEditAircraft_Click);
            // 
            // buttonAddAircraft
            // 
            this.buttonAddAircraft.Location = new System.Drawing.Point(27, 19);
            this.buttonAddAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddAircraft.Name = "buttonAddAircraft";
            this.buttonAddAircraft.Size = new System.Drawing.Size(77, 24);
            this.buttonAddAircraft.TabIndex = 0;
            this.buttonAddAircraft.Text = "Add Aircraft";
            this.buttonAddAircraft.UseVisualStyleBackColor = true;
            this.buttonAddAircraft.Click += new System.EventHandler(this.ButtonAddAircraft_Click);
            // 
            // tabPageLoads
            // 
            this.tabPageLoads.Controls.Add(this.labelSelectedLoad);
            this.tabPageLoads.Controls.Add(this.label2);
            this.tabPageLoads.Controls.Add(this.buttonDeletePersonFromLoad);
            this.tabPageLoads.Controls.Add(this.label3);
            this.tabPageLoads.Controls.Add(this.comboBoxLoadAircraft);
            this.tabPageLoads.Controls.Add(this.panelLoads);
            this.tabPageLoads.Controls.Add(this.buttonAddFunJumper);
            this.tabPageLoads.Controls.Add(this.textBoxManNum);
            this.tabPageLoads.Controls.Add(this.label1);
            this.tabPageLoads.Controls.Add(this.buttonAddTandem);
            this.tabPageLoads.Controls.Add(this.buttonCompleteLoad);
            this.tabPageLoads.Controls.Add(this.buttonNewLoad);
            this.tabPageLoads.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoads.Name = "tabPageLoads";
            this.tabPageLoads.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoads.Size = new System.Drawing.Size(797, 416);
            this.tabPageLoads.TabIndex = 2;
            this.tabPageLoads.Text = "     Loads     ";
            this.tabPageLoads.UseVisualStyleBackColor = true;
            // 
            // labelSelectedLoad
            // 
            this.labelSelectedLoad.AutoSize = true;
            this.labelSelectedLoad.Location = new System.Drawing.Point(368, 51);
            this.labelSelectedLoad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectedLoad.Name = "labelSelectedLoad";
            this.labelSelectedLoad.Size = new System.Drawing.Size(0, 13);
            this.labelSelectedLoad.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Selected load is:";
            // 
            // buttonDeletePersonFromLoad
            // 
            this.buttonDeletePersonFromLoad.Location = new System.Drawing.Point(408, 19);
            this.buttonDeletePersonFromLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeletePersonFromLoad.Name = "buttonDeletePersonFromLoad";
            this.buttonDeletePersonFromLoad.Size = new System.Drawing.Size(128, 21);
            this.buttonDeletePersonFromLoad.TabIndex = 15;
            this.buttonDeletePersonFromLoad.Text = "Delete from Load";
            this.buttonDeletePersonFromLoad.UseVisualStyleBackColor = true;
            this.buttonDeletePersonFromLoad.Click += new System.EventHandler(this.ButtonDeletePersonFromLoad_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "(Reg price, own gear, full altitude only)";
            // 
            // comboBoxLoadAircraft
            // 
            this.comboBoxLoadAircraft.FormattingEnabled = true;
            this.comboBoxLoadAircraft.Location = new System.Drawing.Point(10, 19);
            this.comboBoxLoadAircraft.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxLoadAircraft.Name = "comboBoxLoadAircraft";
            this.comboBoxLoadAircraft.Size = new System.Drawing.Size(130, 21);
            this.comboBoxLoadAircraft.TabIndex = 1;
            // 
            // panelLoads
            // 
            this.panelLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoads.AutoScroll = true;
            this.panelLoads.Location = new System.Drawing.Point(10, 67);
            this.panelLoads.Margin = new System.Windows.Forms.Padding(2);
            this.panelLoads.Name = "panelLoads";
            this.panelLoads.Size = new System.Drawing.Size(764, 302);
            this.panelLoads.TabIndex = 10;
            this.panelLoads.WrapContents = false;
            // 
            // buttonAddFunJumper
            // 
            this.buttonAddFunJumper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFunJumper.Location = new System.Drawing.Point(676, 15);
            this.buttonAddFunJumper.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddFunJumper.Name = "buttonAddFunJumper";
            this.buttonAddFunJumper.Size = new System.Drawing.Size(72, 21);
            this.buttonAddFunJumper.TabIndex = 6;
            this.buttonAddFunJumper.Text = "Quick Add";
            this.buttonAddFunJumper.UseVisualStyleBackColor = true;
            this.buttonAddFunJumper.Click += new System.EventHandler(this.ButtonAddFunJumper_Click);
            // 
            // textBoxManNum
            // 
            this.textBoxManNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxManNum.Location = new System.Drawing.Point(618, 18);
            this.textBoxManNum.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManNum.Name = "textBoxManNum";
            this.textBoxManNum.Size = new System.Drawing.Size(52, 20);
            this.textBoxManNum.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manifest #";
            // 
            // buttonAddTandem
            // 
            this.buttonAddTandem.Location = new System.Drawing.Point(276, 19);
            this.buttonAddTandem.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddTandem.Name = "buttonAddTandem";
            this.buttonAddTandem.Size = new System.Drawing.Size(128, 21);
            this.buttonAddTandem.TabIndex = 4;
            this.buttonAddTandem.Text = "Add Person to Load";
            this.buttonAddTandem.UseVisualStyleBackColor = true;
            this.buttonAddTandem.Click += new System.EventHandler(this.ButtonAddTandem_Click);
            // 
            // buttonCompleteLoad
            // 
            this.buttonCompleteLoad.Location = new System.Drawing.Point(10, 43);
            this.buttonCompleteLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCompleteLoad.Name = "buttonCompleteLoad";
            this.buttonCompleteLoad.Size = new System.Drawing.Size(83, 21);
            this.buttonCompleteLoad.TabIndex = 7;
            this.buttonCompleteLoad.Text = "Complete Load";
            this.buttonCompleteLoad.UseVisualStyleBackColor = true;
            this.buttonCompleteLoad.Click += new System.EventHandler(this.ButtonCompleteLoad_Click);
            // 
            // buttonNewLoad
            // 
            this.buttonNewLoad.Location = new System.Drawing.Point(150, 18);
            this.buttonNewLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewLoad.Name = "buttonNewLoad";
            this.buttonNewLoad.Size = new System.Drawing.Size(70, 21);
            this.buttonNewLoad.TabIndex = 3;
            this.buttonNewLoad.Text = "New Load";
            this.buttonNewLoad.UseVisualStyleBackColor = true;
            this.buttonNewLoad.Click += new System.EventHandler(this.ButtonNewLoad_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(201, 17);
            this.toolStripStatusLabel1.Text = "West Tennessee Skydiving - Manifest";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 466);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(821, 505);
            this.Name = "MainForm";
            this.Text = "West Tennessee Skydiving";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePeople.ResumeLayout(false);
            this.tabPagePeople.PerformLayout();
            this.groupBoxPersonDetails.ResumeLayout(false);
            this.groupBoxPersonDetails.PerformLayout();
            this.tabPageAircraft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxJumpers)).EndInit();
            this.tabPageLoads.ResumeLayout(false);
            this.tabPageLoads.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.CheckBox checkBoxCoach;
        private System.Windows.Forms.CheckBox checkBoxAFF;
        private System.Windows.Forms.CheckBox checkBoxTI;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelManifestNumber;
        private System.Windows.Forms.Button buttonSavePerson;
        private System.Windows.Forms.TextBox textBoxManifestNumber;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Button buttonAddPerson;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelEditDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancelAircraft;
        private System.Windows.Forms.Button buttonSaveAircraft;
        private System.Windows.Forms.Button buttonAddAircraftSubmit;
        private System.Windows.Forms.TextBox textBoxAircraftName;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxJumpers;
        private System.Windows.Forms.Label labelMaxJumpers;
        private System.Windows.Forms.Label labelAircraftName;
        private System.Windows.Forms.Label labelEditDetailsAircraft;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button buttonDeletePersonFromLoad;
        private System.Windows.Forms.Label labelSelectedLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
    }
}

