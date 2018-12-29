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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            String manNum = textBoxManNum.Text;
            String fName = textBoxFirstName.Text;
            String lName = textBoxLastName.Text;

            String connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\Users\jamie\source\repos\Manifest\Manifest\WTSDatabase.mdf; Integrated Security=True;";
            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "insert into People(manifestNumber, firstName, lastName, paid)" +
                    "values(" + manNum + ",'" + fName + "','"
                    + lName + "','" + 0 +  "')";
                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
