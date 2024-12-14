using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace QuanLySieuThi.Class
{
    class DangNhap
    {
        FileXml Fxml = new FileXml();
        public string layMaQuyen(int maQuyen)
        {

            string codeRole = Fxml.LayGiaTri("Role.xml", "maRole", maQuyen.ToString(), "code");

            if (codeRole != null)
            {
                return codeRole;
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng trong hệ thống.");
                return null;
            }
        }


        public DataRow kiemtraTTDN(string duongdan, string MaNhanVien, string MatKhau)
        {
            DataTable dt = Fxml.HienThi(duongdan);
            dt.DefaultView.RowFilter = "tk ='" + MaNhanVien + "' AND mk='" + MatKhau + "'";

            if (dt.DefaultView.Count > 0)
            {
                return dt.DefaultView[0].Row;
            }
            return null;
        }
        public void dangkiTaiKhoan(string MaNhanVien, string MatKhau, int Quyen)
        {
            string noiDung = "<TaiKhoan>"+
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<MatKhau>" + MatKhau + "</MatKhau>" +
                    "<Quyen>" + Quyen + "</Quyen>"+
                    "</TaiKhoan>";
                    
            Fxml.Them("TaiKhoan.xml",noiDung);
        }
        public void xoaTK(string MaNhanVien)
        {
            Fxml.Xoa("TaiKhoan.xml","TaiKhoan","MaNhanVien", MaNhanVien);
            
        }
        public bool kiemtraTTTK(string MaNhanVien)
        {
            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/TaiKhoan[MaNhanVien='" + MaNhanVien + "']");
            reader.Close();
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;

            }
        }
        public void DoiMatKhau(string nguoiDung, string matKhau)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\TaiKhoan.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/TaiKhoan[MaNhanVien = '" + nguoiDung + "']");
            if (node1 != null)
            {
                node1.ChildNodes[1].InnerText = matKhau;
                doc1.Save(Application.StartupPath + "\\TaiKhoan.xml");
            }
        }
        
    }
}
