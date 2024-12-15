using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQuanLy : Form
    {
        Main M = new Main();

        public static string tenDNMain = "";
        public static string maNVMain = "";
        public static string role = "";

        public frmQuanLy()
        {
            InitializeComponent();
            HienThiTrangChu();

        }
        void ThongTinDangNhap()
        {
            lb_Name.Text = tenDNMain;
        }


        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            ThongTinDangNhap();
            if (role.Equals("2"))
            {
                btn_thongKe.Visible = false;
                btn_Loai.Visible = false;
                btn_NV.Visible = false;
                btn_nhaCc.Visible = false;

                lbTitle.Text = "HỆ THỐNG QUẢN LÝ SHOP THÚ CƯNG - NHÂN VIÊN";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmQLNhanVienTab frmQLNhanVien = new frmQLNhanVienTab();
            frmQLNhanVien.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmQLNhanVien.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmQLNhanVien);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmQLNhanVien.BringToFront();

            frmQLNhanVien.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            HienThiTrangChu();
        }
        private void HienThiTrangChu()
        {
            if (role.Equals("2"))
            {
                frmNVDiemDanh frmNVDiemDanh = new frmNVDiemDanh();
                frmNVDiemDanh.TopLevel = false;
                frmNVDiemDanh.maNV = maNVMain;
                if (panelMain.Controls.Count > 0)
                {
                    panelMain.Controls.Clear();
                }

                // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
                frmNVDiemDanh.Size = panelMain.ClientSize;


                panelMain.Controls.Add(frmNVDiemDanh);

                // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
                frmNVDiemDanh.BringToFront();

                frmNVDiemDanh.Show();
            }
            else
            {
                frmQLTrangChu frmQLLoaiThuCung = new frmQLTrangChu();
                frmQLLoaiThuCung.TopLevel = false;

                if (panelMain.Controls.Count > 0)
                {
                    panelMain.Controls.Clear();
                }

                // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
                frmQLLoaiThuCung.Size = panelMain.ClientSize;


                panelMain.Controls.Add(frmQLLoaiThuCung);

                // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
                frmQLLoaiThuCung.BringToFront();

                frmQLLoaiThuCung.Show();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            frmQLLoaiThuCung frmQLLoaiThuCung = new frmQLLoaiThuCung();
            frmQLLoaiThuCung.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmQLLoaiThuCung.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmQLLoaiThuCung);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmQLLoaiThuCung.BringToFront();

            frmQLLoaiThuCung.Show();
        }



        private void btn_Kh_Click(object sender, EventArgs e)
        {
            frmNVKhachHang frmNVKhachHang = new frmNVKhachHang();
            frmNVKhachHang.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVKhachHang.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmNVKhachHang);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVKhachHang.BringToFront();

            frmNVKhachHang.Show();
        }

        private void btn_thuCung_Click(object sender, EventArgs e)
        {
            frmNVThuCung frmNVThuCung = new frmNVThuCung();
            frmNVThuCung.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVThuCung.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmNVThuCung);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVThuCung.BringToFront();

            frmNVThuCung.Show();
        }

        private void btn_hoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.TopLevel = false;
            frmHoaDon.tenNVMain = tenDNMain;
            frmHoaDon.role = role;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmHoaDon.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmHoaDon);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmHoaDon.BringToFront();

            frmHoaDon.Show();
        }

        private void btn_nhaCc_Click(object sender, EventArgs e)
        {
            frmNVNhaCungCap frmNVNhaCungCap = new frmNVNhaCungCap();
            frmNVNhaCungCap.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVNhaCungCap.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmNVNhaCungCap);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVNhaCungCap.BringToFront();

            frmNVNhaCungCap.Show();

        }

        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            frmNVThanhToan frmNVThanhToan = new frmNVThanhToan();
            frmNVThanhToan.TopLevel = false;
            frmNVThanhToan.maNVMain = maNVMain;
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVThanhToan.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmNVThanhToan);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVThanhToan.BringToFront();

            frmNVThanhToan.Show();
        }

        private void btn_giayChungNhan_Click(object sender, EventArgs e)
        {
            frmNVGiayChungNhan frmNVGiayChungNhan = new frmNVGiayChungNhan();
            frmNVGiayChungNhan.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVGiayChungNhan.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmNVGiayChungNhan);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVGiayChungNhan.BringToFront();

            frmNVGiayChungNhan.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private void btn_ChuyenDoi_Click(object sender, EventArgs e)
        {
            frmQLChuyenDoi frmQLLoaiThuCung = new frmQLChuyenDoi();
            frmQLLoaiThuCung.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmQLLoaiThuCung.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmQLLoaiThuCung);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmQLLoaiThuCung.BringToFront();

            frmQLLoaiThuCung.Show();
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();

        }
        private void btn_thongKe_Click(object sender, EventArgs e)
        {
            frmQLThongKe frmQLThongKe = new frmQLThongKe();
            frmQLThongKe.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmQLThongKe.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmQLThongKe);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmQLThongKe.BringToFront();

            frmQLThongKe.Show();
        }
    }
}
