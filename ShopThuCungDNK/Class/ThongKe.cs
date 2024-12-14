using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.Class
{
    internal class ThongKe
    {
        FileXml Fxml = new FileXml();



        public List<KeyValuePair<string, int>> TinhSoLuongHoaDon(DataTable chiTietHoaDonData, DataTable thuCungData, DataTable LoaiThuCungData)
        {
            // Lặp qua tất cả chi tiết hóa đơn để đếm số lượng hóa đơn cho từng loại thú cưng
            var soLuongHoaDon = chiTietHoaDonData.AsEnumerable()
                .GroupBy(row => row["maTC"].ToString()) // Giả sử "maTC" là mã thú cưng trong chi tiết hóa đơn
                .Select(group => new
                {
                    MaThuCung = group.Key,
                    SoLuong = group.Count()
                }).ToList();

            // Danh sách chứa kết quả KeyValuePair
            List<KeyValuePair<string, int>> resultList = new List<KeyValuePair<string, int>>();

            // Duyệt qua từng nhóm để lấy tên thú cưng và số lượng hóa đơn
            foreach (var item in soLuongHoaDon)
            {
                // Lấy mã loại thú cưng từ dữ liệu thú cưng (dựa trên "maTC" trong chi tiết hóa đơn)
                string maLoaiThuCung = thuCungData.AsEnumerable()
                    .Where(row => row["maTC"].ToString() == item.MaThuCung)
                    .Select(row => row["maLoai"].ToString()) // Lấy mã loại thú cưng (maLoai)
                    .FirstOrDefault();

                // Kiểm tra xem mã loại thú cưng có tồn tại hay không
                if (!string.IsNullOrEmpty(maLoaiThuCung))
                {
                    // Tìm tên loại thú cưng dựa trên maLoai từ thuCungData
                    string tenLoaiThuCung = LoaiThuCungData.AsEnumerable()
                        .Where(row => row["maLoai"].ToString() == maLoaiThuCung)
                        .Select(row => row["tenLoai"].ToString()) // Lấy tên loại thú cưng (tenLoai)
                        .FirstOrDefault();

                    // Nếu không tìm thấy tên loại thú cưng, gán giá trị mặc định
                    if (string.IsNullOrEmpty(tenLoaiThuCung))
                    {
                        tenLoaiThuCung = "Không tìm thấy tên loại thú cưng";
                    }

                    // Thêm vào danh sách KeyValuePair với key là tên loại thú cưng và value là số lượng hóa đơn
                    resultList.Add(new KeyValuePair<string, int>(tenLoaiThuCung, item.SoLuong));
                }
            }

            resultList = resultList.OrderByDescending(pair => pair.Value).ToList();
            // Trả về danh sách kết quả
            return resultList;
        }


        public decimal TinhTongHoaDon(DataTable chiTietHoaDonData)
        {
            // Tính tổng tất cả hóa đơn
            decimal tongTien = chiTietHoaDonData.AsEnumerable()
                .Sum(row => Convert.ToDecimal(row["SoLuong"]) * Convert.ToDecimal(row["thanhTien"]));

            return tongTien;
        }

    }
}
