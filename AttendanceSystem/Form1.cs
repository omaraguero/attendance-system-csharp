using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if(TextPass1.Text != TextPass2.Text)
            {
                MessageBox.Show("Passwords dont match");
                return;
            }

            DataSet1TableAdapters.UsersTableAdapter adapter = new DataSet1TableAdapters.UsersTableAdapter();
            adapter.InsertQuery(TextUser.Text, TextPass1.Text);
            MessageBox.Show("Registration Succesfull!");
            Close();

        }
    }
}
