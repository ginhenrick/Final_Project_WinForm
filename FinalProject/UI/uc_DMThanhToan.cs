using DevExpress.DataAccess.Native.Data;
using DevExpress.Utils.MVVM.Internal;
using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
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
using Humanizer;
using DevExpress.XtraGrid.Columns;
using FinalProject.Form;
using DevExpress.XtraExport.Helpers;

namespace FinalProject.UI
{
    public partial class uc_DMThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private System.Data.DataTable dataTable;
        string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True"; 
        private System.Data.DataTable dataTableHangHoa;
        private System.Data.DataTable dataTableKhachHang;
        public BindingList<CartItem> cartItems = new BindingList<CartItem>();
        public BindingList<CustomerItems> customerItems = new BindingList<CustomerItems>();
        internal IEnumerable<object> dtGiamGia;

        public class CartItem
        {
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal GiamGia { get; set; }
            public decimal GiaSanPham { get; set; }
            public decimal ThanhTien { get; internal set; }
            public string PhuongThucThanhToan { get; set; }
        }

        public class CustomerItems
        {
            public string TenKhach { get; set; }
            public int SoDienThoai { get; set; }
            public DateTime NgaySinh { get; set; }
            public string DiaChi { get; set; }
            public string GioiTinh { get; set; }
            public string LoaiKhachHang { get; set; }
        }

        public DateTime NgayMua
        {
            get { return dtpNgayMua.Value; }
        }
        public string PhuongThucThanhToan
        {
            get { return cbxPhuongThucThanhToan.SelectedItem?.ToString(); }
        }
        public string TongTienText
        {
            get { return lblTongTien.Text; }
        }
        public uc_DMThanhToan()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT MAKHACH, TENKHACH, GIOITINH, DIACHI, DIENTHOAI FROM KHACH", sqlConnection);
            dataTableHangHoa = new System.Data.DataTable();
            dataTableKhachHang = new System.Data.DataTable();
            LoadTenSanPhamVaoComboBox();
            cbxTenSanPham.SelectedIndex = 0;
            UpdateTenSanPhamVaoComboBox();
            LoadPhuongThucThanhToanVaoComboBox();
            cbxPhuongThucThanhToan.SelectedIndex = 0;
            gridControlCart.DataSource = cartItems;
            gridViewCart.Columns.Add(new GridColumn() { FieldName = "TenSanPham", Caption = "Tên Sản Phẩm" });
            gridViewCart.Columns.Add(new GridColumn() { FieldName = "SoLuong", Caption = "Số Lượng" });
            gridViewCart.Columns.Add(new GridColumn() { FieldName = "GiamGia", Caption = "Giảm Giá (%)" });
            //gridViewCart.Columns.Add(new GridColumn() { FieldName = "GiaSanPham", Caption = "Giá Sản Phẩm", DisplayFormat = "C2" });
            gridControlCustomer.DataSource = customerItems;
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "TenKhach", Caption = "Tên Khách" });
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "SoDienThoai", Caption = "Số điện thoại" });
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "NgaySinh", Caption = "Ngày sinh" });
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "DiaChi", Caption = "Địa chỉ" });
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "GioiTinh", Caption = "Giới tính" });
            gridViewCustomer.Columns.Add(new GridColumn() { FieldName = "LoaiKhachHang", Caption = "Loại khách hàng" });
        }

        private void LoadPhuongThucThanhToanVaoComboBox()
        {
            cbxPhuongThucThanhToan.Properties.Items.Clear();

            string sql = "SELECT PHUONGTHUCTHANHTOAN FROM THANHTOAN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxPhuongThucThanhToan.Properties.Items.Add(reader["PHUONGTHUCTHANHTOAN"]);
                        }
                    }
                }
            }
        }

        public SqlDependency dependency;
        private SqlCommand command;

        private void LoadTenSanPhamVaoComboBox()
        {
            try
            {
                // Xóa tất cả các mục hiện có trong combobox
                //cbxTenSanPham.Properties.Items.Clear();

                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn SQL để lấy tất cả các giá trị TENSANPHAM từ bảng HANGHOANHAPKHO
                    string sql = "SELECT TENSANPHAM FROM HANGHOANHAPKHO";

                    // Tạo và thực thi đối tượng SqlCommand để thực hiện truy vấn SQL
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        this.command = command; // Lưu lại command cho SqlDependency
                                                // Đọc dữ liệu từ truy vấn
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu được trả về không
                            if (reader.HasRows)
                            {
                                // Đọc từng dòng dữ liệu và thêm giá trị TENSANPHAM vào combobox
                                while (reader.Read())
                                {
                                    string tenSanPham = reader["TENSANPHAM"].ToString();
                                    cbxTenSanPham.Properties.Items.Add(tenSanPham);
                                }
                            }
                        }

                        // Đăng ký SqlDependency sau khi load xong dữ liệu
                        if (dependency == null)
                        {
                            SqlDependency.Start(connectionString);
                            dependency = new SqlDependency(command);
                            dependency.OnChange += Dependency_OnChange;
                        }
                    }
                }

                // Thêm placeholder sau khi đã thêm tất cả sản phẩm
                //cbxTenSanPham.Properties.Items.Insert(0, "Vui lòng chọn sản phẩm để thanh toán");
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu có
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTenSanPhamVaoComboBox()));
            }
            else
            {
                UpdateTenSanPhamVaoComboBox();
            }
        }

        private void UpdateTenSanPhamVaoComboBox()
        {
            // Gỡ bỏ sự kiện cũ
            if (dependency != null)
            {
                dependency.OnChange -= Dependency_OnChange;
                dependency = null;
            }

            // Tải lại dữ liệu và đăng ký SqlDependency mới
            LoadTenSanPhamVaoComboBox();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void lblMaDonHang_Click(object sender, EventArgs e)
        {

        }
        private void lblKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

       
            
        
        private void lblLoaiKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void btnTomTatDonHang_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string tenKhach = txtTenKhach.Text;
            string soDienThoai = txtSoDienThoai.Text;
            DateTime ngayMua = dtpNgayMua.Value;
            string gioiTinh = cbxGioiTinh.SelectedItem?.ToString() ?? "N/A";
            string loaiKhachHang = cbxLoaiKhachHang.SelectedItem?.ToString() ?? "N/A";
            string phuongThucThanhToan = cbxPhuongThucThanhToan.SelectedItem?.ToString() ?? "N/A";

            // Hiển thị thông tin trên các label
            lblKhachHang.Text = tenKhach;
            lblNgayMua.Text = ngayMua.ToShortDateString();
            lblLoaiKhachHang.Text = loaiKhachHang;
            lblPhuongThucThanhToan.Text = phuongThucThanhToan;
            lblSoDienThoai.Text = soDienThoai;

            // Sử dụng Dictionary để nhóm sản phẩm theo tên, tính tổng số lượng, giá trị và giảm giá
            Dictionary<string, (int SoLuong, decimal GiaTri, decimal GiamGia)> sanPhamThongTin = new Dictionary<string, (int, decimal, decimal)>();

            foreach (var item in cartItems) // Giả sử 'cartItems' là danh sách các mặt hàng trong giỏ hàng
            {
                if (sanPhamThongTin.ContainsKey(item.TenSanPham))
                {
                    // Cập nhật số lượng, giá trị và giảm giá cho sản phẩm hiện có
                    var currentInfo = sanPhamThongTin[item.TenSanPham];
                    sanPhamThongTin[item.TenSanPham] = (currentInfo.SoLuong + item.SoLuong,
                                                        currentInfo.GiaTri + item.ThanhTien,
                                                        item.GiamGia); // Giữ nguyên giảm giá
                }
                else
                {
                    // Thêm sản phẩm mới vào dictionary
                    sanPhamThongTin[item.TenSanPham] = (item.SoLuong, item.ThanhTien, item.GiamGia);
                }
            }

            // Xóa các mục hiện có trong ListView
            lvTenSanPham.Items.Clear();
            lvSoLuong.Items.Clear();

            // Xây dựng chuỗi giảm giá và tổng tiền
            StringBuilder giamGiaBuilder = new StringBuilder();
            decimal tongTien = 0;
            bool coGiamGia = false; // Biến để kiểm tra xem có sản phẩm nào được giảm giá hay không

            foreach (var kvp in sanPhamThongTin)
            {
                // Tạo ListViewItem mới cho mỗi sản phẩm
                var itemTen = new ListViewItem(kvp.Key); // Tên sản phẩm
                itemTen.SubItems.Add(kvp.Value.SoLuong.ToString()); // Số lượng

                var itemSoLuong = new ListViewItem(kvp.Value.SoLuong.ToString()); // Số lượng

                // Thêm ListViewItem vào ListView
                lvTenSanPham.Items.Add(itemTen);
                lvSoLuong.Items.Add(itemSoLuong);

                if (kvp.Value.GiamGia > 0)
                {
                    giamGiaBuilder.Append(kvp.Value.GiamGia).Append("%, "); // Thêm giảm giá vào chuỗi
                    coGiamGia = true; // Đánh dấu đã có giảm giá
                }
                tongTien += kvp.Value.GiaTri;
            }

            // Loại bỏ dấu phẩy cuối cùng (nếu có)
            if (giamGiaBuilder.Length > 0) giamGiaBuilder.Length -= 2;

            // Hiển thị chuỗi giảm giá hoặc N/A
            lblGiamGia.Text = coGiamGia ? giamGiaBuilder.ToString() : "N/A";

            // Hiển thị tổng tiền và chuyển đổi sang chữ
            lblTongTien.Text = tongTien.ToString("C", new CultureInfo("vi-VN"));
            lblBangChu.Text = ((long)tongTien).ToWords(new CultureInfo("vi-VN")) + " đồng";
        }

        private void btnAddInCart_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin sản phẩm
            string tenSanPham = cbxTenSanPham.SelectedItem?.ToString() ?? "";
            int soLuong = (int)nudSoLuong.Value;
            decimal giaSanPham;
            if (!decimal.TryParse(lblGiaSanPham.Text, NumberStyles.Currency, null, out giaSanPham))
            {
                MessageBox.Show("Invalid product price format.");
                return;
            }
            string giamGiaText = cbxGiamGia.SelectedItem?.ToString() ?? "0";
            decimal giamGiaPhanTram = decimal.Parse(giamGiaText.TrimEnd('%'));

            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
            CartItem existingItem = cartItems.FirstOrDefault(item => item.TenSanPham == tenSanPham);

            if (existingItem != null)
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng và giảm giá
                existingItem.SoLuong += soLuong;
                existingItem.GiamGia = giamGiaPhanTram;

                // Tính toán lại thành tiền cho sản phẩm với giảm giá mới
                existingItem.ThanhTien = existingItem.GiaSanPham * existingItem.SoLuong * (1 - existingItem.GiamGia / 100);
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm vào giỏ hàng và tính thành tiền
                decimal thanhTien = giaSanPham * soLuong * (1 - giamGiaPhanTram / 100);
                cartItems.Add(new CartItem()
                {
                    TenSanPham = tenSanPham,
                    SoLuong = soLuong,
                    GiaSanPham = giaSanPham,
                    GiamGia = giamGiaPhanTram,
                    ThanhTien = thanhTien,
                });
            }
            // Làm mới GridControl để hiển thị thay đổi
            gridControlCart.RefreshDataSource();
        }
        

        private void cbxTenSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void nudSoLuong_ValueChanged_1(object sender, EventArgs e)
        {
            cbxTenSanPham_SelectedIndexChanged_1(sender, e); // Call the existing method to update the price
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ các control
            string tenKhachHang = txtTenKhach.Text;
            // Kiểm tra xem tên khách hàng đã được nhập hay chưa
            if (string.IsNullOrEmpty(tenKhachHang))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }
            string soDienThoaiText = txtSoDienThoai.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text;
            string gioiTinh = cbxGioiTinh.SelectedItem?.ToString() ?? "N/A";
            string loaiKhachHang = cbxLoaiKhachHang.SelectedItem?.ToString() ?? "N/A";
            // Validate phone number (int)
            int soDienThoai;
            if (!int.TryParse(soDienThoaiText, out soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại");
                return;
            }
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
            CustomerItems existingCustomer = customerItems.FirstOrDefault(item => item.TenKhach == tenKhachHang);
            CustomerItems newCustomer = new CustomerItems()
            {
                TenKhach = tenKhachHang,
                SoDienThoai = soDienThoai, 
                NgaySinh = ngaySinh,
                DiaChi = diaChi,
                GioiTinh = gioiTinh,
                LoaiKhachHang = loaiKhachHang
            };
            customerItems.Add(newCustomer);
            gridControlCustomer.RefreshDataSource();
            //txtTenKhach.Text = "";           // Xóa nội dung của textbox txtTenKhach
            //txtSoDienThoai.Text = "";      // Xóa nội dung của textbox txtSoDienThoai
            //dtpNgaySinh.Value = DateTime.Now;   // Đặt lại giá trị của DateTimePicker dtpNgaySinh về ngày hiện tại 
            //txtDiaChi.Text = "";            // Xóa nội dung của textbox txtDiaChi
            //cbxGioiTinh.SelectedIndex = -1;   // Đặt lại combobox cbxGioiTinh về trạng thái chưa chọn mục nào
            //cbxLoaiKhachHang.SelectedIndex = -1; // Đặt lại combobox cbxLoaiKhachHang về trạng thái chưa chọn mục nào
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, backspace, and delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Discard non-numeric key presses
            }
            else
            {
                // Limit to 10 digits
                if (char.IsDigit(e.KeyChar) && txtSoDienThoai.Text.Length >= 10)
                {
                    e.Handled = true; // Discard key press if already at 10 digits
                }
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            int selectedRowHandle = gridViewCart.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                // Get the TenSanPham value from the selected row
                string tenSanPham = gridViewCart.GetRowCellValue(selectedRowHandle, "TenSanPham").ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " + tenSanPham + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cartItems.RemoveAt(selectedRowHandle);
                    gridControlCart.RefreshDataSource();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            int selectedRowHandle = gridViewCart.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                // Get product details from the selected row
                CartItem selectedItem = cartItems[selectedRowHandle];
                string tenSanPham = selectedItem.TenSanPham;
                int soLuong = selectedItem.SoLuong;
                decimal giamGia = selectedItem.GiamGia;
                decimal giaSanPham = selectedItem.GiaSanPham;

                // Populate input fields with product details
                cbxTenSanPham.SelectedItem = tenSanPham;
                nudSoLuong.Value = soLuong;
                cbxGiamGia.SelectedItem = giamGia.ToString() + "%"; // Assuming discount is stored as a percentage
                lblGiaSanPham.Text = giaSanPham.ToString("C", new CultureInfo("vi-VN"));

                // Remove the item from the cartItems list
                cartItems.RemoveAt(selectedRowHandle);

                // Refresh the GridControl to remove the row
                gridControlCart.RefreshDataSource();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bill này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear cart items and refresh GridControl
                cartItems.Clear();
                gridControlCart.RefreshDataSource();

                // Reset product input fields
                cbxTenSanPham.SelectedIndex = -1;
                nudSoLuong.Value = 1;
                cbxGiamGia.SelectedIndex = -1;
                lblGiaSanPham.Text = "N/A";

                // Clear customer information
                txtTenKhach.Text = "";
                txtSoDienThoai.Text = "";
                dtpNgaySinh.Value = DateTime.Now;
                txtDiaChi.Text = "";
                cbxGioiTinh.SelectedIndex = -1;
                cbxLoaiKhachHang.SelectedIndex = -1;

                // Clear order summary
                lblKhachHang.Text = "N/A";
                lblNgayMua.Text = "N/A";
                lblLoaiKhachHang.Text = "N/A";
                lblPhuongThucThanhToan.Text = "N/A";
                lblSoDienThoai.Text = "N/A";
                lblGiamGia.Text = "N/A";
                lblTongTien.Text = "N/A";
                lblBangChu.Text = "N/A";
                lvTenSanPham.Items.Clear();
                lvSoLuong.Items.Clear();
            }
            else
            {
                // Inform the user if there are no items in the cart
                MessageBox.Show("Không có bill nào để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public ListView.ListViewItemCollection TenSanPhamItems => lvTenSanPham.Items;
        public ListView.ListViewItemCollection SoLuongItems => lvSoLuong.Items;
        public System.Data.DataTable HangHoaDataTable
        {
            get
            {
                // Tạo DataTable mới
                System.Data.DataTable dtHangHoa = new System.Data.DataTable();
                dtHangHoa.Columns.Add("TenSanPham", typeof(string));
                dtHangHoa.Columns.Add("SoLuong", typeof(int));
                dtHangHoa.Columns.Add("GiaSanPham", typeof(decimal));
                dtHangHoa.Columns.Add("GiamGia", typeof(decimal));

                // Sao chép dữ liệu từ BindingList sang DataTable
                foreach (CartItem item in cartItems)
                {
                    DataRow row = dtHangHoa.NewRow();
                    row["TenSanPham"] = item.TenSanPham;
                    row["SoLuong"] = item.SoLuong;
                    row["GiaSanPham"] = item.GiaSanPham;
                    row["GiamGia"] = item.GiamGia;
                    dtHangHoa.Rows.Add(row);
                }

                return dtHangHoa;
            }
        }
        public string GiamGia => lblGiamGia.Text;
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Create an instance of Form_ThanhToan
            Form_ThanhToan thanhToanForm = new Form_ThanhToan(this);

            // Set properties with values from uc_DMThanhToan labels
            thanhToanForm.TenKhach = lblKhachHang.Text;
            thanhToanForm.SoDienThoai = lblSoDienThoai.Text;
            thanhToanForm.LoaiKhachHang = lblLoaiKhachHang.Text;
            thanhToanForm.NgayMua = lblNgayMua.Text;
            thanhToanForm.TongTien = lblTongTien.Text;
            thanhToanForm.BangChu = lblBangChu.Text;

            // Display the Form_ThanhToan (modal or modeless)
            thanhToanForm.ShowDialog(); // Or thanhToanForm.Show()
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxTenSanPham.SelectedItem == null || cbxTenSanPham.SelectedItem.ToString() == "Vui lòng chọn sản phẩm để thanh toán")
            {
                lblGiaSanPham.Text = "N/A";
                return;
            }

            string tenSanPham = cbxTenSanPham.SelectedItem.ToString();
            string giamGiaText = cbxGiamGia.SelectedItem?.ToString() ?? "0";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Sửa đổi câu truy vấn để lấy GIABAN từ HANGHOANHAPKHO
                    string sql = "SELECT GIABAN FROM HANGHOANHAPKHO WHERE TENSANPHAM = @TenSanPham";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal giaBan = reader.GetDecimal(reader.GetOrdinal("GIABAN"));
                                decimal giamGiaPhanTram;

                                if (decimal.TryParse(giamGiaText.TrimEnd('%'), out giamGiaPhanTram) && giamGiaPhanTram > 0)
                                {
                                    giaBan *= (1 - giamGiaPhanTram / 100);
                                }

                                lblGiaSanPham.Text = giaBan.ToString("C", new CultureInfo("vi-VN"));
                            }
                            else
                            {
                                lblGiaSanPham.Text = "N/A"; // Sản phẩm không tìm thấy
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblGiaSanPham.Text = "N/A";
            }
        }
    }
}
