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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                float result = number1 - number2;
                txtAnswer.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                float result = number1 + number2;
                txtAnswer.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                double result = number1 * number2;
                txtAnswer.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNumber1.Text);
                float number2 = float.Parse(txtNumber2.Text);
                double result = Math.Round((number1 / number2), 2);
                txtAnswer.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
