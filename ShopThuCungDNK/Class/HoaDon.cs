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

        public void xoaHoaDon(string MaHD)
        {
            fxml.Xoa("HoaDon.xml", "HoaDon", "maHD", MaHD);
        }

        public void themCTHoaDon(string MaTC, string SoLuong, string ThanhTien)
        {
            int ma = fxml.LayMaxValueFromXml("ChiTietHoaDon.xml", "maChiTiet");
            int maHD = fxml.LayMaxValueFromXml("HoaDon.xml", "maHD");
            maHD = maHD - 1;
            string noiDung = "<ChiTietHoaDon>" +
                    "<maChiTiet>" + ma + "</maChiTiet>" +
                    "<maHD>" + maHD + "</maHD>" +
                    "<maTC>" + MaTC + "</maTC>" +
                    "<soLuong>" + SoLuong + "</soLuong>" +
                    "<thanhTien>" + ThanhTien + "</thanhTien>" +
                        "</ChiTietHoaDon>";

            fxml.Them("ChiTietHoaDon.xml", noiDung);
        }
        public void xoaCTHoaDon(string MaCTHD)
        {
            fxml.Xoa("ChiTietHoaDon.xml", "ChiTietHoaDon", "maChiTiet", MaCTHD);
        }
    }
}
