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
    public partial class SoanVanBan : Form
    {
        public SoanVanBan()
        {
            InitializeComponent();
        }

        private string currentFilePath = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {

                tSCBFont.Items.Add(font.Name);
            }
            for (int size = 8; size <= 72; size++)
            {
                tSCBSize.Items.Add(size);
            }
            richTextBox1.Font = new System.Drawing.Font("Tomaha", 14);
            tSCBFont.SelectedItem = "Tahoma";
            tSCBSize.SelectedItem = 14;

        }

        private void tSBtnNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new System.Drawing.Font("Tomaha", 14);
            tSCBFont.SelectedItem = "Tahoma";
            tSCBSize.SelectedItem = 14;
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new System.Drawing.Font("Tomaha", 14);
            tSCBFont.SelectedItem = "Tahoma";
            tSCBSize.SelectedItem = 14;
            currentFilePath = string.Empty;
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (.txt)|.txt|Rich Text Format (.rtf)|.rtf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở tập tin: " + ex.Message);
                }
            }
        }

        private void tSBtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|.txt|Rich Text Format (.rtf)|.rtf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    currentFilePath = saveFileDialog.FileName; 
                    MessageBox.Show("Lưu thành công!");
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
            else 
            {
                try
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
        }

        private void tSBtnBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void tSBtnItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void tSBtnUnderLine_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|.txt|Rich Text Format (.rtf)|.rtf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    currentFilePath = saveFileDialog.FileName;
                    MessageBox.Show("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDig = new FontDialog();
            fontDig.ShowColor = true;
            fontDig.ShowApply = true;
            fontDig.ShowEffects = true;
            fontDig.ShowHelp = true;
            if (fontDig.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDig.Color;
                richTextBox1.Font = fontDig.Font;
            }
            tSCBFont.Text = fontDig.Font.Name.ToString();
            tSCBSize.Text = fontDig.Font.Size.ToString();
        }

        private void tSCBFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = tSCBFont.SelectedItem.ToString();
            richTextBox1.Font = new Font(a, richTextBox1.Font.Size);
        }

        private void tSCBSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a =(int) tSCBSize.SelectedItem;
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, a);
        }
    }
}