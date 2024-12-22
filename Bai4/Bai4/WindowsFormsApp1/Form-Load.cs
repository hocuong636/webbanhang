using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new StudentContextDB())
                {
                    // 1. Hiển thị danh sách sinh viên trong DataGridView
                    var studentList = context.Students
                        .Include(s => s.Faculty) // Load dữ liệu từ bảng Faculty
                        .Select(s => new
                        {
                            s.StudentID,
                            s.FullName,
                            s.AverageScore,
                            FacultyName = s.Faculty.FacultyName // Lấy tên khoa từ bảng Faculty
                        }).ToList();

                    if (studentList.Count == 0)
                        MessageBox.Show("Bảng Student không có dữ liệu.");

                    dgvStudents.DataSource = studentList;

                    // 2. Load danh sách khoa vào ComboBox
                    var faculties = context.Faculties.ToList();

                    if (faculties.Count == 0)
                        MessageBox.Show("Bảng Faculty không có dữ liệu.");

                    cboFaculty.DataSource = faculties;
                    cboFaculty.DisplayMember = "FacultyName";
                    cboFaculty.ValueMember = "FacultyID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text) ||
        string.IsNullOrEmpty(txtFullName.Text) ||
        string.IsNullOrEmpty(txtAverageScore.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (var context = new StudentContextDB())
            {
                var student = new Student
                {
                    StudentID = txtStudentID.Text,
                    FullName = txtFullName.Text,
                    AverageScore = float.Parse(txtAverageScore.Text),
                    FacultyID = (int)cboFaculty.SelectedValue
                };

                context.Students.Add(student);
                context.SaveChanges();
                MessageBox.Show("Thêm mới dữ liệu thành công!");
                Form1_Load(sender, e); // Refresh Data
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new StudentContextDB())
            {
                string id = txtStudentID.Text;
                var student = context.Students.Find(id);
                if (student != null)
                {
                    student.FullName = txtFullName.Text;
                    student.AverageScore = float.Parse(txtAverageScore.Text);
                    student.FacultyID = (int)cboFaculty.SelectedValue;

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    Form1_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new StudentContextDB())
            {
                int id = int.Parse(txtStudentID.Text);
                var student = context.Students.Find(id);
                if (student != null)
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        MessageBox.Show("Xóa sinh viên thành công!");
                        Form1_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV cần xóa!");
                }
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtAverageScore.Text = row.Cells["AverageScore"].Value.ToString();
                cboFaculty.Text = row.Cells["FacultyName"].Value.ToString();
            }
        }
    }
}
