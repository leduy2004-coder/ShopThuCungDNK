using QuanLySieuThi.Class;
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
    public partial class frmDangNhap : Form
    {
        FileXml Fxml = new FileXml();
        DangNhap dn = new DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") || txtPass.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống các trường!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUser.Focus();
            }
            else
            {
                // Kiểm tra tài khoản và mật khẩu
                DataRow user = dn.kiemtraTTDN("NguoiDung.xml", txtUser.Text, txtPass.Text);

                if (user != null) 
                {
                    MessageBox.Show("Đăng nhập thành công");

                    // Lấy MaRole từ DataRow
                    int maQuyen = Convert.ToInt32(user["maRole"]); 

                    // Gọi phương thức lấy quyền của người dùng
                    String code = dn.layMaQuyen(maQuyen);

                    // Lưu tên người dùng và chuyển tới form chính
                    
                    if (code.Equals("EMPLOYEE")) {
                        frmNhanVien.tenDNMain = user["tenNV"].ToString();
                        frmNhanVien.maNVMain = user["maNV"].ToString();
                        frmNhanVien frm = new frmNhanVien(); 
                        frm.Show();
                    }
                    else
                    {
                        frmQuanLy.tenDNMain = user["tenNV"].ToString();
                        frmQuanLy.maNVMain = user["maNV"].ToString();
                        frmQuanLy frm = new frmQuanLy();
                        frm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtUser.Focus();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
