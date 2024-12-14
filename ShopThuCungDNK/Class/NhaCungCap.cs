using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class NhaCungCap
    {
        FileXml Fxml = new FileXml();

        // Kiểm tra nhà cung cấp tồn tại dựa trên mã nhà cung cấp
        public bool KiemTra(string maNCC)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("NhaCungCap.xml");
            XmlNode node = doc.SelectSingleNode("NewDataSet/NhaCungCap[maNhaCungCap='" + maNCC + "']");

            return node != null;
        }

        // Thêm nhà cung cấp mới
        public void ThemNhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
        {
            string noiDung =
                "<NhaCungCap>" +
                "<maNhaCungCap>" + maNCC + "</maNhaCungCap>" +
                "<tenNhaCungCap>" + tenNCC + "</tenNhaCungCap>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>" +
                "</NhaCungCap>";

            Fxml.Them("NhaCungCap.xml", noiDung);
        }

        // Sửa thông tin nhà cung cấp
        public void SuaNhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
        {
            string noiDung =
                "<maNhaCungCap>" + maNCC + "</maNhaCungCap>" +
                "<tenNhaCungCap>" + tenNCC + "</tenNCC>" +
                "<sdt>" + sdt + "</sdt>" +
                "<diaChi>" + diaChi + "</diaChi>";

            Fxml.Sua("NhaCungCap.xml", "NhaCungCap", "maNhaCungCap", maNCC.ToString(), noiDung);
        }

        // Xóa nhà cung cấp
        public void XoaNhaCungCap(string maNCC)
        {
            Fxml.Xoa("NhaCungCap.xml", "NhaCungCap", "maNhaCungCap", maNCC.ToString());
        }
    }
}
