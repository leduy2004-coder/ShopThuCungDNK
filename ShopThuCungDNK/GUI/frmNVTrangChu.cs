using QuanLySieuThi.Class;
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
    public partial class frmNVTrangChu : Form
    {
        FileXml Fml = new FileXml();
        DiemDanh diemDanh = new DiemDanh();
        public static string maNV = "";

        public frmNVTrangChu()
        {
            InitializeComponent();
        }

        private void btn_DiemDanh_Click(object sender, EventArgs e)
        {
            // Lấy ngày hiện tại
            DateTime ngayHienTai = DateTime.Today; // Lấy ngày hiện tại, bỏ phần giờ


            // Kiểm tra xem nhân viên đã điểm danh hôm nay chưa
            DataTable dtDiemDanh = Fml.HienThi("DiemDanh.xml");
            string filter = $"maNV = '{maNV}' AND ngayDiemDanh LIKE '{ngayHienTai}%'";
            DataRow[] rows = dtDiemDanh.Select($"maNV = '{maNV}' AND ngayDiemDanh >= #{ngayHienTai:yyyy-MM-dd}# AND ngayDiemDanh < #{ngayHienTai.AddDays(1):yyyy-MM-dd}#");


            if (rows.Length > 0)
            {
                MessageBox.Show("Bạn đã điểm danh hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu chưa điểm danh, thêm điểm danh mới
                int maDiemDanh = Fml.LayMaxValueFromXml("DiemDanh.xml", "maDiemDanh");

                // Gọi hàm thêm điểm danh
                diemDanh.ThemDiemDanh(maDiemDanh.ToString(), maNV, DateTime.Now);

                MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmNVTrangChu_Load(object sender, EventArgs e)
        {

        }
    }
}
