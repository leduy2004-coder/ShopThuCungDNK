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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ShopThuCungDNK.GUI
{
    public partial class frmNVKhachHang : Form
    {
        FileXml Fxml = new FileXml();
        private DataTable originalData; // Lưu trữ DataTable gốc
        KhachHang khachhang = new KhachHang();

        public frmNVKhachHang()
        {
            InitializeComponent();
        }
        private void frmNVKhachHang_Load(object sender, EventArgs e)
        {
            HienThiKhachHang();
        }

         public void HienThiKhachHang()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("KhachHang.xml");


            // Cấu hình DataGridView
            dgvKhachHang.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvKhachHang.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width  -  DataPropertyName là tên trường
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã khách hàng", DataPropertyName = "maKH", Name = "maKH", Width = 110 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "tenKH", Width = 110 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số điện thoại", DataPropertyName = "sdt", Width = 80 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa chỉ", DataPropertyName = "diaChi", Width = 150 });
          

            originalData = dt.Copy();

            // Gán dữ liệu vào DataGridView
            dgvKhachHang.DataSource = dt;
            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (originalData == null || originalData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy dữ liệu từ DataTable hiện tại của DataGridView
            DataTable dt = (DataTable)dgvKhachHang.DataSource;

            // Kiểm tra nếu DataTable không null và có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                string maKH = txtTim.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maKH))
                {
                    dgvKhachHang.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maKH = '{maKH}'"; // Điều kiện lọc dựa vào cột `maKH`

                // Kiểm tra nếu không có kết quả phù hợp
                if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu đã lọc vào DataGridView
                dgvKhachHang.DataSource = dv.ToTable();
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
            dialogNVKhachHang dialogNVKhachHang = new dialogNVKhachHang();
            // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
            dialogNVKhachHang.OnSaveSuccess += DialogNVKhachHang_OnSaveSuccess;
            dialogNVKhachHang.ShowDialog();
        }
        private void DialogNVKhachHang_OnSaveSuccess(object sender, EventArgs e)
        {
            HienThiKhachHang();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvKhachHang.SelectedRows[0];

                // Kiểm tra xem cột maKH có tồn tại
                if (selectedRow.Cells["maKH"] != null)
                {
                    // Lấy giá trị của cột "maKH"
                    string maKH = selectedRow.Cells["maKH"].Value.ToString();
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        khachhang.XoaKhachHang(maKH);
                        HienThiKhachHang();
                    }

                }
                else
                {
                    MessageBox.Show("Cột 'maKH' không tồn tại trong dòng dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvKhachHang.SelectedRows[0];

                // Kiểm tra xem cột maTC có tồn tại
                if (selectedRow.Cells["maKH"] != null)
                {
                    // Lấy giá trị của cột "maTC"
                    int maKH = Convert.ToInt32(selectedRow.Cells["maKH"].Value);

                    // Hiển thị dialog với giá trị maThuCung
                    dialogNVKhachHang dialog = new dialogNVKhachHang(maKH);
                    // Đăng ký sự kiện để khi lưu thành công thì thực hiện hành động
                    dialog.OnSaveSuccess += DialogNVKhachHang_OnSaveSuccess;
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
    }


    
}
