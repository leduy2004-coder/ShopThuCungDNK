using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class dialogNVKhachHang : Form
    {
        public event EventHandler OnSaveSuccess;
        KhachHang khachHang = new KhachHang();
        FileXml Fxml = new FileXml();
        private bool isEditMode = false; // Biến xác định chế độ chỉnh sửa
        private int maKH; // Biến lưu mã thú cưng khi chỉnh sửa
        public dialogNVKhachHang()
        {
            InitializeComponent();
            isEditMode = false; // Chế độ thêm mới

        }


        public dialogNVKhachHang(int maKH)
        {
            InitializeComponent();
            isEditMode = true; // Chế độ chỉnh sửa
            this.maKH = maKH;
        }

        private void dialogNVKhachHang_Load(object sender, EventArgs e)
        {
           
            // Nếu chế độ chỉnh sửa, điền dữ liệu vào các ô
            if (isEditMode)
            {
                // Ví dụ điền dữ liệu, bạn cần thay thế bằng logic lấy dữ liệu từ cơ sở dữ liệu hoặc XML
                DataRow row = GetKhachHangById(maKH);
                lbMa.Text = maKH.ToString();
                txtHoTen.Text = row["tenKH"].ToString();
                txtSdt.Text = row["sdt"].ToString();
                txtDiaChi.Text = row["diachi"].ToString();


            }
            else
            {
                // Nếu là chế độ thêm mới, làm trống các ô
                lbMa.Text = GetMaxMaKhachHang().ToString();
                txtHoTen.Clear();
                txtSdt.Clear();
                txtDiaChi.Clear();
                lbMa.Visible = false;
                btnRemove.Visible = false;
            }

        }
        // Phương thức để lấy thông tin thú cưng theo mã
        private DataRow GetKhachHangById(int maKH)
        {
            // Thay thế logic lấy thông tin thú cưng từ cơ sở dữ liệu hoặc XML
            DataTable dt = Fxml.HienThi("KhachHang.xml");
            var row = dt.Select("maKH = " + maKH).FirstOrDefault();
            return row;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                // Lấy các dữ liệu từ các ô nhập liệu
                string tenKH = txtHoTen.Text;
                string sdt = txtSdt.Text;
                string diachi = txtDiaChi.Text;




                if (maKH != 0)
                {
                    // Cập nhật khách
                    khachHang.SuaKhachHang(maKH.ToString(), tenKH, sdt, diachi);
                }
                else
                {
                    int ma = Fxml.LayMaxValueFromXml("KhachHang.xml", "maKH");
                    // Thêm mới khách
                    khachHang.ThemKhachHang(ma.ToString(), tenKH, sdt, diachi);
                }

                OnSaveSuccess?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi lưu thành công
                this.Close();

                MessageBox.Show("Dữ liệu đã được lưu thành công!");
            }
        }

        private bool KiemTraDuLieu()
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!");
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Khách hàng này?", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    khachHang.XoaKhachHang(maKH.ToString());
                    OnSaveSuccess?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private int GetMaxMaKhachHang()
        {
            DataTable dt = Fxml.HienThi("KhachHang.xml");
            if (dt.Rows.Count == 0) return 1; // Nếu chưa có khách hàng nào, trả về 1

            int maxMaKH = dt.AsEnumerable()
                            .Max(row => int.Parse(row["maKH"].ToString())); // Lấy giá trị lớn nhất
            return maxMaKH + 1; // Tăng thêm 1 để làm mã mới
        }
    }
}
