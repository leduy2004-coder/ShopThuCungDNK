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

namespace ShopThuCungDNK.GUI
{
    public partial class frmQLLoaiThuCung : Form
    {
        LoaiThuCung l = new LoaiThuCung();
        FileXml Fxml = new FileXml();
        string MaLoai, TenLoai;
        private DataTable originalData;

        public frmQLLoaiThuCung()
        {
            
            InitializeComponent();
        }
        public void hienthiLoai()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("LoaiThuCung.xml");
            // Cấu hình DataGridView
            dataGridView1.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa các cột cũ nếu có
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã loài", DataPropertyName = "maLoai", Name = "maLoai", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên loài", DataPropertyName = "tenLoai", Width = 110 });

            originalData = dt.Copy();

            dataGridView1.DataSource = dt;

            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LoadDuLieu()
        {
            MaLoai = textBox1.Text;
            TenLoai = textBox2.Text;
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (l.KiemTra(MaLoai) == true)
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else
            {
                l.ThemLoai(MaLoai, TenLoai);
                MessageBox.Show("Ok");
                hienthiLoai();
                textBox1.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDuLieu();

            l.SuaLoai(MaLoai, TenLoai);
            MessageBox.Show("Ok");
            hienthiLoai();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            l.XoaLoai(MaLoai);
            MessageBox.Show("Ok");
            hienthiLoai();
        }

        private void frmQLLoaiThuCung_Load(object sender, EventArgs e)
        {
            hienthiLoai();
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
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
                string maLoai= txtTimKiem.Text.Trim();

                // Nếu input rỗng, hiển thị toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maLoai))
                {
                    dataGridView1.DataSource = originalData.Copy();
                    return;
                }

                // Lọc dữ liệu dựa vào mã thú cưng
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"maLoai= '{maLoai}'"; 

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


            /* XmlReader reader = XmlReader.Create("LoaiThuCung.xml");
             DataSet ds = new DataSet();
             ds.ReadXml(reader);
             DataView dv = new DataView(ds.Tables[0]);
             dv.Sort = "maLoai";
             reader.Close();
             int index = dv.Find(txtTimKiem.Text);
             if (index == -1)
             {
                 MessageBox.Show("Không tìm thấy");
                 txtTimKiem.Text = "";
                 txtTimKiem.Focus();

             }
             else
             {
                 DataTable dt = new DataTable();
                 dt.Columns.Add("Mã loài");
                 dt.Columns.Add("Tên loài");


                 object[] list = { dv[index]["maLoai"], dv[index]["tenLoai"]};
                 dt.Rows.Add(list);
                 dataGridView1.DataSource = dt;
                 txtTimKiem.Text = "";
             }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dataGridView1.CurrentRow.Index;
            textBox1.Text  = dataGridView1.Rows[d].Cells[0].Value?.ToString() ?? string.Empty;
            textBox2.Text  = dataGridView1.Rows[d].Cells[1].Value?.ToString() ?? string.Empty;
        }

    }
}
