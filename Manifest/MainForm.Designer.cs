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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.peopleTabPage = new System.Windows.Forms.TabPage();
            this.groupBoxPersonDetails = new System.Windows.Forms.GroupBox();
            this.editDetailsLabel = new System.Windows.Forms.Label();
            this.addPersonCancelButton = new System.Windows.Forms.Button();
            this.addPersonSubmitButton = new System.Windows.Forms.Button();
            this.videographerCheckbox = new System.Windows.Forms.CheckBox();
            this.coachCheckbox = new System.Windows.Forms.CheckBox();
            this.affInstructorCheckbox = new System.Windows.Forms.CheckBox();
            this.tandemInstructorCheckbox = new System.Windows.Forms.CheckBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.manifestNumberLabel = new System.Windows.Forms.Label();
            this.addPersonSaveButton = new System.Windows.Forms.Button();
            this.manifestNumberTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.deletePersonButton = new System.Windows.Forms.Button();
            this.editPersonButton = new System.Windows.Forms.Button();
            this.addNewPersonButton = new System.Windows.Forms.Button();
            this.searchPeopleButton = new System.Windows.Forms.Button();
            this.searchPeopleTextBox = new System.Windows.Forms.TextBox();
            this.peopleListBox = new System.Windows.Forms.ListBox();
            this.aircraftTabPage = new System.Windows.Forms.TabPage();
            this.aircraftDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.addAircraftCancelButton = new System.Windows.Forms.Button();
            this.addAircraftSaveButton = new System.Windows.Forms.Button();
            this.addAircraftSubmitButton = new System.Windows.Forms.Button();
            this.aircraftNameTextBox = new System.Windows.Forms.TextBox();
            this.maxJumpersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxJumbersLabel = new System.Windows.Forms.Label();
            this.aircraftNameLabel = new System.Windows.Forms.Label();
            this.editAircraftDetailLabel = new System.Windows.Forms.Label();
            this.aircraftListBox = new System.Windows.Forms.ListBox();
            this.deleteAircractButton = new System.Windows.Forms.Button();
            this.editAircractButton = new System.Windows.Forms.Button();
            this.addAircraftButton = new System.Windows.Forms.Button();
            this.loadsTabPage = new System.Windows.Forms.TabPage();
            this.selectedLoadLabel = new System.Windows.Forms.Label();
            this.selectedLoadIsLabel = new System.Windows.Forms.Label();
            this.deletePersonFromLoadButton = new System.Windows.Forms.Button();
            this.quickAddNotesLabel = new System.Windows.Forms.Label();
            this.loadAircraftComboBox = new System.Windows.Forms.ComboBox();
            this.loadsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.quickAddButton = new System.Windows.Forms.Button();
            this.quickAddManifestNumberTextBox = new System.Windows.Forms.TextBox();
            this.quickAddManifestNumberLabel = new System.Windows.Forms.Label();
            this.addPersonToLoadButton = new System.Windows.Forms.Button();
            this.completeLoadButton = new System.Windows.Forms.Button();
            this.newLoadButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.peopleTabPage.SuspendLayout();
            this.groupBoxPersonDetails.SuspendLayout();
            this.aircraftTabPage.SuspendLayout();
            this.aircraftDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxJumpersNumericUpDown)).BeginInit();
            this.loadsTabPage.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(805, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
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
            this.tabControl.Controls.Add(this.peopleTabPage);
            this.tabControl.Controls.Add(this.aircraftTabPage);
            this.tabControl.Controls.Add(this.loadsTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(805, 442);
            this.tabControl.TabIndex = 1;
            // 
            // peopleTabPage
            // 
            this.peopleTabPage.Controls.Add(this.groupBoxPersonDetails);
            this.peopleTabPage.Controls.Add(this.deletePersonButton);
            this.peopleTabPage.Controls.Add(this.editPersonButton);
            this.peopleTabPage.Controls.Add(this.addNewPersonButton);
            this.peopleTabPage.Controls.Add(this.searchPeopleButton);
            this.peopleTabPage.Controls.Add(this.searchPeopleTextBox);
            this.peopleTabPage.Controls.Add(this.peopleListBox);
            this.peopleTabPage.Location = new System.Drawing.Point(4, 22);
            this.peopleTabPage.Name = "peopleTabPage";
            this.peopleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.peopleTabPage.Size = new System.Drawing.Size(797, 416);
            this.peopleTabPage.TabIndex = 0;
            this.peopleTabPage.Text = "Fun Jumpers & Staff  ";
            this.peopleTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonDetails
            // 
            this.groupBoxPersonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPersonDetails.Controls.Add(this.editDetailsLabel);
            this.groupBoxPersonDetails.Controls.Add(this.addPersonCancelButton);
            this.groupBoxPersonDetails.Controls.Add(this.addPersonSubmitButton);
            this.groupBoxPersonDetails.Controls.Add(this.videographerCheckbox);
            this.groupBoxPersonDetails.Controls.Add(this.coachCheckbox);
            this.groupBoxPersonDetails.Controls.Add(this.affInstructorCheckbox);
            this.groupBoxPersonDetails.Controls.Add(this.tandemInstructorCheckbox);
            this.groupBoxPersonDetails.Controls.Add(this.lastNameLabel);
            this.groupBoxPersonDetails.Controls.Add(this.firstNameLabel);
            this.groupBoxPersonDetails.Controls.Add(this.manifestNumberLabel);
            this.groupBoxPersonDetails.Controls.Add(this.addPersonSaveButton);
            this.groupBoxPersonDetails.Controls.Add(this.manifestNumberTextBox);
            this.groupBoxPersonDetails.Controls.Add(this.lastNameTextBox);
            this.groupBoxPersonDetails.Controls.Add(this.firstNameTextBox);
            this.groupBoxPersonDetails.Location = new System.Drawing.Point(262, 71);
            this.groupBoxPersonDetails.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPersonDetails.Name = "groupBoxPersonDetails";
            this.groupBoxPersonDetails.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPersonDetails.Size = new System.Drawing.Size(484, 317);
            this.groupBoxPersonDetails.TabIndex = 6;
            this.groupBoxPersonDetails.TabStop = false;
            this.groupBoxPersonDetails.Text = "Person Details";
            // 
            // editDetailsLabel
            // 
            this.editDetailsLabel.AutoSize = true;
            this.editDetailsLabel.Location = new System.Drawing.Point(28, 31);
            this.editDetailsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.editDetailsLabel.Name = "editDetailsLabel";
            this.editDetailsLabel.Size = new System.Drawing.Size(87, 13);
            this.editDetailsLabel.TabIndex = 24;
            this.editDetailsLabel.Text = "Editing details for";
            // 
            // addPersonCancelButton
            // 
            this.addPersonCancelButton.Location = new System.Drawing.Point(121, 212);
            this.addPersonCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPersonCancelButton.Name = "addPersonCancelButton";
            this.addPersonCancelButton.Size = new System.Drawing.Size(86, 24);
            this.addPersonCancelButton.TabIndex = 23;
            this.addPersonCancelButton.Text = "Cancel";
            this.addPersonCancelButton.UseVisualStyleBackColor = true;
            this.addPersonCancelButton.Click += new System.EventHandler(this.AddPersonCancelButton_Click);
            // 
            // addPersonSubmitButton
            // 
            this.addPersonSubmitButton.Location = new System.Drawing.Point(121, 157);
            this.addPersonSubmitButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPersonSubmitButton.Name = "addPersonSubmitButton";
            this.addPersonSubmitButton.Size = new System.Drawing.Size(86, 24);
            this.addPersonSubmitButton.TabIndex = 22;
            this.addPersonSubmitButton.Text = "Add";
            this.addPersonSubmitButton.UseVisualStyleBackColor = true;
            this.addPersonSubmitButton.Click += new System.EventHandler(this.AddPersonSubmitButton_Click);
            // 
            // videographerCheckbox
            // 
            this.videographerCheckbox.AutoSize = true;
            this.videographerCheckbox.Location = new System.Drawing.Point(258, 149);
            this.videographerCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.videographerCheckbox.Name = "videographerCheckbox";
            this.videographerCheckbox.Size = new System.Drawing.Size(89, 17);
            this.videographerCheckbox.TabIndex = 21;
            this.videographerCheckbox.Text = "Videographer";
            this.videographerCheckbox.UseVisualStyleBackColor = true;
            // 
            // coachCheckbox
            // 
            this.coachCheckbox.AutoSize = true;
            this.coachCheckbox.Location = new System.Drawing.Point(258, 122);
            this.coachCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.coachCheckbox.Name = "coachCheckbox";
            this.coachCheckbox.Size = new System.Drawing.Size(57, 17);
            this.coachCheckbox.TabIndex = 20;
            this.coachCheckbox.Text = "Coach";
            this.coachCheckbox.UseVisualStyleBackColor = true;
            // 
            // affInstructorCheckbox
            // 
            this.affInstructorCheckbox.AutoSize = true;
            this.affInstructorCheckbox.Location = new System.Drawing.Point(258, 96);
            this.affInstructorCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.affInstructorCheckbox.Name = "affInstructorCheckbox";
            this.affInstructorCheckbox.Size = new System.Drawing.Size(92, 17);
            this.affInstructorCheckbox.TabIndex = 19;
            this.affInstructorCheckbox.Text = "AFF Instructor";
            this.affInstructorCheckbox.UseVisualStyleBackColor = true;
            // 
            // tandemInstructorCheckbox
            // 
            this.tandemInstructorCheckbox.AutoSize = true;
            this.tandemInstructorCheckbox.Location = new System.Drawing.Point(258, 69);
            this.tandemInstructorCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.tandemInstructorCheckbox.Name = "tandemInstructorCheckbox";
            this.tandemInstructorCheckbox.Size = new System.Drawing.Size(112, 17);
            this.tandemInstructorCheckbox.TabIndex = 18;
            this.tandemInstructorCheckbox.Text = "Tandem Instructor";
            this.tandemInstructorCheckbox.UseVisualStyleBackColor = true;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(28, 125);
            this.lastNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.lastNameLabel.TabIndex = 17;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(30, 99);
            this.firstNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.firstNameLabel.TabIndex = 16;
            this.firstNameLabel.Text = "First Name";
            // 
            // manifestNumberLabel
            // 
            this.manifestNumberLabel.AutoSize = true;
            this.manifestNumberLabel.Location = new System.Drawing.Point(30, 71);
            this.manifestNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.manifestNumberLabel.Name = "manifestNumberLabel";
            this.manifestNumberLabel.Size = new System.Drawing.Size(57, 13);
            this.manifestNumberLabel.TabIndex = 15;
            this.manifestNumberLabel.Text = "Manifest #";
            // 
            // addPersonSaveButton
            // 
            this.addPersonSaveButton.Location = new System.Drawing.Point(121, 185);
            this.addPersonSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPersonSaveButton.Name = "addPersonSaveButton";
            this.addPersonSaveButton.Size = new System.Drawing.Size(86, 24);
            this.addPersonSaveButton.TabIndex = 14;
            this.addPersonSaveButton.Text = "Save";
            this.addPersonSaveButton.UseVisualStyleBackColor = true;
            this.addPersonSaveButton.Click += new System.EventHandler(this.AddPersonSaveButton_Click);
            // 
            // manifestNumberTextBox
            // 
            this.manifestNumberTextBox.Location = new System.Drawing.Point(94, 69);
            this.manifestNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.manifestNumberTextBox.Name = "manifestNumberTextBox";
            this.manifestNumberTextBox.Size = new System.Drawing.Size(52, 20);
            this.manifestNumberTextBox.TabIndex = 11;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(94, 122);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.lastNameTextBox.TabIndex = 13;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(94, 96);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.firstNameTextBox.TabIndex = 12;
            // 
            // deletePersonButton
            // 
            this.deletePersonButton.Location = new System.Drawing.Point(262, 38);
            this.deletePersonButton.Margin = new System.Windows.Forms.Padding(2);
            this.deletePersonButton.Name = "deletePersonButton";
            this.deletePersonButton.Size = new System.Drawing.Size(109, 22);
            this.deletePersonButton.TabIndex = 5;
            this.deletePersonButton.Text = "Delete person";
            this.deletePersonButton.UseVisualStyleBackColor = true;
            this.deletePersonButton.Click += new System.EventHandler(this.DeletePersonButton_Click);
            // 
            // editPersonButton
            // 
            this.editPersonButton.Location = new System.Drawing.Point(131, 37);
            this.editPersonButton.Margin = new System.Windows.Forms.Padding(2);
            this.editPersonButton.Name = "editPersonButton";
            this.editPersonButton.Size = new System.Drawing.Size(109, 23);
            this.editPersonButton.TabIndex = 4;
            this.editPersonButton.Text = "Edit person";
            this.editPersonButton.UseVisualStyleBackColor = true;
            this.editPersonButton.Click += new System.EventHandler(this.EditPersonButton_Click);
            // 
            // addNewPersonButton
            // 
            this.addNewPersonButton.Location = new System.Drawing.Point(6, 37);
            this.addNewPersonButton.Name = "addNewPersonButton";
            this.addNewPersonButton.Size = new System.Drawing.Size(109, 23);
            this.addNewPersonButton.TabIndex = 3;
            this.addNewPersonButton.Text = "Add new person";
            this.addNewPersonButton.UseVisualStyleBackColor = true;
            this.addNewPersonButton.Click += new System.EventHandler(this.AddNewPersonButton_Click);
            // 
            // searchPeopleButton
            // 
            this.searchPeopleButton.Location = new System.Drawing.Point(215, 4);
            this.searchPeopleButton.Name = "searchPeopleButton";
            this.searchPeopleButton.Size = new System.Drawing.Size(97, 23);
            this.searchPeopleButton.TabIndex = 2;
            this.searchPeopleButton.Text = "Search People";
            this.searchPeopleButton.UseVisualStyleBackColor = true;
            this.searchPeopleButton.Click += new System.EventHandler(this.SearchPeopleButton_Click);
            // 
            // searchPeopleTextBox
            // 
            this.searchPeopleTextBox.Location = new System.Drawing.Point(6, 6);
            this.searchPeopleTextBox.Name = "searchPeopleTextBox";
            this.searchPeopleTextBox.Size = new System.Drawing.Size(203, 20);
            this.searchPeopleTextBox.TabIndex = 1;
            this.searchPeopleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchPeopleTextBox_KeyDown);
            // 
            // peopleListBox
            // 
            this.peopleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.peopleListBox.FormattingEnabled = true;
            this.peopleListBox.Location = new System.Drawing.Point(6, 71);
            this.peopleListBox.MultiColumn = true;
            this.peopleListBox.Name = "peopleListBox";
            this.peopleListBox.Size = new System.Drawing.Size(244, 316);
            this.peopleListBox.TabIndex = 0;
            // 
            // aircraftTabPage
            // 
            this.aircraftTabPage.Controls.Add(this.aircraftDetailsGroupBox);
            this.aircraftTabPage.Controls.Add(this.aircraftListBox);
            this.aircraftTabPage.Controls.Add(this.deleteAircractButton);
            this.aircraftTabPage.Controls.Add(this.editAircractButton);
            this.aircraftTabPage.Controls.Add(this.addAircraftButton);
            this.aircraftTabPage.Location = new System.Drawing.Point(4, 22);
            this.aircraftTabPage.Name = "aircraftTabPage";
            this.aircraftTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aircraftTabPage.Size = new System.Drawing.Size(797, 416);
            this.aircraftTabPage.TabIndex = 1;
            this.aircraftTabPage.Text = "     Aircraft     ";
            this.aircraftTabPage.UseVisualStyleBackColor = true;
            // 
            // aircraftDetailsGroupBox
            // 
            this.aircraftDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aircraftDetailsGroupBox.Controls.Add(this.addAircraftCancelButton);
            this.aircraftDetailsGroupBox.Controls.Add(this.addAircraftSaveButton);
            this.aircraftDetailsGroupBox.Controls.Add(this.addAircraftSubmitButton);
            this.aircraftDetailsGroupBox.Controls.Add(this.aircraftNameTextBox);
            this.aircraftDetailsGroupBox.Controls.Add(this.maxJumpersNumericUpDown);
            this.aircraftDetailsGroupBox.Controls.Add(this.maxJumbersLabel);
            this.aircraftDetailsGroupBox.Controls.Add(this.aircraftNameLabel);
            this.aircraftDetailsGroupBox.Controls.Add(this.editAircraftDetailLabel);
            this.aircraftDetailsGroupBox.Location = new System.Drawing.Point(316, 58);
            this.aircraftDetailsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.aircraftDetailsGroupBox.Name = "aircraftDetailsGroupBox";
            this.aircraftDetailsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.aircraftDetailsGroupBox.Size = new System.Drawing.Size(466, 301);
            this.aircraftDetailsGroupBox.TabIndex = 4;
            this.aircraftDetailsGroupBox.TabStop = false;
            this.aircraftDetailsGroupBox.Text = "Aircraft details";
            // 
            // addAircraftCancelButton
            // 
            this.addAircraftCancelButton.Location = new System.Drawing.Point(94, 178);
            this.addAircraftCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAircraftCancelButton.Name = "addAircraftCancelButton";
            this.addAircraftCancelButton.Size = new System.Drawing.Size(64, 22);
            this.addAircraftCancelButton.TabIndex = 7;
            this.addAircraftCancelButton.Text = "Cancel";
            this.addAircraftCancelButton.UseVisualStyleBackColor = true;
            this.addAircraftCancelButton.Click += new System.EventHandler(this.AddAircraftCancelButton_Click);
            // 
            // addAircraftSaveButton
            // 
            this.addAircraftSaveButton.Location = new System.Drawing.Point(94, 152);
            this.addAircraftSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAircraftSaveButton.Name = "addAircraftSaveButton";
            this.addAircraftSaveButton.Size = new System.Drawing.Size(64, 22);
            this.addAircraftSaveButton.TabIndex = 6;
            this.addAircraftSaveButton.Text = "Save";
            this.addAircraftSaveButton.UseVisualStyleBackColor = true;
            this.addAircraftSaveButton.Click += new System.EventHandler(this.AddAircraftSaveButton_Click);
            // 
            // addAircraftSubmitButton
            // 
            this.addAircraftSubmitButton.Location = new System.Drawing.Point(94, 127);
            this.addAircraftSubmitButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAircraftSubmitButton.Name = "addAircraftSubmitButton";
            this.addAircraftSubmitButton.Size = new System.Drawing.Size(64, 22);
            this.addAircraftSubmitButton.TabIndex = 5;
            this.addAircraftSubmitButton.Text = "Add";
            this.addAircraftSubmitButton.UseVisualStyleBackColor = true;
            this.addAircraftSubmitButton.Click += new System.EventHandler(this.AddAircraftSubmitButton_Click);
            // 
            // aircraftNameTextBox
            // 
            this.aircraftNameTextBox.Location = new System.Drawing.Point(72, 60);
            this.aircraftNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.aircraftNameTextBox.Name = "aircraftNameTextBox";
            this.aircraftNameTextBox.Size = new System.Drawing.Size(145, 20);
            this.aircraftNameTextBox.TabIndex = 4;
            // 
            // maxJumpersNumericUpDown
            // 
            this.maxJumpersNumericUpDown.Location = new System.Drawing.Point(98, 89);
            this.maxJumpersNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.maxJumpersNumericUpDown.Name = "maxJumpersNumericUpDown";
            this.maxJumpersNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.maxJumpersNumericUpDown.TabIndex = 3;
            // 
            // maxJumbersLabel
            // 
            this.maxJumbersLabel.AutoSize = true;
            this.maxJumbersLabel.Location = new System.Drawing.Point(28, 89);
            this.maxJumbersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxJumbersLabel.Name = "maxJumbersLabel";
            this.maxJumbersLabel.Size = new System.Drawing.Size(66, 13);
            this.maxJumbersLabel.TabIndex = 2;
            this.maxJumbersLabel.Text = "Max jumpers";
            // 
            // aircraftNameLabel
            // 
            this.aircraftNameLabel.AutoSize = true;
            this.aircraftNameLabel.Location = new System.Drawing.Point(28, 63);
            this.aircraftNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.aircraftNameLabel.Name = "aircraftNameLabel";
            this.aircraftNameLabel.Size = new System.Drawing.Size(35, 13);
            this.aircraftNameLabel.TabIndex = 1;
            this.aircraftNameLabel.Text = "Name";
            // 
            // editAircraftDetailLabel
            // 
            this.editAircraftDetailLabel.AutoSize = true;
            this.editAircraftDetailLabel.Location = new System.Drawing.Point(28, 32);
            this.editAircraftDetailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.editAircraftDetailLabel.Name = "editAircraftDetailLabel";
            this.editAircraftDetailLabel.Size = new System.Drawing.Size(90, 13);
            this.editAircraftDetailLabel.TabIndex = 0;
            this.editAircraftDetailLabel.Text = "Editing details for ";
            // 
            // aircraftListBox
            // 
            this.aircraftListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aircraftListBox.FormattingEnabled = true;
            this.aircraftListBox.Location = new System.Drawing.Point(15, 58);
            this.aircraftListBox.Margin = new System.Windows.Forms.Padding(2);
            this.aircraftListBox.Name = "aircraftListBox";
            this.aircraftListBox.Size = new System.Drawing.Size(288, 303);
            this.aircraftListBox.TabIndex = 3;
            // 
            // deleteAircractButton
            // 
            this.deleteAircractButton.Location = new System.Drawing.Point(204, 19);
            this.deleteAircractButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteAircractButton.Name = "deleteAircractButton";
            this.deleteAircractButton.Size = new System.Drawing.Size(82, 24);
            this.deleteAircractButton.TabIndex = 2;
            this.deleteAircractButton.Text = "Delete Aircraft";
            this.deleteAircractButton.UseVisualStyleBackColor = true;
            this.deleteAircractButton.Click += new System.EventHandler(this.DeleteAircraftButton_Click);
            // 
            // editAircractButton
            // 
            this.editAircractButton.Location = new System.Drawing.Point(116, 19);
            this.editAircractButton.Margin = new System.Windows.Forms.Padding(2);
            this.editAircractButton.Name = "editAircractButton";
            this.editAircractButton.Size = new System.Drawing.Size(76, 24);
            this.editAircractButton.TabIndex = 1;
            this.editAircractButton.Text = "Edit Aircraft";
            this.editAircractButton.UseVisualStyleBackColor = true;
            this.editAircractButton.Click += new System.EventHandler(this.EditAircraftButton_Click);
            // 
            // addAircraftButton
            // 
            this.addAircraftButton.Location = new System.Drawing.Point(27, 19);
            this.addAircraftButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAircraftButton.Name = "addAircraftButton";
            this.addAircraftButton.Size = new System.Drawing.Size(77, 24);
            this.addAircraftButton.TabIndex = 0;
            this.addAircraftButton.Text = "Add Aircraft";
            this.addAircraftButton.UseVisualStyleBackColor = true;
            this.addAircraftButton.Click += new System.EventHandler(this.AddAircraftButton_Click);
            // 
            // loadsTabPage
            // 
            this.loadsTabPage.Controls.Add(this.selectedLoadLabel);
            this.loadsTabPage.Controls.Add(this.selectedLoadIsLabel);
            this.loadsTabPage.Controls.Add(this.deletePersonFromLoadButton);
            this.loadsTabPage.Controls.Add(this.quickAddNotesLabel);
            this.loadsTabPage.Controls.Add(this.loadAircraftComboBox);
            this.loadsTabPage.Controls.Add(this.loadsPanel);
            this.loadsTabPage.Controls.Add(this.quickAddButton);
            this.loadsTabPage.Controls.Add(this.quickAddManifestNumberTextBox);
            this.loadsTabPage.Controls.Add(this.quickAddManifestNumberLabel);
            this.loadsTabPage.Controls.Add(this.addPersonToLoadButton);
            this.loadsTabPage.Controls.Add(this.completeLoadButton);
            this.loadsTabPage.Controls.Add(this.newLoadButton);
            this.loadsTabPage.Location = new System.Drawing.Point(4, 22);
            this.loadsTabPage.Name = "loadsTabPage";
            this.loadsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.loadsTabPage.Size = new System.Drawing.Size(797, 416);
            this.loadsTabPage.TabIndex = 2;
            this.loadsTabPage.Text = "     Loads     ";
            this.loadsTabPage.UseVisualStyleBackColor = true;
            // 
            // selectedLoadLabel
            // 
            this.selectedLoadLabel.AutoSize = true;
            this.selectedLoadLabel.Location = new System.Drawing.Point(368, 51);
            this.selectedLoadLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedLoadLabel.Name = "selectedLoadLabel";
            this.selectedLoadLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedLoadLabel.TabIndex = 17;
            // 
            // selectedLoadIsLabel
            // 
            this.selectedLoadIsLabel.AutoSize = true;
            this.selectedLoadIsLabel.Location = new System.Drawing.Point(280, 51);
            this.selectedLoadIsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedLoadIsLabel.Name = "selectedLoadIsLabel";
            this.selectedLoadIsLabel.Size = new System.Drawing.Size(85, 13);
            this.selectedLoadIsLabel.TabIndex = 16;
            this.selectedLoadIsLabel.Text = "Selected load is:";
            // 
            // deletePersonFromLoadButton
            // 
            this.deletePersonFromLoadButton.Location = new System.Drawing.Point(408, 19);
            this.deletePersonFromLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.deletePersonFromLoadButton.Name = "deletePersonFromLoadButton";
            this.deletePersonFromLoadButton.Size = new System.Drawing.Size(128, 21);
            this.deletePersonFromLoadButton.TabIndex = 15;
            this.deletePersonFromLoadButton.Text = "Delete from Load";
            this.deletePersonFromLoadButton.UseVisualStyleBackColor = true;
            this.deletePersonFromLoadButton.Click += new System.EventHandler(this.DeletePersonFromLoadButton_Click);
            // 
            // quickAddNotesLabel
            // 
            this.quickAddNotesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quickAddNotesLabel.AutoSize = true;
            this.quickAddNotesLabel.Location = new System.Drawing.Point(558, 38);
            this.quickAddNotesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quickAddNotesLabel.Name = "quickAddNotesLabel";
            this.quickAddNotesLabel.Size = new System.Drawing.Size(187, 13);
            this.quickAddNotesLabel.TabIndex = 14;
            this.quickAddNotesLabel.Text = "(Reg price, own gear, full altitude only)";
            // 
            // loadAircraftComboBox
            // 
            this.loadAircraftComboBox.FormattingEnabled = true;
            this.loadAircraftComboBox.Location = new System.Drawing.Point(10, 19);
            this.loadAircraftComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.loadAircraftComboBox.Name = "loadAircraftComboBox";
            this.loadAircraftComboBox.Size = new System.Drawing.Size(130, 21);
            this.loadAircraftComboBox.TabIndex = 1;
            // 
            // loadsPanel
            // 
            this.loadsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadsPanel.AutoScroll = true;
            this.loadsPanel.Location = new System.Drawing.Point(10, 67);
            this.loadsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loadsPanel.Name = "loadsPanel";
            this.loadsPanel.Size = new System.Drawing.Size(764, 302);
            this.loadsPanel.TabIndex = 10;
            this.loadsPanel.WrapContents = false;
            // 
            // quickAddButton
            // 
            this.quickAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quickAddButton.Location = new System.Drawing.Point(676, 15);
            this.quickAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.quickAddButton.Name = "quickAddButton";
            this.quickAddButton.Size = new System.Drawing.Size(72, 21);
            this.quickAddButton.TabIndex = 6;
            this.quickAddButton.Text = "Quick Add";
            this.quickAddButton.UseVisualStyleBackColor = true;
            this.quickAddButton.Click += new System.EventHandler(this.QuickAddButton_Click);
            // 
            // quickAddManifestNumberTextBox
            // 
            this.quickAddManifestNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quickAddManifestNumberTextBox.Location = new System.Drawing.Point(618, 18);
            this.quickAddManifestNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.quickAddManifestNumberTextBox.Name = "quickAddManifestNumberTextBox";
            this.quickAddManifestNumberTextBox.Size = new System.Drawing.Size(52, 20);
            this.quickAddManifestNumberTextBox.TabIndex = 5;
            // 
            // quickAddManifestNumberLabel
            // 
            this.quickAddManifestNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quickAddManifestNumberLabel.AutoSize = true;
            this.quickAddManifestNumberLabel.Location = new System.Drawing.Point(558, 21);
            this.quickAddManifestNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quickAddManifestNumberLabel.Name = "quickAddManifestNumberLabel";
            this.quickAddManifestNumberLabel.Size = new System.Drawing.Size(57, 13);
            this.quickAddManifestNumberLabel.TabIndex = 7;
            this.quickAddManifestNumberLabel.Text = "Manifest #";
            // 
            // addPersonToLoadButton
            // 
            this.addPersonToLoadButton.Location = new System.Drawing.Point(276, 19);
            this.addPersonToLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPersonToLoadButton.Name = "addPersonToLoadButton";
            this.addPersonToLoadButton.Size = new System.Drawing.Size(128, 21);
            this.addPersonToLoadButton.TabIndex = 4;
            this.addPersonToLoadButton.Text = "Add Person to Load";
            this.addPersonToLoadButton.UseVisualStyleBackColor = true;
            this.addPersonToLoadButton.Click += new System.EventHandler(this.AddPersonToLoad_Click);
            // 
            // completeLoadButton
            // 
            this.completeLoadButton.Location = new System.Drawing.Point(10, 43);
            this.completeLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.completeLoadButton.Name = "completeLoadButton";
            this.completeLoadButton.Size = new System.Drawing.Size(83, 21);
            this.completeLoadButton.TabIndex = 7;
            this.completeLoadButton.Text = "Complete Load";
            this.completeLoadButton.UseVisualStyleBackColor = true;
            this.completeLoadButton.Click += new System.EventHandler(this.CompleteLoadButton_Click);
            // 
            // newLoadButton
            // 
            this.newLoadButton.Location = new System.Drawing.Point(150, 18);
            this.newLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.newLoadButton.Name = "newLoadButton";
            this.newLoadButton.Size = new System.Drawing.Size(70, 21);
            this.newLoadButton.TabIndex = 3;
            this.newLoadButton.Text = "New Load";
            this.newLoadButton.UseVisualStyleBackColor = true;
            this.newLoadButton.Click += new System.EventHandler(this.NewLoadButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 444);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip.Size = new System.Drawing.Size(805, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(201, 17);
            this.toolStripStatusLabel.Text = "West Tennessee Skydiving - Manifest";
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
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(821, 505);
            this.Name = "MainForm";
            this.Text = "West Tennessee Skydiving";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.peopleTabPage.ResumeLayout(false);
            this.peopleTabPage.PerformLayout();
            this.groupBoxPersonDetails.ResumeLayout(false);
            this.groupBoxPersonDetails.PerformLayout();
            this.aircraftTabPage.ResumeLayout(false);
            this.aircraftDetailsGroupBox.ResumeLayout(false);
            this.aircraftDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxJumpersNumericUpDown)).EndInit();
            this.loadsTabPage.ResumeLayout(false);
            this.loadsTabPage.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage peopleTabPage;
        private System.Windows.Forms.TabPage aircraftTabPage;
        private System.Windows.Forms.TabPage loadsTabPage;
        private System.Windows.Forms.Button searchPeopleButton;
        private System.Windows.Forms.TextBox searchPeopleTextBox;
        private System.Windows.Forms.ListBox peopleListBox;
        private System.Windows.Forms.Button addNewPersonButton;
        private System.Windows.Forms.Button deletePersonButton;
        private System.Windows.Forms.Button editPersonButton;
        private System.Windows.Forms.ListBox aircraftListBox;
        private System.Windows.Forms.Button deleteAircractButton;
        private System.Windows.Forms.Button editAircractButton;
        private System.Windows.Forms.Button addAircraftButton;
        private System.Windows.Forms.Button completeLoadButton;
        private System.Windows.Forms.Button newLoadButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBoxPersonDetails;
        private System.Windows.Forms.Button quickAddButton;
        private System.Windows.Forms.TextBox quickAddManifestNumberTextBox;
        private System.Windows.Forms.Label quickAddManifestNumberLabel;
        private System.Windows.Forms.Button addPersonToLoadButton;
        private System.Windows.Forms.FlowLayoutPanel loadsPanel;
        private System.Windows.Forms.ComboBox loadAircraftComboBox;
        private System.Windows.Forms.Label quickAddNotesLabel;
        private System.Windows.Forms.CheckBox videographerCheckbox;
        private System.Windows.Forms.CheckBox coachCheckbox;
        private System.Windows.Forms.CheckBox affInstructorCheckbox;
        private System.Windows.Forms.CheckBox tandemInstructorCheckbox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label manifestNumberLabel;
        private System.Windows.Forms.Button addPersonSaveButton;
        private System.Windows.Forms.TextBox manifestNumberTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button addPersonSubmitButton;
        private System.Windows.Forms.Button addPersonCancelButton;
        private System.Windows.Forms.Label editDetailsLabel;
        private System.Windows.Forms.GroupBox aircraftDetailsGroupBox;
        private System.Windows.Forms.Button addAircraftCancelButton;
        private System.Windows.Forms.Button addAircraftSaveButton;
        private System.Windows.Forms.Button addAircraftSubmitButton;
        private System.Windows.Forms.TextBox aircraftNameTextBox;
        private System.Windows.Forms.NumericUpDown maxJumpersNumericUpDown;
        private System.Windows.Forms.Label maxJumbersLabel;
        private System.Windows.Forms.Label aircraftNameLabel;
        private System.Windows.Forms.Label editAircraftDetailLabel;
        private System.Windows.Forms.Button deletePersonFromLoadButton;
        private System.Windows.Forms.Label selectedLoadLabel;
        private System.Windows.Forms.Label selectedLoadIsLabel;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
    }
}

