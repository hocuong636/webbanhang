using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_03_TH
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form2_NhapSV addStudentForm = new Form2_NhapSV();

        private void tSBtnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                var student = addStudentForm.NewStudent;
                if (dgvStudent.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["coMSSV"].Value?.ToString() == student.StudentID))
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvStudent.Rows.Add(dgvStudent.Rows.Count+1, student.StudentID, student.StudentName, student.Faculty, student.GPA);
            }
        }

        private void AddStudentToGrid(string studentID, string studentName, string score)
        {
            dgvStudent.Rows.Add(studentID, studentName, score);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void tSBtnTimKiem_Click()
        {
            tSTBTimKiem.Text = "";
            string keyword = tSTBTimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (row.Cells["coTSV"].Value != null)
                {
                    string cellValue = row.Cells["coTSV"].Value.ToString().ToLower();
                    row.Visible = cellValue.Contains(keyword);
                }
                else
                {
                    dgvStudent.AllowUserToAddRows = false;
                }
            }
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                var student = addStudentForm.NewStudent;
                if (dgvStudent.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["coMSSV"].Value?.ToString() == student.StudentID))
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvStudent.Rows.Add(dgvStudent.Rows.Count, student.StudentID, student.StudentName, student.Faculty, student.GPA);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string keyword = tSTBTimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (row.Cells["coTSV"].Value != null)
                {
                    string cellValue = row.Cells["coTSV"].Value.ToString().ToLower();
                    row.Visible = cellValue.Contains(keyword);
                }
                else
                {
                    dgvStudent.AllowUserToAddRows = false;
                }
            }
        }
    }
}
