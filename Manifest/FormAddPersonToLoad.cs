namespace Manifest
{
    using System;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Manifest.Properties;

    public partial class FormAddPersonToLoad : Form
    {
        public string JumpType { get; set; }

        public string ManNum { get; set; }

        public string Altitude { get; set; }

        public string Price { get; set; }

        public string JumperName { get; set; }

        public string Instructor1 { get; set; }

        public string Instructor1ManNum { get; set; }

        public string Instructor2orVideo { get; set; }

        public string Instructor2orVideoManNum { get; set; }

        public DialogResult Result { get; set; }

        public FormAddPersonToLoad(string l)
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(this.KeyPressHandler);

            JumpType = "";
            ManNum = "";
            Altitude = "";
            Price = "";
            JumperName = "";
            Instructor1 = "";
            Instructor1ManNum = "";
            Instructor2orVideo = "";
            Instructor2orVideoManNum = "";

            // Default to the first item in the price list
            comboBoxJumpType.SelectedIndex = 0;

            // Set the DialogResult to
            Result = DialogResult.None;

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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            JumpType = comboBoxJumpType.Text;
            ManNum = textBoxManNum.Text;
            Altitude = textBoxAltitude.Text;
            Price = textBoxPrice.Text;
            JumperName = textBoxName.Text;
            Instructor1 = comboBoxInstructors.Text;
            Instructor2orVideo = comboBoxVideo.Text;

            // If tandem is selected, ensure jumper name isn't blank and an instructor is selected
            if (JumpType.Contains("TAN"))
            {
                if (Instructor1.Trim() == "")
                {
                    MessageBox.Show("This jump type requires a tandem instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If tandem is selected, ensure there's a name for the tandem student
            if (JumpType.Contains("TAN"))
            {
                if (JumperName.Trim() == "")
                {
                    MessageBox.Show("Please enter the tandem student's name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If AFF is selected, ensure manifest number isn't blank
            if (JumpType.Contains("AFF"))
            {
                if (ManNum.Trim() == "")
                {
                    MessageBox.Show("Please enter the student's manifest number.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF2 is selected, ensure 2 instructors are selected
            if (JumpType.Contains("IAFF2"))
            {
                if (Instructor1.Trim() == "" || Instructor2orVideo.Trim() == "")
                {
                    MessageBox.Show("IAFF2 requires 2 instructors. Please select two to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF1 is selected, ensure 1 instructor is selected
            if (JumpType.Contains("IAFF1"))
            {
                if (Instructor1.Trim() == "")
                {
                    MessageBox.Show("IAFF1 requires an AFF instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If 14500 or GRWTS ensure the manifest number isn't blank
            if (JumpType == "14,500 - $26.00" || JumpType == "GRWTS - $51.00")
            {
                if (ManNum.Trim() == "")
                {
                    MessageBox.Show("This jump type requires a manifest number. Please enter one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            Result = DialogResult.OK;
            this.Close();
        }

        private void ComboBoxJumpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the other fields
            textBoxAltitude.Text = "14500";

            string selected = comboBoxJumpType.Items[comboBoxJumpType.SelectedIndex].ToString();
            string price = selected.Split('-')[1].Replace("$", "");
            textBoxPrice.Text = price.Trim();
        }

        private void TextBoxManNum_Leave(object sender, EventArgs e)
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
