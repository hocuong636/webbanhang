namespace B1
{
    partial class frmFalculty
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
            this.btn_close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FacultyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalProfessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TotalProfessor = new System.Windows.Forms.TextBox();
            this.txt_FacultyName = new System.Windows.Forms.TextBox();
            this.txt_FacultyID = new System.Windows.Forms.TextBox();
            this.thêm = new System.Windows.Forms.Button();
            this.xóa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(892, 291);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Đóng";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacultyID,
            this.FacultyName,
            this.TotalProfessor});
            this.dataGridView1.Location = new System.Drawing.Point(352, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(615, 242);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // FacultyID
            // 
            this.FacultyID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FacultyID.HeaderText = "Mã Khoa";
            this.FacultyID.MinimumWidth = 6;
            this.FacultyID.Name = "FacultyID";
            // 
            // FacultyName
            // 
            this.FacultyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FacultyName.HeaderText = "Tên Khoa";
            this.FacultyName.MinimumWidth = 6;
            this.FacultyName.Name = "FacultyName";
            // 
            // TotalProfessor
            // 
            this.TotalProfessor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalProfessor.HeaderText = "Tổng số GS";
            this.TotalProfessor.MinimumWidth = 6;
            this.TotalProfessor.Name = "TotalProfessor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_TotalProfessor);
            this.groupBox1.Controls.Add(this.txt_FacultyName);
            this.groupBox1.Controls.Add(this.txt_FacultyID);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(18, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 168);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(15, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng số GS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Khoa";
            // 
            // txt_TotalProfessor
            // 
            this.txt_TotalProfessor.Location = new System.Drawing.Point(103, 131);
            this.txt_TotalProfessor.Name = "txt_TotalProfessor";
            this.txt_TotalProfessor.Size = new System.Drawing.Size(217, 22);
            this.txt_TotalProfessor.TabIndex = 5;
            // 
            // txt_FacultyName
            // 
            this.txt_FacultyName.Location = new System.Drawing.Point(103, 83);
            this.txt_FacultyName.Name = "txt_FacultyName";
            this.txt_FacultyName.Size = new System.Drawing.Size(217, 22);
            this.txt_FacultyName.TabIndex = 4;
            // 
            // txt_FacultyID
            // 
            this.txt_FacultyID.Location = new System.Drawing.Point(103, 35);
            this.txt_FacultyID.Name = "txt_FacultyID";
            this.txt_FacultyID.Size = new System.Drawing.Size(217, 22);
            this.txt_FacultyID.TabIndex = 3;
            // 
            // thêm
            // 
            this.thêm.AutoSize = true;
            this.thêm.Location = new System.Drawing.Point(131, 239);
            this.thêm.Name = "thêm";
            this.thêm.Size = new System.Drawing.Size(80, 26);
            this.thêm.TabIndex = 5;
            this.thêm.Text = "Thêm/Sửa";
            this.thêm.UseVisualStyleBackColor = true;
            this.thêm.Click += new System.EventHandler(this.thêm_Click);
            // 
            // xóa
            // 
            this.xóa.Location = new System.Drawing.Point(263, 239);
            this.xóa.Name = "xóa";
            this.xóa.Size = new System.Drawing.Size(80, 26);
            this.xóa.TabIndex = 7;
            this.xóa.Text = "Xóa";
            this.xóa.UseVisualStyleBackColor = true;
            this.xóa.Click += new System.EventHandler(this.xóa_Click);
            // 
            // frmFalculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 329);
            this.Controls.Add(this.xóa);
            this.Controls.Add(this.thêm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_close);
            this.Name = "frmFalculty";
            this.Text = "Quản lý khoa";
            this.Load += new System.EventHandler(this.frmFalculty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FacultyName;
        private System.Windows.Forms.TextBox txt_FacultyID;
        private System.Windows.Forms.Button thêm;
        private System.Windows.Forms.Button xóa;
        private System.Windows.Forms.TextBox txt_TotalProfessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacultyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacultyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalProfessor;
    }
}