using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace B1
{
    public partial class frmFalculty : Form
    {
        public frmFalculty()
        {
            InitializeComponent();
        }
        private void frmFalculty_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<Faculty> faculties = db.Faculty.ToList();

            dataGridView1.Rows.Clear();

            foreach (Faculty f in faculties)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    f.FacultyID,
                    f.FacultyName,
                    f.TotalProfessor
                });
            }
            ClearInputFields();
            db.Dispose();
        }
        private void ClearInputFields()
        {
            txt_FacultyID.Text = string.Empty;
            txt_FacultyName.Text = string.Empty;
            txt_TotalProfessor.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    txt_FacultyID.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    txt_FacultyName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    if (selectedRow.Cells.Count > 2)
                    {
                        var totalProfessorValue = selectedRow.Cells[2]?.Value;
                        txt_TotalProfessor.Text = totalProfessorValue != null ? totalProfessorValue.ToString() : "0";
                    }
                    else
                    {
                        txt_TotalProfessor.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thêm_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLySinhVienEntities())
            {
                if (string.IsNullOrWhiteSpace(txt_FacultyName.Text) ||
                    string.IsNullOrWhiteSpace(txt_FacultyID.Text) ||
                    string.IsNullOrWhiteSpace(txt_TotalProfessor.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
                if (dataGridView1.SelectedRows.Count == 0) 
                {
                    try
                    {
                        if (!int.TryParse(txt_FacultyID.Text, out int newFacultyID))
                        {
                            MessageBox.Show("ID khoa không hợp lệ!");
                            return;
                        }
                        if (!int.TryParse(txt_TotalProfessor.Text, out int totalProfessorValue))
                        {
                            MessageBox.Show("Số lượng giảng viên không hợp lệ!");
                            return;
                        }
                        var newFaculty = new Faculty
                        {
                            FacultyID = newFacultyID,
                            FacultyName = txt_FacultyName.Text,
                            TotalProfessor = totalProfessorValue
                        };
                        if (db.Faculty.Any(f => f.FacultyID == newFacultyID))
                        {
                            MessageBox.Show("ID khoa đã tồn tại, vui lòng nhập ID khác.");
                            return;
                        }
                        db.Faculty.Add(newFaculty);
                        db.SaveChanges();

                        MessageBox.Show("Thêm khoa mới thành công!");
                        BindGrid(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    try
                    {
                        if (!int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value?.ToString(), out int FacultyID))
                        {
                            MessageBox.Show("ID khoa không hợp lệ!");
                            return;
                        }
                        var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID == FacultyID);
                        if (faculty == null)
                        {
                            MessageBox.Show("Không tìm thấy khoa!");
                            return;
                        }
                        faculty.FacultyName = txt_FacultyName.Text;
                        if (!int.TryParse(txt_FacultyID.Text, out int updatedFacultyID))
                        {
                            MessageBox.Show("ID khoa không hợp lệ!");
                            return;
                        }
                        faculty.FacultyID = updatedFacultyID;
                        if (!int.TryParse(txt_TotalProfessor.Text, out int totalProfessorValue))
                        {
                            MessageBox.Show("Số lượng giảng viên không hợp lệ!");
                            return;
                        }
                        faculty.TotalProfessor = totalProfessorValue;
                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin khoa thành công!");
                        BindGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                db.Dispose();
            }
        }

        private void xóa_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLySinhVienEntities())
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa cần xóa!");
                    return;
                }
                if (!int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value?.ToString(), out int FacultyID))
                {
                    MessageBox.Show("ID khoa không hợp lệ!");
                    return;
                }
                var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID == FacultyID);
                if (faculty == null)
                {
                    MessageBox.Show("Không tìm thấy khoa!");
                    return;
                }
                var result = MessageBox.Show("Bạn có chắc muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        db.Faculty.Remove(faculty);
                        db.SaveChanges();

                        MessageBox.Show("Xóa khoa thành công!");
                        BindGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                db.Dispose();
            }

        }
    }
}
