using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace B1
{
    public partial class frm_Search : Form
    {
        public frm_Search()
        {
            InitializeComponent();
        }
        private void frm_Search_Load(object sender, EventArgs e)
        {
            Fill_cbo_khoa();
//            BindGrid();
        }
        private void Fill_cbo_khoa()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<Faculty> faculties = db.Faculty.ToList();

            comboBox1.DataSource = faculties;
            comboBox1.ValueMember = "FacultyID";
            comboBox1.DisplayMember = "FacultyName";
            comboBox1.SelectedIndex = 0;
            db.Dispose();
        }
        private void BindGrid()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<Student> students = db.Student.ToList();

            dataGridView1.Rows.Clear();

            foreach (Student s in students)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    s.StudentID,
                    s.FullName,
                    (s.Faculty != null) ? s.Faculty.FacultyName : db.Faculty.FirstOrDefault(n => n.FacultyID == s.FacultyID).FacultyName,
                    s.AverageScore
                });
            }
            ClearInputFields();
            db.Dispose();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    txt_StudentID.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    txt_FullName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    comboBox1.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                ClearInputFields();
                return;
            }
        }
        private void ClearInputFields()
        {
            txt_StudentID.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string studentID = txt_StudentID.Text.Trim();
            string studentName = txt_FullName.Text.Trim();

            using (var db = new QuanLySinhVienEntities())
            {
                var query = db.Student.Include(s => s.Faculty).AsQueryable();
                if (!string.IsNullOrEmpty(studentID))
                {
                    query = query.Where(s => s.StudentID.Contains(studentID));
                }
                if (!string.IsNullOrEmpty(studentName))
                {
                    query = query.Where(s => s.FullName.Contains(studentName));
                }
                var filteredStudents = query.ToList();
                dataGridView1.Rows.Clear();
                foreach (var student in filteredStudents)
                {
                    dataGridView1.Rows.Add(new object[]{
                        student.StudentID,
                        student.FullName,
                        student.Faculty != null ? student.Faculty.FacultyName : "N/A",
                        student.AverageScore
                    });
                }
            }
        }
        private void xóa_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLySinhVienEntities())
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                    return;
                }

                string studentID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                var student = db.Student.FirstOrDefault(s => s.StudentID == studentID);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    return;
                }

                var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.Student.Remove(student);
                    db.SaveChanges();

                    MessageBox.Show("Xóa sinh viên thành công!");
                    BindGrid();
                }
                db.Dispose();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
