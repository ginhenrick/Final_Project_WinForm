namespace FinalProject
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.mnuDanhMuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuDMNhanVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuDMKhachHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuDMHangHoa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuHoaDonBan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuTimKiem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuFindHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuFindHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuFindKH = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuBaoCao = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuBCHangTon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuBCDoanhThu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuTroGiup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuTGLienLac = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_quyen = new System.Windows.Forms.Label();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarSubItem();
            this.btnGioiThieu = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.fluentDesignFormControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(260, 39);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(733, 548);
            this.mainContainer.TabIndex = 0;
            this.mainContainer.Click += new System.EventHandler(this.mainContainer_Click);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuDanhMuc,
            this.mnuHoaDon,
            this.mnuTimKiem,
            this.mnuBaoCao,
            this.mnuTroGiup});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 548);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuDMNhanVien,
            this.mnuDMKhachHang,
            this.mnuDMHangHoa});
            this.mnuDanhMuc.Expanded = true;
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Text = "Danh Mục";
            // 
            // mnuDMNhanVien
            // 
            this.mnuDMNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuDMNhanVien.ImageOptions.SvgImage")));
            this.mnuDMNhanVien.Name = "mnuDMNhanVien";
            this.mnuDMNhanVien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuDMNhanVien.Text = "Nhân Viên";
            this.mnuDMNhanVien.Click += new System.EventHandler(this.mnuDMNhanVien_Click);
            this.mnuDMNhanVien.VisibleChanged += new System.EventHandler(this.mnuDMNhanVien_VisibleChanged);
            // 
            // mnuDMKhachHang
            // 
            this.mnuDMKhachHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuDMKhachHang.ImageOptions.SvgImage")));
            this.mnuDMKhachHang.Name = "mnuDMKhachHang";
            this.mnuDMKhachHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuDMKhachHang.Text = "Khách Hàng";
            this.mnuDMKhachHang.Click += new System.EventHandler(this.mnuDMKhachHang_Click);
            // 
            // mnuDMHangHoa
            // 
            this.mnuDMHangHoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuDMHangHoa.ImageOptions.SvgImage")));
            this.mnuDMHangHoa.Name = "mnuDMHangHoa";
            this.mnuDMHangHoa.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuDMHangHoa.Text = "Hàng Hóa";
            this.mnuDMHangHoa.Click += new System.EventHandler(this.mnuDMHangHoa_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuHoaDonBan});
            this.mnuHoaDon.Expanded = true;
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Text = "Hóa Đơn";
            // 
            // mnuHoaDonBan
            // 
            this.mnuHoaDonBan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuHoaDonBan.ImageOptions.SvgImage")));
            this.mnuHoaDonBan.Name = "mnuHoaDonBan";
            this.mnuHoaDonBan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuHoaDonBan.Text = "Hóa Đơn Bán";
            this.mnuHoaDonBan.Click += new System.EventHandler(this.mnuHoaDonBan_Click);
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuFindHoaDon,
            this.mnuFindHang,
            this.mnuFindKH});
            this.mnuTimKiem.Expanded = true;
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Text = "Tìm Kiếm";
            // 
            // mnuFindHoaDon
            // 
            this.mnuFindHoaDon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuFindHoaDon.ImageOptions.SvgImage")));
            this.mnuFindHoaDon.Name = "mnuFindHoaDon";
            this.mnuFindHoaDon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuFindHoaDon.Text = "Hóa Đơn";
            this.mnuFindHoaDon.Click += new System.EventHandler(this.mnuFindHoaDon_Click);
            // 
            // mnuFindHang
            // 
            this.mnuFindHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuFindHang.ImageOptions.SvgImage")));
            this.mnuFindHang.Name = "mnuFindHang";
            this.mnuFindHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuFindHang.Text = "Hàng";
            this.mnuFindHang.Click += new System.EventHandler(this.mnuFindHang_Click);
            // 
            // mnuFindKH
            // 
            this.mnuFindKH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuFindKH.ImageOptions.SvgImage")));
            this.mnuFindKH.Name = "mnuFindKH";
            this.mnuFindKH.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuFindKH.Text = "Khách Hàng";
            this.mnuFindKH.Click += new System.EventHandler(this.mnuFindKH_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuBCHangTon,
            this.mnuBCDoanhThu});
            this.mnuBaoCao.Expanded = true;
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Text = "Báo Cáo";
            // 
            // mnuBCHangTon
            // 
            this.mnuBCHangTon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuBCHangTon.ImageOptions.SvgImage")));
            this.mnuBCHangTon.Name = "mnuBCHangTon";
            this.mnuBCHangTon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuBCHangTon.Text = "Hàng Tồn";
            // 
            // mnuBCDoanhThu
            // 
            this.mnuBCDoanhThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuBCDoanhThu.ImageOptions.SvgImage")));
            this.mnuBCDoanhThu.Name = "mnuBCDoanhThu";
            this.mnuBCDoanhThu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuBCDoanhThu.Text = "Doanh Thu";
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuTGLienLac});
            this.mnuTroGiup.Expanded = true;
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Text = "Trợ Giúp";
            // 
            // mnuTGLienLac
            // 
            this.mnuTGLienLac.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuTGLienLac.ImageOptions.SvgImage")));
            this.mnuTGLienLac.Name = "mnuTGLienLac";
            this.mnuTGLienLac.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuTGLienLac.Text = "Liên lạc";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Controls.Add(this.label1);
            this.fluentDesignFormControl1.Controls.Add(this.lb_quyen);
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnClose,
            this.btnGioiThieu,
            this.barListItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnDangXuat,
            this.barButtonItem6,
            this.barButtonItem7});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(993, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnDangXuat);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnClose);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnGioiThieu);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Xin Chào :";
            // 
            // lb_quyen
            // 
            this.lb_quyen.AutoSize = true;
            this.lb_quyen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_quyen.ForeColor = System.Drawing.Color.Red;
            this.lb_quyen.Location = new System.Drawing.Point(379, 9);
            this.lb_quyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_quyen.Name = "lb_quyen";
            this.lb_quyen.Size = new System.Drawing.Size(0, 22);
            this.lb_quyen.TabIndex = 5;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "Exit";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 4;
            this.btnClose.Name = "btnClose";
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnGioiThieu.Caption = "Giới thiệu";
            this.btnGioiThieu.Id = 5;
            this.btnGioiThieu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.btnGioiThieu.Name = "btnGioiThieu";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Về Chúng Tôi";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Về Chương Trình";
            this.barButtonItem4.Id = 8;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "Chúng tôi";
            this.barListItem1.Id = 6;
            this.barListItem1.Name = "barListItem1";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDangXuat.Caption = "Đăng Xuất";
            this.btnDangXuat.Id = 9;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 10;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem7.Caption = "Đăng kí";
            this.barButtonItem7.Id = 11;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnClose,
            this.btnGioiThieu,
            this.barListItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnDangXuat,
            this.barButtonItem6,
            this.barButtonItem7});
            this.fluentFormDefaultManager1.MaxItemId = 12;
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 587);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.fluentDesignFormControl1.ResumeLayout(false);
            this.fluentDesignFormControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuDanhMuc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuDMHangHoa;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuHoaDonBan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuTimKiem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuFindHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuFindHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuFindKH;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuBaoCao;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuBCHangTon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuBCDoanhThu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuTroGiup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuTGLienLac;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem btnClose;
        private DevExpress.XtraBars.BarSubItem btnGioiThieu;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lb_quyen;
        public DevExpress.XtraBars.Navigation.AccordionControlElement mnuDMNhanVien;
        public DevExpress.XtraBars.Navigation.AccordionControlElement mnuDMKhachHang;
    }
}

