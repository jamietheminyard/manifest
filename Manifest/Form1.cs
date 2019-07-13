using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Collections.ObjectModel;
using System.IO;
using Manifest.Properties;

namespace Manifest
{
    public partial class Form1 : Form
    {
        public ImageList Imagelist = new ImageList();
        int searchIndex;
        int tmpLoadNum = 1;
        String selectedLoad = "";
        int imageIndex = 0;
        List<String> selectedPeople = new List<String>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("\n---------------------------------------------Application startup " + DateTime.Now.ToString() + "---------------------------------------------");

            searchIndex = 0;

            // Key event handler for left/right keys
            // Requested by Mike for scrolling left/right through loads
            // Also handles insert key
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);

            textBoxSearchPeople.KeyDown += new KeyEventHandler(searchPeople_KeyDown);

            // show/hide UI components
            hideEditPersonUI();
            buttonSavePerson.Hide();
            buttonAddPerson.Hide();
            buttonCancel.Hide();
            labelEditDetails.Hide();

            hideEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Hide();

            WindowState = FormWindowState.Maximized;
            tabControl.SelectedTab = tabPageLoads;

            numericUpDownMaxJumpers.Value = 1;
            loadPeople();
            loadAircraft();

            // Default to the King Air
            try
            {
                comboBoxLoadAircraft.SelectedIndex = comboBoxLoadAircraft.Items.IndexOf("King Air");
            }
            catch (Exception)
            {
            }

            // Retrieve all image files for logos used to group tandems/AFF
            String[] ImageFiles = Directory.GetFiles(@"C:\test");
            foreach (var file in ImageFiles)
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
                handleAddPersonToLoad();
            }

            if (e.KeyCode == Keys.F12)
            {
                handleAddPersonToLoad();
            }
        }

        private void handleAddPersonToLoad()
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
            DialogResult result = addTandemWindow.result;
            if (result == DialogResult.None)
                return;

            // Add the person to the selected load
            ListViewItem loadInfo;

            // Check to see if this person's manifest number is already manifested
            foreach (ListView c in panelLoads.Controls)
            {
                foreach (ListViewItem i in c.Items)
                {
                    if (i.Text.Contains(addTandemWindow.instructor1ManNum) && addTandemWindow.instructor1ManNum != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.instructor1 + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (i.Text.Contains(addTandemWindow.instructor2orVideoManNum) && addTandemWindow.instructor2orVideoManNum != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.instructor2orVideo + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (i.Text.Contains(addTandemWindow.manNum) && addTandemWindow.manNum != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Double manifest warning for " + addTandemWindow.jumperName + ".\nClick Yes to allow double manifest.", "Double manifest warning", MessageBoxButtons.YesNo);
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
                    if (addTandemWindow.jumpType.Contains("TAN"))
                    {
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];
                        String[] pieces = loadInfo.Text.Split('-');
                        String slots = pieces[2].Replace("slots", "").Trim();
                        Int32 num = 0;
                        Int32.TryParse(slots, out num);
                        if (addTandemWindow.instructor2orVideo.Trim() != "") // Has video, so subtract 3
                            num = num - 3;
                        else
                            num = num - 2; // just TI and student

                        if (num < 0)
                        {
                            MessageBox.Show("Not enough room on this load.");
                            return;
                        }

                        if (num == 0) // If load is full, color it red
                            c.BackColor = Color.Red;

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        // Add the people
                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.instructor1 });
                        addLog(selectedLoad, addTandemWindow.instructor1ManNum, " replace this with instructor pay rate");
                        if (addTandemWindow.instructor2orVideo.Trim() != "")
                        {
                            c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.instructor2orVideo });
                            addLog(selectedLoad, addTandemWindow.instructor2orVideoManNum, " replace this with video pay rate");
                        }

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.jumperName });
                        addLog(selectedLoad, "TANSTUDENT", " replace this with tandems cost");
                        imageIndex = imageIndex + 1;
                        if (imageIndex == 12)
                            imageIndex = 0;
                        return;
                    }

                    // If AFF, make a separate entry for the AFFIs
                    else if (addTandemWindow.jumpType.Contains("AFF"))
                    {
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];
                        String[] pieces = loadInfo.Text.Split('-');
                        String slots = pieces[2].Replace("slots", "").Trim();
                        Int32 num = 0;
                        Int32.TryParse(slots, out num);
                        if (addTandemWindow.instructor2orVideo.Trim() != "") // Has 2 instructors, so subtract 3
                            num = num - 3;
                        else
                            num = num - 2; // just 1 instructor

                        if (num < 0)
                        {
                            MessageBox.Show("Not enough room on this load.");
                            return;
                        }

                        if (num == 0) // If load is full, color it red
                            c.BackColor = Color.Red;

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.instructor1 });
                        addLog(selectedLoad, addTandemWindow.instructor1ManNum, " replace this with instructor pay rate");
                        if (addTandemWindow.instructor2orVideo.Trim() != "")
                        {
                            c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.instructor2orVideo });
                            addLog(selectedLoad, addTandemWindow.instructor2orVideoManNum, " replace this with instructor pay rate");
                        }

                        c.Items.Add(new ListViewItem { ImageIndex = imageIndex, Text = addTandemWindow.manNum + " - " + addTandemWindow.jumperName });
                        addLog(selectedLoad, addTandemWindow.manNum, " replace this with AFF student rate");
                        imageIndex = imageIndex + 1;
                        if (imageIndex == 12)
                            imageIndex = 0;
                        return;
                    }
                    else
                    {
                        // Regular fun jumper
                        // Update the first item in the list to have correct number of slots left
                        loadInfo = c.Items[0];

                        String[] pieces = loadInfo.Text.Split('-');
                        String slots = pieces[2].Replace("slots", "").Trim();

                        Int32 num = 0;
                        Int32.TryParse(slots, out num);

                        num = num - 1;

                        if (num < 0)
                        {
                            MessageBox.Show("Not enough room on this load.");
                            return;
                        }

                        if (num == 0) // If load is full, color it red
                            c.BackColor = Color.Red;

                        c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";

                        c.Items.Add(new ListViewItem { Text = addTandemWindow.manNum + " - " + addTandemWindow.jumperName });
                        addLog(selectedLoad, addTandemWindow.manNum, " replace this with fun jump pay rate or 0 if beginning of year free jumps");
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Manifest Program\nCopyright 2018-" + DateTime.Now.ToString("yyyy") + "\nAll rights reserved", "About");
        }

        public void searchPeople_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchForPeople();
            }
        }

        public void searchForPeople()
        {
            String searchText = textBoxSearchPeople.Text.ToLower();
            Boolean found = false;
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
                searchIndex = selectedIndex + 1;

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

        public void loadPeople()
        {
            ObservableCollection<String> people = new ObservableCollection<String>();
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

            String m, f, l;
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
                            Double.TryParse(dr.GetString(3), out p);
                        else
                            p = 0;
                        PersonType per = new PersonType(m, f, l, p);
                        peopleFromDB.Add(per);
                    }
                }
            }

            peopleFromDB.Sort();

            foreach (PersonType pt in peopleFromDB)
            {
                people.Add(pt.getManifestNumber() + " - " + pt.getFirstName() + " " + pt.getLastName());
            }

            listBoxPeople.DataSource = people;
        }

        private void showEditPersonUI()
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

        private void hideEditPersonUI()
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

        private void buttonAddNewPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            showEditPersonUI();
            buttonAddPerson.Show();
            buttonCancel.Show();
            buttonSavePerson.Hide();

            // Clear the edit UI components
            textBoxManifestNumber.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

        private void buttonAddTandem_Click(object sender, EventArgs e)
        {
            handleAddPersonToLoad();
        }

        private void buttonNewLoad_Click(object sender, EventArgs e)
        {
            ListView loadList = new ListView();

            loadList.LargeImageList = Imagelist;
            loadList.SmallImageList = Imagelist;

            loadList.View = View.Details;

            loadList.HeaderStyle = ColumnHeaderStyle.None;
            loadList.FullRowSelect = true;
            loadList.Columns.Add("", -2);
            String aircraft = comboBoxLoadAircraft.Text;

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

            loadList.Click += new EventHandler(load_click);

            panelLoads.Controls.Add(loadList);
            addLog(tmpLoadNum.ToString());
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
            var DraggedItem = ((ListViewItem)e.Data.GetData(typeof(ListViewItem)));
            MessageBox.Show(DraggedItem.ToString());
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

        void load_click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            String load = lv.Items[0].Text.Split('-')[0];
            selectedLoad = load;
            labelSelectedLoad.Text = selectedLoad;
            selectedPeople.Clear();
            for (int i = 0; i < lv.SelectedItems.Count; i++)
            {
 // MessageBox.Show("person is " + lv.SelectedItems[i].Text);
                selectedPeople.Add(lv.SelectedItems[i].Text);
            }
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                String item = listBoxPeople.GetItemText(listBoxPeople.SelectedItem);
                String[] splitString = item.Split('-');
                String manNum = splitString[0];
                String name = splitString[1];
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
                            loadPeople();

                            // Hide the edit UI components
                            hideEditPersonUI();
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

        private void buttonEditPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
            showEditPersonUI();
            buttonSavePerson.Show();
            buttonCancel.Show();
            buttonAddPerson.Hide();
            try
            {
                String item = listBoxPeople.GetItemText(listBoxPeople.SelectedItem);
                String[] splitString = item.Split('-');
                String manNum = splitString[0].Trim();
                String name = splitString[1].Trim();
                String firstName = name.Split(' ')[0];
                String lastName = name.Split(' ')[1];
                textBoxManifestNumber.Text = manNum;
                textBoxFirstName.Text = firstName;
                textBoxLastName.Text = lastName;

                // Get their checkbox statuses from the database
                Boolean t = false;
                Boolean a = false;
                Boolean c = false;
                Boolean v = false;

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

        private void buttonSavePerson_Click(object sender, EventArgs e)
        {
            String manNum = textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", "");
            String fName = textBoxFirstName.Text;
            fName = fName.Replace("'", "");
            String lName = textBoxLastName.Text;
            lName = lName.Replace("'", "");
            Boolean ti = checkBoxTI.Checked;
            Boolean affi = checkBoxAFF.Checked;
            Boolean coach = checkBoxCoach.Checked;
            Boolean video = checkBoxVideo.Checked;

            String t = "0";
            if (ti)
                t = "1";
            String a = "0";
            if (affi)
                a = "1";
            String c = "0";
            if (coach)
                c = "1";
            String v = "0";
            if (video)
                v = "1";

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
                    loadPeople();

                    // Hide the edit UI components
                    hideEditPersonUI();
                    buttonSavePerson.Hide();
                    buttonCancel.Hide();
                    labelEditDetails.Hide();
                }
            }
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            String manNum = textBoxManifestNumber.Text;
            manNum = manNum.Replace("'", "");
            String fName = textBoxFirstName.Text;
            fName = fName.Replace("'", "");
            String lName = textBoxLastName.Text;
            lName = lName.Replace("'", "");
            Boolean ti = checkBoxTI.Checked;
            Boolean affi = checkBoxAFF.Checked;
            Boolean coach = checkBoxCoach.Checked;
            Boolean video = checkBoxVideo.Checked;

            String t = "0";
            if (ti)
                t = "1";
            String a = "0";
            if (affi)
                a = "1";
            String c = "0";
            if (coach)
                c = "1";
            String v = "0";
            if (video)
                v = "1";

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
                    loadPeople();

                    // Hide the edit UI components
                    hideEditPersonUI();
                    buttonCancel.Hide();
                    buttonAddPerson.Hide();
                }
            }
        }

        private void buttonSearchPeople_Click(object sender, EventArgs e)
        {
            searchForPeople();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            hideEditPersonUI();
            buttonSavePerson.Hide();
            buttonAddPerson.Hide();
            buttonCancel.Hide();
            labelEditDetails.Hide();
        }

        private void showEditAircraftUI()
        {
            labelEditDetailsAircraft.Show();
            labelAircraftName.Show();
            textBoxAircraftName.Show();
            labelMaxJumpers.Show();
            numericUpDownMaxJumpers.Show();
        }

        private void hideEditAircraftUI()
        {
            labelEditDetailsAircraft.Hide();
            labelAircraftName.Hide();
            textBoxAircraftName.Text = "";
            textBoxAircraftName.Hide();
            labelMaxJumpers.Hide();
            numericUpDownMaxJumpers.Value = 0;
            numericUpDownMaxJumpers.Hide();
        }

        private void buttonCancelAircraft_Click(object sender, EventArgs e)
        {
            hideEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Hide();
        }

        private void buttonAddAircraftSubmit_Click(object sender, EventArgs e)
        {
            String name = textBoxAircraftName.Text;
            int cap = (int)numericUpDownMaxJumpers.Value;

            if (String.IsNullOrWhiteSpace(name))
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
                    loadAircraft();

                    // Hide the edit UI components
                    hideEditAircraftUI();
                    buttonAddAircraftSubmit.Hide();
                    buttonSaveAircraft.Hide();
                    buttonCancelAircraft.Hide();
                }
            }
        }

        public void loadAircraft()
        {
            ObservableCollection<String> aircraft = new ObservableCollection<String>();
            ObservableCollection<String> aircraftNames = new ObservableCollection<String>();
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

            String an;
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
                aircraft.Add(plane.getName() + " - Max jumpers " + plane.getCapacity());
                aircraftNames.Add(plane.getName());
            }

            listBoxAircraft.DataSource = aircraft;
            comboBoxLoadAircraft.DataSource = aircraftNames;
        }

        private void buttonSaveAircraft_Click(object sender, EventArgs e)
        {
            String name = textBoxAircraftName.Text;
            int cap = (int)numericUpDownMaxJumpers.Value;

            if (String.IsNullOrWhiteSpace(name))
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
                    loadAircraft();

                    // Hide the edit UI components
                    hideEditAircraftUI();
                    buttonAddAircraftSubmit.Hide();
                    buttonSaveAircraft.Hide();
                    buttonCancelAircraft.Hide();
                }
            }
        }

        private void buttonAddAircraft_Click(object sender, EventArgs e)
        {
            showEditAircraftUI();
            buttonAddAircraftSubmit.Show();
            buttonSaveAircraft.Hide();
            buttonCancelAircraft.Show();
            labelEditDetailsAircraft.Hide();

            // Make the aircraft name read-write
            textBoxAircraftName.Enabled = true;
        }

        private void buttonEditAircraft_Click(object sender, EventArgs e)
        {
            // Make the aircraft name read-only
            textBoxAircraftName.Enabled = false;
            String item = listBoxAircraft.GetItemText(listBoxAircraft.SelectedItem);
            String[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
            String name = splitString[0].Trim();
            String cap = splitString[1].Trim();
            int capacity = 0;
            textBoxAircraftName.Text = name;
            Int32.TryParse(cap, out capacity);
            numericUpDownMaxJumpers.Value = capacity;

            labelEditDetailsAircraft.Text = "Editing details for " + name + " with max jumpers " + capacity + ".";

            showEditAircraftUI();
            buttonAddAircraftSubmit.Hide();
            buttonSaveAircraft.Show();
            buttonCancelAircraft.Show();
        }

        private void buttonDeleteAircraft_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this aircrafit?\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                String item = listBoxAircraft.GetItemText(listBoxAircraft.SelectedItem);
                String[] splitString = item.Split(new string[] { " - Max jumpers " }, StringSplitOptions.None);
                String name = splitString[0].Trim();

                using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "delete from aircraft where aircraftName = '" + name + "'";
                    cn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        // If delete was successful, reload the aircraft in the UI list
                        loadAircraft();
                    }
                }
            }
        }

        private void buttonAddFunJumper_Click(object sender, EventArgs e)
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

        private void buttonDeletePersonFromLoad_Click(object sender, EventArgs e)
        {
            // Delete the selected entries

            // If deleting a tandem, must select all people to delete
            String load = selectedLoad;
            String manNum = "";

            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad)) // For the selected load
                {
                    foreach (ListViewItem listitem in c.Items) // For each item in the load
                    {
                        foreach (String item in selectedPeople) // For each of the selected people
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
                                addLog(load, manNum);

                                ListViewItem loadInfo = c.Items[0];
                                String[] pieces = loadInfo.Text.Split('-');
                                String slots = pieces[2].Replace("slots", "").Trim();
                                Int32 num = 0;
                                Int32.TryParse(slots, out num);
                                num = num + 1;

                                if (num > 0) // If load is full, color it red
                                    c.BackColor = Color.White;

                                c.Items[0].Text = pieces[0].Trim() + " - " + pieces[1].Trim() + " - " + num + " slots";
                            }
                        }
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printCertificate();
        }

        private void printCertificate()
        {
            String load = selectedLoad;
            String manNum = "";

            foreach (ListView c in panelLoads.Controls)
            {
                if (c.Items[0].ToString().Contains(selectedLoad)) // For the selected load
                {
                    foreach (ListViewItem listitem in c.Items) // For each item in the load
                    {
                        foreach (String item in selectedPeople) // For each of the selected people
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
                                String studentname = "Joe Tandem";
                                String aircraft = "Super King Air";
                                String instructor = "TI Jim";
                                FormPrintCertificate printCert = new FormPrintCertificate(studentname, aircraft, instructor);
                                printCert.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void buttonCompleteLoad_Click(object sender, EventArgs e)
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

        private void addLog(String loadNum, String manifestNum, String price)
        {
            log.Info("\nLoad " + loadNum + " added number " + manifestNum + " $" + price);
        }

        private void addLog(String loadNum, String manifestNum)
        {
            log.Info("\nLoad " + loadNum + " removed number " + manifestNum);
        }

        private void addLog(String loadNum)
        {
            log.Info("\nLoad " + loadNum + " created.");
        }
    }
}
