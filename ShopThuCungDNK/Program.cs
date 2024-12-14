using QuanLySieuThi.Class;
using ShopThuCungDNK.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HeThong heThong = new HeThong();
            heThong.TaoXMLFirst();
            //FileXml fileXml = new FileXml();
            //fileXml.XoaTatCaFileXML(Application.StartupPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }
}
