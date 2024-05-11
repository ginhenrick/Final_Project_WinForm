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
        string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True";
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
            int maKhachHang = LuuKhachHangVaoCSDL();
            int maDonHang = LuuDonHangVaoCSDL(maKhachHang);

            if (maDonHang > 0)
            {
                GiamSoLuongSanPham();
                DialogResult result = MessageBox.Show("Thanh toán thành công!\nBạn có muốn xem trước hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Tạo và hiển thị Report (bạn cần thiết kế report này)
                    HienThiReport(maDonHang);
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiReport(int maDonHang)
        {
            throw new NotImplementedException();
            //// Tạo Report và truyền dữ liệu (bạn cần thiết kế report này)
            //XtraReport report = new XtraReport();
            //// ... Thêm logic để thiết kế report và truyền dữ liệu, ví dụ: maDonHang ...

            //ReportPrintTool printTool = new ReportPrintTool(report);
            //printTool.ShowPreviewDialog();
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
                            UPDATE HANGHOA 
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maKhachHang;
        }
    }
}