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
        public frmQLTrangChu()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //lay so meo
        private void LoadSoLuongMeoDaBan()
        {
            try
            {
                // Đọc dữ liệu từ các file XML
                XDocument chiTietHoaDon = XDocument.Load("ChiTietHoaDon.xml");
                XDocument loaiThuCung = XDocument.Load("LoaiThuCung.xml");
                XDocument thuCung = XDocument.Load("ThuCung.xml");

                // Truy vấn để lấy tổng số lượng thú cưng loại "Chó" đã bán
                var tongSoLuong = (
                    from cthd in chiTietHoaDon.Descendants("ChiTiet")
                    join tc in thuCung.Descendants("Thu")
                    on (string)cthd.Element("maTC") equals (string)tc.Element("maTC")
                    join ltc in loaiThuCung.Descendants("Loai")
                    on (string)tc.Element("maLoai") equals (string)ltc.Element("maLoai")
                    where (string)ltc.Element("maLoai") == "2"
                    select (int)cthd.Element("soLuong")
                ).Sum();

                // Hiển thị tổng số lượng vào Label6
                label7.Text = $"{tongSoLuong}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //lay so cho da ban 
        private void LoadSoLuongChoDaBan()
        {
            try
            {
                // Đọc dữ liệu từ các file XML
                XDocument chiTietHoaDon = XDocument.Load("ChiTietHoaDon.xml");
                XDocument loaiThuCung = XDocument.Load("LoaiThuCung.xml");
                XDocument thuCung = XDocument.Load("ThuCung.xml");

                // Truy vấn để lấy tổng số lượng thú cưng loại "Chó" đã bán
                var tongSoLuong = (
                    from cthd in chiTietHoaDon.Descendants("ChiTiet")
                    join tc in thuCung.Descendants("Thu")
                    on (string)cthd.Element("maTC") equals (string)tc.Element("maTC")
                    join ltc in loaiThuCung.Descendants("Loai")
                    on (string)tc.Element("maLoai") equals (string)ltc.Element("maLoai")
                    where (string)ltc.Element("maLoai") == "1"
                    select (int)cthd.Element("soLuong")
                ).Sum();

                // Hiển thị tổng số lượng vào Label6
                label7.Text = $"{tongSoLuong}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //chim
        private void LoadSoLuongChimDaBan()
        {
            try
            {
                // Đọc dữ liệu từ các file XML
                XDocument chiTietHoaDon = XDocument.Load("ChiTietHoaDon.xml");
                XDocument loaiThuCung = XDocument.Load("LoaiThuCung.xml");
                XDocument thuCung = XDocument.Load("ThuCung.xml");

                // Truy vấn để lấy tổng số lượng thú cưng loại "Chó" đã bán
                var tongSoLuong = (
                    from cthd in chiTietHoaDon.Descendants("ChiTiet")
                    join tc in thuCung.Descendants("Thu")
                    on (string)cthd.Element("maTC") equals (string)tc.Element("maTC")
                    join ltc in loaiThuCung.Descendants("Loai")
                    on (string)tc.Element("maLoai") equals (string)ltc.Element("maLoai")
                    where (string)ltc.Element("maLoai") == "4"
                    select (int)cthd.Element("soLuong")
                ).Sum();

                // Hiển thị tổng số lượng vào Label6
                label8.Text = $"{tongSoLuong}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSoLuongThoDaBan()
        {
            try
            {
                // Đọc dữ liệu từ các file XML
                XDocument chiTietHoaDon = XDocument.Load("ChiTietHoaDon.xml");
                XDocument loaiThuCung = XDocument.Load("LoaiThuCung.xml");
                XDocument thuCung = XDocument.Load("ThuCung.xml");

                // Truy vấn để lấy tổng số lượng thú cưng loại "Chó" đã bán
                var tongSoLuong = (
                    from cthd in chiTietHoaDon.Descendants("ChiTiet")
                    join tc in thuCung.Descendants("Thu")
                    on (string)cthd.Element("maTC") equals (string)tc.Element("maTC")
                    join ltc in loaiThuCung.Descendants("Loai")
                    on (string)tc.Element("maLoai") equals (string)ltc.Element("maLoai")
                    where (string)ltc.Element("maLoai") == "3"
                    select (int)cthd.Element("soLuong")
                ).Sum();

                // Hiển thị tổng số lượng vào Label6
                label9.Text = $"{tongSoLuong}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TongDoanhThu()
        {
            try
            {
                // Đọc dữ liệu từ file ChiTietHoaDon.xml
                XDocument chiTietHoaDon = XDocument.Load("ChiTietHoaDon.xml");

                // Truy vấn để tính tổng doanh thu
                var tongDoanhThu = chiTietHoaDon.Descendants("ChiTiet")
                    .Sum(cthd => (decimal)cthd.Element("thanhTien"));

                // Hiển thị tổng doanh thu vào Label10
                label10.Text = $"{tongDoanhThu:C} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQLTrangChu_Load(object sender, EventArgs e)
        {
            LoadSoLuongChoDaBan();
            LoadSoLuongMeoDaBan();
            LoadSoLuongChimDaBan();
            LoadSoLuongThoDaBan();
            TongDoanhThu();
        }
    }
}
