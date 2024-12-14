using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class NhanVien
    {
        FileXml Fxml = new FileXml();

        public bool KiemTra(string maNV)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("NguoiDung.xml");
            XmlNode node = doc.SelectSingleNode("NewDataSet/NguoiDung[maNV='" + maNV + "']");

            return node != null;
        }
        // Thêm nhân viên
        public void ThemNguoiDung(string maNV, string tenNV, string sdt, string diaChi, string tk, string mk)
        {
            string noiDung =
                "<NguoiDung>" +
                "<maNV>" + maNV + "</maNV>" +
                "<tenNV>" + tenNV + "</tenNV>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>" +
                "<tk>" + tk + "</tk>" +
                "<mk>" + mk + "</mk>" +
                "<maRole>" + 1 + "</maRole>" +
                "</NguoiDung>";

            Fxml.Them("NguoiDung.xml", noiDung);
        }

        // Sửa thông tin nhân viên
        public void SuaNguoiDung(string maNV, string tenNV, string sdt, string diaChi, string tk, string mk)
        {
            string noiDung =
                "<maNV>" + maNV + "</maNV>" +
                "<tenNV>" + tenNV + "</tenNV>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>" +
                "<tk>" + tk + "</tk>" +
                "<mk>" + mk + "</mk>" +
                "<maRole>" + 2 + "</maRole>";

            Fxml.Sua("NguoiDung.xml", "NguoiDung", "maNV", maNV.ToString(), noiDung);
        }

        // Xóa nhân viên
        public void XoaNguoiDung(string maNV)
        {
            Fxml.Xoa("NguoiDung.xml", "NguoiDung", "maNV", maNV.ToString());
        }
    }
}
