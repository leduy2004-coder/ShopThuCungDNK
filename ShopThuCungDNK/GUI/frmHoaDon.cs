using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using ShopThuCungDNK.GUI.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class frmHoaDon : Form
    {
        FileXml Fxml = new FileXml();
        public static string tenNVMain = "";
        private DataTable originalData; // Lưu trữ DataTable gốc
        HoaDon hoaDon = new HoaDon();
        public frmHoaDon()
        {
            InitializeComponent();
        }

 

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            HienThiHoaDon();
        }

        public void HienThiHoaDon()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("HoaDon.xml");

            // Thêm các cột bổ sung vào DataTable
            dt.Columns.Add("tenKH", typeof(string));
            dt.Columns.Add("tenNV", typeof(string));
            dt.Columns.Add("ngayChuyenDoi", typeof(string));

            // Tra cứu thông tin từ các bảng liên quan và điền vào DataTable
            foreach (DataRow row in dt.Rows)
            {
                int maKH = Convert.ToInt32(row["maKH"]);
                row["tenKH"] = Fxml.LayGiaTri("KhachHang.xml", "maKH", maKH.ToString(), "tenKH");

                int maNV = Convert.ToInt32(row["maNV"]);
                row["tenNV"] = Fxml.LayGiaTri("NguoiDung.xml", "maNV", maNV.ToString(), "tenNV");

                if (row["ngayTao"] != DBNull.Value && DateTime.TryParse(row["ngayTao"].ToString(), out DateTime ngay))
                {
                    // Chuyển định dạng ngày sang dd/MM/yyyy và gán vào cột mới
                    row["ngayChuyenDoi"] = ngay.ToString("dd/MM/yyyy");
                }
                else
                {
                    row["ngayChuyenDoi"] = ""; // Giá trị rỗng nếu không có ngày hợp lệ
                }

            }

            // Cấu hình DataGridView
            dgvBill.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvBill.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Hóa Đơn", DataPropertyName = "maHD", Name = "maHD", Width = 160 });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Khách Hàng", DataPropertyName = "maKH", Name = "maKH", Width = 160 });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Khách Hàng", DataPropertyName = "tenKH", Name = "tenKH", Width = 150 });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên NV", DataPropertyName = "tenNV", Name = "tenNV", Width = 150 });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày", DataPropertyName = "ngayChuyenDoi", Name = "ngayChuyenDoi", Width = 170 });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng Tiền", DataPropertyName = "tongTien", Name = "tongTien", Width = 150 });

            originalData = dt.Copy();

            // Gán dữ liệu vào DataGridView
            dgvBill.DataSource = dt;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string nameKH = txNameKH.Text.Trim();
            bool hasNameKH = !string.IsNullOrEmpty(nameKH);

            bool hasDate = dateTime.CustomFormat != " ";


            if (originalData == null || originalData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = (DataTable)dgvBill.DataSource;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lọc dữ liệu
            DataView dv = dt.DefaultView;

            if (hasNameKH && hasDate)
            {
                // Lọc theo cả tên khách hàng và ngày
                dv.RowFilter = $"tenKH LIKE '%{nameKH}%' AND ngayChuyenDoi = '{dateTime.Value.ToString("dd/MM/yyyy")}'";
            }
            else if (hasNameKH)
            {
                // Lọc chỉ theo tên khách hàng
                dv.RowFilter = $"tenKH LIKE '%{nameKH}%'";

            }
            else if (hasDate)
            {
                // Lọc chỉ theo ngày
                dv.RowFilter = $"ngayChuyenDoi  = '{dateTime.Value.ToString("dd/MM/yyyy")}'";
            }
            else
            {
                // Không có điều kiện, hiển thị toàn bộ dữ liệu
                dgvBill.DataSource = originalData.Copy();
                MessageBox.Show("Cả hai trường đều trống!");
                return;
            }

            // Kiểm tra kết quả sau lọc
            if (dv.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvBill.DataSource = dv.ToTable();
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txNameKH.Text = "";
            ClearDatePicker(dateTime);
            dgvBill.DataSource = originalData.Copy();
        }
        private void ClearDatePicker(DateTimePicker datePicker)
        {
            // Thiết lập định dạng hiển thị trống
            datePicker.CustomFormat = " ";
            datePicker.Format = DateTimePickerFormat.Custom;
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker datePicker = sender as DateTimePicker;
            if (datePicker != null)
            {
                // Khôi phục định dạng mặc định
                datePicker.CustomFormat = "dd/MM/yyyy";
                datePicker.Format = DateTimePickerFormat.Custom;
            }
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBill.Rows.Count)
            {
                // Lấy thông tin từ dòng được nhấp đúp
                DataGridViewRow selectedRow = dgvBill.Rows[e.RowIndex];

                string maHD = selectedRow.Cells["maHD"].Value?.ToString();
                string tenKH = selectedRow.Cells["tenKH"].Value?.ToString();
                string ngayChuyenDoi = selectedRow.Cells["ngayChuyenDoi"].Value?.ToString();
                string tenNV = selectedRow.Cells["tenNV"].Value?.ToString();
                string tongTien = selectedRow.Cells["tongTien"].Value?.ToString();


                dialogCTHoaDon chiTietForm = new dialogCTHoaDon(ngayChuyenDoi, tongTien, tenKH, tenNV, maHD);
                chiTietForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            if (dgvBill.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DataGridViewRow selectedRow = dgvBill.SelectedRows[0];
            string maHoaDon = selectedRow.Cells["maHD"].Value?.ToString();

            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Không thể lấy mã hóa đơn từ dòng được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị xác nhận xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn có mã '{maHoaDon}' không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                dgvBill.Rows.Remove(selectedRow);

                hoaDon.xoaHoaDon(maHoaDon);

                // Lấy danh sách chi tiết hóa đơn từ file XML
                DataTable dtChiTietHoaDon = Fxml.HienThi("ChiTietHoaDon.xml");
                DataView dv = dtChiTietHoaDon.DefaultView;
                dv.RowFilter = $"maHD = '{maHoaDon}'";

                // Duyệt qua các dòng chi tiết hóa đơn có liên quan
                foreach (DataRowView rowView in dv)
                {
                    DataRow row = rowView.Row; 
                    string maChiTiet = row["maChiTiet"]?.ToString(); 
                    if (!string.IsNullOrEmpty(maChiTiet))
                    {
                        hoaDon.xoaCTHoaDon(maChiTiet);
                    }
                }

                MessageBox.Show($"Hóa đơn có mã '{maHoaDon}' đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
