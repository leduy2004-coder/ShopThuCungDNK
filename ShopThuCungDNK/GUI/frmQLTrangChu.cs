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
using System.Xml.Linq;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQLTrangChu : Form
    {

        FileXml Fxml = new FileXml();
        ThongKe thongKe = new ThongKe();
        List<KeyValuePair<string, int>> ketQua = new List<KeyValuePair<string, int>>();
        decimal tongTien = 0;
        public frmQLTrangChu()
        {
            InitializeComponent();
        }


        private void frmQLTrangChu_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu trước
            getData();

            decimal tongTien = 1000000m; // Thay thế bằng giá trị thực tế bạn nhận được từ getData()

            // Đảm bảo giá trị Maximum hợp lý cho progress bar
            decimal maxLimit = 1000000m; // Chỉnh lại giới hạn nếu cần thiết
            circularProgressBar1.Maximum = (int)maxLimit;

            // Đảm bảo tongTien không vượt quá Maximum, và kiểu giá trị của Value phải hợp lệ.
            circularProgressBar1.Value = (int)Math.Min(tongTien, maxLimit);

            circularProgressBar1.BackColor = Color.Transparent;

            // Hiển thị giá trị tongTien, nếu cần phải làm tròn hoặc định dạng, dùng:
            circularProgressBar1.Text = tongTien.ToString("N0"); // Định dạng số nguyên
        }


        public void getData()
        {
            // Bước 1: Lấy dữ liệu từ file Hóa Đơn
            DataTable hoaDonData = Fxml.HienThi("hoaDon.xml");

            // Bước 2: Lấy dữ liệu từ file Chi Tiết Hóa Đơn
            DataTable chiTietHoaDonData = Fxml.HienThi("chiTietHoaDon.xml");

            // Bước 3: Lấy dữ liệu từ file Thú Cưng
            DataTable thuCungData = Fxml.HienThi("thuCung.xml");
            DataTable LoaiThuCungData = Fxml.HienThi("LoaiThuCung.xml");
            ketQua = thongKe.TinhSoLuongHoaDon(chiTietHoaDonData, thuCungData, LoaiThuCungData);
            tongTien = thongKe.TinhTongHoaDon(chiTietHoaDonData);
            int index = 0;
            foreach (var hoaDon in ketQua)
            {
                // Lấy tên thú cưng và số lượng hóa đơn
                string tenThuCung = hoaDon.Key;
                int soLuongHoaDon = hoaDon.Value;

                // Gán giá trị cho các label có sẵn
                switch (index)
                {
                    case 0:
                        lb1.Text = $"{tenThuCung}";
                        count1.Text = $"{soLuongHoaDon}";
                        break;
                    case 1:
                        lb2.Text = $"{tenThuCung}";
                        count2.Text = $"{soLuongHoaDon}";
                        break;
                    case 2:
                        lb3.Text = $"{tenThuCung}";
                        count3.Text = $"{soLuongHoaDon}";
                        break;
                    case 3:
                        lb4.Text = $"{tenThuCung}";
                        count4.Text = $"{soLuongHoaDon}";
                        break;
                 
                    default:
                        // Nếu số lượng kết quả vượt quá số lượng Label có sẵn
                        break;
                }

                // Tăng index lên để gán cho label tiếp theo
                index++;
            }
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
