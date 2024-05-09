using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
using FinalProject.UI;
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
    public partial class Form_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }
        uc_DangNhap ucDangNhap;
        

        

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            //string imagePath = @"D:\Winforms\AssignmentFinal\Project\Final_Project_WinForm\Banner.png";
            //pictureBox1.Image = Image.FromFile(imagePath);
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        internal void Show()
        {

        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            if (ucDangNhap == null)
            {
                ucDangNhap = new uc_DangNhap();
                ucDangNhap.Dock = DockStyle.Right;
                mainContainer.Controls.Add(ucDangNhap);
                ucDangNhap.BringToFront();
            }
            else
            {
                ucDangNhap.BringToFront();
            }
        }
    }
}