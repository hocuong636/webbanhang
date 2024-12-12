namespace Lab_02_TH
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textAsset = new System.Windows.Forms.TextBox();
            this.buttonInsertUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.customerList = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.textSumAsset = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(428, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(259, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(233, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(209, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(184, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số tiền trong tài khoản";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(435, 115);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(550, 22);
            this.textId.TabIndex = 5;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(435, 167);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(550, 22);
            this.textName.TabIndex = 6;
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(435, 215);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(550, 22);
            this.textAddress.TabIndex = 7;
            // 
            // textAsset
            // 
            this.textAsset.Location = new System.Drawing.Point(435, 264);
            this.textAsset.Name = "textAsset";
            this.textAsset.Size = new System.Drawing.Size(550, 22);
            this.textAsset.TabIndex = 8;
            // 
            // buttonInsertUpdate
            // 
            this.buttonInsertUpdate.Location = new System.Drawing.Point(608, 309);
            this.buttonInsertUpdate.Name = "buttonInsertUpdate";
            this.buttonInsertUpdate.Size = new System.Drawing.Size(163, 33);
            this.buttonInsertUpdate.TabIndex = 9;
            this.buttonInsertUpdate.Text = "Thêm / Cập nhật";
            this.buttonInsertUpdate.UseVisualStyleBackColor = true;
            this.buttonInsertUpdate.Click += new System.EventHandler(this.buttonInsertUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(792, 309);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 33);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(901, 309);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 33);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // customerList
            // 
            this.customerList.AllowUserToAddRows = false;
            this.customerList.AllowUserToDeleteRows = false;
            this.customerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.maTaiKhoan,
            this.tenKhachHang,
            this.diaChi,
            this.soTien});
            this.customerList.Location = new System.Drawing.Point(12, 359);
            this.customerList.Name = "customerList";
            this.customerList.ReadOnly = true;
            this.customerList.RowHeadersWidth = 51;
            this.customerList.RowTemplate.Height = 24;
            this.customerList.Size = new System.Drawing.Size(1282, 431);
            this.customerList.TabIndex = 12;
            this.customerList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customerList_CellMouseClick);
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // maTaiKhoan
            // 
            this.maTaiKhoan.HeaderText = "Mã tài khoản";
            this.maTaiKhoan.MinimumWidth = 6;
            this.maTaiKhoan.Name = "maTaiKhoan";
            this.maTaiKhoan.ReadOnly = true;
            // 
            // tenKhachHang
            // 
            this.tenKhachHang.HeaderText = "Tên khách hàng";
            this.tenKhachHang.MinimumWidth = 6;
            this.tenKhachHang.Name = "tenKhachHang";
            this.tenKhachHang.ReadOnly = true;
            // 
            // diaChi
            // 
            this.diaChi.HeaderText = "Địa chỉ";
            this.diaChi.MinimumWidth = 6;
            this.diaChi.Name = "diaChi";
            this.diaChi.ReadOnly = true;
            // 
            // soTien
            // 
            this.soTien.HeaderText = "Số tiền";
            this.soTien.MinimumWidth = 6;
            this.soTien.Name = "soTien";
            this.soTien.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(798, 807);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tổng tiền: ";
            // 
            // textSumAsset
            // 
            this.textSumAsset.Location = new System.Drawing.Point(901, 804);
            this.textSumAsset.Name = "textSumAsset";
            this.textSumAsset.ReadOnly = true;
            this.textSumAsset.Size = new System.Drawing.Size(358, 22);
            this.textSumAsset.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 904);
            this.Controls.Add(this.textSumAsset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerList);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonInsertUpdate);
            this.Controls.Add(this.textAsset);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textAsset;
        private System.Windows.Forms.Button buttonInsertUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView customerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn maTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSumAsset;
    }
}

