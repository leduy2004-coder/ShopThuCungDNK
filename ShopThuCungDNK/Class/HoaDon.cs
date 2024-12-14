using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThuCungDNK.Class
{
    internal class HoaDon
    {
        FileXml fxml = new FileXml();
        public void themHoaDon(string MaKH, string MaNV, string TrangThai, string NgayTao, string TongTien)
        {
            int ma = fxml.LayMaxValueFromXml("HoaDon.xml", "maHD");
            string noiDung = "<HoaDon>" +
                    "<maHD>" + ma + "</maHD>" +
                    "<maKH>" + MaKH + "</maKH>" +
                    "<maNV>" + MaNV + "</maNV>" +
                    "<trangThai>" + TrangThai + "</trangThai>" +
                    "<ngayTao>" + NgayTao + "</ngayTao>" +
                    "<tongTien>" + TongTien + "</tongTien>" +
                "</HoaDon>";

            fxml.Them("HoaDon.xml", noiDung);
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

        public void themCTHoaDon(string MaTC, string SoLuong, string ThanhTien)
        {
            int ma = fxml.LayMaxValueFromXml("ChiTietHoaDon.xml", "maChiTiet");
            int maHD = fxml.LayMaxValueFromXml("HoaDon.xml", "maHD");
            string noiDung = "<ChiTietHoaDon>" +
                    "<maChiTiet>" + ma + "</maChiTiet>" +
                    "<maHD>" + maHD + "</maHD>" +
                    "<maTC>" + MaTC + "</maTC>" +
                    "<soLuong>" + SoLuong + "</soLuong>" +
                    "<thanhTien>" + ThanhTien + "</thanhTien>" +
                        "</ChiTietHoaDon>";

            fxml.Them("ChiTietHoaDon.xml", noiDung);
        }
    }
}
