namespace Manifest
{
    using System;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Manifest.Properties;

    public partial class FormAddPersonToLoad : Form
    {
        public string jumpType { get; set; }

        public string manNum { get; set; }

        public string altitude { get; set; }

        public string price { get; set; }

        public string jumperName { get; set; }

        public string instructor1 { get; set; }

        public string instructor1ManNum { get; set; }

        public string instructor2orVideo { get; set; }

        public string instructor2orVideoManNum { get; set; }

        public DialogResult result { get; set; }

        public FormAddPersonToLoad(string l)
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(this.KeyPressHandler);

            jumpType = "";
            manNum = "";
            altitude = "";
            price = "";
            jumperName = "";
            instructor1 = "";
            instructor1ManNum = "";
            instructor2orVideo = "";
            instructor2orVideoManNum = "";

            // Default to the first item in the price list
            comboBoxJumpType.SelectedIndex = 0;

            // Set the DialogResult to
            result = DialogResult.None;

            // Display which load is selected
            labelLoad.Text = l;

            this.KeyDown += new KeyEventHandler(this.FormAddPersonToLoad_KeyDown);

            // Load the instructors and videographers
            string num;
            string fname;
            string lname;

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
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

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
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

        void KeyPressHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
            jumpType = comboBoxJumpType.Text;
            manNum = textBoxManNum.Text;
            altitude = textBoxAltitude.Text;
            price = textBoxPrice.Text;
            jumperName = textBoxName.Text;
            instructor1 = comboBoxInstructors.Text;
            instructor2orVideo = comboBoxVideo.Text;

            // If tandem is selected, ensure jumper name isn't blank and an instructor is selected
            if (jumpType.Contains("TAN"))
            {
                if (instructor1.Trim() == "")
                {
                    MessageBox.Show("This jump type requires a tandem instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If tandem is selected, ensure there's a name for the tandem student
            if (jumpType.Contains("TAN"))
            {
                if (jumperName.Trim() == "")
                {
                    MessageBox.Show("Please enter the tandem student's name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If AFF is selected, ensure manifest number isn't blank
            if (jumpType.Contains("AFF"))
            {
                if (manNum.Trim() == "")
                {
                    MessageBox.Show("Please enter the student's manifest number.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF2 is selected, ensure 2 instructors are selected
            if (jumpType.Contains("IAFF2"))
            {
                if (instructor1.Trim() == "" || instructor2orVideo.Trim() == "")
                {
                    MessageBox.Show("IAFF2 requires 2 instructors. Please select two to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF1 is selected, ensure 1 instructor is selected
            if (jumpType.Contains("IAFF1"))
            {
                if (instructor1.Trim() == "")
                {
                    MessageBox.Show("IAFF1 requires an AFF instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If 14500 or GRWTS ensure the manifest number isn't blank
            if (jumpType == "14,500 - $26.00" || jumpType == "GRWTS - $51.00")
            {
                if (manNum.Trim() == "")
                {
                    MessageBox.Show("This jump type requires a manifest number. Please enter one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            result = DialogResult.OK;
            this.Close();
        }

        private void comboBoxJumpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the other fields
            textBoxAltitude.Text = "14500";

            string selected = comboBoxJumpType.Items[comboBoxJumpType.SelectedIndex].ToString();
            string price = selected.Split('-')[1].Replace("$", "");
            textBoxPrice.Text = price.Trim();
        }

        private void textBoxManNum_Leave(object sender, EventArgs e)
        {
            // Pull up this manifest number's name
            string num = textBoxManNum.Text.Trim();
            string fname = "";
            string lname = "";

            if (num == "")
            {
                return;
            }

            using (SqlConnection cn = new SqlConnection(Settings.Default.WTSDatabaseConnectionString))
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
