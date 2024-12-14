using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopThuCungDNK.Class
{
    internal class LoaiThuCung
    {
        FileXml Fxml = new FileXml();

        // Kiểm tra khách hàng tồn tại dựa trên mã khách hàng
        public bool KiemTra(string maLoai)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("LoaiThuCung.xml");
            XmlNode node = doc.SelectSingleNode("NewDataSet/LoaiThuCung[maLoai='" + maLoai+ "']");

            return node != null;
        }
        public void ThemLoai(string maLoai, string tenLoai)
        {
            int ma = Fxml.LayMaxValueFromXml("LoaiThuCung.xml", "maLoai");
            // Xây dựng nội dung XML cho một loại thú cưng
            string noiDung =
                "<LoaiThuCung>" +
                "<maLoai>" + ma + "</maLoai>" +
                "<tenLoai>" + tenLoai + "</tenLoai>" +
                "</LoaiThuCung>";

            // Gọi phương thức thêm nội dung vào file XML
            Fxml.Them("LoaiThuCung.xml", noiDung);
        }
        public void SuaLoai(string maLoai, string tenLoai)
        {
            // Xây dựng nội dung XML cần sửa
            string noiDung =
                "<maLoai>" + maLoai + "</maLoai>" +
                "<tenLoai>" + tenLoai + "</tenLoai>";

            // Gọi phương thức sửa nội dung trong file XML
            Fxml.Sua("LoaiThuCung.xml", "LoaiThuCung", "maLoai", maLoai, noiDung);
        }

        public void XoaLoai(string maLoai)
        {
            Fxml.Xoa("LoaiThuCung.xml", "LoaiThuCung", "maLoai", maLoai);
        }
    }
}
