using DevExpress.XtraBars;
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
        }

        uc_DMNhanVien ucDMNhanVien; //UC nhân viên
        uc_DMKhachHang ucDMKhachHang; //UC Khách Hàng
        uc_DMHangHoa ucDMHangHoa; //UC hàng hóa
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
            if (ucDMNhanVien==null)
            {
                ucDMNhanVien = new uc_DMNhanVien();
                ucDMNhanVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDMNhanVien);
                ucDMNhanVien.BringToFront();

            } else
            {
                ucDMNhanVien.BringToFront();
            }
        }

        private void mnuDMKhachHang_Click(object sender, EventArgs e)
        {
            if (ucDMKhachHang == null)
            {
                ucDMKhachHang = new uc_DMKhachHang();
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
                Form2 a = new Form2();
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
    }
}
