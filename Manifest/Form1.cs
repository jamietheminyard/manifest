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

namespace Manifest
{
    public partial class Form1 : Form
    {
        public ImageList Imagelist = new ImageList();
        public Form1()
        {
            InitializeComponent();
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
            Form addPersonWindow = new AddUserForm();
            addPersonWindow.FormClosed += new FormClosedEventHandler(Person_Form_Closed);
            addPersonWindow.ShowDialog();
        }

        void Person_Form_Closed(object sender, FormClosedEventArgs e)
        {
            listBoxPeople.DataSource = null;
            loadPeople();
        }

        private void buttonAddTandem_Click(object sender, EventArgs e)
        {
            Form addTandemWindow = new FormAddTandem();
            addTandemWindow.ShowDialog();
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Point current = panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X + 1100, current.Y);
                panelLoads.AutoScrollPosition = scrolled;
            }
            if (e.KeyCode == Keys.Left)
            {
                Point current = panelLoads.AutoScrollPosition;
                Point scrolled = new Point(current.X - 1100, current.Y);
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
    }
}
