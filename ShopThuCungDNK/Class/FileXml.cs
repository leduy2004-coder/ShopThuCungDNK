using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Diagnostics;   // Dùng cho Pricess.Start()


namespace QuanLySieuThi.Class
{
    class FileXml
    {


        //string Conn = @"Data Source=DESKTOP-2NFEM03;Initial Catalog=SHOPTHUCUNG;Integrated Security=True;Encrypt=False";
        string Conn = @"Data Source=LAPTOP-F30SDEST\SQLEXPRESS;Initial Catalog=SHOPTHUCUNG;Integrated Security=True;Encrypt=False";

        public DataTable HienThi(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + file;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }

            return dt;
        }
        public void TaoXML(string bang)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();

            // Truy vấn lấy dữ liệu từ bảng
            string sql = "Select * from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable(bang);  // Sử dụng tên bảng làm tên DataTable
            ad.Fill(dt);

            // Tạo XmlTextWriter với encoding UTF-8
            XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "\\" + bang + ".xml", System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;  // Định dạng cho đẹp mắt
            dt.WriteXml(writer, XmlWriteMode.WriteSchema);

            // Đóng writer sau khi ghi
            writer.Close();

            con.Close();
        }
        public void XoaTatCaFileXML(string thuMuc)
        {
            // Lấy danh sách tất cả các file XML trong thư mục
            string[] files = Directory.GetFiles(thuMuc, "*.xml");

            foreach (string file in files)
            {
                // Xóa từng file XML
                File.Delete(file);
            }

            Console.WriteLine("Đã xóa tất cả file XML.");
        }
        public void Them(string duongDan, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode currNode;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            docFrag.InnerXml = noiDung;
            currNode = doc.DocumentElement;
            currNode.InsertAfter(docFrag, currNode.LastChild);
            doc.Save(duongDan);
        }
        public void Xoa(string duongDan, string tenFileXML, string xoaTheoTruong, string giaTriTruong)
        {
            string fileName = Application.StartupPath + "\\" + duongDan;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode nodeCu = doc.SelectSingleNode("NewDataSet/" + tenFileXML + "[" + xoaTheoTruong + "='" + giaTriTruong + "']");
            doc.DocumentElement.RemoveChild(nodeCu);
            doc.Save(fileName);
        }

        public void Sua(string duongDan, string tenFile, string suaTheoTruong, string giaTriTruong, string noiDung)
        {

            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldHang;
            XmlElement root = doc.DocumentElement;
            oldHang = root.SelectSingleNode("/NewDataSet/" + tenFile + "[" + suaTheoTruong + "='" + giaTriTruong + "']");
            XmlElement newhang = doc.CreateElement(tenFile);
            newhang.InnerXml = noiDung;
            root.ReplaceChild(newhang, oldHang);
            doc.Save(duongDan);
        }
        public string LayGiaTri(string duongDan, string truongA, string giaTriA, string truongB)
        {
            string giatriB = "";
            DataTable dt = new DataTable();
            dt = HienThi(duongDan);
            int soDongNhanVien = dt.Rows.Count;
            for (int i = 0; i < soDongNhanVien; i++)
            {
                if (dt.Rows[i][truongA].ToString().Trim().Equals(giaTriA))
                {
                    giatriB = dt.Rows[i][truongB].ToString();
                    return giatriB;
                }
            }
            return giatriB;
        }
        public int LayMaxValueFromXml(string filePath, string tagName)
        {
            // Kiểm tra file XML có tồn tại không
            if (!File.Exists(filePath))
            {
                return 0; // Nếu không tồn tại, trả về giá trị mặc định
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            int maxValue = 0;

            // Duyệt qua tất cả các thẻ có tên tagName trong file XML
            XmlNodeList nodes = doc.GetElementsByTagName(tagName);
            foreach (XmlNode node in nodes)
            {
                if (int.TryParse(node.InnerText, out int value))
                {
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }
            }

            return maxValue + 1; // Trả về giá trị lớn nhất
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
        public void TimKiemXSLT(string data, string tenFileXML, string tenfileXSLT)
        {

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("\\" + tenfileXSLT + ".xslt");
            // Create the XsltArgumentList.
            XsltArgumentList argList = new XsltArgumentList();
            // Calculate the discount date.
            argList.AddParam("Data", "", data);
            // Create an XmlWriter to write the output.             
            XmlWriter writer = XmlWriter.Create("\\" + tenFileXML + ".html");
            // Transform the file.
            xslt.Transform(new XPathDocument("\\" + tenFileXML + ".xml"), argList, writer);
            writer.Close();
            System.Diagnostics.Process.Start("\\" + tenFileXML + ".html");

        }
        public void InsertOrUpDateSQL(string sql)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
