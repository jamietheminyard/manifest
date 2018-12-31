﻿using System;
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

namespace Manifest
{
    public partial class Form1 : Form
    {
        public ImageList Imagelist = new ImageList();
        public Form1()
        {
            InitializeComponent();
            // Hide edit UI components
            labelManifestNumber.Hide();
            textBoxManifestNumber.Hide();
            labelFirstName.Hide();
            textBoxFirstName.Hide();
            labelLastName.Hide();
            textBoxLastName.Hide();
            checkBoxTI.Hide();
            checkBoxAFF.Hide();
            checkBoxCoach.Hide();
            checkBoxVideo.Hide();
            buttonSavePerson.Hide();
            buttonAddPerson.Hide();

            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
            WindowState = FormWindowState.Maximized;
            tabControl.SelectedTab = tabPageLoads;
            comboBoxLoadAircraft.SelectedIndex = 0;
            loadPeople();

            
            //retrieve all image files
            String[] ImageFiles = Directory.GetFiles(@"C:\test");
            foreach (var file in ImageFiles)
            {
                //Add images to Imagelist
                Imagelist.Images.Add(Image.FromFile(file));
            }



        }

        public void loadPeople()
        {
            ObservableCollection<String> people = new ObservableCollection<String>();
            List<PersonType> peopleFromDB = new List<PersonType>();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (var conn = new SqlConnection(connString))
            {
                string sqlString = @"select manifestNumber, firstName, lastName, paid from people";
                using (var command = new SqlCommand(sqlString, conn))
                {
                    conn.Open();
                    var result = command.ExecuteScalar();
                    System.Diagnostics.Debug.WriteLine(result.ToString());
                    conn.Close();
                }
            }

            String m, f, l;
            double p;

            using (SqlConnection cn = new SqlConnection(connString))
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPeople.SelectedIndex >= 0)
            {
                String data = listBoxPeople.Items[listBoxPeople.SelectedIndex].ToString();
                String manifestNumber = data.Split('-')[0].Trim();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("West Tennessee Skydiving - Manifest software\nCopyright 2018\nAll rights reserved", "About");
        }

        private void buttonAddNewPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
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
            buttonAddPerson.Show();

            buttonSavePerson.Hide();

            // Clear the edit UI components
            textBoxManifestNumber.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";


            //           Form addPersonWindow = new AddUserForm();
            //           addPersonWindow.FormClosed += new FormClosedEventHandler(Person_Form_Closed);
            //           addPersonWindow.ShowDialog();
        }

        void Person_Form_Closed(object sender, FormClosedEventArgs e)
        {
            listBoxPeople.DataSource = null;
            loadPeople();
        }

        private void buttonAddTandem_Click(object sender, EventArgs e)
        {
            Form addTandemWindow = new FormAddPersonToLoad();
            addTandemWindow.ShowDialog();
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
            loadList.Items.Add(aircraft);
            loadList.Items.Add("5368 - Jamie Minyard AFF1");
            loadList.View = View.Details; // Enables Details view so you can see columns
            loadList.Items.Add(new ListViewItem { ImageIndex = 0, Text = "5368 - Jamie Minyard AFF1" });
            loadList.Width = 200;
            loadList.Height = 500;
            loadList.Columns[0].Width = Width - 50;

            panelLoads.Controls.Add(loadList);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPageLoads_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                String item = listBoxPeople.GetItemText(listBoxPeople.SelectedItem);
                String[] splitString = item.Split('-');
                String manNum = splitString[0];
                String name = splitString[1];
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE you want to delete this person from the database?\n\nManifest Number: " + manNum + "\nName: " + name + "\n\n***THIS ACTION CANNOT BE UNDONE***", "Confirm delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
                    using (SqlConnection cn = new SqlConnection(connString))
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "delete from People where manifestNumber = '" + manNum + "'";
                        cn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            // If delete was successful, reload the people in the UI list
                            loadPeople();

                            // Hide the edit UI components
                            labelManifestNumber.Hide();
                            textBoxManifestNumber.Hide();
                            labelFirstName.Hide();
                            textBoxFirstName.Hide();
                            labelLastName.Hide();
                            textBoxLastName.Hide();
                            checkBoxTI.Hide();
                            checkBoxAFF.Hide();
                            checkBoxCoach.Hide();
                            checkBoxVideo.Hide();
                            buttonSavePerson.Hide();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Unable to delete person.");
            }
        }

        private void buttonEditPerson_Click(object sender, EventArgs e)
        {
            // Display the edit UI components
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
            buttonSavePerson.Show();

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
                String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
                using (SqlConnection cn = new SqlConnection(connString))
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

            String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "update People set firstName = '" + fName + "', lastName = '" + lName + "', TI = " + t + ", AFFI = " + a + ", coach = " + c + ", videographer = " + v + " where manifestNumber = '" + manNum + "'";
                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    loadPeople();

                    // Hide the edit UI components
                    labelManifestNumber.Hide();
                    textBoxManifestNumber.Hide();
                    labelFirstName.Hide();
                    textBoxFirstName.Hide();
                    labelLastName.Hide();
                    textBoxLastName.Hide();
                    checkBoxTI.Hide();
                    checkBoxAFF.Hide();
                    checkBoxCoach.Hide();
                    checkBoxVideo.Hide();
                    buttonSavePerson.Hide();
                }
            }
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            String manNum = textBoxManifestNumber.Text;
            manNum = manNum.Replace("'","");
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



            String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "insert into People(manifestNumber, firstName, lastName, paid, TI, AFFI, coach, videographer)" +
                    "values(" + manNum + ",'" + fName + "','"
                    + lName + "','" + 0 + "'," + t + "," + a + "," + c + "," + v + ")";
                cn.Open();
                MessageBox.Show(cmd.CommandText);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    // If insert was successful, reload the people in the UI list
                    loadPeople();

                    // Hide the edit UI components
                    labelManifestNumber.Hide();
                    textBoxManifestNumber.Hide();
                    labelFirstName.Hide();
                    textBoxFirstName.Hide();
                    labelLastName.Hide();
                    textBoxLastName.Hide();
                    checkBoxTI.Hide();
                    checkBoxAFF.Hide();
                    checkBoxCoach.Hide();
                    checkBoxVideo.Hide();
                    buttonAddPerson.Hide();
                }
            }
        }

        private void buttonSearchPeople_Click(object sender, EventArgs e)
        {
            String searchText = textBoxSearchPeople.Text.ToLower();
            Boolean found = false;
            int selectedIndex = listBoxPeople.SelectedIndex;
            int numItems = listBoxPeople.Items.Count;
            int searchIndex;
            if (selectedIndex == numItems)
                searchIndex = 0;
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
                searchIndex = 0;
 //               listBoxPeople.SelectedIndex = 0;
            }
                
        }
    }
}
