using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class KhachHang
    {
        FileXml Fxml = new FileXml();

        // Kiểm tra khách hàng tồn tại dựa trên mã khách hàng
        public bool KiemTra(string maKH)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("KhachHang.xml");
            XmlNode node = doc.SelectSingleNode("NewDataSet/KhachHang[maKH='" + maKH + "']");

            return node != null;
        }

        // Thêm khách hàng mới
        public void ThemKhachHang(string maKH, string tenKH, string sdt, string diaChi)
        {
            string noiDung =
                "<KhachHang>" +
                "<maKH>" + maKH + "</maKH>" +
                "<tenKH>" + tenKH + "</tenKH>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>" +
                "</KhachHang>";

            Fxml.Them("KhachHang.xml", noiDung);
        }

        // Sửa thông tin khách hàng
        public void SuaKhachHang(string maKH, string tenKH, string sdt, string diaChi)
        {
            string noiDung =
                "<maKH>" + maKH + "</maKH>" +
                "<tenKH>" + tenKH + "</tenKH>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>";

            Fxml.Sua("KhachHang.xml", "KhachHang", "maKH", maKH, noiDung);
        }

        // Xóa khách hàng
        public void XoaKhachHang(string maKH)
        {
            Fxml.Xoa("KhachHang.xml", "KhachHang", "maKH", maKH);
        }

      
    }
}
