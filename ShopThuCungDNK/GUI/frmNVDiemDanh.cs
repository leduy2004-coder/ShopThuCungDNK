﻿using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class frmNVDiemDanh : Form
    {
        FileXml Fml = new FileXml();
        DiemDanh diemDanh = new DiemDanh();
        public static string maNV = "";

        public frmNVDiemDanh()
        {
            InitializeComponent();
        }

        private void btn_DiemDanh_Click(object sender, EventArgs e)
        {
            // Lấy ngày hiện tại

            DateTime ngayHienTai = DateTime.Today; // Lấy ngày hiện tại, bỏ phần giờ
            // Kiểm tra xem nhân viên đã điểm danh hôm nay chưa
            DataTable dtDiemDanh = Fml.HienThi("DiemDanh.xml");
            int maNVInt = int.Parse(maNV); 
            DataRow[] rows = dtDiemDanh.Select(
         $"maNV = {maNVInt} AND ngayDiemDanh >= #{ngayHienTai}#"
     );


            if (rows.Length > 0)
            {
                MessageBox.Show("Bạn đã điểm danh hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu chưa điểm danh, thêm điểm danh mới
                int maDiemDanh = Fml.LayMaxValueFromXml("DiemDanh.xml", "maDiemDanh");

                // Gọi hàm thêm điểm danh
                diemDanh.ThemDiemDanh(maDiemDanh.ToString(), maNV, ngayHienTai);

                MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmNVTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
