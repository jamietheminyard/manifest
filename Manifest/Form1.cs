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
        public ImageList Imagelist = new ImageList();
        int searchIndex;
        int tmpLoadNum = 1;
        string selectedLoad = "";
        int imageIndex = 0;
        List<string> selectedPeople = new List<string>();
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("\n---------------------------------------------Application startup " + DateTime.Now.ToString() + "---------------------------------------------");

            searchIndex = 0;

            // Key event handler for left/right keys
            // Requested by Mike for scrolling left/right through loads
            // Also handles insert key
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);

            textBoxSearchPeople.KeyDown += new KeyEventHandler(SearchPeople_KeyDown);

            // show/hide UI components
            HideEditPersonUI();
            buttonSavePerson.Hide();
            buttonAddPerson.Hide();
            buttonCancel.Hide();
            labelEditDetails.Hide();

            HideEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Hide();

            WindowState = FormWindowState.Maximized;
            tabControl.SelectedTab = tabPageLoads;

            numericUpDownMaxJumpers.Value = 1;
            LoadPeople();
            LoadAircraft();

            // Default to the King Air
            try
            {
                comboBoxLoadAircraft.SelectedIndex = comboBoxLoadAircraft.Items.IndexOf("King Air");
            }
            catch (Exception)
            {
            }

            // Retrieve all image files for logos used to group tandems/AFF
            string[] imageFiles = Directory.GetFiles(@"C:\test");
            foreach (var file in imageFiles)
            {
                // Add images to Imagelist
                Imagelist.Images.Add(Image.FromFile(file));
            }
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Point current = panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X + 50, current.Y);
                panelLoads.AutoScrollPosition = scrolled;
            }

            if (e.KeyCode == Keys.Left)
            {
                Point current = panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X - 50, current.Y);
                panelLoads.AutoScrollPosition = scrolled;
            }

            if (e.KeyCode == Keys.Insert)
            {
                HandleAddPersonToLoad();
            }

            if (e.KeyCode == Keys.F12)
            {
                HandleAddPersonToLoad();
            }
        }

        private void HandleAddPersonToLoad()
        {
            if (panelLoads.Controls.Count == 0)
            {
                MessageBox.Show("Please create a load first.", "Create a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (selectedLoad == "")
            {
                MessageBox.Show("Please click a load first to select it.", "Select a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            FormAddPersonToLoad addTandemWindow = new FormAddPersonToLoad(selectedLoad);
            addTandemWindow.ShowDialog();
            DialogResult result = addTandemWindow.Result;
            if (result == DialogResult.None)
            {
                return;
            }

            // Add the person to the selected load
            ListViewItem loadInfo;

            // Check to see if this person's manifest number is already manifested
            foreach (ListView c in panelLoads.Controls)
            {
                foreach (ListViewItem i in c.Items)
                {
                    if (i.Text.Contains(addTandemWindow.Instructor1ManNum) && addTandemWindow.Instructor1ManNum != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.Instructor1 + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (i.Text.Contains(addTandemWindow.Instructor2orVideoManNum) && addTandemWindow.Instructor2orVideoManNum != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.Instructor2orVideo + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (i.Text.Contains(addTandemWindow.ManNum) && addTandemWindow.ManNum != "")
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
            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad))
                {
                    // If tandem, make a separate entry for the TI and video if applicable
                    if (addTandemWindow.JumpType.Contains("TAN"))
                    {
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];
                        string[] pieces = loadInfo.Text.Split('-');
                        string slots = pieces[2].Replace("slots", "").Trim();
                        int num = 0;
                        int.TryParse(slots, out num);
                        if (addTandemWindow.Instructor2orVideo.Trim() != "") // Has video, so subtract 3
                        {
                            num = num - 3;
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

                        if (num == 0) // If load is full, color it red
                        {
                            c.BackColor = Color.Red;
                        }

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        // Add the people
                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.Instructor1 });
                        AddLog(selectedLoad, addTandemWindow.Instructor1ManNum, " replace this with instructor pay rate");
                        if (addTandemWindow.Instructor2orVideo.Trim() != "")
                        {
                            c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.Instructor2orVideo });
                            AddLog(selectedLoad, addTandemWindow.Instructor2orVideoManNum, " replace this with video pay rate");
                        }

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.JumperName });
                        AddLog(selectedLoad, "TANSTUDENT", " replace this with tandems cost");
                        imageIndex = imageIndex + 1;
                        if (imageIndex == 12)
                        {
                            imageIndex = 0;
                        }

                        return;
                    }

                    // If AFF, make a separate entry for the AFFIs
                    else if (addTandemWindow.JumpType.Contains("AFF"))
                    {
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];
                        string[] pieces = loadInfo.Text.Split('-');
                        string slots = pieces[2].Replace("slots", "").Trim();
                        int num = 0;
                        int.TryParse(slots, out num);
                        if (addTandemWindow.Instructor2orVideo.Trim() != "") // Has 2 instructors, so subtract 3
                        {
                            num = num - 3;
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

                        if (num == 0) // If load is full, color it red
                        {
                            c.BackColor = Color.Red;
                        }

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.Instructor1 });
                        AddLog(selectedLoad, addTandemWindow.Instructor1ManNum, " replace this with instructor pay rate");
                        if (addTandemWindow.Instructor2orVideo.Trim() != "")
                        {
                            c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.Instructor2orVideo });
                            AddLog(selectedLoad, addTandemWindow.Instructor2orVideoManNum, " replace this with instructor pay rate");
                        }

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.ManNum + " - " + addTandemWindow.JumperName });
                        AddLog(selectedLoad, addTandemWindow.ManNum, " replace this with AFF student rate");
                        imageIndex = imageIndex + 1;
                        if (imageIndex == 12)
                        {
                            imageIndex = 0;
                        }

                        return;
                    }
                    else
                    {
                        // Regular fun jumper
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];

                        string[] pieces = loadInfo.Text.Split('-');
                        string slots = pieces[2].Replace("slots", "").Trim();

                        int num = 0;
                        int.TryParse(slots, out num);

                        num = num - 1;

                        if (num < 0)
                        {
                            MessageBox.Show("Not enough room on this load.");
                            return;
                        }

                        if (num == 0) // If load is full, color it red
                        {
                            c.BackColor = Color.Red;
                        }

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        c.Items.Add(new ListViewItem { Text = addTandemWindow.ManNum + " - " + addTandemWindow.JumperName });
                        AddLog(selectedLoad, addTandemWindow.ManNum, " replace this with fun jump pay rate or 0 if beginning of year free jumps");
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

        public void SearchPeople_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForPeople();
            }
        }

        public void SearchForPeople()
        {
            string searchText = textBoxSearchPeople.Text.ToLower();
            bool found = false;
            int selectedIndex = listBoxPeople.SelectedIndex;
            int numItems = listBoxPeople.Items.Count;

            // If the first item in the list is selected and matches, just increment search index and return
            if (selectedIndex == 0 && searchIndex == 0 && listBoxPeople.Items[0].ToString().ToLower().Contains(searchText))
            {
                searchIndex++;
                return;
            }

            if (selectedIndex + 1 == numItems)
            {
                searchIndex = 0;
                selectedIndex = 0;
                listBoxPeople.SelectedIndex = 0;
            }
            else
            {
                searchIndex = selectedIndex + 1;
            }

            // Starting at the search index, look for the next instance of the search text
            for (int i = searchIndex; i < listBoxPeople.Items.Count; i++)
            {
                if (listBoxPeople.Items[i].ToString().ToLower().Contains(searchText))
                {
                    found = true;
                    listBoxPeople.SelectedIndex = i;
                    searchIndex = i;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Reached the end of the list.");
                searchIndex = 0;
                listBoxPeople.SelectedIndex = 0;
            }
        }

        public void LoadPeople()
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

            listBoxPeople.DataSource = people;
        }

        private void ShowEditPersonUI()
        {
            labelManifestNumber.Show();
            textBoxManifestNumber.Show();
            labelFirstName.Show();
            textBoxFirstName.Show();
            labelLastName.Show();
            textBoxLastName.Show();
            checkBoxTI.Show();
            checkBoxAFF.Show();
            checkBoxCoach.Show();
            checkBoxVideo.Show();
        }

        private void HideEditPersonUI()
        {
            labelManifestNumber.Hide();
            textBoxManifestNumber.Text = "";
            textBoxManifestNumber.Hide();
            labelFirstName.Hide();
            textBoxFirstName.Text = "";
            textBoxFirstName.Hide();
            labelLastName.Hide();
            textBoxLastName.Text = "";
            textBoxLastName.Hide();
            checkBoxTI.Checked = false;
            checkBoxTI.Hide();
            checkBoxAFF.Checked = false;
            checkBoxAFF.Hide();
            checkBoxCoach.Checked = false;
            checkBoxCoach.Hide();
            checkBoxVideo.Checked = false;
            checkBoxVideo.Hide();
        }

        private void ButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            ShowEditPersonUI();
            buttonAddPerson.Show();
            buttonCancel.Show();
            buttonSavePerson.Hide();

            // Clear the edit UI components
            textBoxManifestNumber.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

        private void ButtonAddTandem_Click(object sender, EventArgs e)
        {
            HandleAddPersonToLoad();
        }

        private void ButtonNewLoad_Click(object sender, EventArgs e)
        {
            ListView loadList = new ListView();

            loadList.LargeImageList = Imagelist;
            loadList.SmallImageList = Imagelist;

            loadList.View = View.Details;

            loadList.HeaderStyle = ColumnHeaderStyle.None;
            loadList.FullRowSelect = true;
            loadList.Columns.Add("", -2);
            string aircraft = comboBoxLoadAircraft.Text;

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

            loadList.Items.Add("Load " + tmpLoadNum + " - " + aircraft + " - " + num + " slots");

            loadList.Scrollable = false;

            loadList.View = View.Details; // Enables Details view so you can see columns
            loadList.AllowDrop = true;
            loadList.DragDrop += ListView_DragDrop;
            loadList.DragEnter += ListView_DragEnter;
            loadList.ItemDrag += ListView_ItemDrag;
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
            loadList.Columns[0].Width = Width - 50;

            loadList.Click += new EventHandler(Load_click);

            panelLoads.Controls.Add(loadList);
            AddLog(tmpLoadNum.ToString());
            tmpLoadNum++;

            if (panelLoads.Controls.Count == 1)
            {
                selectedLoad = "Load 1";
                labelSelectedLoad.Text = "Load 1";
            }
        }

        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            // Translate the mouse coordinates (screen coords) into control coordinates
//            Point p = listView1.PointToClient(new Point(e.X, e.Y));
            // Find the item that the object was dragged onto
//            var ItemToReplace = listView1.GetItemAt(p.X, p.Y);
            // extract the listview item from the dragged items IData member
            var draggedItem = ((ListViewItem)e.Data.GetData(typeof(ListViewItem)));
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

        void Load_click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string load = lv.Items[0].Text.Split('-')[0];
            selectedLoad = load;
            labelSelectedLoad.Text = selectedLoad;
            selectedPeople.Clear();
            for (int i = 0; i < lv.SelectedItems.Count; i++)
            {
 // MessageBox.Show("person is " + lv.SelectedItems[i].Text);
                selectedPeople.Add(lv.SelectedItems[i].Text);
            }
        }

        private void ButtonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                string item = listBoxPeople.GetItemText(listBoxPeople.SelectedItem);
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
                            LoadPeople();

                            // Hide the edit UI components
                            HideEditPersonUI();
                            buttonSavePerson.Hide();
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
            ShowEditPersonUI();
            buttonSavePerson.Show();
            buttonCancel.Show();
            buttonAddPerson.Hide();
            try
            {
                string item = listBoxPeople.GetItemText(listBoxPeople.SelectedItem);
                string[] splitString = item.Split('-');
                string manNum = splitString[0].Trim();
                string name = splitString[1].Trim();
                string firstName = name.Split(' ')[0];
                string lastName = name.Split(' ')[1];
                textBoxManifestNumber.Text = manNum;
                textBoxFirstName.Text = firstName;
                textBoxLastName.Text = lastName;

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

                checkBoxTI.Checked = t;
                checkBoxAFF.Checked = a;
                checkBoxCoach.Checked = c;
                checkBoxVideo.Checked = v;

                labelEditDetails.Text = "Editing details for " + manNum.ToString() + " - " + firstName + " " + lastName;
                labelEditDetails.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Unable to edit person.\n\nError: " + x.ToString());
            }
        }

        private void ButtonSavePerson_Click(object sender, EventArgs e)
        {
            string manNum = textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", "");
            string fName = textBoxFirstName.Text;
            fName = fName.Replace("'", "");
            string lName = textBoxLastName.Text;
            lName = lName.Replace("'", "");
            bool ti = checkBoxTI.Checked;
            bool affi = checkBoxAFF.Checked;
            bool coach = checkBoxCoach.Checked;
            bool video = checkBoxVideo.Checked;

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
                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = fName;
                cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = lName;

                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    LoadPeople();

                    // Hide the edit UI components
                    HideEditPersonUI();
                    buttonSavePerson.Hide();
                    buttonCancel.Hide();
                    labelEditDetails.Hide();
                }
            }
        }

        private void ButtonAddPerson_Click(object sender, EventArgs e)
        {
            string manNum = textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", "");
            string fName = textBoxFirstName.Text;
            fName = fName.Replace("'", "");
            string lName = textBoxLastName.Text;
            lName = lName.Replace("'", "");
            bool ti = checkBoxTI.Checked;
            bool affi = checkBoxAFF.Checked;
            bool coach = checkBoxCoach.Checked;
            bool video = checkBoxVideo.Checked;

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
                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = fName;
                cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = lName;

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    LoadPeople();

                    // Hide the edit UI components
                    HideEditPersonUI();
                    buttonCancel.Hide();
                    buttonAddPerson.Hide();
                }
            }
        }

        private void ButtonSearchPeople_Click(object sender, EventArgs e)
        {
            SearchForPeople();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            HideEditPersonUI();
            buttonSavePerson.Hide();
            buttonAddPerson.Hide();
            buttonCancel.Hide();
            labelEditDetails.Hide();
        }

        private void ShowEditAircraftUI()
        {
            labelEditDetailsAircraft.Show();
            labelAircraftName.Show();
            textBoxAircraftName.Show();
            labelMaxJumpers.Show();
            numericUpDownMaxJumpers.Show();
        }

        private void HideEditAircraftUI()
        {
            labelEditDetailsAircraft.Hide();
            labelAircraftName.Hide();
            textBoxAircraftName.Text = "";
            textBoxAircraftName.Hide();
            labelMaxJumpers.Hide();
            numericUpDownMaxJumpers.Value = 0;
            numericUpDownMaxJumpers.Hide();
        }

        private void ButtonCancelAircraft_Click(object sender, EventArgs e)
        {
            HideEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Hide();
        }

        private void ButtonAddAircraftSubmit_Click(object sender, EventArgs e)
        {
            string name = textBoxAircraftName.Text;
            int cap = (int)numericUpDownMaxJumpers.Value;

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

                cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = name.Replace("-", "");
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = cap;

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    LoadAircraft();

                    // Hide the edit UI components
                    HideEditAircraftUI();
                    buttonAddAircraftSubmit.Hide();
                    buttonSaveAircraft.Hide();
                    buttonCancelAircraft.Hide();
                }
            }
        }

        public void LoadAircraft()
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

            listBoxAircraft.DataSource = aircraft;
            comboBoxLoadAircraft.DataSource = aircraftNames;
        }

        private void ButtonSaveAircraft_Click(object sender, EventArgs e)
        {
            string name = textBoxAircraftName.Text;
            int cap = (int)numericUpDownMaxJumpers.Value;

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

                cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = name.Replace("-", "");

                cn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    LoadAircraft();

                    // Hide the edit UI components
                    HideEditAircraftUI();
                    buttonAddAircraftSubmit.Hide();
                    buttonSaveAircraft.Hide();
                    buttonCancelAircraft.Hide();
                }
            }
        }

        private void ButtonAddAircraft_Click(object sender, EventArgs e)
        {
            ShowEditAircraftUI();
            buttonAddAircraftSubmit.Show();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Show();
            labelEditDetailsAircraft.Hide();

            // Make the aircraft name read-write
            textBoxAircraftName.Enabled = true;
        }

        private void ButtonEditAircraft_Click(object sender, EventArgs e)
        {
            // Make the aircraft name read-only
            textBoxAircraftName.Enabled = false;
            string item = listBoxAircraft.GetItemText(listBoxAircraft.SelectedItem);
            string[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
            string name = splitString[0].Trim();
            string cap = splitString[1].Trim();
            int capacity = 0;
            textBoxAircraftName.Text = name;
            int.TryParse(cap, out capacity);
            numericUpDownMaxJumpers.Value = capacity;

            labelEditDetailsAircraft.Text = "Editing details for " + name + " with max jumpers " + capacity + ".";

            ShowEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Show();
            buttonCancelAircraft.Show();
        }

        private void ButtonDeleteAircraft_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this aircrafit?\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                string item = listBoxAircraft.GetItemText(listBoxAircraft.SelectedItem);
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
                        LoadAircraft();
                    }
                }
            }
        }

        private void ButtonAddFunJumper_Click(object sender, EventArgs e)
        {
            if (panelLoads.Controls.Count == 0)
            {
                MessageBox.Show("Please create a load first.", "Create a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (selectedLoad == "")
            {
                MessageBox.Show("Please click a load first to select it.", "Select a load", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            MessageBox.Show("The selected load is " + selectedLoad);
        }

        private void ButtonDeletePersonFromLoad_Click(object sender, EventArgs e)
        {
            // Delete the selected entries

            // If deleting a tandem, must select all people to delete
            string load = selectedLoad;
            string manNum = "";

            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad)) // For the selected load
                {
                    foreach (ListViewItem listitem in c.Items) // For each item in the load
                    {
                        foreach (string item in selectedPeople) // For each of the selected people
                        {
                            if (listitem.ToString().Contains(item)) // If they match an entry in the list, remove them
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
                                string slots = pieces[2].Replace("slots", "").Trim();
                                int num = 0;
                                int.TryParse(slots, out num);
                                num = num + 1;

                                if (num > 0) // If load is full, color it red
                                {
                                    c.BackColor = Color.White;
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
            PrintCertificate();
        }

        private void PrintCertificate()
        {
            string load = selectedLoad;
            string manNum = "";

            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad)) // For the selected load
                {
                    foreach (ListViewItem listitem in c.Items) // For each item in the load
                    {
                        foreach (string item in selectedPeople) // For each of the selected people
                        {
                            if (listitem.ToString().Contains(item)) // If selected
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
                                FormPrintCertificate printCert = new FormPrintCertificate(studentname, aircraft, instructor);
                                printCert.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void ButtonCompleteLoad_Click(object sender, EventArgs e)
        {
            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad)) // For the selected load
                {
                    foreach (ListViewItem listitem in c.Items) // For each item in the load
                    {
                        // For each person on the load, charge them
                        MessageBox.Show(listitem.Text);
                    }

                    panelLoads.Controls.Remove(c); // Delete the load from the view
                }
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
    }
}
