using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_03_TH
{
    public partial class Form2_NhapSV : Form
    {
        public Student NewStudent { get; private set; }

        public Form2_NhapSV()
        {
            InitializeComponent();
            this.AcceptButton = btnThemMoi;
            this.CancelButton = btnThoat;
        }

        void setNull()
        {
            txtMSSV.Text = "";
            txtTenSV.Text = "";
            cmbKhoa.Text = "Công nghệ thông tin";
            txtDTB.Text = "";
            txtMSSV.Focus();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) || string.IsNullOrWhiteSpace(txtTenSV.Text) || cmbKhoa.SelectedIndex == -1 || !double.TryParse(txtDTB.Text, out double gpa) || gpa < 0 || gpa > 10)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NewStudent = new Student
            {
                StudentID = txtMSSV.Text.Trim(),
                StudentName = txtTenSV.Text.Trim(),
                Faculty = cmbKhoa.SelectedItem.ToString(),
                GPA = gpa
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
            Form2 f2 = (Form2)Application.OpenForms["Form2"].FindForm();
            f2.Show();
            f2.tSBtnTimKiem_Click();
            setNull();  
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = (Form2)Application.OpenForms["Form2"].FindForm();
            f2.Show();
        }
    }
}
