using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DataAccess.Native.Data;


namespace FinalProject.UI
{
    public partial class uc_DMHangHoa : DevExpress.XtraEditors.XtraUserControl
    {
        private string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True"; 

        public uc_DMHangHoa()
        {
            InitializeComponent();
            LoadDanhSachHangHoa();
        }

        private void LoadDanhSachHangHoa()
        {
            string sql = @"SELECT hh.MANHAPKHO, hh.MASANPHAM, hh.TENSANPHAM, hh.SOLUONG, hh.MACHATLIEU, cl.TENCHATLIEU, hh.ANH, nh.GIABAN, nh.GIANHAP
                    FROM HANGHOANHAPKHO hh
                    INNER JOIN CHATLIEU cl ON hh.MACHATLIEU = cl.MACHATLIEU
                    INNER JOIN HANGHOANHAPKHO nh ON hh.MASANPHAM = nh.MASANPHAM";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                gridControlHangHoa.DataSource = dataTable; 
                GridView gridView = gridViewHangHoa; 
                
                gridView.Columns.Add(new GridColumn() { FieldName = "MANHAPKHO", Caption = "Mã nhập kho" });
                gridView.Columns.Add(new GridColumn() { FieldName = "MASANPHAM", Caption = "Mã Sản Phẩm" });
                gridView.Columns.Add(new GridColumn() { FieldName = "TENSANPHAM", Caption = "Tên Sản Phẩm" });
                gridView.Columns.Add(new GridColumn() { FieldName = "SOLUONG", Caption = "Số lượng" });
                gridView.Columns.Add(new GridColumn() { FieldName = "MACHATLIEU", Caption = "Mã chất liệu" });
                gridView.Columns.Add(new GridColumn() { FieldName = "TENCHATLIEU", Caption = "Tên chất liệu" });
                gridView.Columns.Add(new GridColumn() { FieldName = "ANH", Caption = "Ảnh" });
                gridView.Columns.Add(new GridColumn() { FieldName = "GIANHAP", Caption = "Giá nhập" });
                gridView.Columns.Add(new GridColumn() { FieldName = "GIABAN", Caption = "Giá bán ra" });
                

                gridView.OptionsView.ColumnAutoWidth = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void btnHienThiDS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //// 1. Lấy danh sách hàng hóa từ cơ sở dữ liệu
            //// Chuẩn bị câu lệnh SQL để lấy tất cả dữ liệu từ bảng HANG, bao gồm cả cột ANH (ảnh)
            //string sql = "SELECT *, CAST(ANH AS VARBINARY(MAX)) AS ANH FROM HANG";

            //// Tạo DataTable để lưu trữ dữ liệu hàng hóa
            //DataTable dataTableHangHoa = new DataTable();

            //// Sử dụng khối using để đảm bảo giải phóng tài nguyên
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            //    {
            //        // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
            //        adapter.Fill(dataTableHangHoa);
            //    }
            //}

            //// 2. Xuất danh sách hàng hóa sang file Excel
            //// Sử dụng khối using để đảm bảo giải phóng tài nguyên
            //using (ExcelPackage excelPackage = new ExcelPackage())
            //{
            //    // Tạo worksheet mới với tên "Hàng Hóa"
            //    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Hàng Hóa");

            //    // Tải dữ liệu từ DataTable vào sheet Excel, bắt đầu từ ô A1, có header
            //    worksheet.Cells["A1"].LoadFromDataTable(dataTableHangHoa, true);

            //    // Định dạng header (in đậm, nền xám)
            //    // Giả sử có 8 cột dữ liệu (A đến H) và 1 cột ảnh (I)
            //    using (ExcelRange headerRange = worksheet.Cells["A1:I1"])
            //    {
            //        headerRange.Style.Font.Bold = true; // Đặt kiểu chữ in đậm
            //        headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid; // Đặt kiểu tô màu nền
            //        headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray); // Đặt màu nền là xám nhạt
            //    }

            //    // Tự động điều chỉnh độ rộng cột cho phù hợp với nội dung
            //    worksheet.Cells.AutoFitColumns();

            //    // Điều chỉnh độ rộng cột ảnh (cột I)
            //    worksheet.Column(9).Width = ptxAnhHangHoa.Width / 7; // Điều chỉnh hệ số chia nếu cần

            //    // Chèn ảnh vào từng dòng
            //    for (int i = 2; i <= dataTableHangHoa.Rows.Count + 1; i++)
            //    {
            //        byte[] anhData = null;
            //        // Lấy dữ liệu ảnh từ DataTable
            //        //byte[] anhData = (byte[])dataTableHangHoa.Rows[i - 2]["ANH"];

            //        // Kiểm tra xem có dữ liệu ảnh hay không
            //        if (!dataTableHangHoa.Rows[i - 2].IsNull("ANH"))
            //        {
            //            anhData = (byte[])dataTableHangHoa.Rows[i - 2]["ANH"];
            //            using (MemoryStream stream = new MemoryStream(anhData))
            //            {
            //                // Tạo đối tượng Image từ MemoryStream
            //                Image img = Image.FromStream(stream);

            //                // Tạo file tạm thời để lưu trữ ảnh
            //                string tempFilePath = Path.Combine(Path.GetTempPath(), $"temp_image_{i}.png");
            //                img.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png);

            //                // Thêm ảnh vào worksheet từ file tạm thời
            //                FileInfo fileInfo = new FileInfo(tempFilePath);
            //                ExcelPicture pic = worksheet.Drawings.AddPicture($"Image{i}", fileInfo);

            //                // Đặt vị trí ảnh trong cột I (cột 9)
            //                pic.SetPosition(i - 2, 0, 8, 0); // Điều chỉnh chỉ số cột nếu cần

            //                // Đặt kích thước ảnh bằng với kích thước của PictureBox
            //                pic.SetSize(ptxAnhHangHoa.Width, ptxAnhHangHoa.Height);

            //                // Xóa file tạm thời sau khi thêm ảnh vào Excel
            //                fileInfo.Delete();
            //            }
            //        }
            //    }

            //    // Lấy tên nhân viên đang đăng nhập (thay thế bằng cách lấy tên thực tế)
            //    // Ví dụ: sử dụng Session, biến global, hoặc lấy từ cơ sở dữ liệu
            //    string tenNhanVien = GetCurrentUserName(); // Implement this method to retrieve the current user name

            //    // Xây dựng đường dẫn file Excel
            //    // Lấy đường dẫn thư mục Desktop của người dùng hiện tại
            //    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //    // Xây dựng tên file theo cấu trúc "Hàng Hóa - Ngày xuất - Nhân viên xuất"
            //    string fileName = $"Hàng Hóa - {DateTime.Now:yyyyMMdd} - {tenNhanVien}.xlsx";

            //    // Kết hợp đường dẫn thư mục và tên file để tạo đường dẫn đầy đủ
            //    string filePath = Path.Combine(folderPath, fileName);

            //    // Bảo vệ sheet không cho chỉnh sửa (với mật khẩu)
            //    worksheet.Protection.IsProtected = true;
            //    worksheet.Protection.SetPassword("YourPasswordHere"); // Thay đổi mật khẩu

            //    // Lưu file Excel
            //    FileInfo file = new FileInfo(filePath);
            //    excelPackage.SaveAs(file);

            //    // Hiển thị thông báo với đường dẫn file và cho phép mở file
            //    string message = $"Xuất danh sách hàng hóa thành công!\nFile đã được lưu tại: {filePath}\nBạn có muốn mở file Excel?";

            //    // Hiển thị hộp thoại xác nhận với nội dung message
            //    if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // Mở file Excel bằng ứng dụng mặc định
            //        System.Diagnostics.Process.Start(filePath);
            //    }
            //}
        }

        private string GetCurrentUserName()
        {
            // Get the Windows identity of the current user
            System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();

            // Return the user's name (domain\username or username)
            return currentUser.Name;
        }

        private void btnOpenAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Lọc file ảnh (jpg, jpeg, png)
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                // Hiển thị hộp thoại OpenFileDialog
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file ảnh
                    string filePath = openFileDialog.FileName;
                    // Hiển thị ảnh trong PictureBox
                    ptxAnhHangHoa.Image = Image.FromFile(filePath);
                }
            }
        }

        private void ptxAnhHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ptxAnhHangHoa.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnSua_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedRowHandle = gridViewHangHoa.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                DataRow row = gridViewHangHoa.GetDataRow(selectedRowHandle);

                txtTenSanPham.Text = row["TENSANPHAM"].ToString();
                nudSoLuong.Value = Convert.ToDecimal(row["SOLUONG"]);
                cbxMaChatLieu.SelectedItem = row["MACHATLIEU"];
                cbxTenChatLieu.SelectedItem = row["TENCHATLIEU"]; // Assuming you have populated these comboboxes
                txtGiaBanRa.Text = row["GIABAN"].ToString();
                

                // Handle image display
                if (row["ANH"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["ANH"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        ptxAnhHangHoa.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    ptxAnhHangHoa.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.");
            }
        }

        private void cbxMaChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaChatLieu.SelectedItem != null)
            {
                string selectedMaChatLieu = cbxMaChatLieu.SelectedItem.ToString();

                cbxTenChatLieu.Properties.Items.Clear();

                string sql = "SELECT TENCHATLIEU FROM CHATLIEU WHERE MACHATLIEU = @MaChatLieu";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaChatLieu", selectedMaChatLieu);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Assuming there's only one matching TENCHATLIEU
                        {
                            cbxTenChatLieu.SelectedItem = reader["TENCHATLIEU"];
                        }
                    }
                }
            }
        }

        private void cbxTenChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTenChatLieu.SelectedItem != null)
            {
                string selectedTenChatLieu = cbxTenChatLieu.SelectedItem.ToString();

                cbxMaChatLieu.Properties.Items.Clear();

                string sql = "SELECT MACHATLIEU FROM CHATLIEU WHERE TENCHATLIEU = @TenChatLieu";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenChatLieu", selectedTenChatLieu);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Assuming there's only one matching MACHATLIEU
                        {
                            cbxMaChatLieu.SelectedItem = reader["MACHATLIEU"];
                        }
                    }
                }
            }
        }
    }
}
