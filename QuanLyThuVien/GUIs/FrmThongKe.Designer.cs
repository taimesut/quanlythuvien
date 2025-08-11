namespace QuanLyThuVien.GUIs
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.chartColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Bảng Thống Kê Thư Viện";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Location = new System.Drawing.Point(760, 12);
            this.btnRefresh.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvSummary
            // 
            this.dgvSummary.Location = new System.Drawing.Point(16, 50);
            this.dgvSummary.Size = new System.Drawing.Size(420, 380);
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // chartColumn
            // 
            this.chartColumn.Location = new System.Drawing.Point(452, 50);
            this.chartColumn.Size = new System.Drawing.Size(440, 200);
            this.chartColumn.TabIndex = 1;
            this.chartColumn.Text = "chartColumn";
            // 
            // chartPie
            // 
            this.chartPie.Location = new System.Drawing.Point(452, 270);
            this.chartPie.Size = new System.Drawing.Size(440, 160);
            this.chartPie.TabIndex = 2;
            this.chartPie.Text = "chartPie";
            // 
            // FrmThongKe
            // 
            this.ClientSize = new System.Drawing.Size(920, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvSummary);
            this.Controls.Add(this.chartColumn);
            this.Controls.Add(this.chartPie);
            this.Name = "FrmThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
