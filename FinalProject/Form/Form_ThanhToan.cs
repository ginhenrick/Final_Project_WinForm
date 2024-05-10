using DevExpress.XtraEditors;
using FinalProject.UI;
using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Form
{
    public partial class Form_ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public string TenKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiKhachHang { get; set; }
        public string NgayMua { get; set; }
        public string TongTien { get; set; }
        public string BangChu { get; set; }


        public Form_ThanhToan()
        {   
            InitializeComponent();

        }

        private void Form_ThanhToan_Load(object sender, EventArgs e)
        {
            lblTenKhach.Text = TenKhach;
            lblSoDienThoai.Text = SoDienThoai;
            lblLoaiKhachHang.Text = LoaiKhachHang;
            lblNgayMua.Text = NgayMua;
            lblTongTien.Text = TongTien;
            lblBangChu.Text = BangChu;

        }
    
    }
}