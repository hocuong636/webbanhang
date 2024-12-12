namespace Lab_03_TH
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tSBtnTimKiem = new System.Windows.Forms.ToolStripButton();
            this.tSTBTimKiem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.coSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coTSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coDTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMớiToolStripMenuItem,
            this.toolStripSeparator1,
            this.thoátToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.thêmMớiToolStripMenuItem.Text = "Thêm mới";
            this.thêmMớiToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBtnAdd,
            this.tSBtnTimKiem,
            this.tSTBTimKiem,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBtnAdd
            // 
            this.tSBtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnAdd.Image")));
            this.tSBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnAdd.Name = "tSBtnAdd";
            this.tSBtnAdd.Size = new System.Drawing.Size(100, 24);
            this.tSBtnAdd.Text = "Thêm mới";
            this.tSBtnAdd.Click += new System.EventHandler(this.tSBtnAdd_Click);
            // 
            // tSBtnTimKiem
            // 
            this.tSBtnTimKiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSBtnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnTimKiem.Image")));
            this.tSBtnTimKiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnTimKiem.Name = "tSBtnTimKiem";
            this.tSBtnTimKiem.Size = new System.Drawing.Size(136, 24);
            this.tSBtnTimKiem.Text = "Tìm kiếm theo tên:";
            // 
            // tSTBTimKiem
            // 
            this.tSTBTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tSTBTimKiem.Name = "tSTBTimKiem";
            this.tSTBTimKiem.Size = new System.Drawing.Size(250, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 24);
            this.toolStripButton1.Text = "Tìm Kiếm";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coSTT,
            this.coMSSV,
            this.coTSV,
            this.coKhoa,
            this.coDTB});
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(0, 55);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 51;
            this.dgvStudent.RowTemplate.Height = 24;
            this.dgvStudent.Size = new System.Drawing.Size(800, 395);
            this.dgvStudent.TabIndex = 2;
            // 
            // coSTT
            // 
            this.coSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coSTT.HeaderText = "Số TT";
            this.coSTT.MinimumWidth = 6;
            this.coSTT.Name = "coSTT";
            // 
            // coMSSV
            // 
            this.coMSSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coMSSV.HeaderText = "Mã Số SV";
            this.coMSSV.MinimumWidth = 6;
            this.coMSSV.Name = "coMSSV";
            // 
            // coTSV
            // 
            this.coTSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coTSV.HeaderText = "Tên Sinh Viên";
            this.coTSV.MinimumWidth = 6;
            this.coTSV.Name = "coTSV";
            // 
            // coKhoa
            // 
            this.coKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coKhoa.HeaderText = "Khoa";
            this.coKhoa.MinimumWidth = 6;
            this.coKhoa.Name = "coKhoa";
            // 
            // coDTB
            // 
            this.coDTB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coDTB.HeaderText = "Điểm TB";
            this.coDTB.MinimumWidth = 6;
            this.coDTB.Name = "coDTB";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvStudent);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBtnAdd;
        private System.Windows.Forms.ToolStripButton tSBtnTimKiem;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn coSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn coMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn coTSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn coKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn coDTB;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tSTBTimKiem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}