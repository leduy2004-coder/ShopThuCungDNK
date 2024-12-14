﻿using QuanLySieuThi.Class;
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
        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        public void hienthiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NguoiDung.xml");
            dataGridView1.DataSource = dt;

            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            hienthiNhanVien();
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("NguoiDung.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "maNV";
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
                dt.Columns.Add("Mã nhân viên");
                dt.Columns.Add("Họ và tên");
                dt.Columns.Add("SDT");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("Tài khoản");
                dt.Columns.Add("Mật khẩu");
                dt.Columns.Add("Mã role");


                object[] list = { dv[index]["maNV"], dv[index]["tenNV"], dv[index]["sdt"], dv[index]["diachi"], dv[index]["tk"], dv[index]["mk"], dv[index]["maRole"] };
                dt.Rows.Add(list);
                dataGridView1.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        // Load dữ liệu từ các trường nhập liệu vào đối tượng NguoiDung
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
            }
            else
            {
                nv.ThemNguoiDung(MaNhanVien, TenNhanVien, Sdt, DiaChi, tk, mk);
                MessageBox.Show("Ok");
                hienthiNhanVien();
                textBox6.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDuLieu();

            nv.SuaNguoiDung(MaNhanVien, TenNhanVien, Sdt, DiaChi, tk, mk);
            MessageBox.Show("Ok");
            hienthiNhanVien();

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
            nv.XoaNguoiDung(MaNhanVien);
            MessageBox.Show("Ok");
            hienthiNhanVien();
        }
    }
}