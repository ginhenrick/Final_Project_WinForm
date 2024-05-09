using DevExpress.XtraBars;
using FinalProject.Form;
using FinalProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        uc_DMNhanVien ucDMNhanVien; //UC nhân viên
        uc_DMThanhToan ucDMKhachHang; //UC Khách Hàng
        uc_DMHangHoa ucDMHangHoa; //UC hàng hóa
        uc_DMChatLieu ucDMChatLieu;
        uc_HDBan ucHDBan;   //uc hóa đơn bán
        uc_FindHD ucFindHD; //uc tìm kiếm hóa đơn
        uc_BCDoanhThu ucBCDoanhThu;
        uc_BCHangTon ucBCHangTon;
        uc_FindHang ucFindHang;
        uc_FindKH ucFindKH;
        uc_GioiThieu ucGioiThieu;
        uc_TGLienLac ucTGLienLac;
        uc_DangNhap ucDangNhap;
        
        private void mnuDMNhanVien_Click(object sender, EventArgs e)
        {
            if (ucDMNhanVien == null)
            {
                ucDMNhanVien = new uc_DMNhanVien();
                ucDMNhanVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDMNhanVien);
                ucDMNhanVien.BringToFront();

            }
            else
            {
                ucDMNhanVien.BringToFront();
            }
        }

        private void mnuDMKhachHang_Click(object sender, EventArgs e)
        {
            if (ucDMKhachHang == null)
            {
                ucDMKhachHang = new uc_DMThanhToan();
                ucDMKhachHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDMKhachHang);
                ucDMKhachHang.BringToFront();

            }
            else
            {
                ucDMKhachHang.BringToFront();
            }
        }

        private void mnuDMHangHoa_Click(object sender, EventArgs e)
        {
            if (ucDMHangHoa == null)
            {
                ucDMHangHoa = new uc_DMHangHoa();
                ucDMHangHoa.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDMHangHoa);
                ucDMHangHoa.BringToFront();

            }
            else
            {
                ucDMHangHoa.BringToFront();
            }
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            if (ucFindHD == null)
            {
                ucFindHD = new uc_FindHD();
                ucFindHD.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucFindHD);
                ucFindHD.BringToFront();

            }
            else
            {
                ucFindHD.BringToFront();
            }
        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {
            if (ucFindHang == null)
            {
                ucFindHang = new uc_FindHang();
                ucFindHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucFindHang);
                ucFindHang.BringToFront();

            }
            else
            {
                ucFindHang.BringToFront();
            }
        }

        private void mnuFindKH_Click(object sender, EventArgs e)
        {
            if (ucFindKH == null)
            {
                ucFindKH = new uc_FindKH();
                ucFindKH.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucFindKH);
                ucFindKH.BringToFront();

            }
            else
            {
                ucFindKH.BringToFront();
            }
        }

            private void mnuHoaDonBan_Click(object sender, EventArgs e)
            {
                if (ucHDBan == null)
                {
                    ucHDBan = new uc_HDBan();
                    ucHDBan.Dock = DockStyle.Fill;
                    mainContainer.Controls.Add(ucHDBan);
                    ucHDBan.BringToFront();

                }
                else
                {
                    ucHDBan.BringToFront();
                }
            }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Form_DangNhap a = new Form_DangNhap();
                a.Show();
                this.Hide();
            }

        }

        private void mainContainer_Click(object sender, EventArgs e)
        {

        }

        public void mnuDMNhanVien_VisibleChanged(object sender, EventArgs e)
        {
           mnuDMNhanVien.Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (ucDMChatLieu == null)
            {
                ucDMChatLieu = new uc_DMChatLieu();
                ucDMChatLieu.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDMChatLieu);
                ucDMChatLieu.BringToFront();

            }
            else
            {
                ucDMChatLieu.BringToFront();
            }
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_VeChungToi formVeChungToi = new Form_VeChungToi();
            formVeChungToi.Show(); 
            formVeChungToi.StartPosition = FormStartPosition.CenterParent;
        }

        private void about_chuongtrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_VeChuongTrinh formVeChuongTrinh = new Form_VeChuongTrinh();
            formVeChuongTrinh.Show();
            formVeChuongTrinh.StartPosition = FormStartPosition.CenterParent;
        }

        private void accordionControlElement1_Click_1(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }
    }
}
