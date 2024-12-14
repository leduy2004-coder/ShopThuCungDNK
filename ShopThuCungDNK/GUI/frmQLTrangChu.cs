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
            getData();
         
            circularProgressBar1.Maximum = 20000000;
            circularProgressBar1.Value = Convert.ToInt32(tongTien);
            circularProgressBar1.BackColor = Color.Transparent;
            circularProgressBar1.Text = Convert.ToInt32(tongTien).ToString();

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

   
    }
}
