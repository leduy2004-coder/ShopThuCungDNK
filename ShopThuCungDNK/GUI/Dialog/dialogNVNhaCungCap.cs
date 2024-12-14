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

    public partial class dialogNVNhaCungCap : Form
    {
        public event EventHandler OnSaveSuccess;
        NhaCungCap nhaCungCap = new NhaCungCap();
        FileXml Fxml = new FileXml();
        private bool isEditMode = false; // Biến xác định chế độ chỉnh sửa
        private int maNCC; // Biến lưu mã thú cưng khi chỉnh sửa
        public dialogNVNhaCungCap()
        {
            InitializeComponent();
            isEditMode = false; // Chế độ thêm mới

        }


        public dialogNVNhaCungCap(int maNCC)
        {
            InitializeComponent();
            isEditMode = true; // Chế độ chỉnh sửa
            this.maNCC = maNCC;
        }

        private void dialogNVNhaCungCap_Load(object sender, EventArgs e)
        {

            // Nếu chế độ chỉnh sửa, điền dữ liệu vào các ô
            if (isEditMode)
            {
                // Ví dụ điền dữ liệu, bạn cần thay thế bằng logic lấy dữ liệu từ cơ sở dữ liệu hoặc XML
                DataRow row = GetNhaCungCapById(maNCC);
                lbMa.Text = maNCC.ToString();
                txtHoTen.Text = row["tenNhaCungCap"].ToString();
                txtSdt.Text = row["sdt"].ToString();
                txtDiaChi.Text = row["diachi"].ToString();


            }
            else
            {
                // Nếu là chế độ thêm mới, làm trống các ô
                lbMa.Text = Fxml.LayMaxValueFromXml("NhaCungCap.xml","maNhaCungCap").ToString();
                txtHoTen.Clear();
                txtSdt.Clear();
                txtDiaChi.Clear();
                lbMa.Visible = false;
                btnRemove.Visible = false;
            }
        }

        private DataRow GetNhaCungCapById(int maNCC)
        {
            // Thay thế logic lấy thông tin thú cưng từ cơ sở dữ liệu hoặc XML
            DataTable dt = Fxml.HienThi("NhaCungCap.xml");
            var row = dt.Select("maNhaCungCap = " + maNCC).FirstOrDefault();
            return row;
        }

     
        private bool KiemTraDuLieu()
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return false;
            }


            return true;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Nhà cung cấp này?", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    nhaCungCap.XoaNhaCungCap(maNCC.ToString());
                    OnSaveSuccess?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                // Lấy các dữ liệu từ các ô nhập liệu
                string tenNCC = txtHoTen.Text;
                string sdt = txtSdt.Text;
                string diachi = txtDiaChi.Text;




                if (maNCC != 0)
                {
                    // Cập nhật khách
                    nhaCungCap.SuaNhaCungCap(maNCC.ToString(), tenNCC, sdt, diachi);
                }
                else
                {
                    int ma = Fxml.LayMaxValueFromXml("KhachHang.xml", "maKH");
                    // Thêm mới khách
                    nhaCungCap.ThemNhaCungCap(ma.ToString(), tenNCC, sdt, diachi);
                }

                OnSaveSuccess?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi lưu thành công
                this.Close();

                MessageBox.Show("Dữ liệu đã được lưu thành công!");
            }
        }
    }
}
