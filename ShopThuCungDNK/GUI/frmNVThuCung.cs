using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
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
    public partial class frmNVThuCung : Form
    {
        FileXml Fxml = new FileXml();
        private DataTable originalData; // Lưu trữ DataTable gốc
        ThuCung thuCung = new ThuCung();
        public frmNVThuCung()
        {
            InitializeComponent();
        }
        public void HienThiThuCung()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("ThuCung.xml");

            // Thêm các cột bổ sung vào DataTable
            dt.Columns.Add("loaiThuCung", typeof(string));
            dt.Columns.Add("tinhTrang", typeof(string));
            dt.Columns.Add("nhaCC", typeof(string));

            // Tra cứu thông tin từ các bảng liên quan và điền vào DataTable
            foreach (DataRow row in dt.Rows)
            {
                int maLoai = Convert.ToInt32(row["maLoai"]);
                row["loaiThuCung"] = Fxml.LayGiaTri("LoaiThuCung.xml", "maLoai", maLoai.ToString(), "tenLoai");

                int maNhaCungCap = Convert.ToInt32(row["maNhaCungCap"]);
                row["nhaCC"] = Fxml.LayGiaTri("NhaCungCap.xml", "maNhaCungCap", maNhaCungCap.ToString(), "tenNhaCungCap");

                int maTinhTrang = Convert.ToInt32(row["maTinhTrang"]);
                row["tinhTrang"] = Fxml.LayGiaTri("TinhTrang.xml", "maTinhTrang", maTinhTrang.ToString(), "moTa");
            }

            // Cấu hình DataGridView
            dgvThuCung.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvThuCung.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Thú Cưng", DataPropertyName = "maTC", Name = "maTC", Width = 110 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại Thú Cưng", DataPropertyName = "loaiThuCung", Width = 110 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tuổi", DataPropertyName = "tuoi", Width = 80 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giống", DataPropertyName = "giong", Width = 170 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tình Trạng", DataPropertyName = "tinhTrang", Width = 120 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nhà Cung Cấp", DataPropertyName = "nhaCC", Width = 180 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá Bán", DataPropertyName = "giaTC", Width = 100 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số Lượng", DataPropertyName = "soLuong", Width = 80 });

            originalData = dt.Copy();

            // Gán dữ liệu vào DataGridView
            dgvThuCung.DataSource = dt;

        }


        private void frmNVThuCung_Load(object sender, EventArgs e)
        {
            HienThiThuCung();
        }

        private void dgvThuCung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (originalData == null || originalData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy dữ liệu từ DataTable hiện tại của DataGridView
            DataTable dt = (DataTable)dgvThuCung.DataSource;

            // Kiểm tra nếu DataTable không null và có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                string maTC = txtTim.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maTC))
                {
                    dgvThuCung.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maTC = '{maTC}'"; // Điều kiện lọc dựa vào cột `maTC`

                // Kiểm tra nếu không có kết quả phù hợp
                if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thú cưng có mã phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu đã lọc vào DataGridView
                dgvThuCung.DataSource = dv.ToTable();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtTim.Text = "";
            txtTim.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dialogNVThuCung dialogNVThuCung = new dialogNVThuCung();
            // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
            dialogNVThuCung.OnSaveSuccess += DialogNVThuCung_OnSaveSuccess;
            dialogNVThuCung.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvThuCung.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvThuCung.SelectedRows[0];

                // Kiểm tra xem cột maTC có tồn tại
                if (selectedRow.Cells["maTC"] != null)
                {
                    // Lấy giá trị của cột "maTC"
                    int maThuCung = Convert.ToInt32(selectedRow.Cells["maTC"].Value);

                    // Hiển thị dialog với giá trị maThuCung
                    dialogNVThuCung dialog = new dialogNVThuCung(maThuCung);
                    // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
                    dialog.OnSaveSuccess += DialogNVThuCung_OnSaveSuccess;
                    dialog.ShowDialog(); // Hiển thị dialog
                }
                else
                {
                    MessageBox.Show("Cột 'maTC' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để chỉnh sửa.");
            }

        }
        private void DialogNVThuCung_OnSaveSuccess(object sender, EventArgs e)
        {
            HienThiThuCung();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvThuCung.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvThuCung.SelectedRows[0];

                // Kiểm tra xem cột maTC có tồn tại
                if (selectedRow.Cells["maTC"] != null)
                {
                    // Lấy giá trị của cột "maTC"
                    string maThuCung = selectedRow.Cells["maTC"].Value.ToString();
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thú cưng này?", "Xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        thuCung.xoaThuCung(maThuCung);
                        HienThiThuCung();
                    }

                }
                else
                {
                    MessageBox.Show("Cột 'maTC' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để chỉnh sửa.");
            }
        }
    }
}
