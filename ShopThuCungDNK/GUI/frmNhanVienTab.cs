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
    public partial class frmNhanVienTab : Form
    {
        public frmNhanVienTab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmDiemDanh frmQLNhanVien = new frmDiemDanh();
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
    }
}
