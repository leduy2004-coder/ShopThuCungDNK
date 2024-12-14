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
    public partial class frmQuanLy : Form
    {
        Main M = new Main();

        public static string tenDNMain = "";
        public static string maNVMain = "";

        public frmQuanLy()
        {
            InitializeComponent();
        }
        void ThongTinDangNhap()
        {
            lb_Name.Text = tenDNMain;
        }
        

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            ThongTinDangNhap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frmQLNhanVien = new frmQLNhanVien();
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

  
    }
}
