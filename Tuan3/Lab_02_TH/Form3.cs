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
    public partial class Form3 : Form
    {
        int soluongghe = 20;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            KhoiTaoGhe();
        }

        private void KhoiTaoGhe()
        {
            Button btn;
            int x = 20, y = 20;
            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < soluongghe / 4; j++)
                {
                    btn = new Button();
                    btn.Location = new System.Drawing.Point(x + 80 * j, y + 46 * i);
                    btn.Name = "btn" + count;
                    btn.Size = new System.Drawing.Size(80, 46);
                    btn.TabIndex = 0;
                    btn.Text = count.ToString();
                    btn.UseVisualStyleBackColor = true;
                    btn.BackColor = Color.White;
                    btn.Click += BtnGhe_Click;
                    groupBox1.Controls.Add(btn);
                    count++;
                }
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế này đã được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Blue;
                TinhTong();
            }
            else btn.BackColor = Color.White;
        }

        private double LayGiaVe(int gheSo)
        {
            if (gheSo <= 5) return 30000;
            if (gheSo <= 10) return 40000;
            if (gheSo <= 15) return 50000;
            return 80000;
        }

        private void TinhTong()
        {
            double tongTien = 0;
            foreach (Button btnGhe in groupBox1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Blue))
            {
                tongTien += LayGiaVe(int.Parse(btnGhe.Text));
            }
            txtThanhTien.Text = $"{tongTien:N0} đ";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (Button btnGhe in groupBox1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Blue))
            {
                btnGhe.BackColor = Color.White;
            }
            txtThanhTien.Text = "0 đ";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            double tongTien = 0;
            DialogResult result = MessageBox.Show("Bạn có muốn xác nhận các ghế đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                foreach (Button btnGhe in groupBox1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Blue))
                {
                    tongTien += LayGiaVe(int.Parse(btnGhe.Text));
                    btnGhe.BackColor = Color.Yellow;
                }
            }
            txtThanhTien.Text = $"{tongTien:N0} đ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
