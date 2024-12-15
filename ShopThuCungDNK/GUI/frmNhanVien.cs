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

namespace ShopThuCungDNK.GUI
{
    public partial class frmNhanVien : Form
    {
        Main M = new Main();
        public frmNhanVien()
        {
            InitializeComponent();
            frmNVTrangChu frmNVTrangChu = new frmNVTrangChu();
            frmNVTrangChu.TopLevel = false;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            frmNVTrangChu.Size = panelDesktop.ClientSize;

            panelDesktop.Controls.Add(frmNVTrangChu);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVTrangChu.BringToFront();

            frmNVTrangChu.Show();
        }
        public static string tenDNMain = "";
        public static string maNVMain = "";
        void ThongTinDangNhap()
        {
            lb_Name.Text = tenDNMain;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ThongTinDangNhap();
            btnHome_Click_1(sender, e);
        }

        //trang chủ
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            frmNVTrangChu frmNVTrangChu = new frmNVTrangChu();
            frmNVTrangChu.TopLevel = false;
            frmNVTrangChu.maNV = maNVMain;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVTrangChu.Size = panelDesktop.ClientSize;

    
            panelDesktop.Controls.Add(frmNVTrangChu);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVTrangChu.BringToFront();

            frmNVTrangChu.Show();
        }


        //log out
        private void btnExit_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        //thú cưng
        private void button3_Click(object sender, EventArgs e)
        {
            frmNVThuCung frmNVThuCung = new frmNVThuCung();
            frmNVThuCung.TopLevel = false;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVThuCung.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmNVThuCung);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVThuCung.BringToFront();

            frmNVThuCung.Show();
        }

        // khách hàng
        private void button2_Click(object sender, EventArgs e)
        {
            frmNVKhachHang frmNVKhachHang = new frmNVKhachHang();
            frmNVKhachHang.TopLevel = false;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVKhachHang.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmNVKhachHang);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVKhachHang.BringToFront();

            frmNVKhachHang.Show();
        }

        //nhà cung cấp
        private void button4_Click(object sender, EventArgs e)
        {
            frmNVNhaCungCap frmNVNhaCungCap = new frmNVNhaCungCap();
            frmNVNhaCungCap.TopLevel = false;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVNhaCungCap.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmNVNhaCungCap);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVNhaCungCap.BringToFront();

            frmNVNhaCungCap.Show();

        }

        // thanh toán
        private void button5_Click(object sender, EventArgs e)
        {
            frmNVThanhToan frmNVThanhToan = new frmNVThanhToan();
            frmNVThanhToan.TopLevel = false;
            frmNVThanhToan.maNVMain = maNVMain;
            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVThanhToan.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmNVThanhToan);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVThanhToan.BringToFront();

            frmNVThanhToan.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.TopLevel = false;
            frmHoaDon.tenNVMain = tenDNMain;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmHoaDon.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmHoaDon);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmHoaDon.BringToFront();

            frmHoaDon.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            frmNVGiayChungNhan frmNVGiayChungNhan = new frmNVGiayChungNhan();
            frmNVGiayChungNhan.TopLevel = false;

            if (panelDesktop.Controls.Count > 0)
            {
                panelDesktop.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmNVGiayChungNhan.Size = panelDesktop.ClientSize;


            panelDesktop.Controls.Add(frmNVGiayChungNhan);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmNVGiayChungNhan.BringToFront();

            frmNVGiayChungNhan.Show();
        }
    }
}
