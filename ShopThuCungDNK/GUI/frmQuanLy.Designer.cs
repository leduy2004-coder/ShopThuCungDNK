using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    partial class frmQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLy));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_ChuyenDoi = new System.Windows.Forms.Button();
            this.btn_giayChungNhan = new System.Windows.Forms.Button();
            this.btn_thanhToan = new System.Windows.Forms.Button();
            this.btn_nhaCc = new System.Windows.Forms.Button();
            this.btn_hoaDon = new System.Windows.Forms.Button();
            this.btn_thuCung = new System.Windows.Forms.Button();
            this.btn_Kh = new System.Windows.Forms.Button();
            this.btn_thongKe = new System.Windows.Forms.Button();
            this.btn_Loai = new System.Windows.Forms.Button();
            this.btn_NV = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_Name = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_DiemDanh = new System.Windows.Forms.Button();
            this.panelDesktop.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelDesktop.Controls.Add(this.panelMain);
            this.panelDesktop.Controls.Add(this.panelTitleBar);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(224, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1126, 759);
            this.panelDesktop.TabIndex = 5;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1126, 699);
            this.panelMain.TabIndex = 5;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Padding = new System.Windows.Forms.Padding(30, 10, 10, 10);
            this.panelTitleBar.Size = new System.Drawing.Size(1126, 60);
            this.panelTitleBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(809, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ SHOP THÚ CƯNG - QUẢN LÝ";
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.DarkMagenta;
            this.panelMenu.Controls.Add(this.btn_DiemDanh);
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btn_ChuyenDoi);
            this.panelMenu.Controls.Add(this.btn_giayChungNhan);
            this.panelMenu.Controls.Add(this.btn_thanhToan);
            this.panelMenu.Controls.Add(this.btn_nhaCc);
            this.panelMenu.Controls.Add(this.btn_hoaDon);
            this.panelMenu.Controls.Add(this.btn_thuCung);
            this.panelMenu.Controls.Add(this.btn_Kh);
            this.panelMenu.Controls.Add(this.btn_thongKe);
            this.panelMenu.Controls.Add(this.btn_Loai);
            this.panelMenu.Controls.Add(this.btn_NV);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.panelMenu.Size = new System.Drawing.Size(224, 759);
            this.panelMenu.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkViolet;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 791);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(203, 49);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "  Đăng xuất";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btn_ChuyenDoi
            // 
            this.btn_ChuyenDoi.BackColor = System.Drawing.Color.Transparent;
            this.btn_ChuyenDoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChuyenDoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ChuyenDoi.FlatAppearance.BorderSize = 0;
            this.btn_ChuyenDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChuyenDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChuyenDoi.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_ChuyenDoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ChuyenDoi.Location = new System.Drawing.Point(0, 733);
            this.btn_ChuyenDoi.Name = "btn_ChuyenDoi";
            this.btn_ChuyenDoi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_ChuyenDoi.Size = new System.Drawing.Size(203, 58);
            this.btn_ChuyenDoi.TabIndex = 14;
            this.btn_ChuyenDoi.Text = "  Chuyển đổi ";
            this.btn_ChuyenDoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ChuyenDoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ChuyenDoi.UseVisualStyleBackColor = false;
            this.btn_ChuyenDoi.Click += new System.EventHandler(this.btn_ChuyenDoi_Click);
            // 
            // btn_giayChungNhan
            // 
            this.btn_giayChungNhan.BackColor = System.Drawing.Color.Transparent;
            this.btn_giayChungNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_giayChungNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_giayChungNhan.FlatAppearance.BorderSize = 0;
            this.btn_giayChungNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_giayChungNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_giayChungNhan.ForeColor = System.Drawing.Color.White;
            this.btn_giayChungNhan.Image = ((System.Drawing.Image)(resources.GetObject("btn_giayChungNhan.Image")));
            this.btn_giayChungNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_giayChungNhan.Location = new System.Drawing.Point(0, 675);
            this.btn_giayChungNhan.Name = "btn_giayChungNhan";
            this.btn_giayChungNhan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_giayChungNhan.Size = new System.Drawing.Size(203, 58);
            this.btn_giayChungNhan.TabIndex = 13;
            this.btn_giayChungNhan.Text = "  Giấy chứng nhận";
            this.btn_giayChungNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_giayChungNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_giayChungNhan.UseVisualStyleBackColor = false;
            this.btn_giayChungNhan.Click += new System.EventHandler(this.btn_giayChungNhan_Click);
            // 
            // btn_thanhToan
            // 
            this.btn_thanhToan.BackColor = System.Drawing.Color.Transparent;
            this.btn_thanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_thanhToan.FlatAppearance.BorderSize = 0;
            this.btn_thanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thanhToan.ForeColor = System.Drawing.Color.White;
            this.btn_thanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btn_thanhToan.Image")));
            this.btn_thanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thanhToan.Location = new System.Drawing.Point(0, 617);
            this.btn_thanhToan.Name = "btn_thanhToan";
            this.btn_thanhToan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_thanhToan.Size = new System.Drawing.Size(203, 58);
            this.btn_thanhToan.TabIndex = 12;
            this.btn_thanhToan.Text = "  Thanh toán";
            this.btn_thanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_thanhToan.UseVisualStyleBackColor = false;
            this.btn_thanhToan.Click += new System.EventHandler(this.btn_thanhToan_Click);
            // 
            // btn_nhaCc
            // 
            this.btn_nhaCc.BackColor = System.Drawing.Color.Transparent;
            this.btn_nhaCc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nhaCc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_nhaCc.FlatAppearance.BorderSize = 0;
            this.btn_nhaCc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nhaCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhaCc.ForeColor = System.Drawing.Color.White;
            this.btn_nhaCc.Image = ((System.Drawing.Image)(resources.GetObject("btn_nhaCc.Image")));
            this.btn_nhaCc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nhaCc.Location = new System.Drawing.Point(0, 559);
            this.btn_nhaCc.Name = "btn_nhaCc";
            this.btn_nhaCc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_nhaCc.Size = new System.Drawing.Size(203, 58);
            this.btn_nhaCc.TabIndex = 11;
            this.btn_nhaCc.Text = "  Nhà cung cấp";
            this.btn_nhaCc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nhaCc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_nhaCc.UseVisualStyleBackColor = false;
            this.btn_nhaCc.Click += new System.EventHandler(this.btn_nhaCc_Click);
            // 
            // btn_hoaDon
            // 
            this.btn_hoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btn_hoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_hoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_hoaDon.FlatAppearance.BorderSize = 0;
            this.btn_hoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_hoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btn_hoaDon.Image")));
            this.btn_hoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hoaDon.Location = new System.Drawing.Point(0, 501);
            this.btn_hoaDon.Name = "btn_hoaDon";
            this.btn_hoaDon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_hoaDon.Size = new System.Drawing.Size(203, 58);
            this.btn_hoaDon.TabIndex = 10;
            this.btn_hoaDon.Text = "  Hóa đơn";
            this.btn_hoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_hoaDon.UseVisualStyleBackColor = false;
            this.btn_hoaDon.Click += new System.EventHandler(this.btn_hoaDon_Click);
            // 
            // btn_thuCung
            // 
            this.btn_thuCung.BackColor = System.Drawing.Color.Transparent;
            this.btn_thuCung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thuCung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_thuCung.FlatAppearance.BorderSize = 0;
            this.btn_thuCung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thuCung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thuCung.ForeColor = System.Drawing.Color.White;
            this.btn_thuCung.Image = ((System.Drawing.Image)(resources.GetObject("btn_thuCung.Image")));
            this.btn_thuCung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thuCung.Location = new System.Drawing.Point(0, 443);
            this.btn_thuCung.Name = "btn_thuCung";
            this.btn_thuCung.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_thuCung.Size = new System.Drawing.Size(203, 58);
            this.btn_thuCung.TabIndex = 9;
            this.btn_thuCung.Text = "  Thú cưng";
            this.btn_thuCung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thuCung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_thuCung.UseVisualStyleBackColor = false;
            this.btn_thuCung.Click += new System.EventHandler(this.btn_thuCung_Click);
            // 
            // btn_Kh
            // 
            this.btn_Kh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Kh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Kh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Kh.FlatAppearance.BorderSize = 0;
            this.btn_Kh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Kh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Kh.ForeColor = System.Drawing.Color.White;
            this.btn_Kh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Kh.Image")));
            this.btn_Kh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Kh.Location = new System.Drawing.Point(0, 385);
            this.btn_Kh.Name = "btn_Kh";
            this.btn_Kh.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Kh.Size = new System.Drawing.Size(203, 58);
            this.btn_Kh.TabIndex = 8;
            this.btn_Kh.Text = "  Khách hàng";
            this.btn_Kh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Kh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Kh.UseVisualStyleBackColor = false;
            this.btn_Kh.Click += new System.EventHandler(this.btn_Kh_Click);
            // 
            // btn_thongKe
            // 
            this.btn_thongKe.BackColor = System.Drawing.Color.Transparent;
            this.btn_thongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_thongKe.FlatAppearance.BorderSize = 0;
            this.btn_thongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thongKe.ForeColor = System.Drawing.Color.White;
            this.btn_thongKe.Image = ((System.Drawing.Image)(resources.GetObject("btn_thongKe.Image")));
            this.btn_thongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thongKe.Location = new System.Drawing.Point(0, 327);
            this.btn_thongKe.Name = "btn_thongKe";
            this.btn_thongKe.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_thongKe.Size = new System.Drawing.Size(203, 58);
            this.btn_thongKe.TabIndex = 5;
            this.btn_thongKe.Text = "  Thống kê";
            this.btn_thongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_thongKe.UseVisualStyleBackColor = false;
            this.btn_thongKe.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Loai
            // 
            this.btn_Loai.BackColor = System.Drawing.Color.Transparent;
            this.btn_Loai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Loai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Loai.FlatAppearance.BorderSize = 0;
            this.btn_Loai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Loai.ForeColor = System.Drawing.Color.White;
            this.btn_Loai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Loai.Location = new System.Drawing.Point(0, 269);
            this.btn_Loai.Name = "btn_Loai";
            this.btn_Loai.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Loai.Size = new System.Drawing.Size(203, 58);
            this.btn_Loai.TabIndex = 4;
            this.btn_Loai.Text = "  Loài";
            this.btn_Loai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Loai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Loai.UseVisualStyleBackColor = false;
            this.btn_Loai.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btn_NV
            // 
            this.btn_NV.BackColor = System.Drawing.Color.Transparent;
            this.btn_NV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_NV.FlatAppearance.BorderSize = 0;
            this.btn_NV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NV.ForeColor = System.Drawing.Color.White;
            this.btn_NV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NV.Location = new System.Drawing.Point(0, 211);
            this.btn_NV.Name = "btn_NV";
            this.btn_NV.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_NV.Size = new System.Drawing.Size(203, 58);
            this.btn_NV.TabIndex = 1;
            this.btn_NV.Text = "  Nhân viên";
            this.btn_NV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_NV.UseVisualStyleBackColor = false;
            this.btn_NV.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 150);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(203, 61);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "  Trang chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 150);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_Name);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(203, 43);
            this.panel2.TabIndex = 0;
            // 
            // lb_Name
            // 
            this.lb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Name.AutoSize = true;
            this.lb_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Name.ForeColor = System.Drawing.Color.White;
            this.lb_Name.Location = new System.Drawing.Point(34, 0);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(74, 25);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "Lê Duy";
            this.lb_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(148, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btn_DiemDanh
            // 
            this.btn_DiemDanh.BackColor = System.Drawing.Color.Transparent;
            this.btn_DiemDanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DiemDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_DiemDanh.FlatAppearance.BorderSize = 0;
            this.btn_DiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DiemDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DiemDanh.ForeColor = System.Drawing.Color.White;
            this.btn_DiemDanh.Image = ((System.Drawing.Image)(resources.GetObject("btn_DiemDanh.Image")));
            this.btn_DiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DiemDanh.Location = new System.Drawing.Point(0, 840);
            this.btn_DiemDanh.Name = "btn_DiemDanh";
            this.btn_DiemDanh.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_DiemDanh.Size = new System.Drawing.Size(203, 58);
            this.btn_DiemDanh.TabIndex = 16;
            this.btn_DiemDanh.Text = "  Điểm danh";
            this.btn_DiemDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_DiemDanh.UseVisualStyleBackColor = false;
            this.btn_DiemDanh.Click += new System.EventHandler(this.btn_DiemDanh_Click);
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 759);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmQuanLy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuanLy_Load);
            this.panelDesktop.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btn_NV;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btn_Loai;
        private System.Windows.Forms.Button btn_thongKe;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btn_ChuyenDoi;
        private System.Windows.Forms.Button btn_giayChungNhan;
        private System.Windows.Forms.Button btn_thanhToan;
        private System.Windows.Forms.Button btn_nhaCc;
        private System.Windows.Forms.Button btn_hoaDon;
        private System.Windows.Forms.Button btn_thuCung;
        private System.Windows.Forms.Button btn_Kh;
        private Button btn_DiemDanh;
    }
}