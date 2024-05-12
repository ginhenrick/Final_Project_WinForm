namespace FinalProject.Form
{
    partial class Form_ThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ThanhToan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblBangChu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.dgvSanPhamDaMua = new System.Windows.Forms.DataGridView();
            this.TENSANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIASANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIAMGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOTIENDAGIAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THANHTIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayMua = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.lblSoDienThoai = new DevExpress.XtraEditors.LabelControl();
            this.lblTenKhach = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThanhToanVaIn = new DevExpress.XtraEditors.SimpleButton();
            this.hoaDonDataSet = new FinalProject.HoaDonDataSet();
            this.hANGHOANHAPKHOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hANGHOANHAPKHOTableAdapter = new FinalProject.HoaDonDataSetTableAdapters.HANGHOANHAPKHOTableAdapter();
            this.tableAdapterManager = new FinalProject.HoaDonDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamDaMua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hANGHOANHAPKHOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(673, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 721);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(673, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 721);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(673, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 721);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.lblBangChu);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl20);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTongTien);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl15);
            this.splitContainerControl1.Panel1.Controls.Add(this.dgvSanPhamDaMua);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl13);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblNgayMua);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblLoaiKhachHang);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblSoDienThoai);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTenKhach);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.btnHuy);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnThanhToanVaIn);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(673, 721);
            this.splitContainerControl1.SplitterPosition = 589;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // lblBangChu
            // 
            this.lblBangChu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangChu.Appearance.Options.UseFont = true;
            this.lblBangChu.Location = new System.Drawing.Point(218, 541);
            this.lblBangChu.Name = "lblBangChu";
            this.lblBangChu.Size = new System.Drawing.Size(24, 16);
            this.lblBangChu.TabIndex = 20;
            this.lblBangChu.Text = "***";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Appearance.Options.UseFont = true;
            this.labelControl20.Location = new System.Drawing.Point(26, 541);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(159, 21);
            this.labelControl20.TabIndex = 19;
            this.labelControl20.Text = "Tổng tiền(Bằng chữ):";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Location = new System.Drawing.Point(218, 514);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(33, 21);
            this.lblTongTien.TabIndex = 15;
            this.lblTongTien.Text = "***";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(26, 514);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(76, 21);
            this.labelControl15.TabIndex = 14;
            this.labelControl15.Text = "Tổng tiền:";
            // 
            // dgvSanPhamDaMua
            // 
            this.dgvSanPhamDaMua.AllowUserToAddRows = false;
            this.dgvSanPhamDaMua.AllowUserToDeleteRows = false;
            this.dgvSanPhamDaMua.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPhamDaMua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPhamDaMua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TENSANPHAM,
            this.SOLUONG,
            this.GIASANPHAM,
            this.GIAMGIA,
            this.SOTIENDAGIAM,
            this.THANHTIEN});
            this.dgvSanPhamDaMua.Location = new System.Drawing.Point(22, 241);
            this.dgvSanPhamDaMua.Name = "dgvSanPhamDaMua";
            this.dgvSanPhamDaMua.ReadOnly = true;
            this.dgvSanPhamDaMua.RowHeadersWidth = 51;
            this.dgvSanPhamDaMua.RowTemplate.Height = 24;
            this.dgvSanPhamDaMua.Size = new System.Drawing.Size(626, 250);
            this.dgvSanPhamDaMua.TabIndex = 13;
            // 
            // TENSANPHAM
            // 
            this.TENSANPHAM.HeaderText = "Tên sản phẩm";
            this.TENSANPHAM.MinimumWidth = 6;
            this.TENSANPHAM.Name = "TENSANPHAM";
            this.TENSANPHAM.ReadOnly = true;
            this.TENSANPHAM.Width = 230;
            // 
            // SOLUONG
            // 
            this.SOLUONG.HeaderText = "Số lượng";
            this.SOLUONG.MinimumWidth = 6;
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.ReadOnly = true;
            this.SOLUONG.Width = 50;
            // 
            // GIASANPHAM
            // 
            this.GIASANPHAM.HeaderText = "Giá";
            this.GIASANPHAM.MinimumWidth = 6;
            this.GIASANPHAM.Name = "GIASANPHAM";
            this.GIASANPHAM.ReadOnly = true;
            this.GIASANPHAM.Width = 80;
            // 
            // GIAMGIA
            // 
            this.GIAMGIA.HeaderText = "Giảm Giá";
            this.GIAMGIA.MinimumWidth = 6;
            this.GIAMGIA.Name = "GIAMGIA";
            this.GIAMGIA.ReadOnly = true;
            this.GIAMGIA.Width = 50;
            // 
            // SOTIENDAGIAM
            // 
            this.SOTIENDAGIAM.HeaderText = "Số tiền đã giảm";
            this.SOTIENDAGIAM.MinimumWidth = 6;
            this.SOTIENDAGIAM.Name = "SOTIENDAGIAM";
            this.SOTIENDAGIAM.ReadOnly = true;
            this.SOTIENDAGIAM.Width = 80;
            // 
            // THANHTIEN
            // 
            this.THANHTIEN.HeaderText = "Thành tiền";
            this.THANHTIEN.MinimumWidth = 6;
            this.THANHTIEN.Name = "THANHTIEN";
            this.THANHTIEN.ReadOnly = true;
            this.THANHTIEN.Width = 80;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(22, 214);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(167, 21);
            this.labelControl13.TabIndex = 12;
            this.labelControl13.Text = "SẢN PHẨM ĐÃ MUA";
            // 
            // lblNgayMua
            // 
            this.lblNgayMua.Location = new System.Drawing.Point(547, 138);
            this.lblNgayMua.Name = "lblNgayMua";
            this.lblNgayMua.Size = new System.Drawing.Size(24, 16);
            this.lblNgayMua.TabIndex = 11;
            this.lblNgayMua.Text = "***";
            // 
            // lblLoaiKhachHang
            // 
            this.lblLoaiKhachHang.Location = new System.Drawing.Point(139, 182);
            this.lblLoaiKhachHang.Name = "lblLoaiKhachHang";
            this.lblLoaiKhachHang.Size = new System.Drawing.Size(24, 16);
            this.lblLoaiKhachHang.TabIndex = 10;
            this.lblLoaiKhachHang.Text = "***";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.Location = new System.Drawing.Point(122, 160);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(24, 16);
            this.lblSoDienThoai.TabIndex = 9;
            this.lblSoDienThoai.Text = "***";
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.Location = new System.Drawing.Point(122, 138);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(24, 16);
            this.lblTenKhach.TabIndex = 8;
            this.lblTenKhach.Text = "***";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(297, 138);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(0, 16);
            this.labelControl8.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(464, 138);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 16);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Ngày mua:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(22, 182);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(97, 16);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Loại khách hàng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(22, 160);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Số điện thoại:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 138);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Khách Hàng:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(218, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(217, 28);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "BILL THANH TOÁN";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(158, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(368, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Địa chỉ: 458/3F Nguyễn Hữu Thọ, P. Tân Hưng, Quận 7, TP.HCM";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(201, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(244, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "CTY NỘI THẤT DNC1921";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Location = new System.Drawing.Point(345, 33);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(129, 54);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThanhToanVaIn
            // 
            this.btnThanhToanVaIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThanhToanVaIn.ImageOptions.SvgImage")));
            this.btnThanhToanVaIn.Location = new System.Drawing.Point(201, 33);
            this.btnThanhToanVaIn.Name = "btnThanhToanVaIn";
            this.btnThanhToanVaIn.Size = new System.Drawing.Size(138, 54);
            this.btnThanhToanVaIn.TabIndex = 0;
            this.btnThanhToanVaIn.Text = "Thanh Toán &\r\nIn Hóa Đơn";
            this.btnThanhToanVaIn.Click += new System.EventHandler(this.btnThanhToanVaIn_Click);
            // 
            // hoaDonDataSet
            // 
            this.hoaDonDataSet.DataSetName = "HoaDonDataSet";
            this.hoaDonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hANGHOANHAPKHOBindingSource
            // 
            this.hANGHOANHAPKHOBindingSource.DataMember = "HANGHOANHAPKHO";
            this.hANGHOANHAPKHOBindingSource.DataSource = this.hoaDonDataSet;
            // 
            // hANGHOANHAPKHOTableAdapter
            // 
            this.hANGHOANHAPKHOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HANGHOANHAPKHOTableAdapter = this.hANGHOANHAPKHOTableAdapter;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.LICHSUGIAODICHTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FinalProject.HoaDonDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 721);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Form_ThanhToan.IconOptions.SvgImage")));
            this.Name = "Form_ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.Form_ThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamDaMua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hANGHOANHAPKHOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.DataGridView dgvSanPhamDaMua;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblNgayMua;
        private DevExpress.XtraEditors.LabelControl lblLoaiKhachHang;
        private DevExpress.XtraEditors.LabelControl lblSoDienThoai;
        private DevExpress.XtraEditors.LabelControl lblTenKhach;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblBangChu;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnThanhToanVaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIASANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIAMGIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOTIENDAGIAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn THANHTIEN;
        private System.Windows.Forms.BindingSource hANGHOANHAPKHOBindingSource;
        private HoaDonDataSet hoaDonDataSet;
        private HoaDonDataSetTableAdapters.HANGHOANHAPKHOTableAdapter hANGHOANHAPKHOTableAdapter;
        private HoaDonDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}