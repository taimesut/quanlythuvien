namespace QuanLyThuVien.GUIs
{
    partial class frmSach
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
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.picBoxAnh = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNamXuatBan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNhaXuatBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblMaTheLoai = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAnh)).BeginInit();
            this.panelButton.SuspendLayout();
            this.panelDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 0);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(978, 392);
            this.dgvSach.TabIndex = 0;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.panelInput, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 207);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.label8);
            this.panelInput.Controls.Add(this.picBoxAnh);
            this.panelInput.Controls.Add(this.label7);
            this.panelInput.Controls.Add(this.txtTimKiem);
            this.panelInput.Controls.Add(this.cboTheLoai);
            this.panelInput.Controls.Add(this.label6);
            this.panelInput.Controls.Add(this.txtSoLuong);
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.txtNamXuatBan);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.txtNhaXuatBan);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.txtTacGia);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.txtTenSach);
            this.panelInput.Controls.Add(this.lblMaTheLoai);
            this.panelInput.Controls.Add(this.txtMaSach);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(3, 3);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(629, 201);
            this.panelInput.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tìm kiếm";
            // 
            // picBoxAnh
            // 
            this.picBoxAnh.Location = new System.Drawing.Point(431, 19);
            this.picBoxAnh.Name = "picBoxAnh";
            this.picBoxAnh.Size = new System.Drawing.Size(177, 130);
            this.picBoxAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxAnh.TabIndex = 17;
            this.picBoxAnh.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(431, 168);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(182, 20);
            this.txtTimKiem.TabIndex = 15;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(109, 68);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(182, 21);
            this.cboTheLoai.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(109, 172);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(182, 20);
            this.txtSoLuong.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Năm xuất bản";
            // 
            // txtNamXuatBan
            // 
            this.txtNamXuatBan.Location = new System.Drawing.Point(109, 146);
            this.txtNamXuatBan.Name = "txtNamXuatBan";
            this.txtNamXuatBan.Size = new System.Drawing.Size(182, 20);
            this.txtNamXuatBan.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhà xuất bản";
            // 
            // txtNhaXuatBan
            // 
            this.txtNhaXuatBan.Location = new System.Drawing.Point(109, 120);
            this.txtNhaXuatBan.Name = "txtNhaXuatBan";
            this.txtNhaXuatBan.Size = new System.Drawing.Size(182, 20);
            this.txtNhaXuatBan.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tác giả";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(109, 94);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(182, 20);
            this.txtTacGia.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thể loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Sách";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(109, 42);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(182, 20);
            this.txtTenSach.TabIndex = 3;
            // 
            // lblMaTheLoai
            // 
            this.lblMaTheLoai.AutoSize = true;
            this.lblMaTheLoai.Location = new System.Drawing.Point(10, 19);
            this.lblMaTheLoai.Name = "lblMaTheLoai";
            this.lblMaTheLoai.Size = new System.Drawing.Size(50, 13);
            this.lblMaTheLoai.TabIndex = 0;
            this.lblMaTheLoai.Text = "Mã Sách";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(109, 16);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(182, 20);
            this.txtMaSach.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnChoose);
            this.panelButton.Controls.Add(this.btnThem);
            this.panelButton.Controls.Add(this.btnCapNhat);
            this.panelButton.Controls.Add(this.btnXoa);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButton.Location = new System.Drawing.Point(638, 3);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(337, 201);
            this.panelButton.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(113, 50);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 30);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "Chọn ảnh";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(15, 50);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 30);
            this.btnCapNhat.TabIndex = 5;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(113, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dgvSach);
            this.panelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGridView.Location = new System.Drawing.Point(3, 216);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(978, 392);
            this.panelDataGridView.TabIndex = 2;
            // 
            // frmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSach";
            this.Text = "frmSach";
            this.Load += new System.EventHandler(this.frmSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAnh)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.panelDataGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblMaTheLoai;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamXuatBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNhaXuatBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox picBoxAnh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChoose;
    }
}