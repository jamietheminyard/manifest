namespace Manifest
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Manifest.Domain.Entities;
    using Manifest.Persistence.Context;
    using Microsoft.EntityFrameworkCore;

    public partial class MainForm : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int searchIndex;
        private int tmpLoadNum = 1;
        private string selectedLoad = string.Empty;
        private int imageIndex = 0;
        private List<string> selectedPeople = new List<string>();

        public MainForm()
        {
            this.InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("\n---------------------------------------------Application startup " + DateTime.Now.ToString() + "---------------------------------------------");

            this.searchIndex = 0;

            // show/hide UI components
            this.HideEditPersonUI();
            this.addPersonSaveButton.Hide();
            this.addPersonSubmitButton.Hide();
            this.addPersonCancelButton.Hide();
            this.editDetailsLabel.Hide();

            this.HideEditAircraftUI();
            this.addAircraftSubmitButton.Hide();
            this.addAircraftSaveButton.Hide();
            this.addAircraftCancelButton.Hide();

            this.WindowState = FormWindowState.Maximized;
            this.tabControl.SelectedTab = this.loadsTabPage;

            this.maxJumpersNumericUpDown.Value = 1;
            this.LoadPeople();
            this.LoadAircraft();

            // Default to the King Air
            try
            {
                this.loadAircraftComboBox.SelectedIndex = this.loadAircraftComboBox.Items.IndexOf("King Air");
            }
            catch (Exception)
            {
            }

            // Retrieve all image files for logos used to group tandems/AFF
            string[] imageFiles = Directory.GetFiles(@"C:\test");
            foreach (var file in imageFiles)
            {
                // Add images to Imagelist
                this.imageList.Images.Add(Image.FromFile(file));
            }
        }

        private static void AddLog(string loadNum, string manifestNum, string price)
        {
            Log.Info("\nLoad " + loadNum + " added number " + manifestNum + " $" + price);
        }

        private static void AddLog(string loadNum, string manifestNum)
        {
            Log.Info("\nLoad " + loadNum + " removed number " + manifestNum);
        }

        private static void AddLog(string loadNum)
        {
            Log.Info("\nLoad " + loadNum + " created.");
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Point current = this.loadsPanel.AutoScrollPosition;
                Point scrolled = new Point(current.X + 50, current.Y);
                this.loadsPanel.AutoScrollPosition = scrolled;
            }

            if (e.KeyCode == Keys.Left)
            {
                Point current = this.loadsPanel.AutoScrollPosition;
                Point scrolled = new Point(current.X - 50, current.Y);
                this.loadsPanel.AutoScrollPosition = scrolled;
            }

            if (e.KeyCode == Keys.Insert)
            {
                this.HandleAddPersonToLoad();
            }

            if (e.KeyCode == Keys.F12)
            {
                this.HandleAddPersonToLoad();
            }
        }

        private void HandleAddPersonToLoad()
        {
            if (this.loadsPanel.Controls.Count == 0)
            {
                MessageBox.Show("Please create a load first.", "Create a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(this.selectedLoad))
            {
                MessageBox.Show("Please click a load first to select it.", "Select a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            using (AddPersonToLoadForm addPersonToLoadForm = new AddPersonToLoadForm(this.selectedLoad))
            {
                addPersonToLoadForm.ShowDialog();
                DialogResult result = addPersonToLoadForm.Result;
                if (result == DialogResult.None)
                {
                    return;
                }

                // Add the person to the selected load
                ListViewItem loadInfo;

                // Check to see if this person's manifest number is already manifested
                foreach (ListView c in this.loadsPanel.Controls)
                {
                    foreach (ListViewItem i in c.Items)
                    {
                        if (i.Text.Contains(addPersonToLoadForm.Instructor1ManNum) && string.IsNullOrEmpty(addPersonToLoadForm.Instructor1ManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addPersonToLoadForm.Instructor1 + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (i.Text.Contains(addPersonToLoadForm.Instructor2orVideoManNum) && string.IsNullOrEmpty(addPersonToLoadForm.Instructor2orVideoManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addPersonToLoadForm.Instructor2orVideo + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (i.Text.Contains(addPersonToLoadForm.ManNum) && string.IsNullOrEmpty(addPersonToLoadForm.ManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addPersonToLoadForm.JumperName + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }

                // Proceed with adding them to the load
                foreach (ListView c in this.loadsPanel.Controls)
                {
                    if (c.Items[0].ToString().Contains(this.selectedLoad))
                    {
                        // If tandem, make a separate entry for the TI and video if applicable
                        if (addPersonToLoadForm.JumpType.Contains("TAN"))
                        {
                            // Update the first item in the list to have correct number of slots left
                            loadInfo = c.Items[0];
                            string[] pieces = loadInfo.Text.Split('-');
                            string slots = pieces[2].Replace("slots", string.Empty).Trim();
                            int num = 0;
                            int.TryParse(slots, out num);

                            if (string.IsNullOrEmpty(addPersonToLoadForm.Instructor2orVideo.Trim()) == false)
                            {
                                num = num - 3; // Has video, so subtract 3
                            }
                            else
                            {
                                num = num - 2; // just TI and student
                            }

                            if (num < 0)
                            {
                                MessageBox.Show("Not enough room on this load.");
                                return;
                            }

                            if (num == 0)
                            {
                                c.BackColor = Color.Red; // If load is full, color it red
                            }

                            c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                            // Add the people
                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.Instructor1 });
                            AddLog(this.selectedLoad, addPersonToLoadForm.Instructor1ManNum, " replace this with instructor pay rate");
                            if (string.IsNullOrEmpty(addPersonToLoadForm.Instructor2orVideo.Trim()) == false)
                            {
                                c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.Instructor2orVideo });
                                AddLog(this.selectedLoad, addPersonToLoadForm.Instructor2orVideoManNum, " replace this with video pay rate");
                            }

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.JumperName });
                            AddLog(this.selectedLoad, "TANSTUDENT", " replace this with tandems cost");
                            this.imageIndex = this.imageIndex + 1;
                            if (this.imageIndex == 12)
                            {
                                this.imageIndex = 0;
                            }

                            return;
                        }

                        // If AFF, make a separate entry for the AFFIs
                        else if (addPersonToLoadForm.JumpType.Contains("AFF"))
                        {
                            // Update the first item in the list to have correct number of slots left
                            loadInfo = c.Items[0];
                            string[] pieces = loadInfo.Text.Split('-');
                            string slots = pieces[2].Replace("slots", string.Empty).Trim();
                            int num = 0;
                            int.TryParse(slots, out num);
                            if (string.IsNullOrEmpty(addPersonToLoadForm.Instructor2orVideo.Trim()) == false)
                            {
                                num = num - 3; // Has 2 instructors, so subtract 3
                            }
                            else
                            {
                                num = num - 2; // just 1 instructor
                            }

                            if (num < 0)
                            {
                                MessageBox.Show("Not enough room on this load.");
                                return;
                            }

                            if (num == 0)
                            {
                                c.BackColor = Color.Red; // If load is full, color it red
                            }

                            c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.Instructor1 });
                            AddLog(this.selectedLoad, addPersonToLoadForm.Instructor1ManNum, " replace this with instructor pay rate");
                            if (string.IsNullOrEmpty(addPersonToLoadForm.Instructor2orVideo.Trim()) == false)
                            {
                                c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.Instructor2orVideo });
                                AddLog(this.selectedLoad, addPersonToLoadForm.Instructor2orVideoManNum, " replace this with instructor pay rate");
                            }

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addPersonToLoadForm.ManNum + " - " + addPersonToLoadForm.JumperName });
                            AddLog(this.selectedLoad, addPersonToLoadForm.ManNum, " replace this with AFF student rate");
                            this.imageIndex = this.imageIndex + 1;
                            if (this.imageIndex == 12)
                            {
                                this.imageIndex = 0;
                            }

                            return;
                        }
                        else
                        {
                            // Regular fun jumper
                            // Update the first item in the list to have correct number of slots left
                            loadInfo = c.Items[0];

                            string[] pieces = loadInfo.Text.Split('-');
                            string slots = pieces[2].Replace("slots", string.Empty).Trim();

                            int num = 0;
                            int.TryParse(slots, out num);

                            num = num - 1;

                            if (num < 0)
                            {
                                MessageBox.Show("Not enough room on this load.");
                                return;
                            }

                            if (num == 0)
                            {
                                c.BackColor = Color.Red; // If load is full, color it red
                            }

                            c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                            c.Items.Add(new ListViewItem { Text = addPersonToLoadForm.ManNum + " - " + addPersonToLoadForm.JumperName });
                            AddLog(this.selectedLoad, addPersonToLoadForm.ManNum, " replace this with fun jump pay rate or 0 if beginning of year free jumps");
                        }
                    }
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Manifest Program\nCopyright 2018-" + DateTime.Now.ToString("yyyy") + "\nAll rights reserved", "About");
        }

        private void SearchPeopleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchForPeople();
            }
        }

        private void SearchForPeople()
        {
            string searchText = this.searchPeopleTextBox.Text.ToLower();
            bool found = false;
            int selectedIndex = this.peopleListBox.SelectedIndex;
            int numItems = this.peopleListBox.Items.Count;

            // If the first item in the list is selected and matches, just increment search index and return
            if (selectedIndex == 0 && this.searchIndex == 0 && this.peopleListBox.Items[0].ToString().ToLower().Contains(searchText))
            {
                this.searchIndex++;
                return;
            }

            if (selectedIndex + 1 == numItems)
            {
                this.searchIndex = 0;
                selectedIndex = 0;
                this.peopleListBox.SelectedIndex = 0;
            }
            else
            {
                this.searchIndex = selectedIndex + 1;
            }

            // Starting at the search index, look for the next instance of the search text
            for (int i = this.searchIndex; i < this.peopleListBox.Items.Count; i++)
            {
                if (this.peopleListBox.Items[i].ToString().ToLower().Contains(searchText))
                {
                    found = true;
                    this.peopleListBox.SelectedIndex = i;
                    this.searchIndex = i;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Reached the end of the list.");
                this.searchIndex = 0;
                this.peopleListBox.SelectedIndex = 0;
            }
        }

        private void LoadPeople()
        {
            IReadOnlyCollection<Person> people;

            using (ManifestDbContext context = new ManifestDbContext())
            {
                people = context.People.OrderBy(p => p.ManifestNumber).ToList();
            }

            this.peopleListBox.DataSource = people
                .Select(person => $"{person.ManifestNumber} - {person.FirstName} {person.LastName}")
                .ToList();
        }

        private void ShowEditPersonUI()
        {
            this.manifestNumberLabel.Show();
            this.manifestNumberTextBox.Show();
            this.firstNameLabel.Show();
            this.firstNameTextBox.Show();
            this.lastNameLabel.Show();
            this.lastNameTextBox.Show();
            this.tandemInstructorCheckbox.Show();
            this.affInstructorCheckbox.Show();
            this.coachCheckbox.Show();
            this.videographerCheckbox.Show();
        }

        private void HideEditPersonUI()
        {
            this.manifestNumberLabel.Hide();
            this.manifestNumberTextBox.Text = string.Empty;
            this.manifestNumberTextBox.Hide();
            this.firstNameLabel.Hide();
            this.firstNameTextBox.Text = string.Empty;
            this.firstNameTextBox.Hide();
            this.lastNameLabel.Hide();
            this.lastNameTextBox.Text = string.Empty;
            this.lastNameTextBox.Hide();
            this.tandemInstructorCheckbox.Checked = false;
            this.tandemInstructorCheckbox.Hide();
            this.affInstructorCheckbox.Checked = false;
            this.affInstructorCheckbox.Hide();
            this.coachCheckbox.Checked = false;
            this.coachCheckbox.Hide();
            this.videographerCheckbox.Checked = false;
            this.videographerCheckbox.Hide();
        }

        private void AddNewPersonButton_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            this.ShowEditPersonUI();
            this.addPersonSubmitButton.Show();
            this.addPersonCancelButton.Show();
            this.addPersonSaveButton.Hide();

            // Clear the edit UI components
            this.manifestNumberTextBox.Text = string.Empty;
            this.firstNameTextBox.Text = string.Empty;
            this.lastNameTextBox.Text = string.Empty;
        }

        private void AddPersonToLoad_Click(object sender, EventArgs e)
        {
            this.HandleAddPersonToLoad();
        }

        private void NewLoadButton_Click(object sender, EventArgs e)
        {
            ListView loadList = new ListView();

            loadList.LargeImageList = this.imageList;
            loadList.SmallImageList = this.imageList;

            loadList.View = View.Details;

            loadList.HeaderStyle = ColumnHeaderStyle.None;
            loadList.FullRowSelect = true;
            loadList.Columns.Add(string.Empty, -2);

            // Get the number of max jumpers for this aircraft
            string aircraftName = this.loadAircraftComboBox.Text;
            Aircraft aircraft;

            using (ManifestDbContext context = new ManifestDbContext())
            {
                aircraft = context.Aircraft.Single(a => a.Name == aircraftName);
            }

            loadList.Items.Add($"Load {this.tmpLoadNum} - {aircraft.Name} - {aircraft.Capacity} slots");

            loadList.Scrollable = false;

            loadList.View = View.Details; // Enables Details view so you can see columns
            loadList.AllowDrop = true;
            loadList.DragDrop += this.ListView_DragDrop;
            loadList.DragEnter += this.ListView_DragEnter;
            loadList.ItemDrag += this.ListView_ItemDrag;
/*
            loadList.Items.Add(new ListViewItem { ImageIndex = 0, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 0, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 1, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 1, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 2, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 2, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 3, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 3, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 4, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 4, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 5, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 5, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 6, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 6, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 7, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 7, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 8, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 8, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 9, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 9, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 10, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 10, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 11, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Items.Add(new ListViewItem { ImageIndex = 11, Text = "5368 - Jamie Minyard AFF1" });
*/
            loadList.Width = 200;
            loadList.Height = 500;
            loadList.Columns[0].Width = this.Width - 50;

            loadList.Click += new EventHandler(this.LoadList_Click);

            this.loadsPanel.Controls.Add(loadList);
            AddLog(this.tmpLoadNum.ToString());
            this.tmpLoadNum++;

            if (this.loadsPanel.Controls.Count == 1)
            {
                this.selectedLoad = "Load 1";
                this.selectedLoadLabel.Text = "Load 1";
            }
        }

        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            // Translate the mouse coordinates (screen coords) into control coordinates
//            Point p = listView1.PointToClient(new Point(e.X, e.Y));
            // Find the item that the object was dragged onto
//            var ItemToReplace = listView1.GetItemAt(p.X, p.Y);
            // extract the listview item from the dragged items IData member
            var draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            MessageBox.Show(draggedItem.ToString());
        }

        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Start the dragdrop operation with the currently dragged listview item as the drag data
            ListView lv = (ListView)sender;
            lv.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Move);
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            // If the item being dragged isn't associated with this listview, it's not allowed to be dragged here
   //         ListView lv = (ListView)sender;
   //         if (((ListViewItem)e.Data.GetData(typeof(ListViewItem))).ListView == lv)
                e.Effect = DragDropEffects.Move;

   // else
   //             e.Effect = DragDropEffects.None;
        }

        private void LoadList_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string load = lv.Items[0].Text.Split('-')[0];
            this.selectedLoad = load;
            this.selectedLoadLabel.Text = this.selectedLoad;
            this.selectedPeople.Clear();
            for (int i = 0; i < lv.SelectedItems.Count; i++)
            {
 // MessageBox.Show("person is " + lv.SelectedItems[i].Text);
                this.selectedPeople.Add(lv.SelectedItems[i].Text);
            }
        }

        private void DeletePersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                string item = this.peopleListBox.GetItemText(this.peopleListBox.SelectedItem);
                string[] splitString = item.Split('-');
                string manifestNumber = splitString[0];
                string name = splitString[1];
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this person from the database?\n\nManifest Number: " + manifestNumber + "\nName: " + name + "\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    using (ManifestDbContext context = new ManifestDbContext())
                    {
                        Person person = context.People.Single(p => p.ManifestNumber == manifestNumber);

                        context.Entry(person).State = EntityState.Deleted;
                        context.SaveChanges();
                    }

                    // If delete was successful, reload the people in the UI list
                    this.LoadPeople();

                    // Hide the edit UI components
                    this.HideEditPersonUI();
                    this.addPersonSaveButton.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete person.");
            }
        }

        private void EditPersonButton_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            this.ShowEditPersonUI();
            this.addPersonSaveButton.Show();
            this.addPersonCancelButton.Show();
            this.addPersonSubmitButton.Hide();
            try
            {
                string item = this.peopleListBox.GetItemText(this.peopleListBox.SelectedItem);
                string[] splitString = item.Split('-');
                string manifestNumber = splitString[0].Trim();

                Person person;

                using (ManifestDbContext context = new ManifestDbContext())
                {
                    person = context.People.Single(p => p.ManifestNumber == manifestNumber);
                }

                this.manifestNumberTextBox.Text = person.ManifestNumber;
                this.firstNameTextBox.Text = person.FirstName;
                this.lastNameTextBox.Text = person.LastName;
                this.tandemInstructorCheckbox.Checked = person.IsTandemInstructor;
                this.affInstructorCheckbox.Checked = person.IsAffInstructor;
                this.coachCheckbox.Checked = person.IsCoach;
                this.videographerCheckbox.Checked = person.IsVideographer;

                this.editDetailsLabel.Text = $"Editing details for {person.ManifestNumber} - {person.FirstName} {person.LastName}";
                this.editDetailsLabel.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Unable to edit person.\n\nError: " + x.ToString());
            }
        }

        private void AddPersonSaveButton_Click(object sender, EventArgs e)
        {
            string manifestNumber = this.manifestNumberTextBox.Text;

            using (ManifestDbContext context = new ManifestDbContext())
            {
                Person person = context.People.Single(p => p.ManifestNumber == manifestNumber);

                person.FirstName = this.firstNameTextBox.Text;
                person.LastName = this.lastNameTextBox.Text;
                person.IsTandemInstructor = this.tandemInstructorCheckbox.Checked;
                person.IsAffInstructor = this.affInstructorCheckbox.Checked;
                person.IsCoach = this.coachCheckbox.Checked;
                person.IsVideographer = this.videographerCheckbox.Checked;

                context.SaveChanges();
            }

            // If save was successful, reload the people in the UI list
            this.LoadPeople();

            // Hide the edit UI components
            this.HideEditPersonUI();
            this.addPersonSaveButton.Hide();
            this.addPersonCancelButton.Hide();
            this.editDetailsLabel.Hide();
        }

        private void AddPersonSubmitButton_Click(object sender, EventArgs e)
        {
            Person person = new Person(this.manifestNumberTextBox.Text)
            {
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                IsTandemInstructor = this.tandemInstructorCheckbox.Checked,
                IsAffInstructor = this.affInstructorCheckbox.Checked,
                IsCoach = this.coachCheckbox.Checked,
                IsVideographer = this.videographerCheckbox.Checked,
            };

            using (ManifestDbContext context = new ManifestDbContext())
            {
                context.Add(person);
                context.SaveChanges();
            }

            // If insert was successful, reload the people in the UI list
            this.LoadPeople();

            // Hide the edit UI components
            this.HideEditPersonUI();
            this.addPersonCancelButton.Hide();
            this.addPersonSubmitButton.Hide();
        }

        private void SearchPeopleButton_Click(object sender, EventArgs e)
        {
            this.SearchForPeople();
        }

        private void AddPersonCancelButton_Click(object sender, EventArgs e)
        {
            this.HideEditPersonUI();
            this.addPersonSaveButton.Hide();
            this.addPersonSubmitButton.Hide();
            this.addPersonCancelButton.Hide();
            this.editDetailsLabel.Hide();
        }

        private void ShowEditAircraftUI()
        {
            this.editAircraftDetailLabel.Show();
            this.aircraftNameLabel.Show();
            this.aircraftNameTextBox.Show();
            this.maxJumbersLabel.Show();
            this.maxJumpersNumericUpDown.Show();
        }

        private void HideEditAircraftUI()
        {
            this.editAircraftDetailLabel.Hide();
            this.aircraftNameLabel.Hide();
            this.aircraftNameTextBox.Text = string.Empty;
            this.aircraftNameTextBox.Hide();
            this.maxJumbersLabel.Hide();
            this.maxJumpersNumericUpDown.Value = 0;
            this.maxJumpersNumericUpDown.Hide();
        }

        private void AddAircraftCancelButton_Click(object sender, EventArgs e)
        {
            this.HideEditAircraftUI();
            this.addAircraftSubmitButton.Hide();
            this.addAircraftSaveButton.Hide();
            this.addAircraftCancelButton.Hide();
        }

        private void AddAircraftSubmitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.aircraftNameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for this aircraft.");
                return;
            }

            if (this.maxJumpersNumericUpDown.Value < 1)
            {
                MessageBox.Show("Max jumpers cannot be less than 1.");
                return;
            }

            Aircraft aircraft = new Aircraft(
                name: this.aircraftNameTextBox.Text.Replace("-", string.Empty),
                capacity: (int)this.maxJumpersNumericUpDown.Value);

            using (ManifestDbContext context = new ManifestDbContext())
            {
                context.Add(aircraft);
                context.SaveChanges();
            }

            // If insert was successful, reload the aircraft in the UI list
            this.LoadAircraft();

            // Hide the edit UI components
            this.HideEditAircraftUI();
            this.addAircraftSubmitButton.Hide();
            this.addAircraftSaveButton.Hide();
            this.addAircraftCancelButton.Hide();
        }

        private void LoadAircraft()
        {
            IReadOnlyCollection<Aircraft> aircraft;

            using (ManifestDbContext context = new ManifestDbContext())
            {
                aircraft = context.Aircraft.ToList();
            }

            this.aircraftListBox.DataSource = aircraft
                .Select(a => $"{a.Name} - Max jumpers {a.Capacity}")
                .ToList();

            this.loadAircraftComboBox.DataSource = aircraft
                .Select(a => a.Name)
                .ToList();
        }

        private void AddAircraftSaveButton_Click(object sender, EventArgs e)
        {
            string aircraftName = this.aircraftNameTextBox.Text;
            int capacity = (int)this.maxJumpersNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(aircraftName))
            {
                MessageBox.Show("Please enter a name for this aircraft.");
                return;
            }

            if (capacity < 1)
            {
                MessageBox.Show("Max jumpers cannot be less than 1.");
                return;
            }

            using (ManifestDbContext context = new ManifestDbContext())
            {
                Aircraft aircraft = context.Aircraft.Single(a => a.Name == aircraftName);

                aircraft.Capacity = capacity;

                context.SaveChanges();
            }

            // If save was successful, reload the aircraft in the UI list
            this.LoadAircraft();

            // Hide the edit UI components
            this.HideEditAircraftUI();
            this.addAircraftSubmitButton.Hide();
            this.addAircraftSaveButton.Hide();
            this.addAircraftCancelButton.Hide();
        }

        private void AddAircraftButton_Click(object sender, EventArgs e)
        {
            this.ShowEditAircraftUI();
            this.addAircraftSubmitButton.Show();
            this.addAircraftSaveButton.Hide();
            this.addAircraftCancelButton.Show();
            this.editAircraftDetailLabel.Hide();

            // Make the aircraft name read-write
            this.aircraftNameTextBox.Enabled = true;
        }

        private void EditAircraftButton_Click(object sender, EventArgs e)
        {
            // Make the aircraft name read-only
            this.aircraftNameTextBox.Enabled = false;
            string item = this.aircraftListBox.GetItemText(this.aircraftListBox.SelectedItem);
            string[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
            string name = splitString[0].Trim();
            string cap = splitString[1].Trim();
            int capacity = 0;
            this.aircraftNameTextBox.Text = name;
            int.TryParse(cap, out capacity);
            this.maxJumpersNumericUpDown.Value = capacity;

            this.editAircraftDetailLabel.Text = "Editing details for " + name + " with max jumpers " + capacity + ".";

            this.ShowEditAircraftUI();
            this.addAircraftSubmitButton.Hide();
            this.addAircraftSaveButton.Show();
            this.addAircraftCancelButton.Show();
        }

        private void DeleteAircraftButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this aircrafit?\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                string item = this.aircraftListBox.GetItemText(this.aircraftListBox.SelectedItem);
                string[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
                string aircraftName = splitString[0].Trim();

                using (ManifestDbContext context = new ManifestDbContext())
                {
                    Aircraft aircraft = context.Aircraft.Single(a => a.Name == aircraftName);

                    context.Entry(aircraft).State = EntityState.Deleted;
                    context.SaveChanges();
                }

                this.LoadAircraft();
            }
        }

        private void QuickAddButton_Click(object sender, EventArgs e)
        {
            if (this.loadsPanel.Controls.Count == 0)
            {
                MessageBox.Show("Please create a load first.", "Create a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(this.selectedLoad))
            {
                MessageBox.Show("Please click a load first to select it.", "Select a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            MessageBox.Show("The selected load is " + this.selectedLoad);
        }

        private void DeletePersonFromLoadButton_Click(object sender, EventArgs e)
        {
            // Delete the selected entries

            // If deleting a tandem, must select all people to delete
            string load = this.selectedLoad;
            string manNum = string.Empty;

            foreach (ListView c in this.loadsPanel.Controls)
            {
                if (c.Items[0].ToString().Contains(this.selectedLoad))
                {
                    foreach (ListViewItem listitem in c.Items)
                    {
                        foreach (string item in this.selectedPeople)
                        {
                            if (listitem.ToString().Contains(item))
                            {
                                if (c.Items.IndexOf(listitem) == 0)
                                {
                                    continue; // You can't delete the first item with the load info
                                }

                                try
                                {
                                    manNum = item.Split('-')[0].Trim();
                                }
                                catch
                                {
                                } // Tandems don't have a manifest number so naturally this fails

                                c.Items.Remove(listitem);
                                AddLog(load, manNum);

                                ListViewItem loadInfo = c.Items[0];
                                string[] pieces = loadInfo.Text.Split('-');
                                string slots = pieces[2].Replace("slots", string.Empty).Trim();
                                int num = 0;
                                int.TryParse(slots, out num);
                                num = num + 1;

                                if (num > 0)
                                {
                                    c.BackColor = Color.White; // If load is full, color it red
                                }

                                c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";
                            }
                        }
                    }
                }
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PrintCertificate();
        }

        private void PrintCertificate()
        {
            string load = this.selectedLoad;
            string manNum = string.Empty;

            foreach (ListView c in this.loadsPanel.Controls)
            {
                if (c.Items[0].ToString().Contains(this.selectedLoad))
                {
                    foreach (ListViewItem listitem in c.Items)
                    {
                        foreach (string item in this.selectedPeople)
                        {
                            if (listitem.ToString().Contains(item))
                            {
                                if (c.Items.IndexOf(listitem) == 0)
                                {
                                    continue; // You can't print the first item with the load info
                                }

                                try
                                {
                                    manNum = item.Split('-')[0].Trim();
                                }
                                catch
                                {
                                } // Tandems don't have a manifest number so naturally this fails

                                // Print!!
                                string studentname = "Joe Tandem";
                                string aircraft = "Super King Air";
                                string instructor = "TI Jim";

                                using (PrintCertificateForm printCertificateForm = new PrintCertificateForm(studentname, aircraft, instructor))
                                {
                                    printCertificateForm.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CompleteLoadButton_Click(object sender, EventArgs e)
        {
            foreach (ListView c in this.loadsPanel.Controls)
            {
                if (c.Items[0].ToString().Contains(this.selectedLoad))
                {
                    foreach (ListViewItem listitem in c.Items)
                    {
                        // For each person on the load, charge them
                        MessageBox.Show(listitem.Text);
                    }

                    this.loadsPanel.Controls.Remove(c); // Delete the load from the view
                }
            }
        }
    }
}
