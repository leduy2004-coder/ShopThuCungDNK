using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI.Dialog
{
    public partial class dialogCTHoaDon : Form
    {
        private string ngay;
        private string tongtien;
        private string tenKH;
        private string tenNV;
        private string maHD;

        public dialogCTHoaDon(string ngay, string tongtien, string tenKH, string tenNV, string maHD)
        {
            InitializeComponent();

            // Gán giá trị cho các biến
            this.ngay = ngay;
            this.tongtien = tongtien;
            this.tenKH = tenKH;
            this.tenNV = tenNV;
            this.maHD = maHD;
        }

        private void dialogCTHoaDon_Load(object sender, EventArgs e)
        {
            // Gắn dữ liệu vào các Label
            lbDate.Text = ngay;
            lbMoney.Text = $"{tongtien} VNĐ";
            lbNameKH.Text = tenKH;
            lbNameNV.Text = tenNV;

            // Hiển thị chi tiết hóa đơn lên DataGridView
            LoadChiTietHoaDon(maHD);
        }

        private void LoadChiTietHoaDon(string maHD)
        {
            // Lấy danh sách chi tiết hóa đơn từ file XML
            FileXml fxml = new FileXml();
            DataTable dtChiTietHoaDon = fxml.HienThi("ChiTietHoaDon.xml");
   
            DataTable dtThuCung = fxml.HienThi("ThuCung.xml");


            if (!dtChiTietHoaDon.Columns.Contains("giong"))
                dtChiTietHoaDon.Columns.Add("giong", typeof(string));
            if (!dtChiTietHoaDon.Columns.Contains("donGia"))
                dtChiTietHoaDon.Columns.Add("donGia", typeof(decimal));

            // Dùng ánh xạ để tăng hiệu suất
            var thuCungMap = dtThuCung.AsEnumerable()
                .ToDictionary(
                    row => row["maTC"].ToString(),
                    row => new
                    {
                        Giong = row["giong"].ToString(),
                        DonGia = decimal.TryParse(row["giaTC"]?.ToString(), out var gia) ? gia : 0
                    });

            // Cập nhật cột "giong" và "donGia" cho từng dòng
            foreach (DataRow row in dtChiTietHoaDon.Rows)
            {
                string maTC = row["maTC"]?.ToString();
                if (!string.IsNullOrEmpty(maTC) && thuCungMap.ContainsKey(maTC))
                {
                    row["giong"] = thuCungMap[maTC].Giong;
                    row["donGia"] = thuCungMap[maTC].DonGia;
                }
            }


            // Lọc dữ liệu theo maHD
            DataView dv = dtChiTietHoaDon.DefaultView;
            dv.RowFilter = $"maHD = '{maHD}'";

            // Hiển thị dữ liệu sau lọc lên DataGridView
            dgvDetailBill.AutoGenerateColumns = false;
            dgvDetailBill.DataSource = dv.ToTable();

            // Thiết lập các cột hiển thị trong DataGridView
            dgvDetailBill.Columns.Clear();
            dgvDetailBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã", DataPropertyName = "maChiTiet", Name = "maChiTiet", Width = 50 });
            dgvDetailBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giống", DataPropertyName = "giong", Name = "giong", Width = 150 });
            dgvDetailBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "soLuong", Name = "soLuong", Width = 80 });
            dgvDetailBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "donGia", Name = "donGia", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDetailBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "thanhTien", Name = "thanhTien", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }

}
