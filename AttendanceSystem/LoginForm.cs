using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class LoginForm : Form

    {
        public bool loginFlag { get; set; }
        public int UserID { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            loginFlag = false;
        }

        private void metroButtonLogin_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAdapter = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAdapter.GetDataByUserAndPass(metroTextBoxUser.Text, metroTextBoxPass.Text);

            if (dt.Rows.Count > 0)
            {
                // Valid login
                MessageBox.Show("Login ok");
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                loginFlag = true;
                this.Close(); // Close the login form if login is successful
            }
            else
            {
                // Invalid login
                loginFlag = false;
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
