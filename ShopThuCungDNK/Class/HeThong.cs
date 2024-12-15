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
            Fxml.TaoXML("LoaiGiayChungNhan");
            Fxml.TaoXML("Role");
            Fxml.TaoXML("DiemDanh");
        }
        public void TaoXMLFirst()
        {
            // Danh sách các tên bảng cần tạo XML
            string[] bang = { "NguoiDung", "ChiTietHoaDon", "KhachHang", "HoaDon", "LoaiThuCung", "TinhTrang", "NhaCungCap", "ThuCung", "GiayChungNhan", "Role", "DiemDanh", "LoaiGiayChungNhan" };

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
        public void XoaHetFileXML()
        {
            string[] bang = { "NguoiDung", "ChiTietHoaDon", "KhachHang", "HoaDon", "LoaiThuCung", "TinhTrang", "NhaCungCap", "ThuCung", "GiayChungNhan", "Role", "DiemDanh", "LoaiGiayChungNhan" };

            foreach (var tenBang in bang)
            {
                string duongDan = Application.StartupPath + "\\" + tenBang + ".xml";

                if (File.Exists(duongDan))
                {
                    File.Delete(duongDan);
                    Console.WriteLine($"Đã xóa file XML cho bảng: {tenBang}");
                }
                else
                {
                    Console.WriteLine($"File XML cho bảng {tenBang} không tồn tại.");
                }
            }
        }

        void CapNhapTungBang(string tenBang)
        {
            string duongDan = @"" + tenBang + ".xml";
            DataTable table = Fxml.HienThi(duongDan);

            try
            {
                // Bật IDENTITY_INSERT
                string sql = $"SET IDENTITY_INSERT {tenBang} ON;";
                Fxml.InsertOrUpDateSQL(sql);

                // Lặp qua các dòng và chèn vào bảng
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sql = $"INSERT INTO {tenBang} (";

                    // Lặp qua các cột và thêm vào câu lệnh INSERT
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        sql += table.Columns[j].ColumnName + ", ";
                    }

                    // Xóa dấu ',' thừa cuối câu lệnh
                    sql = sql.TrimEnd(',', ' ') + ") VALUES(";

                    // Thêm giá trị từ DataTable vào câu lệnh VALUES
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        // Kiểm tra giá trị có thể bị null hay không
                        var value = table.Rows[i][j].ToString().Trim();
                        sql += value == string.Empty ? "NULL," : $"N'{value}',";
                    }

                    // Xóa dấu ',' thừa cuối câu lệnh VALUES
                    sql = sql.TrimEnd(',') + ");";

                    // Thực thi câu lệnh INSERT
                    Fxml.InsertOrUpDateSQL(sql);
                }

                // Tắt IDENTITY_INSERT
                sql = $"SET IDENTITY_INSERT {tenBang} OFF;";
                Fxml.InsertOrUpDateSQL(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi chèn dữ liệu vào bảng {tenBang}: {ex.Message}");
            }
        }





        public void CapNhapSQL()
        {
            //Xóa toàn bộ dữ liệu các bảng
            Fxml.InsertOrUpDateSQL("delete from DiemDanh");
            Fxml.InsertOrUpDateSQL("delete from NguoiDung");
            Fxml.InsertOrUpDateSQL("delete from ChiTietHoaDon");
            Fxml.InsertOrUpDateSQL("delete from KhachHang");
            Fxml.InsertOrUpDateSQL("delete from HoaDon");
            Fxml.InsertOrUpDateSQL("delete from LoaiThuCung");
            Fxml.InsertOrUpDateSQL("delete from NhaCungCap");
            Fxml.InsertOrUpDateSQL("delete from TinhTrang");
            Fxml.InsertOrUpDateSQL("delete from LoaiGiayChungNhan");
            Fxml.InsertOrUpDateSQL("delete from GiayChungNhan");
            Fxml.InsertOrUpDateSQL("delete from Role");
            Fxml.InsertOrUpDateSQL("delete from ThuCung");

            //Cập nhập toàn bộ dữ liệu các bảng
            CapNhapTungBang("Role");
            CapNhapTungBang("NguoiDung");
            CapNhapTungBang("DiemDanh");
            CapNhapTungBang("NhaCungCap");
            CapNhapTungBang("KhachHang");
            CapNhapTungBang("LoaiThuCung");
            CapNhapTungBang("TinhTrang");
            CapNhapTungBang("ThuCung");
            CapNhapTungBang("LoaiGiayChungNhan");
            CapNhapTungBang("GiayChungNhan");
            CapNhapTungBang("HoaDon");
            CapNhapTungBang("ChiTietHoaDon");
        }
    }
}
