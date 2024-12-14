using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class frmNVThanhToan : Form
    {
        public static string maNVMain = "";

        FileXml Fxml = new FileXml();
        HoaDon HoaDon = new HoaDon();
        private int soLuongToiDa = 0;
        string maThCung, maKHang;
        DataTable billTable = new DataTable();
        decimal tongTien = 0;

        public frmNVThanhToan()
        {
            InitializeComponent();
        }

        private void frmNVThanhToan_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            HienThiThuCung();
            HienThiHoaDon();
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

            // Gán dữ liệu vào DataGridView
            dgvThuCung.DataSource = dt;

        }
        private void HienThiHoaDon()
        {
            billTable.Columns.Add("maTC", typeof(int));
            billTable.Columns.Add("giong", typeof(string));
            billTable.Columns.Add("soLuong", typeof(int));
            billTable.Columns.Add("giaTC", typeof(decimal));
            billTable.Columns.Add("tong", typeof(decimal));

            // Cấu hình DataGridView
            dvgBill.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dvgBill.Columns.Clear();

            // Thêm cột với header tiếng Việt và chỉnh Width
            dvgBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã TC", DataPropertyName = "maTC", Name = "maTC", Width = 70 });
            dvgBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giống", DataPropertyName = "giong", Name = "giong", Width = 140 });
            dvgBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = "soLuong", Name = "soLuong", Width = 40 });
            dvgBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá Bán", DataPropertyName = "giaTC", Name = "giaTC", Width = 90 });
            dvgBill.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng", DataPropertyName = "tong", Name = "tong", Width = 100 });

            dvgBill.DataSource = billTable;
 
            lbTotalMoney.Text = "";
        }
       
        private void LoadComboBoxes()
        {
            DataTable dtLoai = Fxml.HienThi("KhachHang.xml");

            // Thêm cột tạm để hiển thị "maKH | tenKH"
            dtLoai.Columns.Add("MaVaTen", typeof(string), "maKH + ' | ' + tenKH");

            cbxMaKH.DataSource = dtLoai;
            cbxMaKH.DisplayMember = "MaVaTen"; 
            cbxMaKH.ValueMember = "maKH";    
        }

        private void cbxMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaKH.SelectedItem != null)
            {
  
                DataRowView selectedRow = cbxMaKH.SelectedItem as DataRowView;
 
                if (selectedRow != null)
                {
                    lbName.Text = selectedRow["tenKH"].ToString();
                    maKHang = selectedRow["maKH"].ToString();
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
                txtType.Text = selectedRow.Cells["giong"].Value?.ToString(); 
                txtMoney.Text = selectedRow.Cells["giaTC"].Value?.ToString();
                soLuongToiDa = Convert.ToInt32(selectedRow.Cells["soLuong"].Value);
                maThCung = selectedRow.Cells["maTC"].Value?.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int soNhap;

            if (!int.TryParse(txtConnt.Text, out soNhap))
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtType.Text == "" || txtMoney.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thú cưng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> selectedPets = new List<string>();

            if (billTable.Rows.Count > 0)
            {
                foreach (DataRow row in billTable.Rows)
                {
                    string maTC = row["maTC"].ToString();
                    selectedPets.Add(maTC); 
                }

                // Kiểm tra nếu mã thú cưng đã có trong danh sách
                if (selectedPets.Contains(maThCung))
                {
                    MessageBox.Show("Đã chọn thú cưng này rồi !", "Lỗi chọn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (soLuongToiDa < soNhap)
            {
                MessageBox.Show("Số lượng nhập vượt quá số lượng hiện có!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string giong = txtType.Text; 
                int soLuong = int.Parse(txtConnt.Text); 
                decimal giaTC = decimal.Parse(txtMoney.Text);
                decimal tong = soLuong * giaTC; 

                // Thêm hàng vào DataTable
                billTable.Rows.Add(maThCung, giong, soLuong, giaTC, tong);

                tongTien = tongTien + tong;

                lbTotalMoney.Text = tongTien.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtConnt.Text = "";
            txtMoney.Text = "";
            txtType.Text = "";
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            txtConnt.Text = "";
            txtMoney.Text = "";
            txtType.Text = "";
            lbTotalMoney.Text = "";
            billTable.Clear();
            tongTien = 0;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dvgBill.SelectedRows.Count > 0)
            {
                // Xử lý các dòng được chọn, trong trường hợp có thể chọn nhiều dòng
                foreach (DataGridViewRow selectedRow in dvgBill.SelectedRows)
                {
                    // Lấy giá trị 'tong' từ dòng đã chọn và trừ từ tongTien
                    decimal tong = Convert.ToDecimal(selectedRow.Cells["tong"].Value);
                    tongTien -= tong;

                    // Cập nhật lại tổng tiền
                    lbTotalMoney.Text = tongTien.ToString();

                    // Xóa dòng khỏi DataGridView
                    dvgBill.Rows.RemoveAt(selectedRow.Index);

                }

                billTable.AcceptChanges();

                // Cập nhật lại tổng tiền sau khi xóa
                lbTotalMoney.Text = CalculateTotalMoney().ToString(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        // Hàm tính lại tổng tiền trong billTable
        private decimal CalculateTotalMoney()
        {
            decimal total = 0;
            foreach (DataRow row in billTable.Rows)
            {
                // Kiểm tra dòng chưa bị xóa
                if (row.RowState != DataRowState.Deleted)
                {
                    total += Convert.ToDecimal(row["tong"]);
                }
            }
            return total;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (maKHang.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn khách hàng !!");
                return;
            }
            if(billTable.Rows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn thú cưng !!");
                return;
            }

            string trangThai = "true";
            string tongTien = lbTotalMoney.Text;
            string ngayTao = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            // Gọi phương thức thêm hóa đơn
            HoaDon.themHoaDon(maKHang, maNVMain, trangThai, ngayTao, tongTien);
            ThemCTHoaDon();
            
            MessageBox.Show("Hóa đơn đã được thêm thành công!");

            reset();
        }

        private void ThemCTHoaDon()
        {
            // Kiểm tra xem bảng billTable có dữ liệu không
            if (billTable.Rows.Count > 0)
            {
                foreach (DataRow row in billTable.Rows)
                {
                    // Lấy giá trị cần thiết từ từng dòng
                    string maTC = row["maTC"].ToString();  
                    string soLuong = row["soLuong"].ToString(); 
                    string thanhTien = row["tong"].ToString();  

                    // Gọi phương thức để thêm chi tiết hóa đơn
                    HoaDon.themCTHoaDon(maTC, soLuong, thanhTien);
                }

            }
            else
            {
                // Thông báo nếu bảng không có dữ liệu
                MessageBox.Show("Không có dữ liệu để thêm chi tiết hóa đơn.");
            }
        }

    }

}
