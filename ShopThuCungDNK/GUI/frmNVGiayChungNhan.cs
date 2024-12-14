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
    public partial class frmNVGiayChungNhan : Form
    {
        FileXml Fxml = new FileXml();
        private DataTable originalData; // Lưu trữ DataTable gốc
        GiayChungNhan giayChungNhan = new GiayChungNhan();

        
        public frmNVGiayChungNhan()
        {
            InitializeComponent();
        }

        private void frmNVGiayChungNhan_Load(object sender, EventArgs e)
        {
            HienThiGiayChungNhan();
        } 
        public void HienThiGiayChungNhan()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("GiayChungNhan.xml");

            // Thêm các cột bổ sung vào DataTable
            dt.Columns.Add("loaiGiayChungNhan", typeof(string));
            dt.Columns.Add("loaiThuCung", typeof(string));

            // Tra cứu thông tin từ các bảng liên quan và điền vào DataTable
            foreach (DataRow row in dt.Rows)
            {
                int maLoaiGiay = Convert.ToInt32(row["maLoaiGiay"]);
                row["loaiGiayChungNhan"] = Fxml.LayGiaTri("LoaiGiayChungNhan.xml", "maLoaiGiay", maLoaiGiay.ToString(), "tenLoaiGiay");

                int maTC = Convert.ToInt32(row["maTC"]);
                string ma1 = Fxml.LayGiaTri("ThuCung.xml", "maTC", maTC.ToString(), "maLoai");
                row["loaiThuCung"] = Fxml.LayGiaTri("LoaiThuCung.xml", "maLoai", ma1.ToString(), "tenLoai");


            }

            // Cấu hình DataGridView
            dgvGiayChungNhan.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvGiayChungNhan.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Giấy", DataPropertyName = "maGiayChungNhan", Name = "maGiayChungNhan", Width = 110 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại giấy", DataPropertyName = "loaiGiayChungNhan", Width = 110 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại thú cưng ", DataPropertyName = "loaiThuCung", Width = 100 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày cấp", DataPropertyName = "ngayCap", Width = 170 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày hết hạn", DataPropertyName = "ngayHetHan", Width = 120 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người cấp", DataPropertyName = "nguoiCap", Width = 180 });
            dgvGiayChungNhan.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chi tiết", DataPropertyName = "chiTiet", Width = 100 });

            originalData = dt.Copy();
            

            // Gán dữ liệu vào DataGridView
            dgvGiayChungNhan.DataSource = dt;
            dgvGiayChungNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            dialogNVGiayChungNhan dialogNVGiayChungNhan = new dialogNVGiayChungNhan();
            // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
            dialogNVGiayChungNhan.OnSaveSuccess += DialogNVGiayChungNhan_OnSaveSuccess;
            dialogNVGiayChungNhan.ShowDialog();
        }

        private void DialogNVGiayChungNhan_OnSaveSuccess(object sender, EventArgs e)
        {
            HienThiGiayChungNhan();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvGiayChungNhan.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvGiayChungNhan.SelectedRows[0];

                // Kiểm tra xem cột maGiayChungNhan có tồn tại
                if (selectedRow.Cells["maGiayChungNhan"] != null)
                {
                    // Lấy giá trị của cột "maGiayChungNhan"
                    int maGiayChungNhan = Convert.ToInt32(selectedRow.Cells["maGiayChungNhan"].Value);

                    // Hiển thị dialog với giá trị maThuCung
                    dialogNVGiayChungNhan dialog = new dialogNVGiayChungNhan(maGiayChungNhan);
                    // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
                    dialog.OnSaveSuccess += DialogNVGiayChungNhan_OnSaveSuccess;
                    dialog.ShowDialog(); // Hiển thị dialog
                }
                else
                {
                    MessageBox.Show("Cột 'maGiayChungNhan' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để chỉnh sửa.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvGiayChungNhan.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvGiayChungNhan.SelectedRows[0];

                // Kiểm tra xem cột maKH có tồn tại
                if (selectedRow.Cells["maGiayChungNhan"] != null)
                {
                    // Lấy giá trị của cột "maKH"
                    string maGiayChungNhan = selectedRow.Cells["maGiayChungNhan"].Value.ToString();
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Giấy chứng nhận này?", "Xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        giayChungNhan.XoaGiayChungNhan(maGiayChungNhan);
                        HienThiGiayChungNhan();
                    }

                }
                else
                {
                    MessageBox.Show("Cột 'maGiayChungNhan' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Giấy chứng nhận để chỉnh sửa.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (originalData == null || originalData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy dữ liệu từ DataTable hiện tại của DataGridView
            DataTable dt = (DataTable)dgvGiayChungNhan.DataSource;

            // Kiểm tra nếu DataTable không null và có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                string maGiayChungNhan = txtTim.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maGiayChungNhan))
                {
                    dgvGiayChungNhan.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maGiayChungNhan = '{maGiayChungNhan}'"; // Điều kiện lọc dựa vào cột `maKH`

                // Kiểm tra nếu không có kết quả phù hợp
                if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy Giấy chứng nhận có mã phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu đã lọc vào DataGridView
                dgvGiayChungNhan.DataSource = dv.ToTable();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtTim.Text = "";
            txtTim.Focus();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
