using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace B1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
                Fill_cbo_khoa();
                BindGrid();
        }
        private void Fill_cbo_khoa()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<Faculty> faculties = db.Faculty.ToList();
            db.Dispose();

            comboBox1.DataSource = faculties;
            comboBox1.ValueMember = "FacultyID";
            comboBox1.DisplayMember = "FacultyName";
            comboBox1.SelectedIndex = 0;
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
        private void ClearInputFields()
        {
            txt_StudentID.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void thêm_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLySinhVienEntities())
            {
                if (string.IsNullOrWhiteSpace(txt_StudentID.Text) ||
                    string.IsNullOrWhiteSpace(txt_FullName.Text) ||
                    comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
                if (txt_StudentID.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải dài hơn 10 ký tự!");
                    return;
                }
                if (db.Student.Any(s => s.StudentID == txt_StudentID.Text))
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!");
                    return;
                }

                var newStudent = new Student
                {
                    StudentID = txt_StudentID.Text,
                    FullName = txt_FullName.Text,
                    FacultyID = (int)comboBox1.SelectedValue,
                    AverageScore = double.TryParse(txt_AvageScore.Text, out var score) ? score : 0
                };

                db.Student.Add(newStudent);
                db.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!");
                BindGrid(); 
                db.Dispose();
            }
        }

        private void sửa_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLySinhVienEntities())
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                    return;
                }

                string studentID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                var student = db.Student.FirstOrDefault(s => s.StudentID == studentID);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    return;
                }

                student.FullName = txt_FullName.Text;
                student.FacultyID = (int)comboBox1.SelectedValue;
                student.AverageScore = double.TryParse(txt_AvageScore.Text, out var score) ? score : 0;

                db.SaveChanges();

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
                BindGrid(); 
                db.Dispose();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    txt_StudentID.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    txt_FullName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    txt_AvageScore.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                    comboBox1.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tìmKiếmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Search timkiem = new frm_Search();
            timkiem.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFalculty quanlykhoa = new frmFalculty();
            quanlykhoa.Show();
        }
    }
}
