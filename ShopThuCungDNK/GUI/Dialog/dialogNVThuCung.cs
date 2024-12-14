using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class dialogNVThuCung : Form
    {
        public event EventHandler OnSaveSuccess;
        ThuCung ThuCung = new ThuCung();
        FileXml Fxml = new FileXml();
        private bool isEditMode = false; // Biến xác định chế độ chỉnh sửa
        private int maThuCung; // Biến lưu mã thú cưng khi chỉnh sửa
        private bool kiemTraUpAnh = false;
        byte[] imageBytes = null;
        string hinhAnh = null;

        public dialogNVThuCung()
        {
            InitializeComponent();
            isEditMode = false; // Chế độ thêm mới
        }

        // Constructor với tham số cho chế độ chỉnh sửa
        public dialogNVThuCung(int maThuCung)
        {
            InitializeComponent();
            isEditMode = true; // Chế độ chỉnh sửa
            this.maThuCung = maThuCung;
        }
        private void dialogNVThuCung_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            // Nếu chế độ chỉnh sửa, điền dữ liệu vào các ô
            if (isEditMode)
            {
                // Ví dụ điền dữ liệu, bạn cần thay thế bằng logic lấy dữ liệu từ cơ sở dữ liệu hoặc XML
                DataRow row = GetThuCungById(maThuCung);
                lbMa.Text = maThuCung.ToString();
                txtAge.Text = row["tuoi"].ToString();
                txtSpecie.Text = row["giong"].ToString();
                txtMoney.Text = row["giaTC"].ToString();
                txtCount.Text = row["soLuong"].ToString();


                SetComboBoxSelectedValue(cbxType, row["maLoai"].ToString());
                SetComboBoxSelectedValue(cbxProvider, row["maNhaCungCap"].ToString());
                SetComboBoxSelectedValue(cbxStatus, row["maTinhTrang"].ToString());

                // Lấy hình ảnh từ cơ sở dữ liệu và gán vào PictureBox
                imageBytes = row["hinhAnh"] as byte[];
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        picture.Image = image; // Gán ảnh vào PictureBox
                        picture.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo ảnh hiển thị đúng                      
                    }
                }
            }
            else
            {
                // Nếu là chế độ thêm mới, làm trống các ô
                cbxType.SelectedIndex = 0;
                txtAge.Clear();
                txtSpecie.Clear();
                cbxProvider.SelectedIndex = 0;
                cbxStatus.SelectedIndex = 0;
                txtMoney.Clear();
                txtCount.Clear();
                lbMa.Visible = false;
                picture.Image = null;
                btnRemove.Visible = false;
            }

        }
        // Phương thức để lấy thông tin thú cưng theo mã
        private DataRow GetThuCungById(int maThuCung)
        {
            // Thay thế logic lấy thông tin thú cưng từ cơ sở dữ liệu hoặc XML
            DataTable dt = Fxml.HienThi("ThuCung.xml");
            var row = dt.Select("maTC = " + maThuCung).FirstOrDefault();
            return row;
        }
        // Điền giá trị vào ComboBox khi chỉnh sửa
        private void SetComboBoxSelectedValue(ComboBox comboBox, string value)
        {
            // Duyệt qua các item trong ComboBox
            foreach (var item in comboBox.Items)
            {
                // Kiểm tra nếu item là DataRowView (vì DataSource của bạn là DataTable)
                if (item is DataRowView dataRowView)
                {
                    // Lấy giá trị của item theo ValueMember
                    var itemValue = dataRowView[comboBox.ValueMember]?.ToString();

                    // So sánh giá trị của item với value
                    if (itemValue == value)
                    {
                        comboBox.SelectedItem = item; // Chọn item tương ứng
                        break; // Dừng vòng lặp khi tìm thấy
                    }
                }
            }
        }

        private void LoadComboBoxes()
        {
            DataTable dtLoai = Fxml.HienThi("LoaiThuCung.xml");
            DataTable dtNhaCC = Fxml.HienThi("NhaCungCap.xml");
            DataTable dtTrangThai = Fxml.HienThi("TinhTrang.xml");

            cbxType.DataSource = dtLoai;
            cbxType.DisplayMember = "tenLoai";
            cbxType.ValueMember = "maLoai";

            cbxProvider.DataSource = dtNhaCC;
            cbxProvider.DisplayMember = "tenNhaCungCap";
            cbxProvider.ValueMember = "maNhaCungCap";

            cbxStatus.DataSource = dtTrangThai;
            cbxStatus.DisplayMember = "moTa";
            cbxStatus.ValueMember = "maTinhTrang";
        }

        // Xử lý sự kiện Xóa
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho OpenFileDialog
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.InitialDirectory = @"E:\";

            // Kiểm tra nếu người dùng chọn ảnh và nhấn "Open"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của ảnh
                string filePath = openFileDialog.FileName;

                // Gán ảnh vào PictureBox
                picture.Image = Image.FromFile(filePath);
                picture.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo ảnh hiển thị đúng kích thước
                hinhAnh = "ok";
                kiemTraUpAnh = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                // Lấy các dữ liệu từ các ô nhập liệu
                string tuoi = txtAge.Text;
                string giong = txtSpecie.Text;
                string giaTC = txtMoney.Text;
                string soLuong = txtCount.Text;

                // Chuyển các giá trị từ ComboBox thành kiểu string
                string maLoai = cbxType.SelectedValue.ToString();
                string maNhaCungCap = cbxProvider.SelectedValue.ToString();
                string maTinhTrang = cbxStatus.SelectedValue.ToString();

                // Khởi tạo mảng byte để lưu ảnh, sau đó chuyển thành chuỗi Base64

                if (picture.Image != null && kiemTraUpAnh)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picture.Image.Save(ms, picture.Image.RawFormat);
                        byte[] imageBytes = ms.ToArray();
                        hinhAnh = Convert.ToBase64String(imageBytes);
                    }
                }

                // Kiểm tra nếu có mã thú cưng (maThuCung), thực hiện cập nhật (sửa), còn không có thì thêm mới
                if (maThuCung != 0)
                {
                    if (!kiemTraUpAnh)
                        hinhAnh = Convert.ToBase64String(imageBytes);
                    // Cập nhật thú cưng
                    ThuCung.suaThuCung(maThuCung.ToString(), tuoi, giong, giaTC, soLuong, maLoai, maNhaCungCap, maTinhTrang, hinhAnh);
                }
                else
                {
                    // Thêm mới thú cưng
                    ThuCung.themThuCung(tuoi, giong, giaTC, soLuong, maLoai, maNhaCungCap, maTinhTrang, hinhAnh);
                }

                OnSaveSuccess?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi lưu thành công
                this.Close();

                MessageBox.Show("Dữ liệu đã được lưu thành công!");
            }

        }
        private bool KiemTraDuLieu()
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Tuổi không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSpecie.Text))
            {
                MessageBox.Show("Giống không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageBox.Show("Giá trị không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCount.Text))
            {
                MessageBox.Show("Số lượng không được để trống!");
                return false;
            }

            // Kiểm tra các ComboBox phải chọn giá trị hợp lệ
            if (cbxType.SelectedValue == null)
            {
                MessageBox.Show("Loại thú cưng phải được chọn!");
                return false;
            }
            if (cbxProvider.SelectedValue == null)
            {
                MessageBox.Show("Nhà cung cấp phải được chọn!");
                return false;
            }
            if (cbxStatus.SelectedValue == null)
            {
                MessageBox.Show("Tình trạng phải được chọn!");
                return false;
            }

            // Kiểm tra ảnh (nếu có yêu cầu)
            if (hinhAnh == null)  // Nếu yêu cầu có ảnh nhưng không có ảnh
            {
                MessageBox.Show("Ảnh không được để trống!");
                return false;
            }

            return true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thú cưng này?", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ThuCung.xoaThuCung(maThuCung.ToString());
                    OnSaveSuccess?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa.");
            }
        }
    }
}
