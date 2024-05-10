using DevExpress.DataAccess.Native.Data;
using DevExpress.PivotGrid.QueryMode;
using DevExpress.SpreadsheetSource.Xls;
using DevExpress.Utils;
using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Table;

namespace FinalProject.UI
{
    public partial class uc_DMNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private System.Data.DataTable dataTable;
        // Kết nối đến SQL Server
        string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True"; // Thay đổi thông tin kết nối cho phù hợp

        // Khai báo sự kiện
        public event EventHandler CloseRequested;
        public uc_DMNhanVien()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            // Mở kết nối
            sqlConnection.Open();
            dataTable = new System.Data.DataTable();
            LoadDanhSachNhanVien();
            LoadMaNhanVienComboBox();
        }

        private void LoadDanhSachNhanVien()
        {
            string sql = "SELECT MANHANVIEN, TEN, GIOITINH, DIACHI, DIENTHOAI, EMAIL, NGAYSINH, CHUCVU, ANHNV, ISADMIN, PASSWORD FROM NHANVIEN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    // Set GridControl's DataSource
                    gridControlNhanVien.DataSource = dt;

                    // Access the GridView to configure columns
                    GridView gridView = gridViewNhanVien;

                    // Add columns to GridView
                    gridView.Columns.Add(new GridColumn() { FieldName = "MANHANVIEN", Caption = "Mã Nhân Viên" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "TEN", Caption = "Họ và Tên" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "DIACHI", Caption = "Địa Chỉ" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "DIENTHOAI", Caption = "Số điện thoại" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "EMAIL", Caption = "Email" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "GIOITINH", Caption = "Giới tính" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "NGAYSINH", Caption = "Ngày sinh" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "CHUCVU", Caption = "Chức vụ" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "ISADMIN", Caption = "IsAdmin" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "PASSWORD", Caption = "Mật khẩu đăng nhập" });
                    gridView.Columns.Add(new GridColumn() { FieldName = "ANHNV", Caption = "Ảnh Nhân Viên" });

                    // Auto-size columns based on content
                    gridView.OptionsView.ColumnAutoWidth = true;
                }
            }
        }
        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Lấy thông tin từ giao diện
            string hoTen = txtHoVaTenNV.Text;
            string gioiTinh = cbxGioiTinh.SelectedItem.ToString();
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtDienThoai.Text;
            string email = txtEmail.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string chucVu = (cbxChucVu.SelectedIndex == 0) ? "Admin" : "Staff"; // Assuming cbxChucVu has 2 options: Admin and Staff
            string isAdmin = cbxIsAdmin.SelectedItem.ToString();
            string password = txtMatKhau.Text;

            // Convert image to byte array
            byte[] imageData = null;
            if (ptbAnhNhanVien.Image != null)
            {
                imageData = ConvertImageToByteArray(ptbAnhNhanVien.Image);
            }

            // Tạo câu lệnh SQL INSERT
            string sql = "INSERT INTO NHANVIEN (TEN, GIOITINH, DIACHI, DIENTHOAI, EMAIL, NGAYSINH, CHUCVU, ANHNV, ISADMIN, PASSWORD) VALUES (@Ten, @GioiTinh, @DiaChi, @DienThoai, @Email, @NgaySinh, @ChucVu, @AnhNV, @IsAdmin, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Thêm tham số
                    command.Parameters.AddWithValue("@Ten", hoTen);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@DienThoai", dienThoai);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@AnhNV", imageData);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    command.Parameters.AddWithValue("@Password", password);

                    // Mở kết nối và thực thi
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhân viên thành công!");
                }
            }

            // Cập nhật DataGridView
            LoadDanhSachNhanVien();
            LoadMaNhanVienComboBox();
        }

        

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Lấy chỉ mục của dòng đang được chọn
            int selectedRowHandle = gridViewNhanVien.FocusedRowHandle;

            // Kiểm tra xem có dòng nào được chọn hay không
            if (selectedRowHandle >= 0)
            {
                // Lấy mã nhân viên từ dòng đã chọn
                int maNhanVien = (int)gridViewNhanVien.GetRowCellValue(selectedRowHandle, "MANHANVIEN");

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã " + maNhanVien + "?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Tạo câu lệnh SQL DELETE
                    string sql = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @MaNhanVien";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa nhân viên thành công.");
                                LoadDanhSachNhanVien(); // Reload data after deletion
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhân viên có mã " + maNhanVien);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void dgvDanhSachNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int maNhanVien;
                if (cbxMaNhanVien.SelectedItem != null)
                {
                    maNhanVien = (int)cbxMaNhanVien.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên.");
                    return; // Exit the function if no MaNV is selected
                }
                string hoTen = txtHoVaTenNV.Text;
                string gioiTinh = cbxGioiTinh.SelectedItem.ToString();
                string diaChi = txtDiaChi.Text;
                string dienThoai = txtDienThoai.Text;
                string email = txtEmail.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string chucVu = cbxChucVu.SelectedItem.ToString();
                string isAdmin = cbxIsAdmin.SelectedItem.ToString();
                string password = txtMatKhau.Text.ToString();

                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(gioiTinh) ||
            string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(dienThoai) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(chucVu) ||
            string.IsNullOrEmpty(isAdmin) || string.IsNullOrEmpty(password) ||
            ptbAnhNhanVien.Image == null) // Check if image is missing
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin, bao gồm cả hình ảnh nhân viên.");
                    return; // Exit if any required field is empty
                }

                byte[] imageData = null;
                if (ptbAnhNhanVien.Image != null)
                {
                    imageData = ConvertImageToByteArray(ptbAnhNhanVien.Image);
                }

                // Create SQL UPDATE statement
                string sql = "UPDATE NHANVIEN SET TEN = @Ten, GIOITINH = @GioiTinh, DIACHI = @DiaChi, " +
                             "DIENTHOAI = @DienThoai, EMAIL = @Email, NGAYSINH = @NgaySinh, CHUCVU = @ChucVu, " +
                             "ANHNV = @AnhNV, ISADMIN = @IsAdmin, PASSWORD = @Password WHERE MANHANVIEN = @MaNV";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@MaNV", maNhanVien);
                        command.Parameters.AddWithValue("@Ten", hoTen);
                        command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@DienThoai", dienThoai);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        command.Parameters.AddWithValue("@ChucVu", chucVu);
                        command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@AnhNV", imageData);

                        // Open connection and execute
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    }
                }

                // Update DataGridView
                LoadDanhSachNhanVien();
                LoadMaNhanVienComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedRowHandle = gridViewNhanVien.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                // Get cell values from the selected row using GetRowCellValue
                cbxMaNhanVien.SelectedItem = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "MANHANVIEN").ToString();
                txtHoVaTenNV.Text = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "TEN").ToString();
                cbxGioiTinh.SelectedItem = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "GIOITINH").ToString();
                txtDiaChi.Text = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "DIACHI").ToString();
                txtDienThoai.Text = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "DIENTHOAI").ToString();
                dtpNgaySinh.Value = (DateTime)gridViewNhanVien.GetRowCellValue(selectedRowHandle, "NGAYSINH");
                txtEmail.Text = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "EMAIL").ToString();
                cbxChucVu.SelectedItem = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "CHUCVU").ToString();
                cbxIsAdmin.SelectedItem = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "ISADMIN").ToString();

                object passwordValue = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "PASSWORD");
                if (passwordValue != null)
                {
                    txtMatKhau.Text = passwordValue.ToString();
                }
                else
                {
                    txtMatKhau.Text = ""; // Xóa nội dung textbox nếu không có mật khẩu
                }

                object imageData = gridViewNhanVien.GetRowCellValue(selectedRowHandle, "ANHNV");
                if (imageData != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])imageData;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        ptbAnhNhanVien.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    ptbAnhNhanVien.Image = null; // Clear image if no data is available
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
            LoadMaNhanVienComboBox();
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Clear dữ liệu trong các control
            txtHoVaTenNV.Text = "";                   // Xóa nội dung textbox Họ và Tên
            cbxGioiTinh.SelectedItem = null;          // Xóa lựa chọn trong combobox Giới tính
            txtDiaChi.Text = "";                      // Xóa nội dung textbox Địa chỉ
            txtDienThoai.Text = "";                    // Xóa nội dung textbox Điện thoại
            dtpNgaySinh.Value = DateTime.Today;        // Đặt lại ngày sinh về ngày hiện tại
            txtEmail.Text = "";                       // Xóa nội dung textbox Email
            cbxChucVu.SelectedItem = null;             // Xóa lựa chọn trong combobox Chức vụ
            cbxIsAdmin.SelectedItem = null;            // Xóa lựa chọn trong combobox IsAdmin
            txtMatKhau.Text = "";                     // Xóa nội dung textbox Mật khẩu
            ptbAnhNhanVien.Image = null;              // Xóa ảnh trong PictureBox

            // 2. Bỏ chọn dòng hiện tại trong GridControl
            gridViewNhanVien.RefreshData();        // Xóa lựa chọn trên GridView
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbAnhNhanVien.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            ptbAnhNhanVien.Image = null;
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            {
                e.Handled = true; // Block the input
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            // Regex pattern for Gmail addresses
            string pattern = @"^[^@\s]+@[^@\s]+\.(com|net|org)$";

            // Check if the email matches the pattern
            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email Gmail hợp lệ.");
                e.Cancel = true; // Prevent saving if the email is invalid
            }
        }

        private void cbxGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxChucVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void cbxMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaNhanVienComboBox();
        }
        private void LoadMaNhanVienComboBox()
        {
            cbxMaNhanVien.Properties.Items.Clear(); // Clear existing items

            string sql = "SELECT MANHANVIEN FROM NHANVIEN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxMaNhanVien.Properties.Items.Add(reader["MANHANVIEN"]);
                        }
                    }
                }
            }
        }

        private void cbxIsAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_DMNhanVien_Load(object sender, EventArgs e)
        {
            LoadMaNhanVienComboBox();
        }

        private void cbxIsAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIsAdmin.SelectedIndex == 0) 
            {
                cbxChucVu.SelectedIndex = 0; 
            }
            else if (cbxIsAdmin.SelectedIndex == 1) 
            {
                cbxChucVu.SelectedIndex = 1; 
            }
        }

        private void cbxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChucVu.SelectedIndex == 0) 
            {
                cbxIsAdmin.SelectedIndex = 0;
            }
            else if (cbxChucVu.SelectedIndex == 1) 
            {
                cbxIsAdmin.SelectedIndex = 1;
            }
        }

        private void btnXoaTheoMa_Click(object sender, EventArgs e)
        { 
            // 1. Lấy mãnhân viên từ textbox
            string maNhanVienText = txtMaNhanVien.Text;

            // 2. Kiểm tra mã nhân viên có hợp lệ hay không
            int maNhanVien;
            if (!int.TryParse(maNhanVienText, out maNhanVien))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ. Vui lòng nhập số nguyên.");
                return;
            }

            // 3. Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã " + maNhanVien + "?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // 4. Tạo câu lệnh SQL DELETE
                string sql = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @MaNhanVien";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 5. Thêm tham số cho mã nhân viên
                        command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        // 6. Mở kết nối và thực thi lệnh xóa
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // 7. Kiểm tra kết quả và thông báo
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa nhân viên thành công.");
                            LoadDanhSachNhanVien(); // Tải lại danh sách nhân viên
                            LoadMaNhanVienComboBox();
                            txtMaNhanVien.Text = ""; // Xóa nội dung textbox
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên có mã " + maNhanVien);
                        }
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Get data from GridControl
            System.Data.DataTable dtNhanVien = (System.Data.DataTable)gridControlNhanVien.DataSource;

            // Create ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Create worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Danh Sách Nhân Viên");

                // Load data from DataTable
                worksheet.Cells["A1"].LoadFromDataTable(dtNhanVien, true);

                // Format header
                using (ExcelRange headerRange = worksheet.Cells[1, 1, 1, dtNhanVien.Columns.Count])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }
                // Remove image column from the Excel file
                int imageColumnIndex = dtNhanVien.Columns.IndexOf("ANHNV");
                if (imageColumnIndex != -1)
                {
                    worksheet.DeleteColumn(imageColumnIndex + 1);
                }

                // AutoFit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Add border around cells
                using (ExcelRange borderRange = worksheet.Cells[1, 1, worksheet.Dimension.Rows, worksheet.Dimension.Columns])
                {
                    borderRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    borderRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    borderRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    borderRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Create file path (Desktop)
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"Danh Sách Nhân Viên - {DateTime.Now:yyyyMMdd}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                // Save Excel file
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);

                // Ask user to open the file
                if (MessageBox.Show("Xuất file Excel thành công! Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filePath);
                }
            }
        }
    }
}

