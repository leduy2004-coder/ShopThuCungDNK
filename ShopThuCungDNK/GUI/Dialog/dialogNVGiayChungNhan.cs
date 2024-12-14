using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopThuCungDNK.GUI.Dialog
{
    public partial class dialogNVGiayChungNhan : Form
    {


        FileXml Fxml = new FileXml();
        GiayChungNhan giayChungNhan = new GiayChungNhan();
        string maThCung, maLoai;
        private DataTable originalData;
        public event EventHandler OnSaveSuccess;
        private bool isEditMode = false; // Biến xác định chế độ chỉnh sửa
        private int maGiayChungNhan; // Biến lưu mã thú cưng khi chỉnh sửa
        public dialogNVGiayChungNhan()
        {
            InitializeComponent();
            isEditMode = false; // Chế độ thêm mới

        }


        public dialogNVGiayChungNhan(int maGiayChungNhan)
        {
            InitializeComponent();
            isEditMode = true; // Chế độ chỉnh sửa
            this.maGiayChungNhan = maGiayChungNhan;
        }

        private void dialogNVGiayChungNhan_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            HienThiThuCung();


            // Thiết lập định dạng DateTimePicker để chỉ hiển thị số
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy"; // Hiển thị dạng ngày/tháng/năm

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            // Nếu chế độ chỉnh sửa, điền dữ liệu vào các ô
            if (isEditMode)
            {
                // Ví dụ điền dữ liệu, bạn cần thay thế bằng logic lấy dữ liệu từ cơ sở dữ liệu hoặc XML
                DataRow row = GetGiayChungNhanById(maGiayChungNhan);
                cbxType.Text = row["maLoaiGiay"].ToString();
                dateTimePicker1.Text = row["ngayCap"].ToString();
                dateTimePicker2.Text = row["ngayHetHan"].ToString();
                nguoiCap.Text = row["nguoiCap"].ToString();
                chiTiet.Text = row["chiTiet"].ToString();
                maThCung = row["maTC"].ToString();

                txtGiong.Text = Fxml.LayGiaTri("ThuCung.xml", "maTC", row["maTC"].ToString(), "giong");
                txtType.Text = Fxml.LayGiaTri("LoaiThuCung.xml", "maLoai", row["maTC"].ToString(), "tenLoai");

            }
            else
            {
                // Nếu là chế độ thêm mới, làm trống các ô
                maGiayChungNhan = Fxml.LayMaxValueFromXml("NhaCungCap.xml", "maNhaCungCap");
               
                btnRemove.Visible = false;
            }
        }

        private DataRow GetGiayChungNhanById(int maNCC)
        {
            // Thay thế logic lấy thông tin thú cưng từ cơ sở dữ liệu hoặc XML
            DataTable dt = Fxml.HienThi("GiayChungNhan.xml");
            var row = dt.Select("maGiayChungNhan = " + maNCC).FirstOrDefault();
            return row;
        }


        private void LoadComboBoxes()
        {
            DataTable dtLoai = Fxml.HienThi("LoaiGiayChungNhan.xml");

            // Thêm cột tạm để hiển thị "maKH | tenKH"
            dtLoai.Columns.Add("MaVaTen", typeof(string), "maLoaiGiay + ' | ' + tenLoaiGiay");

            cbxType.DataSource = dtLoai;
            cbxType.DisplayMember = "MaVaTen";
            cbxType.ValueMember = "maLoaiGiay";
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedItem != null)
            {

                DataRowView selectedRow = cbxType.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    maLoai = selectedRow["maLoaiGiay"].ToString();
                    
                }
            }
        }

        private void dgvThuCung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow selectedRow = dgvThuCung.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào TextBox

                int maTC = Convert.ToInt32(selectedRow.Cells["maTC"].Value);
                txtType.Text = Fxml.LayGiaTri("LoaiThuCung.xml", "maLoai", maTC.ToString(), "tenLoai");
                //txtType.Text = selectedRow.Cells["giong"].Value?.ToString();
                txtGiong.Text = selectedRow.Cells["giong"].Value?.ToString();
                maThCung = selectedRow.Cells["maTC"].Value?.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                // Lấy các dữ liệu từ các ô nhập liệu
                string maLoaiGiay =cbxType.SelectedValue.ToString();
                DateTime ngayCap = dateTimePicker1.Value;
                DateTime ngayHetHan = dateTimePicker2.Value;

                string nguoiCapGiay = nguoiCap.Text;
                string mota = chiTiet.Text;




                if (isEditMode)
                {
                    // Cập nhật khách
                    giayChungNhan.SuaGiayChungNhan(maGiayChungNhan.ToString(), maThCung, maLoaiGiay, ngayCap, ngayHetHan, nguoiCapGiay, mota);
                }
                else
                {
                    int ma = Fxml.LayMaxValueFromXml("GiayChungNhan.xml", "maGiayChungNhan");
                    // Thêm mới khách
                    giayChungNhan.ThemGiayChungNhan(ma.ToString(), maThCung, maLoaiGiay, ngayCap, ngayHetHan, nguoiCapGiay, mota);
                }

                OnSaveSuccess?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi lưu thành công
                this.Close();

                MessageBox.Show("Dữ liệu đã được lưu thành công!");
            }
        }

        private bool KiemTraDuLieu()
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                MessageBox.Show("Chưa chọn thú cưng!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbxType.Text))
            {
                MessageBox.Show("Loại giấy không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                MessageBox.Show("Ngày cấp không được để trống!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text))
            {
                MessageBox.Show("Ngày hết hạn không được để trống!");
                return false;
            }


            return true;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Giấy chứng nhận này?", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    giayChungNhan.XoaGiayChungNhan(maGiayChungNhan.ToString());
                    OnSaveSuccess?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa.");
            }
        }

        private void HienThiThuCung()
        {
            // Lấy dữ liệu từ file XML
            DataTable dt = Fxml.HienThi("ThuCung.xml");

            // Thêm các cột bổ sung vào DataTable
            dt.Columns.Add("loaiThuCung", typeof(string));

            // Tra cứu thông tin từ các bảng liên quan và điền vào DataTable
            foreach (DataRow row in dt.Rows)
            {
                int maLoai = Convert.ToInt32(row["maLoai"]);
                row["loaiThuCung"] = Fxml.LayGiaTri("LoaiThuCung.xml", "maLoai", maLoai.ToString(), "tenLoai");
            }

            // Cấu hình DataGridView
            dgvThuCung.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dgvThuCung.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã", DataPropertyName = "maTC", Name = "maTC", Width = 30 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại", DataPropertyName = "loaiThuCung", Width = 70 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tuổi", DataPropertyName = "tuoi", Width = 60 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giống", DataPropertyName = "giong", Name = "giong", Width = 160 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá Bán", DataPropertyName = "giaTC", Name = "giaTC", Width = 90 });
            dgvThuCung.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số Lượng", DataPropertyName = "soLuong", Name = "soLuong", Width = 80 });

            originalData = dt.Copy();
            // Gán dữ liệu vào DataGridView
            dgvThuCung.DataSource = dt;

        }


    }
}
