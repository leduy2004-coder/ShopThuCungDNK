using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThuCungDNK.Class
{
    internal class ThuCung
    {
        FileXml fxml = new FileXml();
        public void themThuCung(string Tuoi, string Giong, string GiaTC, string SoLuong, string MaLoai, string MaNhaCungCap, string MaTinhTrang, string HinhAnh)
        {
            int ma = fxml.LayMaxValueFromXml("ThuCung.xml", "maTC");
            string noiDung = "<ThuCung>" +
                    "<maTC>" + ma + "</maTC>" +
                    "<tuoi>" + Tuoi + "</tuoi>" +
                    "<giong>" + Giong + "</giong>" +
                    "<giaTC>" + GiaTC + "</giaTC>" +
                    "<soLuong>" + SoLuong + "</soLuong>" +
                    "<maLoai>" + MaLoai + "</maLoai>" +
                    "<maNhaCungCap>" + MaNhaCungCap + "</maNhaCungCap>" +
                    "<maTinhTrang>" + MaTinhTrang + "</maTinhTrang>" +
                    "<hinhAnh>" + HinhAnh + "</hinhAnh>" +
                    "</ThuCung>";

            fxml.Them("ThuCung.xml", noiDung);
        }

        public void suaThuCung(string MaThuCung, string Tuoi, string Giong, string GiaTC, string SoLuong, string MaLoai, string MaNhaCungCap, string MaTinhTrang, string HinhAnh)
        {

            string noiDung =
                    "<maTC>" + MaThuCung + "</maTC>" +
                    "<tuoi>" + Tuoi + "</tuoi>" +
                    "<giong>" + Giong + "</giong>" +
                    "<giaTC>" + GiaTC + "</giaTC>" +
                    "<soLuong>" + SoLuong + "</soLuong>" +
                    "<maLoai>" + MaLoai + "</maLoai>" +
                    "<maNhaCungCap>" + MaNhaCungCap + "</maNhaCungCap>" +
                    "<maTinhTrang>" + MaTinhTrang + "</maTinhTrang>" +
                    "<hinhAnh>" + HinhAnh + "</hinhAnh>";


            fxml.Sua("ThuCung.xml", "ThuCung", "maTC", MaThuCung, noiDung);
        }

        public void xoaThuCung(string MaThuCung)
        {
            fxml.Xoa("ThuCung.xml", "ThuCung", "maTC", MaThuCung);
        }
    }
}
