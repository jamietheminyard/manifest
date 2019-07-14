namespace Manifest
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Manifest.Domain.Entities;
    using Manifest.Persistence.Context;

    public partial class AddPersonToLoadForm : Form
    {
        public AddPersonToLoadForm(string load)
        {
            this.InitializeComponent();

            this.JumpType = string.Empty;
            this.ManNum = string.Empty;
            this.Altitude = string.Empty;
            this.Price = string.Empty;
            this.JumperName = string.Empty;
            this.Instructor1 = string.Empty;
            this.Instructor1ManNum = string.Empty;
            this.Instructor2orVideo = string.Empty;
            this.Instructor2orVideoManNum = string.Empty;

            // Default to the first item in the price list
            this.jumpTypeComboBox.SelectedIndex = 0;

            // Set the DialogResult to
            this.Result = DialogResult.None;

            // Display which load is selected
            this.loadLabel.Text = load;

            // Load the instructors and videographers
            using (ManifestDbContext context = new ManifestDbContext())
            {
                foreach (Person person in context.People.Where(p => p.IsTandemInstructor || p.IsAffInstructor))
                {
                    string personText = $"{person.ManifestNumber} - {person.FirstName} {person.LastName}";
                    this.tandemInstructorOrAffInstructor1ComboBox.Items.Add(personText);
                }

                foreach (Person person in context.People.Where(p => p.IsAffInstructor || p.IsVideographer))
                {
                    string personText = $"{person.ManifestNumber} - {person.FirstName} {person.LastName}";
                    this.videographerOrAffInstructor2ComboBox.Items.Add(personText);
                }
            }
        }

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

        private void AddPersonToLoadForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void AddPersonToLoadForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Lets you hit the enter key instead of tab to go through the input fields
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            this.JumpType = this.jumpTypeComboBox.Text;
            this.ManNum = this.manfestNumberTextBox.Text;
            this.Altitude = this.altitudeTextBox.Text;
            this.Price = this.priceTextBox.Text;
            this.JumperName = this.jumberNameTextBox.Text;
            this.Instructor1 = this.tandemInstructorOrAffInstructor1ComboBox.Text;
            this.Instructor2orVideo = this.videographerOrAffInstructor2ComboBox.Text;

            // If tandem is selected, ensure jumper name isn't blank and an instructor is selected
            if (this.JumpType.Contains("TAN"))
            {
                if (string.IsNullOrEmpty(this.Instructor1.Trim()))
                {
                    MessageBox.Show("This jump type requires a tandem instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If tandem is selected, ensure there's a name for the tandem student
            if (this.JumpType.Contains("TAN"))
            {
                if (string.IsNullOrEmpty(this.JumperName.Trim()))
                {
                    MessageBox.Show("Please enter the tandem student's name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If AFF is selected, ensure manifest number isn't blank
            if (this.JumpType.Contains("AFF"))
            {
                if (string.IsNullOrEmpty(this.ManNum.Trim()))
                {
                    MessageBox.Show("Please enter the student's manifest number.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF2 is selected, ensure 2 instructors are selected
            if (this.JumpType.Contains("IAFF2"))
            {
                if (string.IsNullOrEmpty(this.Instructor1.Trim()) || string.IsNullOrEmpty(this.Instructor2orVideo.Trim()))
                {
                    MessageBox.Show("IAFF2 requires 2 instructors. Please select two to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If IAFF1 is selected, ensure 1 instructor is selected
            if (this.JumpType.Contains("IAFF1"))
            {
                if (string.IsNullOrEmpty(this.Instructor1.Trim()))
                {
                    MessageBox.Show("IAFF1 requires an AFF instructor. Please select one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // If 14500 or GRWTS ensure the manifest number isn't blank
            if (this.JumpType == "14,500 - $26.00" || this.JumpType == "GRWTS - $51.00")
            {
                if (string.IsNullOrEmpty(this.ManNum.Trim()))
                {
                    MessageBox.Show("This jump type requires a manifest number. Please enter one to continue.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            this.Result = DialogResult.OK;
            this.Close();
        }

        private void JumpTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the other fields
            this.altitudeTextBox.Text = "14500";

            string selected = this.jumpTypeComboBox.Items[this.jumpTypeComboBox.SelectedIndex].ToString();
            string price = selected.Split('-')[1].Replace("$", string.Empty);
            this.priceTextBox.Text = price.Trim();
        }

        private void ManfestNumberTextBox_Leave(object sender, EventArgs e)
        {
            // Pull up this manifest number's name
            string manifestNumber = this.manfestNumberTextBox.Text.Trim();

            if (string.IsNullOrEmpty(manifestNumber) == false)
            {
                Person person;

                using (ManifestDbContext context = new ManifestDbContext())
                {
                    person = context.People.SingleOrDefault(p => p.ManifestNumber == manifestNumber);
                }

                if (person != null)
                {
                    this.jumberNameTextBox.Text = $"{person.FirstName} {person.LastName}";
                }
            }
        }
    }
}
