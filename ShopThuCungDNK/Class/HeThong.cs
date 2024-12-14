using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace QuanLySieuThi.Class
{
    class HeThong
    {
        FileXml Fxml = new FileXml();
        public void TaoXML()
        {
            Fxml.TaoXML("NguoiDung");
            Fxml.TaoXML("ChiTietHoaDon");
            Fxml.TaoXML("KhachHang");
            Fxml.TaoXML("HoaDon");
            Fxml.TaoXML("LoaiThuCung");
            Fxml.TaoXML("TinhTrang");
            Fxml.TaoXML("NhaCungCap");
            Fxml.TaoXML("ThuCung");
            Fxml.TaoXML("GiayChungNhan");
            Fxml.TaoXML("Role");

        }
        public void TaoXMLFirst()
        {
            // Danh sách các tên bảng cần tạo XML
            string[] bang = { "NguoiDung", "ChiTietHoaDon", "KhachHang", "HoaDon", "LoaiThuCung", "TinhTrang", "NhaCungCap", "ThuCung", "GiayChungNhan", "Role" };

            // Kiểm tra và tạo các file XML nếu chúng chưa tồn tại
            foreach (var tenBang in bang)
            {
                string duongDan = Application.StartupPath + "\\" + tenBang + ".xml";

                // Kiểm tra xem file XML đã tồn tại chưa
                if (!File.Exists(duongDan))
                {
                    // Nếu file chưa tồn tại, gọi phương thức TaoXML của FileXml để tạo
                    Fxml.TaoXML(tenBang);
                    Console.WriteLine($"Đã tạo file XML cho bảng: {tenBang}");
                }
                else
                {
                    Console.WriteLine($"File XML cho bảng {tenBang} đã tồn tại.");
                }
            }
        }

        void CapNhapTungBang(string tenBang)
        {
            string duongDan = @"" + tenBang + ".xml";
            DataTable table = Fxml.HienThi(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                //MessageBox.Show(sql);
                Fxml.InsertOrUpDateSQL(sql);
            }
        }
        public void CapNhapSQL()
        {
            //Xóa toàn bộ dữ liệu các bảng
            Fxml.InsertOrUpDateSQL("delete from NguoiDung");
            Fxml.InsertOrUpDateSQL("delete from ChiTietHoaDon");
            Fxml.InsertOrUpDateSQL("delete from KhachHang");
            Fxml.InsertOrUpDateSQL("delete from HoaDon");
            Fxml.InsertOrUpDateSQL("delete from LoaiThuCung");
            Fxml.InsertOrUpDateSQL("delete from NhaCungCap");
            Fxml.InsertOrUpDateSQL("delete from ThuCung");
            Fxml.InsertOrUpDateSQL("delete from TinhTrang");
            Fxml.InsertOrUpDateSQL("delete from GiayChungNhan");
            Fxml.InsertOrUpDateSQL("delete from Role");

            //Cập nhập toàn bộ dữ liệu các bảng
            CapNhapTungBang("NguoiDung");
            CapNhapTungBang("ChiTietHoaDon");
            CapNhapTungBang("KhachHang");
            CapNhapTungBang("HoaDon");
            CapNhapTungBang("LoaiThuCung");
            CapNhapTungBang("NhaCungCap");
            CapNhapTungBang("ThuCung");
            CapNhapTungBang("TinhTrang");
            CapNhapTungBang("GiayChungNhan");
            CapNhapTungBang("Role");
        }
    }
}
