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
    public partial class frmNVNhaCungCap : Form
    {
        FileXml Fxml = new FileXml();
        private DataTable originalData; // Lưu trữ DataTable gốc
        NhaCungCap nhaCungCap = new NhaCungCap();

        public frmNVNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNVNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiNhaCungCap();
        }

        public void HienThiNhaCungCap()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("NhaCungCap.xml");

            // Cấu hình DataGridView
            dgvNhaCungCap.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvNhaCungCap.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width - DataPropertyName là tên trường
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã nhà cung cấp", DataPropertyName = "maNhaCungCap", Name = "maNhaCungCap", Width = 110 });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên nhà cung cấp", DataPropertyName = "tenNhaCungCap", Name = "tenNhaCungCap", Width = 150 });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số điện thoại", DataPropertyName = "sdt", Name = "sdt", Width = 100 });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa chỉ", DataPropertyName = "diaChi", Name = "diaChi", Width = 150 });

            originalData = dt.Copy();

            // Gán dữ liệu vào DataGridView
            dgvNhaCungCap.DataSource = dt;
            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    

    
        private void DialogNVNhaCungCap_OnSaveSuccess(object sender, EventArgs e)
        {
            HienThiNhaCungCap();
        }

     
 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dialogNVNhaCungCap dialogNVNhaCungCap = new dialogNVNhaCungCap();
            // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
            dialogNVNhaCungCap.OnSaveSuccess += DialogNVNhaCungCap_OnSaveSuccess;
            dialogNVNhaCungCap.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvNhaCungCap.SelectedRows[0];

                // Kiểm tra xem cột maKH có tồn tại
                if (selectedRow.Cells["maNhaCungCap"] != null)
                {
                    // Lấy giá trị của cột "maKH"
                    string maNhaCungCap = selectedRow.Cells["maNhaCungCap"].Value.ToString();
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        nhaCungCap.XoaNhaCungCap(maNhaCungCap);
                        HienThiNhaCungCap();
                    }

                }
                else
                {
                    MessageBox.Show("Cột 'maNhaCungCap' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             if (dgvNhaCungCap.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvNhaCungCap.SelectedRows[0];

                // Kiểm tra xem cột maTC có tồn tại
                if (selectedRow.Cells["maNhaCungCap"] != null)
                {
                    // Lấy giá trị của cột "maTC"
                    int maNhaCungCap = Convert.ToInt32(selectedRow.Cells["maNhaCungCap"].Value);

                    // Hiển thị dialog với giá trị maThuCung
                    dialogNVNhaCungCap dialog = new dialogNVNhaCungCap(maNhaCungCap);
                    // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
                    dialog.OnSaveSuccess += DialogNVNhaCungCap_OnSaveSuccess;
                    dialog.ShowDialog(); // Hiển thị dialog
                }
                else
                {
                    MessageBox.Show("Cột 'maNhaCungCap' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để chỉnh sửa.");
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
            DataTable dt = (DataTable)dgvNhaCungCap.DataSource;

            // Kiểm tra nếu DataTable không null và có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                string maNhaCungCap = txtTim.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maNhaCungCap))
                {
                    dgvNhaCungCap.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maNhaCungCap = '{maNhaCungCap}'"; // Điều kiện lọc dựa vào cột `maKH`

                // Kiểm tra nếu không có kết quả phù hợp
                if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có mã phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu đã lọc vào DataGridView
                dgvNhaCungCap.DataSource = dv.ToTable();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtTim.Text = "";
            txtTim.Focus();
        }
    }
}
