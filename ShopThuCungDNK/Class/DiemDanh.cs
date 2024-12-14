using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class DiemDanh
    {
        FileXml Fxml = new FileXml();

        // Kiểm tra điểm danh dựa trên mã điểm danh
        public bool KiemTra(string maDiemDanh)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DiemDanh.xml");
            XmlNode node = doc.SelectSingleNode("NewDataSet/DiemDanh[maDiemDanh='" + maDiemDanh + "']");

            return node != null;
        }

        // Thêm bản ghi điểm danh mới
        public void ThemDiemDanh(string maDiemDanh, string maNV, DateTime ngayDiemDanh)
        {
            string noiDung =
                "<DiemDanh>" +
                "<maDiemDanh>" + maDiemDanh + "</maDiemDanh>" +
                "<maNV>" + maNV + "</maNV>" +
                "<ngayDiemDanh>" + ngayDiemDanh.ToString("yyyy-MM-ddTHH:mm:sszzz") + "</ngayDiemDanh>" +
                "</DiemDanh>";

            Fxml.Them("DiemDanh.xml", noiDung);
        }

        // Sửa thông tin bản ghi điểm danh
        public void SuaDiemDanh(string maDiemDanh, string maNV, DateTime ngayDiemDanh)
        {
            string noiDung =
                "<maDiemDanh>" + maDiemDanh + "</maDiemDanh>" +
                "<maNV>" + maNV + "</maNV>" +
                "<ngayDiemDanh>" + ngayDiemDanh.ToString("yyyy-MM-ddTHH:mm:sszzz") + "</ngayDiemDanh>";

            Fxml.Sua("DiemDanh.xml", "DiemDanh", "maDiemDanh", maDiemDanh, noiDung);
        }

        // Xóa bản ghi điểm danh
        public void XoaDiemDanh(string maDiemDanh)
        {
            Fxml.Xoa("DiemDanh.xml", "DiemDanh", "maDiemDanh", maDiemDanh);
        }
    }
}
