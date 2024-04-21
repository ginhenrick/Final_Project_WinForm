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

namespace FinalProject
{
    public partial class Form2 : Form
    {
        uc_DangNhap ucDangNhap;
        public Form2()
        {
            InitializeComponent();
        }

        private void đăngNhậpHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucDangNhap == null)
            {
                ucDangNhap = new uc_DangNhap();
                // Đặt kích thước của ucDangNhap là một phần nhỏ hơn kích thước của mainContainer
                ucDangNhap.Size = new Size(panelControl.Width / 2, panelControl.Height / 2);
                // Đặt vị trí của ucDangNhap ở giữa của mainContainer
                ucDangNhap.Location = new Point((panelControl.Width - ucDangNhap.Width) / 2, (panelControl.Height - ucDangNhap.Height) / 2);
                ucDangNhap.Dock = DockStyle.None; // Loại bỏ thuộc tính Dock
                panelControl.Controls.Add(ucDangNhap);
                ucDangNhap.BringToFront();
            }
            else
            {
                ucDangNhap.BringToFront();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string imagePath = @"D:\Winforms\AssignmentFinal\Project\luu_niem.jpg";
            pictureBox1.Image = Image.FromFile(imagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
