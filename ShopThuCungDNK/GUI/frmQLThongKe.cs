using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQLThongKe : Form
    {
        FileXml Fxml = new FileXml();
        public frmQLThongKe()
        {
            InitializeComponent();
        }

        private void frmQLThongKe_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu thống kê ban đầu
            LoadComboBoxOptions();
            LoadThongKeData();
            GetTopCustomer();

            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd-MM-yyyy"; // Chỉ hiển thị ngày tháng năm

            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd-MM-yyyy"; // Chỉ hiển thị ngày tháng năm
        }

        private void LoadComboBoxOptions()
        {
            // Tải các tùy chọn thống kê vào ComboBox
            cbxType.Items.Add("Thống kê theo loại thú cưng");
            cbxType.Items.Add("Thống kê theo doanh thu");
            cbxType.SelectedIndex = 0; // Mặc định chọn "Thống kê theo loại thú cưng"
        }

        private void LoadThongKeData()
        {
            string option = cbxType.SelectedItem.ToString();
            DataTable dt = new DataTable();

            if (option == "Thống kê theo loại thú cưng")
            {
                // Lấy dữ liệu từ bảng ChiTietHoaDon
                dt = Fxml.HienThi("ChiTietHoaDon.xml");
                // Đổi tên header của các cột
                

                // Tính tổng tiền và số lượng theo maTC (mã thú cưng)
                var result = dt.AsEnumerable()
                               .GroupBy(row => row["maTC"])  // Nhóm theo mã thú cưng
                               .Select(g => new
                               {
                                   MaTC = g.Key,                 // Mã thú cưng
                                   SoLuong = g.Sum(row => Convert.ToInt32(row["soLuong"])),  // Tổng số lượng
                                   TongTien = g.Sum(row => Convert.ToDecimal(row["thanhTien"]))  // Tổng tiền
                               }).ToList();

                // Lấy thông tin về loại thú cưng từ bảng ThuCung dựa trên MaTC
                DataTable dtThuCung = Fxml.HienThi("ThuCung.xml");

                // Kết hợp dữ liệu giữa ChiTietHoaDon và ThuCung
                var finalResult = result.Join(dtThuCung.AsEnumerable(),
                                              r => r.MaTC,
                                              tc => tc["maTC"],
                                              (r, tc) => new
                                              {
                                                  LoaiThuCung = tc["maLoai"],  // Mã loại thú cưng
                                                  SoLuong = r.SoLuong,         // Tổng số lượng
                                                  TongTien = r.TongTien        // Tổng tiền
                                              })
                                              .GroupBy(x => x.LoaiThuCung)   // Nhóm theo loại thú cưng
                                              .Select(g => new
                                              {
                                                  LoaiThuCung = g.Key,          // Loại thú cưng
                                                  SoLuong = g.Sum(x => x.SoLuong),  // Tổng số lượng theo loại
                                                  TongTien = g.Sum(x => x.TongTien) // Tổng tiền theo loại
                                              }).ToList();

                dgvThongKe.DataSource = finalResult.ToList();  // Gán kết quả vào DataGridView
                dgvThongKe.Columns["LoaiThuCung"].HeaderText = "Mã Loại";
                dgvThongKe.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvThongKe.Columns["TongTien"].HeaderText = "Tổng Tiền";
                DisplayChart(finalResult);  // Hiển thị biểu đồ
                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else if (option == "Thống kê theo doanh thu")
            {
                
                // Thống kê theo doanh thu trong khoảng thời gian chọn
                dt = Fxml.HienThi("HoaDon.xml");

                DateTime startDate = dtpStartDate.Value.Date;  // Lấy ngày bắt đầu, không có giờ, phút, giây
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);  // Đặt ngày kết thúc vào cuối ngày 2/12 (23:59:59.999)

                var result = dt.AsEnumerable()
                               .Where(row => Convert.ToDateTime(row["ngayTao"]).Date >= startDate && Convert.ToDateTime(row["ngayTao"]).Date <= endDate)
                               .GroupBy(row => row["ngayTao"])
                               .Select(g => new
                               {
                                   NgayBan = g.Key,
                                   DoanhThu = g.Sum(row => Convert.ToDecimal(row["tongTien"]))
                               }).Where(x => x.DoanhThu > 0)
                               .ToList();
                dgvThongKe.DataSource = result.ToList();

                dgvThongKe.Columns["NgayBan"].HeaderText = "Ngày bán";
                dgvThongKe.Columns["DoanhThu"].HeaderText = "Doanh thu";
                DisplayChart(result);
                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
        private void DisplayChart(dynamic result)
        {
            // Reset biểu đồ
            chartThongKe.Series.Clear(); // Xóa các series cũ trong biểu đồ
            chartThongKe.ChartAreas.Clear(); // Xóa các chart areas (nếu có nhiều)
            chartThongKe.Legends.Clear(); // Xóa các legends (nếu có)


            // Tạo lại ChartArea
            ChartArea chartArea = new ChartArea();
            chartThongKe.ChartAreas.Add(chartArea); // Thêm lại ChartArea vào biểu đồ
            chartArea.AxisX.MajorGrid.Enabled = false; // Tắt đường gạch trên trục X
            chartArea.AxisY.MajorGrid.Enabled = false; // Tắt đường gạch trên trục Y


            // Tạo Legend mới và thêm vào biểu đồ
            Legend legend = new Legend();
            chartThongKe.Legends.Add(legend);


            var series = new Series("Số Lượng Thú Cưng");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ là cột
            series.IsValueShownAsLabel = true; // Hiển thị giá trị trên mỗi cột

            // Trường hợp thống kê theo loại thú cưng
            if (cbxType.SelectedItem.ToString() == "Thống kê theo loại thú cưng")
            {
                series.Name = "Số Lượng thú cưng"; // Tên của series cho thống kê theo loại thú cưng
                legend.Name = "Số Lượng thú cưng"; // Cập nhật Legend với tên mới
                foreach (var item in result)
                {
                    // Thêm dữ liệu vào biểu đồ: Loại thú cưng, Số lượng
                    series.Points.AddXY(item.LoaiThuCung, item.SoLuong);
                }
            }
            // Trường hợp thống kê theo doanh thu
            else if (cbxType.SelectedItem.ToString() == "Thống kê theo doanh thu")
            {
                series.Name = "doanh thu"; // Tên của series cho thống kê theo loại thú cưng
                legend.Name = "doanh thu"; // Cập nhật Legend với tên mới
                chartArea.AxisY.LabelStyle.Format = "#,0"; // Định dạng số tiền
                foreach (var item in result)
                {
                    string ngayBan = Convert.ToDateTime(item.NgayBan).ToString("dd-MM-yyyy");
                    // Thêm dữ liệu vào biểu đồ: Ngày bán, Doanh thu
                    series.Points.AddXY(ngayBan, item.DoanhThu);
                }
                // Định dạng lại các nhãn trên trục Y để thêm ký hiệu tiền tệ VND (₫)
                foreach (var point in series.Points)
                {
                    point.Label = string.Format("{0}₫", point.YValues[0]); // Thêm ký hiệu VND vào giá trị
                }
            }

            // Thêm series vào biểu đồ
            chartThongKe.Series.Add(series);
        }




        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeData();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeData();
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongKeData();
            // Kiểm tra giá trị của ComboBox
            if (cbxType.SelectedItem.ToString() == "Thống kê theo loại thú cưng")
            {
                // Ẩn các DatePicker khi thống kê theo số lượng thú cưng
                dtpStartDate.Visible = false;
                dtpEndDate.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
            else if (cbxType.SelectedItem.ToString() == "Thống kê theo doanh thu")
            {
                // Hiển thị lại các DatePicker khi thống kê theo doanh thu
                dtpStartDate.Visible = true;
                dtpEndDate.Visible = true;
                label1.Visible = true;
                label2.Visible = true;  

            }
        }

        private void GetTopCustomer()
        {
            // Lấy dữ liệu từ bảng KhachHang và HoaDon
            var khachHang = Fxml.HienThi("KhachHang.xml");
            var hoaDon = Fxml.HienThi("HoaDon.xml");

            // Tính tổng tiền và số lượng chi tiêu của mỗi khách hàng
            var result = hoaDon.AsEnumerable()
                               .GroupBy(row => row["maKH"])  // Nhóm theo mã khách hàng
                               .Select(g => new
                               {
                                   MaKH = g.Key,                 // Mã khách hàng
                                   TongTien = g.Sum(row => Convert.ToDecimal(row["tongTien"]))  // Tổng tiền chi tiêu
                               }).ToList();

            // Kết hợp dữ liệu giữa KhachHang và tổng tiền chi tiêu từ HoaDon
            var finalResult = result.Join(khachHang.AsEnumerable(),
                                          r => r.MaKH,
                                          kh => kh["maKH"],
                                          (r, kh) => new
                                          {
                                              MaKH = r.MaKH,               // Mã khách hàng
                                              TenKH = (string)kh["tenKH"], // Tên khách hàng
                                              Sdt = (string)kh["sdt"],     // Số điện thoại khách hàng
                                              DiaChi = (string)kh["diaChi"], // Địa chỉ khách hàng
                                              TongTien = r.TongTien        // Tổng tiền chi tiêu
                                          })
                                          .OrderByDescending(x => x.TongTien)  // Sắp xếp theo tổng tiền chi tiêu giảm dần
                                          .Take(5)  // Lấy 5 khách hàng chi tiêu nhiều nhất
                                          .ToList();

            // Hiển thị kết quả lên DataGridView hoặc bất kỳ nơi nào bạn muốn
            dataGridView1.DataSource = finalResult;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Chỉnh sửa màu nền và màu chữ của header
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;  // Màu nền header
            dataGridView1.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dataGridView1.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dataGridView1.Columns["Sdt"].HeaderText = "SĐT";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
