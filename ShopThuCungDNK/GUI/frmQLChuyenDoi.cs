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
    public partial class frmQLChuyenDoi : Form
    {
        HeThong HT = new HeThong();

        public frmQLChuyenDoi()
        {
            InitializeComponent();
        }

        private void XmlSql_Click(object sender, EventArgs e)
        {
            try
            {
                HT.CapNhapSQL();
                MessageBox.Show("Cập nhập SQL server thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void SqlXml_Click(object sender, EventArgs e)
        {
            try
            {
                HT.XoaHetFileXML();
                HT.TaoXML();
                MessageBox.Show("Tạo XML thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
