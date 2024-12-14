using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopThuCungDNK.GUI
{
    public partial class frmDiemDanh : Form
    {
        FileXml Fxml = new FileXml();
        
        public frmDiemDanh()
        {
           
            InitializeComponent();
        }
        public void hienthiDiemDanh()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("DiemDanh.xml");
            dataGridView1.DataSource = dt;

            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadTenNhanVienToComboBoxFromXml()
        {
            string filePath = Application.StartupPath + "\\NguoiDung.xml"; // Đảm bảo đường dẫn đúng đến file XML
            if (File.Exists(filePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNodeList nodeList = doc.SelectNodes("/NewDataSet/NguoiDung/tenNV");

                foreach (XmlNode node in nodeList)
                {
                    // Thêm tên nhân viên vào ComboBox
                    comboBox1.Items.Add(node.InnerText);
                }
            }
            else
            {
                MessageBox.Show("File XML không tồn tại!");
            }
        }

        
        private void frmDiemDanh_Load(object sender, EventArgs e)
        {
            LoadTenNhanVienToComboBoxFromXml();
            hienthiDiemDanh();  // Hiển thị tất cả dữ liệu điểm danh
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenNVSelected = comboBox1.SelectedItem.ToString();  // Lấy tên nhân viên đã chọn
            hienthiDiemDanhTheoTen(tenNVSelected);  // Hiển thị danh sác
        }
        private void hienthiDiemDanhTheoTen(string tenNV)
        {
            string diemDanhFilePath = Application.StartupPath + "\\DiemDanh.xml";
            string nguoiDungFilePath = Application.StartupPath + "\\NguoiDung.xml";

            if (File.Exists(diemDanhFilePath) && File.Exists(nguoiDungFilePath))
            {
                DataSet dsDiemDanh = new DataSet();
                dsDiemDanh.ReadXml(diemDanhFilePath);  // Đọc dữ liệu từ file DiemDanh.xml

                DataSet dsNguoiDung = new DataSet();
                dsNguoiDung.ReadXml(nguoiDungFilePath);  // Đọc dữ liệu từ file NguoiDung.xml

                // Tạo một DataTable để chứa dữ liệu kết hợp
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã điểm danh");
                dt.Columns.Add("Tên nhân viên");
                dt.Columns.Add("Ngày điểm danh");

                // Lặp qua các bản ghi trong DiemDanh
                foreach (DataRow diemDanhRow in dsDiemDanh.Tables[0].Rows)
                {
                    int maNV = Convert.ToInt32(diemDanhRow["maNV"]);
                    string ngayDiemDanh = diemDanhRow["ngayDiemDanh"].ToString();

                    // Tìm nhân viên theo maNV trong bảng NguoiDung
                    DataRow[] nguoiDungRows = dsNguoiDung.Tables[0].Select("maNV = " + maNV);

                    if (nguoiDungRows.Length > 0)
                    {
                        string tenNVFromXml = nguoiDungRows[0]["tenNV"].ToString();

                        // Nếu tên nhân viên trong DiemDanh khớp với tên nhân viên đã chọn
                        if (tenNVFromXml.Equals(tenNV, StringComparison.OrdinalIgnoreCase))
                        {
                            // Thêm dữ liệu vào DataTable
                            dt.Rows.Add(diemDanhRow["maDiemDanh"], tenNVFromXml, ngayDiemDanh);
                        }
                    }
                }

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Một hoặc cả hai file XML không tồn tại.");
            }
        }
    }
}
