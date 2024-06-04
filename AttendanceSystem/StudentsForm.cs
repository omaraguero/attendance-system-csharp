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
    public partial class StudentsForm : Form
    {

        public int ClassID { get; set; }
        public string ClassName { get; set; } 


        public StudentsForm()
        {
            InitializeComponent();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.StudentsTBL' Puede moverla o quitarla según sea necesario.
            this.studentsTBLTableAdapter.Fill(this.dataSet1.StudentsTBL);
            labelClassID.Text   = ClassID.ToString();  
            labelClassName.Text = ClassName.ToString();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.studentsTBLBindingSource.EndEdit();
            this.studentsTBLTableAdapter.Update(dataSet1.StudentsTBL);
        }
    }
}
