using DevExpress.Utils;
using DevExpress.XtraEditors;
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
    public partial class uc_DangNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public static string sqlcon = @"Server=MSITHINGF63; Database=QLBanHang; Integrated Security=True";

        public static SqlConnection mycon;
        public static SqlCommand com;
        public static SqlDataAdapter ad;
        public static DataTable dt;
        public static SqlCommandBuilder bd;
        

        public static string getNameUser(string fullname)
        {
            return fullname;
        }

        public static string username;
        public uc_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql1 = "Select count(*) from NHANVIEN where TEN='" + txtUsername.Text.Trim() + "' and PASSWORD='" + txtMatKhau.Text.Trim() + "' ";
            if (txtUsername.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin! ", "Thông báo", MessageBoxButtons.OK);
            }

            else
            {
                int a = 0;
                mycon = new SqlConnection(sqlcon);
                mycon.Open();

                com = new SqlCommand(sql1, mycon);
                a = (int)com.ExecuteScalar();



                if (a == 0)
                {
                    string t = "Username hoặc password sai !,Bạn vui lòng kiểm tra lại ";
                    MessageBox.Show((t), "thong báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "Select ISADMIN from NHANVIEN where TEN='" + txtUsername.Text.Trim() + "'";
                    mycon = new SqlConnection(sqlcon);
                    mycon.Open();
                    SqlCommand getIsAdmin = new SqlCommand(sql, mycon);
                    int getRole = (int)getIsAdmin.ExecuteScalar();

                    if (getRole == 0)
                    {

                        MessageBox.Show("Ban dang nhap vao tai khoan Admin", "Thong bao ", MessageBoxButtons.OK);
                        frmMain frmMain = new frmMain();             

                        frmMain.lb_quyen.Text = GetFullname(0, txtUsername.Text.Trim()) + " (Quản trị)";

                        


                        frmMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ban dang nhap vao tai khoan Nhân Vien", "Thong bao ", MessageBoxButtons.OK);
                        frmMain frmMain = new frmMain();
                        frmMain.mnuDMNhanVien.Visible = false;
                        frmMain.mnuDMKhachHang.Visible = false;
                        frmMain.lb_quyen.Text = GetFullname(1, txtUsername.Text.Trim()) + " (Nhân viên)";
                        frmMain.Show();
                        this.Hide();

                    }
                }
            }
        }

        public static string GetFullname(int isAdmin, string ten)
        {
            string sqlGetFullname = "Select TEN from NHANVIEN where ISADMIN=" + isAdmin + " and TEN='" + ten + "'";
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            SqlCommand getFullname = new SqlCommand(sqlGetFullname, mycon);
            string Fullname = getFullname.ExecuteScalar().ToString();

            return Fullname;
        }     
      
    }
}
