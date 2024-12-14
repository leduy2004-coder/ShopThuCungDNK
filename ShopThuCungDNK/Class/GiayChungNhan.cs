using QuanLySieuThi.Class;
using System;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class GiayChungNhan
    {
        FileXml Fxml = new FileXml();

        // Kiểm tra Giấy chứng nhận tồn tại dựa trên mã Giấy chứng nhận
        public bool KiemTra(string maGiayChungNhan)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("GiayChungNhan.xml");

            // Sử dụng XPath để tìm kiếm Giấy chứng nhận theo maGiayChungNhan
            XmlNode node = doc.SelectSingleNode("NewDataSet/GiayChungNhan[maGiayChungNhan='" + maGiayChungNhan + "']");

            return node != null;
        }

        // Thêm Giấy chứng nhận mới
        public void ThemGiayChungNhan(string maGiayChungNhan, string maTC, string maLoaiGiay, DateTime ngayCap, DateTime ngayHetHan, string nguoiCap, string chiTiet)
        {
            string noiDung =
                "<GiayChungNhan>" +
                "<maGiayChungNhan>" + maGiayChungNhan + "</maGiayChungNhan>" +
                "<maTC>" + maTC + "</maTC>" +
                "<maLoaiGiay>" + maLoaiGiay + "</maLoaiGiay>" +
                "<ngayCap>" + ngayCap.ToString("yyyy-MM-ddTHH:mm:ssK") + "</ngayCap>" +
                "<ngayHetHan>" + ngayHetHan.ToString("yyyy-MM-ddTHH:mm:ssK") + "</ngayHetHan>" +
                "<nguoiCap>" + nguoiCap + "</nguoiCap>" +
                "<chiTiet>" + chiTiet + "</chiTiet>" +
                "</GiayChungNhan>";

            Fxml.Them("GiayChungNhan.xml", noiDung);
        }

        // Sửa thông tin Giấy chứng nhận
        public void SuaGiayChungNhan(string maGiayChungNhan, string maTC, string maLoaiGiay, DateTime ngayCap, DateTime ngayHetHan, string nguoiCap, string chiTiet)
        {
            string noiDung =
                "<maGiayChungNhan>" + maGiayChungNhan + "</maGiayChungNhan>" +
                "<maTC>" + maTC + "</maTC>" +
                "<maLoaiGiay>" + maLoaiGiay + "</maLoaiGiay>" +
                "<ngayCap>" + ngayCap.ToString("yyyy-MM-ddTHH:mm:ssK") + "</ngayCap>" +
                "<ngayHetHan>" + ngayHetHan.ToString("yyyy-MM-ddTHH:mm:ssK") + "</ngayHetHan>" +
                "<nguoiCap>" + nguoiCap + "</nguoiCap>" +
                "<chiTiet>" + chiTiet + "</chiTiet>";

            Fxml.Sua("GiayChungNhan.xml", "GiayChungNhan", "maGiayChungNhan", maGiayChungNhan.ToString(), noiDung);
        }

        // Xóa Giấy chứng nhận
        public void XoaGiayChungNhan(string maGiayChungNhan)
        {
            Fxml.Xoa("GiayChungNhan.xml", "GiayChungNhan", "maGiayChungNhan", maGiayChungNhan.ToString());
        }
    }
}
