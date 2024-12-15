using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


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

            // Đặt lại giá trị Identity về 0
            string sqlReset = $"DBCC CHECKIDENT ('{tenBang}', RESEED, 0);";
            Fxml.InsertOrUpDateSQL(sqlReset);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // Xây dựng câu lệnh SQL
                string sql = $"INSERT INTO {tenBang} (";
                List<string> columnNames = new List<string>();
                List<string> parameterNames = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Duyệt qua các cột và thêm tham số
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    string columnName = table.Columns[j].ColumnName;
                    columnNames.Add(columnName);

                    string paramName = $"@{columnName}_{i}";
                    parameterNames.Add(paramName);

                    // Xử lý đặc biệt cho cột hinhAnh
                    if (tenBang == "ThuCung" && columnName == "hinhAnh")
                    {
                        string base64String = table.Rows[i][j]?.ToString().Trim();
                        byte[] hinhAnhData = null;

                        if (!string.IsNullOrEmpty(base64String) && IsBase64String(base64String))
                        {
                            hinhAnhData = Convert.FromBase64String(base64String);
                        }

                        SqlParameter param = new SqlParameter(paramName, SqlDbType.VarBinary);
                        param.Value = hinhAnhData ?? (object)DBNull.Value; // Gán null nếu không hợp lệ
                        parameters.Add(param);
                    }
                    else
                    {
                        SqlParameter param = new SqlParameter(paramName, SqlDbType.NVarChar);
                        param.Value = table.Rows[i][j]?.ToString().Trim() ?? (object)DBNull.Value;
                        parameters.Add(param);
                    }
                }

                // Hoàn thiện câu lệnh SQL
                sql += string.Join(", ", columnNames) + ") VALUES (" + string.Join(", ", parameterNames) + ");";

                // Thực thi câu lệnh SQL với tham số
                Fxml.InsertOrUpDateSQL(sql, parameters);
            }
        }

        // Hàm kiểm tra chuỗi có phải Base64 hợp lệ không
        bool IsBase64String(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            input = input.Trim();
            return (input.Length % 4 == 0) && Regex.IsMatch(input, "^[a-zA-Z0-9+/]*={0,2}$");
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
