using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_02_TH
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cmbFaculty.SelectedIndex = 0;
            dgvStudent.CellClick += dgvStudent_CellClick;
            ckbMale.CheckedChanged += ckbMale_CheckedChanged;
            ckbFemale.CheckedChanged += ckbFemale_CheckedChanged;
        }

        private int GetSelectedRows(string studentID)
        {
            if (string.IsNullOrEmpty(studentID)) return -1;
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                var cellValue = dgvStudent.Rows[i].Cells[0].Value;
                if (cellValue != null && cellValue.ToString() == studentID) return i;
            }
            return -1;
        }

        private void InsertUpdate(int selectedRows)
        {
            dgvStudent.Rows[selectedRows].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRows].Cells[1].Value = txtFullName.Text;
            dgvStudent.Rows[selectedRows].Cells[2].Value = ckbFemale.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[selectedRows].Cells[3].Value = float.Parse(txtAverageScore.Text).ToString();
            dgvStudent.Rows[selectedRows].Cells[4].Value = cmbFaculty.Text;
        }

        void setNull()
        {
            txtStudentID.Text = "";
            txtFullName.Text = "";
            txtAverageScore.Text = "";
            ckbMale.Checked = false;
            ckbFemale.Checked = true;
            txtStudentID.Focus();
            cmbFaculty.Text = "QTKD";
        }

        private void UpdateGenderCount()
        {
            int maleCount = 0;
            int femaleCount = 0;
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    string gender = row.Cells[2].Value.ToString();
                    if (gender == "Nam") maleCount++;
                    else if (gender == "Nữ") femaleCount++;
                }
            }
            txtSumMale.Text = $"{maleCount}";
            txtSumFemale.Text = $"{femaleCount}";
        }

        private void ckbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMale.Checked) ckbFemale.Checked = false;
        }

        private void ckbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFemale.Checked) ckbMale.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || txtFullName.Text == "" || txtAverageScore.Text == "") throw new Exception("Vui lòng nhập đầy đủ thông tin sinh viên!");
                int selectedRow = GetSelectedRows(txtStudentID.Text);
                if (selectedRow == -1)
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm mới dữu liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    UpdateGenderCount();
                    setNull();
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    UpdateGenderCount();
                    setNull();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRows(txtStudentID.Text);
                if (selectedRow == -1) throw new Exception("Không tìm thấy MSSV cần xóa!");
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                        UpdateGenderCount();
                        setNull();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvStudent.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];
                    txtStudentID.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    txtFullName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    ckbFemale.Checked = selectedRow.Cells[2].Value?.ToString() == "Nữ";
                    ckbMale.Checked = selectedRow.Cells[2].Value?.ToString() == "Nam";
                    txtAverageScore.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                    cmbFaculty.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
