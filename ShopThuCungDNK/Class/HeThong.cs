using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;


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
                string sql = "insert into " + tenBang + " (";

                List<SqlParameter> parameters = new List<SqlParameter>();

                // Xây dựng danh sách cột
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    sql += table.Columns[j].ColumnName + ", ";
                }
                sql = sql.TrimEnd(',', ' ') + ") values (";

                // Thêm các giá trị
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    if (tenBang == "ThuCung" && table.Columns[j].ColumnName == "hinhAnh")
                    {
                        // Chuyển đổi hình ảnh từ Base64 sang byte[]
                        byte[] hinhAnhData = Convert.FromBase64String(table.Rows[i][j].ToString().Trim());
                        SqlParameter param = new SqlParameter("@hinhAnh" + i, SqlDbType.VarBinary);
                        param.Value = hinhAnhData;
                        parameters.Add(param);
                        sql += "@hinhAnh" + i + ", "; // Tham số
                    }
                    else
                    {
                        sql += $"N'{table.Rows[i][j].ToString().Trim().Replace("'", "''")}', ";
                    }
                }

                sql = sql.TrimEnd(',', ' ') + ");";

                // Thực thi câu lệnh SQL với tham số
                Fxml.InsertOrUpDateSQL(sql, parameters);
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
