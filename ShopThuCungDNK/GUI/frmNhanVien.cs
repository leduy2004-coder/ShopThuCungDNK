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
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            frmNVTrangChu frmNVTrangChu = new frmNVTrangChu();
            frmNVTrangChu.TopLevel = false;

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


        private void btnExit_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

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
    }
}
