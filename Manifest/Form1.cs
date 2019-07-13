namespace Manifest
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Manifest.Properties;

    public partial class Form1 : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int searchIndex;
        private int tmpLoadNum = 1;
        private string selectedLoad = string.Empty;
        private int imageIndex = 0;
        private List<string> selectedPeople = new List<string>();

        public Form1()
        {
            this.InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("\n---------------------------------------------Application startup " + DateTime.Now.ToString() + "---------------------------------------------");

            this.searchIndex = 0;

            // Key event handler for left/right keys
            // Requested by Mike for scrolling left/right through loads
            // Also handles insert key
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);

            this.textBoxSearchPeople.KeyDown += new KeyEventHandler(this.SearchPeople_KeyDown);

            // show/hide UI components
            this.HideEditPersonUI();
            this.buttonSavePerson.Hide();
            this.buttonAddPerson.Hide();
            this.buttonCancel.Hide();
            this.labelEditDetails.Hide();

            this.HideEditAircraftUI();
            this.buttonAddAircraftSubmit.Hide();
            this.buttonSaveAircraft.Hide();
            this.buttonCancelAircraft.Hide();

            this.WindowState = FormWindowState.Maximized;
            this.tabControl.SelectedTab = this.tabPageLoads;

            this.numericUpDownMaxJumpers.Value = 1;
            this.LoadPeople();
            this.LoadAircraft();

            // Default to the King Air
            try
            {
                this.comboBoxLoadAircraft.SelectedIndex = this.comboBoxLoadAircraft.Items.IndexOf("King Air");
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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Point current = this.panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X + 50, current.Y);
                this.panelLoads.AutoScrollPosition = scrolled;
            }

            if (e.KeyCode == Keys.Left)
            {
                Point current = this.panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X - 50, current.Y);
                this.panelLoads.AutoScrollPosition = scrolled;
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
            if (this.panelLoads.Controls.Count == 0)
            {
                MessageBox.Show("Please create a load first.", "Create a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(this.selectedLoad))
            {
                MessageBox.Show("Please click a load first to select it.", "Select a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            using (FormAddPersonToLoad addTandemWindow = new FormAddPersonToLoad(this.selectedLoad))
            {
                addTandemWindow.ShowDialog();
                DialogResult result = addTandemWindow.Result;
                if (result == DialogResult.None)
                {
                    return;
                }

                // Add the person to the selected load
                ListViewItem loadInfo;

                // Check to see if this person's manifest number is already manifested
                foreach (ListView c in this.panelLoads.Controls)
                {
                    foreach (ListViewItem i in c.Items)
                    {
                        if (i.Text.Contains(addTandemWindow.Instructor1ManNum) && string.IsNullOrEmpty(addTandemWindow.Instructor1ManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.Instructor1 + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (i.Text.Contains(addTandemWindow.Instructor2orVideoManNum) && string.IsNullOrEmpty(addTandemWindow.Instructor2orVideoManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.Instructor2orVideo + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (i.Text.Contains(addTandemWindow.ManNum) && string.IsNullOrEmpty(addTandemWindow.ManNum) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.JumperName + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }

                // Proceed with adding them to the load
                foreach (ListView c in this.panelLoads.Controls)
                {
                    if (c.Items[0].ToString().Contains(this.selectedLoad))
                    {
                        // If tandem, make a separate entry for the TI and video if applicable
                        if (addTandemWindow.JumpType.Contains("TAN"))
                        {
                            // Update the first item in the list to have correct number of slots left
                            loadInfo = c.Items[0];
                            string[] pieces = loadInfo.Text.Split('-');
                            string slots = pieces[2].Replace("slots", string.Empty).Trim();
                            int num = 0;
                            int.TryParse(slots, out num);

                            if (string.IsNullOrEmpty(addTandemWindow.Instructor2orVideo.Trim()) == false)
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
                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.Instructor1 });
                            AddLog(this.selectedLoad, addTandemWindow.Instructor1ManNum, " replace this with instructor pay rate");
                            if (string.IsNullOrEmpty(addTandemWindow.Instructor2orVideo.Trim()) == false)
                            {
                                c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.Instructor2orVideo });
                                AddLog(this.selectedLoad, addTandemWindow.Instructor2orVideoManNum, " replace this with video pay rate");
                            }

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.JumperName });
                            AddLog(this.selectedLoad, "TANSTUDENT", " replace this with tandems cost");
                            this.imageIndex = this.imageIndex + 1;
                            if (this.imageIndex == 12)
                            {
                                this.imageIndex = 0;
                            }

                            return;
                        }

                        // If AFF, make a separate entry for the AFFIs
                        else if (addTandemWindow.JumpType.Contains("AFF"))
                        {
                            // Update the first item in the list to have correct number of slots left
                            loadInfo = c.Items[0];
                            string[] pieces = loadInfo.Text.Split('-');
                            string slots = pieces[2].Replace("slots", string.Empty).Trim();
                            int num = 0;
                            int.TryParse(slots, out num);
                            if (string.IsNullOrEmpty(addTandemWindow.Instructor2orVideo.Trim()) == false)
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

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.Instructor1 });
                            AddLog(this.selectedLoad, addTandemWindow.Instructor1ManNum, " replace this with instructor pay rate");
                            if (string.IsNullOrEmpty(addTandemWindow.Instructor2orVideo.Trim()) == false)
                            {
                                c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.Instructor2orVideo });
                                AddLog(this.selectedLoad, addTandemWindow.Instructor2orVideoManNum, " replace this with instructor pay rate");
                            }

                            c.Items.Add(new ListViewItem { ImageIndex = this.imageIndex, Text = addTandemWindow.ManNum + " - " + addTandemWindow.JumperName });
                            AddLog(this.selectedLoad, addTandemWindow.ManNum, " replace this with AFF student rate");
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

                            c.Items.Add(new ListViewItem { Text = addTandemWindow.ManNum + " - " + addTandemWindow.JumperName });
                            AddLog(this.selectedLoad, addTandemWindow.ManNum, " replace this with fun jump pay rate or 0 if beginning of year free jumps");
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

        private void SearchPeople_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchForPeople();
            }
        }

        private void SearchForPeople()
        {
            string searchText = this.textBoxSearchPeople.Text.ToLower();
            bool found = false;
            int selectedIndex = this.listBoxPeople.SelectedIndex;
            int numItems = this.listBoxPeople.Items.Count;

            // If the first item in the list is selected and matches, just increment search index and return
            if (selectedIndex == 0 && this.searchIndex == 0 && this.listBoxPeople.Items[0].ToString().ToLower().Contains(searchText))
            {
                this.searchIndex++;
                return;
            }

            if (selectedIndex + 1 == numItems)
            {
                this.searchIndex = 0;
                selectedIndex = 0;
                this.listBoxPeople.SelectedIndex = 0;
            }
            else
            {
                this.searchIndex = selectedIndex + 1;
            }

            // Starting at the search index, look for the next instance of the search text
            for (int i = this.searchIndex; i < this.listBoxPeople.Items.Count; i++)
            {
                if (this.listBoxPeople.Items[i].ToString().ToLower().Contains(searchText))
                {
                    found = true;
                    this.listBoxPeople.SelectedIndex = i;
                    this.searchIndex = i;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Reached the end of the list.");
                this.searchIndex = 0;
                this.listBoxPeople.SelectedIndex = 0;
            }
        }

        private void LoadPeople()
        {
            ObservableCollection<string> people = new ObservableCollection<string>();
            List<PersonType> peopleFromDB = new List<PersonType>();

            using (var conn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            {
                string sqlString = @"select manifestNumber, firstName, lastName, paid from people";
                using (var command = new SqlCommand(sqlString, conn))
                {
                    try
                    {
                        conn.Open();
                        var result = command.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine(result.ToString());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Unable to connect to database. Exiting now.\n\nError: " + e.ToString());
                    }
                    finally
                    {
                        conn.Close();
                        Application.Exit();
                    }
                }
            }

            string m, f, l;
            double p;

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select manifestNumber, firstName, lastName, paid from people";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        m = dr.GetString(0);
                        f = dr.GetString(1);
                        l = dr.GetString(2);
                        if (dr["paid"] != DBNull.Value)
                        {
                            double.TryParse(dr.GetString(3), out p);
                        }
                        else
                        {
                            p = 0;
                        }

                        PersonType per = new PersonType(m, f, l, p);
                        peopleFromDB.Add(per);
                    }
                }
            }

            peopleFromDB.Sort();

            foreach (PersonType pt in peopleFromDB)
            {
                people.Add(pt.GetManifestNumber() + " - " + pt.GetFirstName() + " " + pt.GetLastName());
            }

            this.listBoxPeople.DataSource = people;
        }

        private void ShowEditPersonUI()
        {
            this.labelManifestNumber.Show();
            this.textBoxManifestNumber.Show();
            this.labelFirstName.Show();
            this.textBoxFirstName.Show();
            this.labelLastName.Show();
            this.textBoxLastName.Show();
            this.checkBoxTI.Show();
            this.checkBoxAFF.Show();
            this.checkBoxCoach.Show();
            this.checkBoxVideo.Show();
        }

        private void HideEditPersonUI()
        {
            this.labelManifestNumber.Hide();
            this.textBoxManifestNumber.Text = string.Empty;
            this.textBoxManifestNumber.Hide();
            this.labelFirstName.Hide();
            this.textBoxFirstName.Text = string.Empty;
            this.textBoxFirstName.Hide();
            this.labelLastName.Hide();
            this.textBoxLastName.Text = string.Empty;
            this.textBoxLastName.Hide();
            this.checkBoxTI.Checked = false;
            this.checkBoxTI.Hide();
            this.checkBoxAFF.Checked = false;
            this.checkBoxAFF.Hide();
            this.checkBoxCoach.Checked = false;
            this.checkBoxCoach.Hide();
            this.checkBoxVideo.Checked = false;
            this.checkBoxVideo.Hide();
        }

        private void ButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            this.ShowEditPersonUI();
            this.buttonAddPerson.Show();
            this.buttonCancel.Show();
            this.buttonSavePerson.Hide();

            // Clear the edit UI components
            this.textBoxManifestNumber.Text = string.Empty;
            this.textBoxFirstName.Text = string.Empty;
            this.textBoxLastName.Text = string.Empty;
        }

        private void ButtonAddTandem_Click(object sender, EventArgs e)
        {
            this.HandleAddPersonToLoad();
        }

        private void ButtonNewLoad_Click(object sender, EventArgs e)
        {
            ListView loadList = new ListView();

            loadList.LargeImageList = this.imageList;
            loadList.SmallImageList = this.imageList;

            loadList.View = View.Details;

            loadList.HeaderStyle = ColumnHeaderStyle.None;
            loadList.FullRowSelect = true;
            loadList.Columns.Add(string.Empty, -2);
            string aircraft = this.comboBoxLoadAircraft.Text;

            // Get the number of max jumpers for this aircraft
            int num = 0;
            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select capacity from Aircraft where aircraftName = '" + aircraft + "'";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        num = dr.GetInt32(0);
                    }
                }
            }

            loadList.Items.Add("Load " + this.tmpLoadNum + " - " + aircraft + " - " + num + " slots");

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

            loadList.Click += new EventHandler(this.Load_click);

            this.panelLoads.Controls.Add(loadList);
            AddLog(this.tmpLoadNum.ToString());
            this.tmpLoadNum++;

            if (this.panelLoads.Controls.Count == 1)
            {
                this.selectedLoad = "Load 1";
                this.labelSelectedLoad.Text = "Load 1";
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

        private void Load_click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string load = lv.Items[0].Text.Split('-')[0];
            this.selectedLoad = load;
            this.labelSelectedLoad.Text = this.selectedLoad;
            this.selectedPeople.Clear();
            for (int i = 0; i < lv.SelectedItems.Count; i++)
            {
 // MessageBox.Show("person is " + lv.SelectedItems[i].Text);
                this.selectedPeople.Add(lv.SelectedItems[i].Text);
            }
        }

        private void ButtonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                string item = this.listBoxPeople.GetItemText(this.listBoxPeople.SelectedItem);
                string[] splitString = item.Split('-');
                string manNum = splitString[0];
                string name = splitString[1];
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this person from the database?\n\nManifest Number: " + manNum + "\nName: " + name + "\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "delete from People where manifestNumber = '" + manNum + "'";
                        cn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            // If delete was successful, reload the people in the UI list
                            this.LoadPeople();

                            // Hide the edit UI components
                            this.HideEditPersonUI();
                            this.buttonSavePerson.Hide();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete person.");
            }
        }

        private void ButtonEditPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            this.ShowEditPersonUI();
            this.buttonSavePerson.Show();
            this.buttonCancel.Show();
            this.buttonAddPerson.Hide();
            try
            {
                string item = this.listBoxPeople.GetItemText(this.listBoxPeople.SelectedItem);
                string[] splitString = item.Split('-');
                string manNum = splitString[0].Trim();
                string name = splitString[1].Trim();
                string firstName = name.Split(' ')[0];
                string lastName = name.Split(' ')[1];
                this.textBoxManifestNumber.Text = manNum;
                this.textBoxFirstName.Text = firstName;
                this.textBoxLastName.Text = lastName;

                // Get their checkbox statuses from the database
                bool t = false;
                bool a = false;
                bool c = false;
                bool v = false;

                using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select TI, AFFI, coach, videographer from people where manifestNumber = '" + manNum + "'";
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            t = dr.IsDBNull(0) ? false : dr.GetBoolean(0);
                            a = dr.IsDBNull(1) ? false : dr.GetBoolean(1);
                            c = dr.IsDBNull(2) ? false : dr.GetBoolean(2);
                            v = dr.IsDBNull(3) ? false : dr.GetBoolean(3);
                        }
                    }
                }

                this.checkBoxTI.Checked = t;
                this.checkBoxAFF.Checked = a;
                this.checkBoxCoach.Checked = c;
                this.checkBoxVideo.Checked = v;

                this.labelEditDetails.Text = "Editing details for " + manNum.ToString() + " - " + firstName + " " + lastName;
                this.labelEditDetails.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Unable to edit person.\n\nError: " + x.ToString());
            }
        }

        private void ButtonSavePerson_Click(object sender, EventArgs e)
        {
            string manNum = this.textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", string.Empty);
            string firstName = this.textBoxFirstName.Text;
            firstName = firstName.Replace("'", string.Empty);
            string lastName = this.textBoxLastName.Text;
            lastName = lastName.Replace("'", string.Empty);
            bool ti = this.checkBoxTI.Checked;
            bool affi = this.checkBoxAFF.Checked;
            bool coach = this.checkBoxCoach.Checked;
            bool video = this.checkBoxVideo.Checked;

            string t = "0";
            if (ti)
            {
                t = "1";
            }

            string a = "0";
            if (affi)
            {
                a = "1";
            }

            string c = "0";
            if (coach)
            {
                c = "1";
            }

            string v = "0";
            if (video)
            {
                v = "1";
            }

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "update People set firstName = @param2, lastName = @param3, TI = " + t + ", AFFI = " + a + ", coach = " + c + ", videographer = " + v + " where manifestNumber = @param1";

                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 8).Value = manNum;
                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = firstName;
                cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = lastName;

                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    this.LoadPeople();

                    // Hide the edit UI components
                    this.HideEditPersonUI();
                    this.buttonSavePerson.Hide();
                    this.buttonCancel.Hide();
                    this.labelEditDetails.Hide();
                }
            }
        }

        private void ButtonAddPerson_Click(object sender, EventArgs e)
        {
            string manNum = this.textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", string.Empty);
            string firstName = this.textBoxFirstName.Text;
            firstName = firstName.Replace("'", string.Empty);
            string lastName = this.textBoxLastName.Text;
            lastName = lastName.Replace("'", string.Empty);
            bool ti = this.checkBoxTI.Checked;
            bool affi = this.checkBoxAFF.Checked;
            bool coach = this.checkBoxCoach.Checked;
            bool video = this.checkBoxVideo.Checked;

            string t = "0";
            if (ti)
            {
                t = "1";
            }

            string a = "0";
            if (affi)
            {
                a = "1";
            }

            string c = "0";
            if (coach)
            {
                c = "1";
            }

            string v = "0";
            if (video)
            {
                v = "1";
            }

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "insert into People(manifestNumber, firstName, lastName, paid, TI, AFFI, coach, videographer)" +
                    "values(@param1, @param2, @param3,'" + 0 + "'," + t + "," + a + "," + c + "," + v + ")";

                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 8).Value = manNum;
                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = firstName;
                cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = lastName;

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    this.LoadPeople();

                    // Hide the edit UI components
                    this.HideEditPersonUI();
                    this.buttonCancel.Hide();
                    this.buttonAddPerson.Hide();
                }
            }
        }

        private void ButtonSearchPeople_Click(object sender, EventArgs e)
        {
            this.SearchForPeople();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.HideEditPersonUI();
            this.buttonSavePerson.Hide();
            this.buttonAddPerson.Hide();
            this.buttonCancel.Hide();
            this.labelEditDetails.Hide();
        }

        private void ShowEditAircraftUI()
        {
            this.labelEditDetailsAircraft.Show();
            this.labelAircraftName.Show();
            this.textBoxAircraftName.Show();
            this.labelMaxJumpers.Show();
            this.numericUpDownMaxJumpers.Show();
        }

        private void HideEditAircraftUI()
        {
            this.labelEditDetailsAircraft.Hide();
            this.labelAircraftName.Hide();
            this.textBoxAircraftName.Text = string.Empty;
            this.textBoxAircraftName.Hide();
            this.labelMaxJumpers.Hide();
            this.numericUpDownMaxJumpers.Value = 0;
            this.numericUpDownMaxJumpers.Hide();
        }

        private void ButtonCancelAircraft_Click(object sender, EventArgs e)
        {
            this.HideEditAircraftUI();
            this.buttonAddAircraftSubmit.Hide();
            this.buttonSaveAircraft.Hide();
            this.buttonCancelAircraft.Hide();
        }

        private void ButtonAddAircraftSubmit_Click(object sender, EventArgs e)
        {
            string name = this.textBoxAircraftName.Text;
            int cap = (int)this.numericUpDownMaxJumpers.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name for this aircraft.");
                return;
            }

            if (cap < 1)
            {
                MessageBox.Show("Max jumpers cannot be less than 1.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "insert into Aircraft(aircraftName, capacity)" +
                    "values(@param1, @param2)";

                cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = name.Replace("-", string.Empty);
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = cap;

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    this.LoadAircraft();

                    // Hide the edit UI components
                    this.HideEditAircraftUI();
                    this.buttonAddAircraftSubmit.Hide();
                    this.buttonSaveAircraft.Hide();
                    this.buttonCancelAircraft.Hide();
                }
            }
        }

        private void LoadAircraft()
        {
            ObservableCollection<string> aircraft = new ObservableCollection<string>();
            ObservableCollection<string> aircraftNames = new ObservableCollection<string>();
            List<AircraftType> aircraftFromDB = new List<AircraftType>();

            using (var conn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            {
                string sqlString = @"select aircraftName, capacity from Aircraft";
                using (var command = new SqlCommand(sqlString, conn))
                {
                    conn.Open();
                    var result = command.ExecuteScalar();
                    System.Diagnostics.Debug.WriteLine(result.ToString());
                    conn.Close();
                }
            }

            string an;
            int c;

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select aircraftName, capacity from Aircraft";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        an = dr.GetString(0);
                        c = dr.GetInt32(1);

                        AircraftType air = new AircraftType(an, c);
                        aircraftFromDB.Add(air);
                    }
                }
            }

            foreach (AircraftType plane in aircraftFromDB)
            {
                aircraft.Add(plane.GetName() + " - Max jumpers " + plane.GetCapacity());
                aircraftNames.Add(plane.GetName());
            }

            this.listBoxAircraft.DataSource = aircraft;
            this.comboBoxLoadAircraft.DataSource = aircraftNames;
        }

        private void ButtonSaveAircraft_Click(object sender, EventArgs e)
        {
            string name = this.textBoxAircraftName.Text;
            int cap = (int)this.numericUpDownMaxJumpers.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name for this aircraft.");
                return;
            }

            if (cap < 1)
            {
                MessageBox.Show("Max jumpers cannot be less than 1.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "update Aircraft set capacity = " + cap + " where aircraftName = @param1";

                cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = name.Replace("-", string.Empty);

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    this.LoadAircraft();

                    // Hide the edit UI components
                    this.HideEditAircraftUI();
                    this.buttonAddAircraftSubmit.Hide();
                    this.buttonSaveAircraft.Hide();
                    this.buttonCancelAircraft.Hide();
                }
            }
        }

        private void ButtonAddAircraft_Click(object sender, EventArgs e)
        {
            this.ShowEditAircraftUI();
            this.buttonAddAircraftSubmit.Show();
            this.buttonSaveAircraft.Hide();
            this.buttonCancelAircraft.Show();
            this.labelEditDetailsAircraft.Hide();

            // Make the aircraft name read-write
            this.textBoxAircraftName.Enabled = true;
        }

        private void ButtonEditAircraft_Click(object sender, EventArgs e)
        {
            // Make the aircraft name read-only
            this.textBoxAircraftName.Enabled = false;
            string item = this.listBoxAircraft.GetItemText(this.listBoxAircraft.SelectedItem);
            string[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
            string name = splitString[0].Trim();
            string cap = splitString[1].Trim();
            int capacity = 0;
            this.textBoxAircraftName.Text = name;
            int.TryParse(cap, out capacity);
            this.numericUpDownMaxJumpers.Value = capacity;

            this.labelEditDetailsAircraft.Text = "Editing details for " + name + " with max jumpers " + capacity + ".";

            this.ShowEditAircraftUI();
            this.buttonAddAircraftSubmit.Hide();
            this.buttonSaveAircraft.Show();
            this.buttonCancelAircraft.Show();
        }

        private void ButtonDeleteAircraft_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this aircrafit?\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                string item = this.listBoxAircraft.GetItemText(this.listBoxAircraft.SelectedItem);
                string[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
                string name = splitString[0].Trim();

                using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "delete from aircraft where aircraftName = '" + name + "'";
                    cn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        // If delete was successful, reload the aircraft in the UI list
                        this.LoadAircraft();
                    }
                }
            }
        }

        private void ButtonAddFunJumper_Click(object sender, EventArgs e)
        {
            if (this.panelLoads.Controls.Count == 0)
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

        private void ButtonDeletePersonFromLoad_Click(object sender, EventArgs e)
        {
            // Delete the selected entries

            // If deleting a tandem, must select all people to delete
            string load = this.selectedLoad;
            string manNum = string.Empty;

            foreach (ListView c in this.panelLoads.Controls)
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

            foreach (ListView c in this.panelLoads.Controls)
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

                                using (FormPrintCertificate printCert = new FormPrintCertificate(studentname, aircraft, instructor))
                                {
                                    printCert.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ButtonCompleteLoad_Click(object sender, EventArgs e)
        {
            foreach (ListView c in this.panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(this.selectedLoad))
                {
                    foreach (ListViewItem listitem in c.Items)
                    {
                        // For each person on the load, charge them
                        MessageBox.Show(listitem.Text);
                    }

                    this.panelLoads.Controls.Remove(c); // Delete the load from the view
                }
            }
        }
    }
}
