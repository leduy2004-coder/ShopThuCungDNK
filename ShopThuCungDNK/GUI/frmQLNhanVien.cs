using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQLNhanVien : Form
    {
        NhanVien nv = new NhanVien();
        FileXml Fxml = new FileXml();
        string MaNhanVien, TenNhanVien, Sdt, DiaChi, tk, mk;
        private DataTable originalData;
        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        public void hienthiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NguoiDung.xml");
            dataGridView1.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã nhân viên", DataPropertyName = "maNV", Name = "maLoai", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "tenNV", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số điện thoại", DataPropertyName = "sdt", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa chỉ", DataPropertyName = "diaChi", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tài khoản", DataPropertyName = "tk", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mật khẩu", DataPropertyName = "mk", Width = 110 });
            originalData = dt.Copy();

            dataGridView1.DataSource = dt;

            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            hienthiNhanVien();
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            if (originalData == null || originalData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy dữ liệu từ DataTable hiện tại của DataGridView
            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (dt != null && dt.Rows.Count > 0)
            {
                string maNV = txtTimKiem.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maNV))
                {
                    dataGridView1.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maNV= '{maNV}'";

                // Kiểm tra nếu không có kết quả phù hợp
                if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu đã lọc vào DataGridView
                dataGridView1.DataSource = dv.ToTable();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtTimKiem.Text = "";
            txtTimKiem.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            textBox6.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            txtTimKiem.Text = "";
        }

        // Load dữ liệu từ các trường nhập liệu vào đối tượng NguoiDung
        public void LoadDuLieu()
        {
            MaNhanVien = textBox6.Text;
            TenNhanVien = textBox1.Text;
            Sdt = textBox2.Text;
            DiaChi = textBox3.Text;
            tk = textBox4.Text;
            mk = textBox5.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (nv.KiemTra(MaNhanVien) == true)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
                return;
            }
            if (TenNhanVien == "" && Sdt == "" && DiaChi == "" && tk == "" && mk == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu");
                return;
            }

            nv.ThemNguoiDung(MaNhanVien, TenNhanVien, Sdt, DiaChi, tk, mk);
            MessageBox.Show("Thêm thành công");
            hienthiNhanVien();
            reset();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (dataGridView1.SelectedRows.Count > 0 && MaNhanVien != "")
            {
                nv.SuaNguoiDung(MaNhanVien, TenNhanVien, Sdt, DiaChi, tk, mk);
                MessageBox.Show("Sửa thành công");
                hienthiNhanVien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
            }
            reset();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có hàng được chọn

            int i = dataGridView1.CurrentRow.Index; // Lấy chỉ mục của hàng hiện tại
                                                    // Hiển thị dữ liệu từ hàng được chọn lên các TextBox
            textBox6.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (dataGridView1.SelectedRows.Count > 0 && MaNhanVien != "")
            {
                nv.XoaNguoiDung(MaNhanVien);
                MessageBox.Show("Xóa thành công");
                hienthiNhanVien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
            reset();
        }
    }
}
