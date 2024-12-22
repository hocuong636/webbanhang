using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;

namespace B4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date_Start.Value = DateTime.Now;
            date_End.Value = DateTime.Now;
        }
        private void BindGrid1()
        {
            ProductOrderEntities db = new ProductOrderEntities();
            List<Invoice> invoices = db.Invoice.ToList();

            dataGridView1.Rows.Clear(); // Xóa các hàng cũ (nếu có)

            int stt = 1;

            foreach (Invoice i in invoices)
            {
                dataGridView1.Rows.Add(new object[]
                {
            stt++,
            i.InvoiceNo,
            i.OrderDate.ToString("dd/MM/yyyy"),
            i.DeliveryDate.ToString("dd/MM/yyyy"),
            i.Order.Sum(n => n.Quantity * n.Price)
                });
            }

            db.Dispose();
        }

        private void BindGrid2()
        {
            using (ProductOrderEntities db = new ProductOrderEntities())
            {
                List<Invoice> invoices;

                if (checkBox1.Checked)
                {
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                    invoices = db.Invoice
                        .Where(i => i.DeliveryDate >= firstDayOfMonth && i.DeliveryDate <= lastDayOfMonth)
                        .ToList();
                }
                else
                {
                    
                    invoices = db.Invoice.Where(i => i.DeliveryDate >= date_Start.Value.Date &&
                                   i.DeliveryDate <= date_End.Value.Date).ToList();
                }

                int stt = 1;
                dataGridView1.Rows.Clear();

                foreach (Invoice i in invoices)
                {
                    dataGridView1.Rows.Add(new object[]
                    {
                    stt++,
                    i.InvoiceNo,
                    i.OrderDate.ToString("dd/MM/yyyy"),
                    i.DeliveryDate.ToString("dd/MM/yyyy"),
                    i.Order.Sum(n => n.Quantity * n.Price)
                    });
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            date_Start.Enabled = !checkBox1.Checked;
            date_End.Enabled = !checkBox1.Checked;

            if (checkBox1.Checked)
            {
                BindGrid1();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void date_Start_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                BindGrid2();
            }
        }

        private void date_End_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                BindGrid2();
            }
        }
    }
}
