using AttendanceSystem.DataSet1TableAdapters;
using System;
using System.Data;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public int UserID = 0;
        public MainForm(int userID)
        {
            UserID = userID;
            InitializeComponent();
            statUser.Text = userID.ToString();
        }


        private void metroButton3_Click(object sender, EventArgs e)
        {
            FormAddClass addclass = new FormAddClass();
            addclass.UserID = this.UserID;
            addclass.ShowDialog();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet11.AttendanceRecordsTBL' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'dataSet1.ClassesTBL' Puede moverla o quitarla según sea necesario.
            this.classesTBLTableAdapter.Fill(this.dataSet1.ClassesTBL);

            classesTBLBindingSource.Filter = "UserID = '" + UserID.ToString() + "'";


        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            StudentsForm students = new StudentsForm();
            students.ClassName = metroComboBox1.Text;
            students.ClassID = (int)metroComboBox1.SelectedValue;


            students.ShowDialog();
        }

        private void metroButtonGet_Click(object sender, EventArgs e)
        {
            /// Check if records exists, if yes load them for edit and if not create a record for eache state and load for edit
            /// 

            AttendanceRecordsTBLTableAdapter adapter = new AttendanceRecordsTBLTableAdapter();
            DataTable dt = adapter.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

            if(dt.Rows.Count > 0 )
            {
                DataTable dt_new = adapter.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;

            }
            else
            {
                StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();
                DataTable dt_Students = students_adapter.GetDataByClassID((int)metroComboBox1.SelectedValue);

                foreach(DataRow row in dt_Students.Rows)
                {
                    adapter.InsertQuery((int)row[0], (int)metroComboBox1.SelectedValue, dateTimePicker1.Text, "", row[1].ToString(), metroComboBox1.Text);




                }

                DataTable dt_new = adapter.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTBLTableAdapter adapter = new AttendanceRecordsTBLTableAdapter();
            

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    adapter.UpdateQuery(row.Cells[1].Value.ToString(), row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }



            }

            DataTable dt_new = adapter.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTBLTableAdapter adapter = new AttendanceRecordsTBLTableAdapter();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    adapter.UpdateQuery("", row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }
            }

            DataTable dt_new = adapter.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();
                DataTable dt_Students = students_adapter.GetDataByClassID((int)metroComboBox2.SelectedValue);

                AttendanceRecordsTBLTableAdapter adapter = new AttendanceRecordsTBLTableAdapter();

                listView1.Items.Clear(); 

                foreach (DataRow row in dt_Students.Rows)
                {
                    string studentName = row[1].ToString();

                    int P = GetAttendanceCount(adapter, dateTimePicker2.Value.Month, studentName, "present");
                    int A = GetAttendanceCount(adapter, dateTimePicker2.Value.Month, studentName, "absent");
                    int L = GetAttendanceCount(adapter, dateTimePicker2.Value.Month, studentName, "late");
                    int E = GetAttendanceCount(adapter, dateTimePicker2.Value.Month, studentName, "excused");

                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = studentName;
                    listViewItem.SubItems.Add(P.ToString());
                    listViewItem.SubItems.Add(A.ToString());
                    listViewItem.SubItems.Add(L.ToString());
                    listViewItem.SubItems.Add(E.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetAttendanceCount(AttendanceRecordsTBLTableAdapter adapter, int month, string studentName, string status)
        {
            DataTable dt = adapter.GetDataByReport(month, studentName, status);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("AttendanceCount"); 
            }
            return 0; 
        }



        private void metroButton6_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.ShowDialog();
        }
    }
}
