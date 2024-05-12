using DevExpress.XtraEditors;
using DevExpress.XtraReports.ReportGeneration;
using DevExpress.XtraReports.UI;
using FinalProject.UI;
using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject.UI.uc_DMThanhToan;

namespace FinalProject.Form
{
    public partial class Form_ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True; MultipleActiveResultSets=true";
        private uc_DMThanhToan ucDMThanhToan;

        public string TenKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiKhachHang { get; set; }
        public string NgayMua { get; set; }
        public string TongTien { get; set; }
        public string BangChu { get; set; }

        public Form_ThanhToan(uc_DMThanhToan uc)
        {   
            InitializeComponent();
            this.ucDMThanhToan = uc;
            dgvSanPhamDaMua.RowsAdded += dgvSanPhamDaMua_RowsAdded;
        }

        private void dgvSanPhamDaMua_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvSanPhamDaMua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int totalWidth = dgvSanPhamDaMua.RowHeadersWidth;
            for (int i = 0; i < dgvSanPhamDaMua.Columns.Count; i++)
            {
                totalWidth += dgvSanPhamDaMua.Columns[i].Width;
            }
            dgvSanPhamDaMua.Width = totalWidth;
        }


        private void Form_ThanhToan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hoaDonDataSet.HANGHOANHAPKHO' table. You can move, or remove it, as needed.
            this.hANGHOANHAPKHOTableAdapter.Fill(this.hoaDonDataSet.HANGHOANHAPKHO);
            lblTenKhach.Text = TenKhach;
            lblSoDienThoai.Text = SoDienThoai;
            lblLoaiKhachHang.Text = LoaiKhachHang;
            lblNgayMua.Text = NgayMua;
            lblTongTien.Text = TongTien;
            lblBangChu.Text = BangChu;

            DataTable dtHangHoa = this.ucDMThanhToan.HangHoaDataTable;
            foreach (DataRow row in dtHangHoa.Rows)
            {
                string tenSanPham = row["TenSanPham"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal giaSanPham = Convert.ToDecimal(row["GiaSanPham"]);
                decimal giamGiaPhanTram = Convert.ToDecimal(row["GiamGia"]);

                decimal soTienDaGiam = giaSanPham * soLuong * (giamGiaPhanTram / 100);
                decimal thanhTien = (giaSanPham * soLuong) - soTienDaGiam;

                dgvSanPhamDaMua.Rows.Add(tenSanPham, soLuong, giaSanPham, giamGiaPhanTram, soTienDaGiam, thanhTien);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToanVaIn_Click(object sender, EventArgs e)
        {
            // 1. Lưu thông tin khách hàng vào cơ sở dữ liệu
            int maKhachHang = LuuKhachHangVaoCSDL();

            // 2. Lưu thông tin đơn hàng vào cơ sở dữ liệu
            int maDonHang = LuuDonHangVaoCSDL(maKhachHang);

            // 3. Giảm số lượng sản phẩm trong bảng HANGHOA
            if (maDonHang > 0)
            {
                GiamSoLuongSanPham();

                // 4. Hiển thị MessageBox
                DialogResult result = MessageBox.Show("Thanh toán thành công!\nBạn có muốn xem trước hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // 5. Hiển thị Report
                    HienThiReport(maDonHang);

                    // 6. Lưu dữ liệu vào bảng HOADON
                    LuuDuLieuVaoHOADON(maDonHang);
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LuuDuLieuVaoHOADON(int maDonHang)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy thông tin từ LICHSUGIAODICH based on maDonHang
                    string sqlDonHang = "SELECT * FROM LICHSUGIAODICH WHERE MAGD = @MAGD";
                    using (SqlCommand cmdDonHang = new SqlCommand(sqlDonHang, connection))
                    {
                        cmdDonHang.Parameters.AddWithValue("@MAGD", maDonHang);
                        using (SqlDataReader readerDonHang = cmdDonHang.ExecuteReader())
                        {
                            if (readerDonHang.Read())
                            {
                                // Lấy thông tin cần thiết từ readerDonHang
                                int maKhachHang = Convert.ToInt32(readerDonHang["MAKHACH"]);
                                string soLuong = readerDonHang["SOLUONG"].ToString();
                                decimal thanhTien = Convert.ToDecimal(readerDonHang["THANHTIEN"]);
                                DateTime ngayMua = Convert.ToDateTime(readerDonHang["NGAYMUA"]);
                                string tenSanPham = readerDonHang["SANPHAMDAMUA"].ToString();
                                string giamGia = readerDonHang["GIAMGIA"].ToString();

                                // Lấy đơn giá từ HANGHOANHAPKHO dựa vào tenSanPham (giả định mỗi sản phẩm chỉ có 1 đơn giá)
                                string sqlDonGia = "SELECT GIABAN FROM HANGHOANHAPKHO WHERE TENSANPHAM = @TENSANPHAM";
                                using (SqlCommand cmdDonGia = new SqlCommand(sqlDonGia, connection))
                                {
                                    cmdDonGia.Parameters.AddWithValue("@TENSANPHAM", tenSanPham);
                                    decimal donGia = Convert.ToDecimal(cmdDonGia.ExecuteScalar());

                                    // Lưu dữ liệu vào HOADON
                                    string sqlInsert = @"
                                INSERT INTO HOADON (SOLUONG, DONGIA, GIAMGIA, THANHTIEN, NGAYMUA, TENSANPHAM, MASANPHAM) 
                                VALUES (@SOLUONG, @DONGIA, @GIAMGIA, @THANHTIEN, @NGAYMUA, @TENSANPHAM, @MASANPHAM)";
                                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection))
                                    {
                                        cmdInsert.Parameters.AddWithValue("@SOLUONG", soLuong);
                                        cmdInsert.Parameters.AddWithValue("@DONGIA", donGia);
                                        cmdInsert.Parameters.AddWithValue("@GIAMGIA", giamGia);
                                        cmdInsert.Parameters.AddWithValue("@THANHTIEN", thanhTien);
                                        cmdInsert.Parameters.AddWithValue("@NGAYMUA", ngayMua);
                                        cmdInsert.Parameters.AddWithValue("@TENSANPHAM", tenSanPham);
                                        cmdInsert.Parameters.AddWithValue("@MASANPHAM", maKhachHang); // Giả định MASANPHAM là MAKHACH

                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu vào HOADON: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiReport(int maDonHang)
        {
            // Tạo DataSet chứa dữ liệu hóa đơn cho maDonHang
            HoaDonDataSet dsHoaDon = TaoHoaDonDataSet(maDonHang);

            // Tạo XtraReport object dựa trên file .repx
            Report_HoaDon report = new Report_HoaDon();

            // Gán DataSet cho thuộc tính DataSource của Report
            report.DataSource = dsHoaDon;

            // Tạo ReportPrintTool và hiển thị preview
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();

            // Lưu dữ liệu vào bảng HOADON sau khi hiển thị report
            LuuDuLieuVaoHOADON(maDonHang);
        }

        private HoaDonDataSet TaoHoaDonDataSet(int maDonHang)
        {
            HoaDonDataSet dsHoaDon = new HoaDonDataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. Lấy thông tin đơn hàng từ LICHSUGIAODICH
                string sqlDonHang = "SELECT * FROM LICHSUGIAODICH WHERE MAGD = @MAGD";
                using (SqlCommand cmdDonHang = new SqlCommand(sqlDonHang, connection))
                {
                    cmdDonHang.Parameters.AddWithValue("@MAGD", maDonHang);
                    using (SqlDataReader readerDonHang = cmdDonHang.ExecuteReader())
                    {
                        if (readerDonHang.Read())
                        {
                            // Lấy thông tin cần thiết từ readerDonHang
                            int maKhachHang = Convert.ToInt32(readerDonHang["MAKHACH"]);
                            DateTime ngayMua = Convert.ToDateTime(readerDonHang["NGAYMUA"]);
                            string phuongThucThanhToan = readerDonHang["PHUONGTHUCTHANHTOAN"].ToString();
                            string sanPhamDaMua = readerDonHang["SANPHAMDAMUA"].ToString(); // Lưu trữ giá trị SANPHAMDAMUA vào biến

                            // 2. Lấy thông tin khách hàng từ KHACHHANG
                            string sqlKhachHang = "SELECT * FROM KHACHHANG WHERE MAKHACH = @MAKHACH";
                            using (SqlCommand cmdKhachHang = new SqlCommand(sqlKhachHang, connection))
                            {
                                cmdKhachHang.Parameters.AddWithValue("@MAKHACH", maKhachHang);
                                using (SqlDataReader readerKhachHang = cmdKhachHang.ExecuteReader())
                                {
                                    if (readerKhachHang.Read())
                                    {
                                        // 4. Lấy thông tin sản phẩm từ HANGHOANHAPKHO
                                        string[] tenSanPhamArray = sanPhamDaMua.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (string sanPham in tenSanPhamArray)
                                        {
                                            string sqlSanPham = "SELECT * FROM HANGHOANHAPKHO WHERE TENSANPHAM = @TENSANPHAM";
                                            using (SqlCommand cmdSanPham = new SqlCommand(sqlSanPham, connection))
                                            {
                                                cmdSanPham.Parameters.AddWithValue("@TENSANPHAM", sanPham);
                                                using (SqlDataReader readerSanPham = cmdSanPham.ExecuteReader())
                                                {
                                                    if (readerSanPham.Read())
                                                    {
                                                        // 3. Thêm dữ liệu vào DataTable HoaDon
                                                        DataRow rowHoaDon = dsHoaDon.HOADON.NewRow();
                                                        rowHoaDon["TENKHACH"] = readerKhachHang["TENKHACH"];
                                                        rowHoaDon["SODIENTHOAI"] = readerKhachHang["SODIENTHOAI"];
                                                        rowHoaDon["DIACHI"] = readerKhachHang["DIACHI"];
                                                        rowHoaDon["NGAYMUA"] = ngayMua;
                                                        rowHoaDon["PHUONGTHUCTHANHTOAN"] = phuongThucThanhToan;
                                                        rowHoaDon["TENSANPHAM"] = sanPham;
                                                        rowHoaDon["SOLUONG"] = readerDonHang["SOLUONG"];
                                                        rowHoaDon["GIABAN"] = readerSanPham["GIABAN"];
                                                        rowHoaDon["GIAMGIA"] = readerDonHang["GIAMGIA"];
                                                        rowHoaDon["THANHTIEN"] = readerDonHang["THANHTIEN"];
                                                        //dsHoaDon.HOADON.Rows.Add(rowHoaDon);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    // Đóng readerKhachHang sau khi sử dụng
                                    readerKhachHang.Close();
                                }
                            }
                        }
                    }
                }
            }
            return dsHoaDon;
        }

        private void GiamSoLuongSanPham()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (CartItem item in ucDMThanhToan.cartItems)
                    {
                        string query = @"
                            UPDATE HANGHOANHAPKHO 
                            SET SOLUONG = SOLUONG - @SoLuong 
                            WHERE TENSANPHAM = @TenSanPham";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            command.Parameters.AddWithValue("@TenSanPham", item.TenSanPham);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi giảm số lượng sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int LuuDonHangVaoCSDL(int maKhachHang)
        {
            int maDonHang = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Xây dựng chuỗi tên sản phẩm, số lượng, và giảm giá
                    StringBuilder tenSanPhamBuilder = new StringBuilder();
                    StringBuilder soLuongBuilder = new StringBuilder();
                    StringBuilder giamGiaBuilder = new StringBuilder();

                    foreach (CartItem item in ucDMThanhToan.cartItems)
                    {
                        tenSanPhamBuilder.Append(item.TenSanPham).Append(", ");
                        soLuongBuilder.Append("[").Append(item.TenSanPham).Append("].[SL: ").Append(item.SoLuong).Append("], ");
                        giamGiaBuilder.Append("[").Append(item.TenSanPham).Append("].[GG: ").Append(item.GiamGia).Append("], ");
                    }

                    // Loại bỏ dấu phẩy và khoảng trắng thừa ở cuối chuỗi
                    if (tenSanPhamBuilder.Length > 2) tenSanPhamBuilder.Length -= 2;
                    if (soLuongBuilder.Length > 2) soLuongBuilder.Length -= 2;
                    if (giamGiaBuilder.Length > 2) giamGiaBuilder.Length -= 2;

                    string tenSanPham = tenSanPhamBuilder.ToString();
                    string soLuong = soLuongBuilder.ToString();
                    string giamGia = giamGiaBuilder.ToString();

                    // Lấy thông tin trực tiếp từ uc_DMThanhToan
                    DateTime ngayMua = ucDMThanhToan.NgayMua;
                    string phuongThucThanhToan = ucDMThanhToan.PhuongThucThanhToan;
                    decimal thanhTien = decimal.Parse(ucDMThanhToan.TongTienText, NumberStyles.Currency);

                    string query = @"
                INSERT INTO LICHSUGIAODICH (MAKHACH, SANPHAMDAMUA, SOLUONG, NGAYMUA, PHUONGTHUCTHANHTOAN, GIAMGIA, THANHTIEN)
                VALUES (@MAKHACH, @SANPHAMDAMUA, @SOLUONG, @NGAYMUA, @PHUONGTHUCTHANHTOAN, @GIAMGIA, @THANHTIEN);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAKHACH", maKhachHang);
                        command.Parameters.AddWithValue("@SANPHAMDAMUA", tenSanPham);
                        command.Parameters.AddWithValue("@SOLUONG", soLuong);
                        command.Parameters.AddWithValue("@NGAYMUA", ngayMua);
                        command.Parameters.AddWithValue("@PHUONGTHUCTHANHTOAN", phuongThucThanhToan);
                        command.Parameters.AddWithValue("@GIAMGIA", giamGia);
                        command.Parameters.AddWithValue("@THANHTIEN", thanhTien);

                        maDonHang = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maDonHang;
        }

        private int LuuKhachHangVaoCSDL()
        {
            int maKhachHang = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (ucDMThanhToan.customerItems.Count > 0)
                    {
                        string tenKhachHang = ucDMThanhToan.customerItems[0].TenKhach;
                        string soDienThoai = ucDMThanhToan.customerItems[0].SoDienThoai.ToString();
                        string diaChi = ucDMThanhToan.customerItems[0].DiaChi;
                        string gioiTinh = ucDMThanhToan.customerItems[0].GioiTinh;
                        string loaiKhachHang = ucDMThanhToan.customerItems[0].LoaiKhachHang;

                        string query = @"
                        INSERT INTO KHACHHANG (TENKHACH, SODIENTHOAI, DIACHI, GIOITINH, LOAIKHACHHANG)
                        VALUES (@TENKHACH, @SODIENTHOAI, @DIACHI, @GIOITINH, @LOAIKHACHHANG);
                        SELECT SCOPE_IDENTITY();";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TENKHACH", tenKhachHang);
                            command.Parameters.AddWithValue("@SODIENTHOAI", soDienThoai);
                            command.Parameters.AddWithValue("@DIACHI", diaChi);
                            command.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                            command.Parameters.AddWithValue("@LOAIKHACHHANG", loaiKhachHang);

                            maKhachHang = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp list rỗng (ví dụ: hiển thị thông báo lỗi)
                        MessageBox.Show("Chưa có thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0; // Hoặc xử lý theo logic của bạn
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maKhachHang;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void hANGHOANHAPKHOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hANGHOANHAPKHOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hoaDonDataSet);
        }
    }
}