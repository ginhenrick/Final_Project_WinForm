using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.UI
{
    public partial class uc_DMChatLieu : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private System.Data.DataTable dataTable;

        // Chuỗi kết nối đến SQL Server
        string connectionString = "Data Source=MSITHINGF63;Initial Catalog=QLBanHang;Integrated Security=True";

        public uc_DMChatLieu()
        {
            InitializeComponent();
            LoadDanhSachChatLieu();
        }

        private void LoadDanhSachChatLieu()
        {
            string sql = "SELECT MACHATLIEU, TENCHATLIEU, GIANHAP, ANHCHATLIEU FROM CHATLIEU";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gridControlChatLieu.DataSource = dt; // Assuming your GridControl is named gridControlChatLieu

                GridView gridView = gridViewChatLieu; // Assuming your GridView is named gridViewChatLieu

                // Add columns in the specified order
                gridView.Columns.Add(new GridColumn() { FieldName = "MACHATLIEU", Caption = "Mã Chất Liệu" });
                gridView.Columns.Add(new GridColumn() { FieldName = "TENCHATLIEU", Caption = "Tên Chất Liệu" });
                gridView.Columns.Add(new GridColumn() { FieldName = "GIANHAP", Caption = "Giá Nhập Chất Liệu" });
                gridView.Columns.Add(new GridColumn() { FieldName = "ANHCHATLIEU", Caption = "Ảnh" });

                gridView.OptionsView.ColumnAutoWidth = true; // Auto-size columns
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //// Lấy tên chất liệu từ textbox
            //string tenChatLieu = txtTenChatLieu.Text; // Sửa lại control để lấy tên chất liệu

            //// Câu lệnh SQL để thêm chất liệu mới
            //string sql = "INSERT INTO CHATLIEU (TENCHATLIEU) VALUES (@TenChatLieu)";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(sql, connection))
            //{
            //    // Thêm tham số cho tên chất liệu
            //    command.Parameters.AddWithValue("@TenChatLieu", tenChatLieu);

            //    connection.Open();
            //    command.ExecuteNonQuery(); // Thực thi câu lệnh INSERT

            //    MessageBox.Show("Thêm chất liệu mới thành công!");
            //}

            //// Cập nhật DataGridView sau khi thêm
            //LoadDanhSachChatLieu();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int maChatLieu;

            //// Xác định mã chất liệu cần xóa
            //if (dgvChatLieu.SelectedRows.Count > 0)
            //{
            //    // Lấy mã từ dòng được chọn trong DataGridView
            //    maChatLieu = (int)dgvChatLieu.SelectedRows[0].Cells["MACHATLIEU"].Value;
            //}
            //else if (int.TryParse(txtMaChatLieu.Text, out maChatLieu))
            //{
            //    // Lấy mã từ textbox (nếu người dùng nhập)
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một chất liệu hoặc nhập mã chất liệu hợp lệ.");
            //    return;
            //}

            //// Xác nhận xóa với người dùng
            //DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chất liệu có mã " + maChatLieu + "?", "Xác nhận", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    // Câu lệnh SQL để xóa chất liệu
            //    string sql = "DELETE FROM CHATLIEU WHERE MACHATLIEU = @MaChatLieu";

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    using (SqlCommand command = new SqlCommand(sql, connection))
            //    {
            //        command.Parameters.AddWithValue("@MaChatLieu", maChatLieu);
            //        connection.Open();
            //        int rowsAffected = command.ExecuteNonQuery(); // Thực thi câu lệnh DELETE

            //        if (rowsAffected > 0)
            //        {
            //            MessageBox.Show("Xóa chất liệu thành công.");
            //            LoadDanhSachChatLieu(); // Cập nhật DataGridView
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không tìm thấy chất liệu có mã " + maChatLieu);
            //        }
            //    }
            //}
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (dgvChatLieu.SelectedRows.Count > 0)
            //{
            //    // Lấy thông tin từ dòng được chọn
            //    DataGridViewRow row = dgvChatLieu.SelectedRows[0];
            //    txtMaChatLieu.Text = row.Cells["MACHATLIEU"].Value.ToString(); // Thêm mã chất liệu vào textbox
            //    txtTenChatLieu.Text = row.Cells["TENCHATLIEU"].Value.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một chất liệu để sửa.");
            //}
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    // Câu lệnh SQL để cập nhật thông tin chất liệu 
            //    string sql = "UPDATE CHATLIEU SET TENCHATLIEU = @TenChatLieu WHERE MACHATLIEU = @MaChatLieu";
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    using (SqlCommand command = new SqlCommand(sql, connection))
            //    {
            //        // Thêm tham số cho tên chất liệu và mã chất liệu
            //        command.Parameters.AddWithValue("@TenChatLieu", txtTenChatLieu.Text);
            //        command.Parameters.AddWithValue("@MaChatLieu", txtMaChatLieu.Text); // Thêm tham số mã chất liệu

            //        connection.Open();
            //        command.ExecuteNonQuery(); // Thực thi câu lệnh UPDATE
            //    }

            //    MessageBox.Show("Cập nhật thông tin chất liệu thành công!");
            //    LoadDanhSachChatLieu(); // Cập nhật DataGridView
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message);
            //}
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //// Xóa dữ liệu trong textbox
            //txtMaChatLieu.Text = "";
            //txtTenChatLieu.Text = "";

            //// Bỏ chọn dòng hiện tại trong DataGridView
            //dgvChatLieu.ClearSelection();
        }
        public void Dispose()
        {
            sqlConnection?.Dispose(); // Giải phóng tài nguyên kết nối
        }
    }
}
