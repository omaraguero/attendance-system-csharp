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
    public partial class FormAddClass : Form
    {
        public int UserID { get; set; }
        public FormAddClass()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.ClassesTBLTableAdapter adapter = new DataSet1TableAdapters.ClassesTBLTableAdapter();
                adapter.AddClass(metroTextBox1.Text, UserID);
            MessageBox.Show("Class added");
            Close();


        }
    }
}
