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

namespace Manifest
{
    public partial class FormAddPersonToLoad : Form
    {
        public string jumpType { get; set; }
        public string manNum { get; set; }
        public string altitude { get; set; }
        public string price { get; set; }
        public string jumperName { get; set; }
        public string instructor1 { get; set; }
        public string instructor2orVideo { get; set; }

        public FormAddPersonToLoad(String l)
        {
            InitializeComponent();
            // Default to the first item in the price list
            comboBoxJumpType.SelectedIndex = 0;

            // Display which load is selected
            labelLoad.Text = l;

            this.KeyDown += new KeyEventHandler(this.FormAddPersonToLoad_KeyDown);

            // Load the instructors and videographers
            String num;
            String fname;
            String lname;
            String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select manifestNumber, firstName, lastName from People where TI = 1 or AFFI = 1";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        num = dr.GetString(0);
                        fname = dr.GetString(1);
                        lname = dr.GetString(2);
                        comboBoxInstructors.Items.Add(num + " - " + fname + " " + lname);
                    }
                }
            }

            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select manifestNumber, firstName, lastName from People where AFFI = 1 or videographer = 1";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        num = dr.GetString(0);
                        fname = dr.GetString(1);
                        lname = dr.GetString(2);
                        comboBoxVideo.Items.Add(num + " - " + fname + " " + lname);
                    }
                }
            }
        }

        void FormAddPersonToLoad_KeyDown(object sender, KeyEventArgs e)
        {
            // Lets you hit the enter key instead of tab to go through the input fields
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //TODO If tandem is selected, ensure jumper name isn't blank and an instructor is selected

            jumpType = comboBoxJumpType.Text;
            manNum = textBoxManNum.Text;
            altitude = textBoxAltitude.Text;
            price = textBoxPrice.Text;
            jumperName = textBoxName.Text;
            instructor1 = comboBoxInstructors.Text;
            instructor2orVideo = comboBoxVideo.Text;

            this.Close();
        }

        private void comboBoxJumpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the other fields
            textBoxAltitude.Text = "14500";

            String selected = comboBoxJumpType.Items[comboBoxJumpType.SelectedIndex].ToString();
            String price = selected.Split('-')[1].Replace("$","");
            textBoxPrice.Text = price.Trim();
        }

        private void textBoxManNum_Leave(object sender, EventArgs e)
        {
            // Pull up this manifest number's name
            String num = textBoxManNum.Text.Trim();
            String fname = "";
            String lname = "";

            if (num == "")
                return;

            String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select firstName, lastName from People where manifestNumber = '" + num + "'";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        fname = dr.GetString(0);
                        lname = dr.GetString(1);
                    }
                }
            }

            textBoxName.Text = fname + " " + lname;
        }
    }
}
