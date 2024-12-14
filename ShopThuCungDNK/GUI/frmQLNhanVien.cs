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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQLNhanVien : Form
    {
        private string connectionString = "Data Source=LAPTOP-F30SDEST\\SQLEXPRESS;Initial Catalog=SHOPTHUCUNG;Integrated Security=True;Encrypt=False";
        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to fetch data from NguoiDung table
                    string query = "SELECT maNV, tenNV, sdt, diaChi, tk, mk, maRole FROM NguoiDung";

                    // SqlDataAdapter to execute the query and fill the data into DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind DataTable to DataGridView
                    dataGridView1.DataSource = dt;

                    // Optional: Adjust column headers
                    dataGridView1.Columns["maNV"].HeaderText = "Mã Nhân Viên";
                    dataGridView1.Columns["tenNV"].HeaderText = "Tên Nhân Viên";
                    dataGridView1.Columns["sdt"].HeaderText = "Số Điện Thoại";
                    dataGridView1.Columns["diaChi"].HeaderText = "Địa Chỉ";
                    dataGridView1.Columns["tk"].HeaderText = "Tài Khoản";
                    dataGridView1.Columns["mk"].HeaderText = "Mật Khẩu";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            // Lấy dữ liệu từ các TextBox và DateTimePicker
            string tenNV =  textBox1.Text.Trim();
            string sdt =    textBox2.Text.Trim();
            string diaChi = textBox3.Text.Trim();
            string tk =     textBox4.Text.Trim();
            string mk =     textBox5.Text.Trim();
        

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(tenNV) || string.IsNullOrWhiteSpace(sdt) ||
                string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(tk) ||
                string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu lệnh INSERT để chèn dữ liệu vào bảng NguoiDung
                    string query = @"INSERT INTO NguoiDung (tenNV, sdt, diaChi, tk, mk, maRole) 
                              VALUES (@tenNV, @sdt, @diaChi, @tk, @mk, @maRole)";

                    // Tạo SqlCommand để thực thi câu lệnh SQL
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán giá trị cho các tham số
                        cmd.Parameters.AddWithValue("@tenNV", tenNV);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@tk", tk);
                        cmd.Parameters.AddWithValue("@mk", mk);
                        cmd.Parameters.AddWithValue("@maRole", 1); // maRole cố định là 1

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Thông báo kết quả
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Làm mới hoặc tải lại dữ liệu trên DataGridView nếu cần
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            // Lấy dữ liệu từ các TextBox và DateTimePicker
            string tenNV =  textBox1.Text.Trim();
            string sdt =    textBox2.Text.Trim();
            string diaChi = textBox3.Text.Trim();
            string tk =     textBox4.Text.Trim();
            string mk =     textBox5.Text.Trim();
           

            // Lấy mã nhân viên từ hàng đang chọn trong DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maNV = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["maNV"].Value);

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(tenNV) || string.IsNullOrWhiteSpace(sdt) ||
                    string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(tk) ||
                    string.IsNullOrWhiteSpace(mk))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (sdt.Length != 10 || !sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Tạo kết nối đến cơ sở dữ liệu
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Câu lệnh UPDATE để cập nhật dữ liệu nhân viên
                        string query = @"UPDATE NguoiDung 
                                  SET tenNV = @tenNV, sdt = @sdt, diaChi = @diaChi, tk = @tk, mk = @mk
                                  WHERE maNV = @maNV";

                        // Tạo SqlCommand để thực thi câu lệnh SQL
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Gán giá trị cho các tham số
                            cmd.Parameters.AddWithValue("@tenNV", tenNV);
                            cmd.Parameters.AddWithValue("@sdt", sdt);
                            cmd.Parameters.AddWithValue("@diaChi", diaChi);
                            cmd.Parameters.AddWithValue("@tk", tk);
                            cmd.Parameters.AddWithValue("@mk", mk);
                        
                            cmd.Parameters.AddWithValue("@maNV", maNV);

                            // Thực thi câu lệnh
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Thông báo kết quả
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Làm mới hoặc tải lại dữ liệu trên DataGridView nếu cần
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có hàng được chọn
            
                int i = dataGridView1.CurrentRow.Index; // Lấy chỉ mục của hàng hiện tại
                                                        // Hiển thị dữ liệu từ hàng được chọn lên các TextBox
                textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            // Kiểm tra nếu có hàng được chọn trong DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ DataGridView (giả sử mã nhân viên là cột đầu tiên)
                int selectedRowIndex = dataGridView1.CurrentRow.Index;
                int maNV = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                try
                {
                    // Tạo kết nối đến cơ sở dữ liệu
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Câu lệnh DELETE để xóa nhân viên
                        string query = @"DELETE FROM NguoiDung WHERE maNV = @maNV";

                        // Tạo SqlCommand để thực thi câu lệnh SQL
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Gán giá trị cho tham số
                            cmd.Parameters.AddWithValue("@maNV", maNV);

                            // Thực thi câu lệnh
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Thông báo kết quả
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Làm mới hoặc tải lại dữ liệu trên DataGridView nếu cần
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Xóa nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
