namespace Paint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbDrawZone = new System.Windows.Forms.PictureBox();
            this.btDrawPixel = new System.Windows.Forms.Button();
            this.btDrawArrow = new System.Windows.Forms.Button();
            this.cbWidthLine = new System.Windows.Forms.ComboBox();
            this.lbDoDay = new System.Windows.Forms.Label();
            this.cbDrawColor = new System.Windows.Forms.CheckBox();
            this.btFillColor = new System.Windows.Forms.Button();
            this.btSymmetry = new System.Windows.Forms.Button();
            this.btRotate = new System.Windows.Forms.Button();
            this.tbRotate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_drawElip = new System.Windows.Forms.Button();
            this.btn_DrawSquare = new System.Windows.Forms.Button();
            this.btn_Quay = new System.Windows.Forms.Button();
            this.btn_DoiXungOy = new System.Windows.Forms.Button();
            this.btn_DoiXungOx = new System.Windows.Forms.Button();
            this.btn_DoiXungQuaO = new System.Windows.Forms.Button();
            this.btn_drawCircle = new System.Windows.Forms.Button();
            this.btTatTiLe = new System.Windows.Forms.Button();
            this.btTatTinhTien = new System.Windows.Forms.Button();
            this.cbIsStop = new System.Windows.Forms.CheckBox();
            this.btConLacCD = new System.Windows.Forms.Button();
            this.BtXoa = new System.Windows.Forms.Button();
            this.tbTiLeY = new System.Windows.Forms.TextBox();
            this.tbTiLeX = new System.Windows.Forms.TextBox();
            this.lbTiLeY = new System.Windows.Forms.Label();
            this.lbTiLeX = new System.Windows.Forms.Label();
            this.btTiLe = new System.Windows.Forms.Button();
            this.tbTinhTienY = new System.Windows.Forms.TextBox();
            this.lbTinhTienY = new System.Windows.Forms.Label();
            this.tbTinhTienX = new System.Windows.Forms.TextBox();
            this.lbTinhTienX = new System.Windows.Forms.Label();
            this.btTinhTien = new System.Windows.Forms.Button();
            this.tbRongDay = new System.Windows.Forms.TextBox();
            this.tbChieuCao = new System.Windows.Forms.TextBox();
            this.lbRongDay = new System.Windows.Forms.Label();
            this.lbChieuCao = new System.Windows.Forms.Label();
            this.btTamGiac = new System.Windows.Forms.Button();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.btHCN = new System.Windows.Forms.Button();
            this.txtCheoB = new System.Windows.Forms.TextBox();
            this.txtCheoA = new System.Windows.Forms.TextBox();
            this.lbCheoB = new System.Windows.Forms.Label();
            this.lbCheoA = new System.Windows.Forms.Label();
            this.btHinhThoi = new System.Windows.Forms.Button();
            this.btDrawLine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPoint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDrawZone
            // 
            this.pbDrawZone.BackColor = System.Drawing.SystemColors.Control;
            this.pbDrawZone.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbDrawZone.Location = new System.Drawing.Point(406, 197);
            this.pbDrawZone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbDrawZone.Name = "pbDrawZone";
            this.pbDrawZone.Size = new System.Drawing.Size(974, 585);
            this.pbDrawZone.TabIndex = 0;
            this.pbDrawZone.TabStop = false;
            this.pbDrawZone.Click += new System.EventHandler(this.pbDrawZone_Click_1);
            this.pbDrawZone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbDrawZone_MouseClick);
            this.pbDrawZone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDrawZone_MouseDown);
            this.pbDrawZone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDrawZone_MouseMove);
            this.pbDrawZone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDrawZone_MouseUp);
            this.pbDrawZone.Resize += new System.EventHandler(this.pbDrawZone_Resize);
            // 
            // btDrawPixel
            // 
            this.btDrawPixel.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawPixel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDrawPixel.ForeColor = System.Drawing.Color.Red;
            this.btDrawPixel.Location = new System.Drawing.Point(83, 131);
            this.btDrawPixel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawPixel.Name = "btDrawPixel";
            this.btDrawPixel.Size = new System.Drawing.Size(93, 45);
            this.btDrawPixel.TabIndex = 1;
            this.btDrawPixel.Text = "Vẽ\r\n";
            this.btDrawPixel.UseVisualStyleBackColor = false;
            this.btDrawPixel.Click += new System.EventHandler(this.btLine_Click);
            // 
            // btDrawArrow
            // 
            this.btDrawArrow.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDrawArrow.ForeColor = System.Drawing.Color.Red;
            this.btDrawArrow.Location = new System.Drawing.Point(182, 131);
            this.btDrawArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawArrow.Name = "btDrawArrow";
            this.btDrawArrow.Size = new System.Drawing.Size(109, 45);
            this.btDrawArrow.TabIndex = 1;
            this.btDrawArrow.Text = "Mũi Tên";
            this.btDrawArrow.UseVisualStyleBackColor = false;
            this.btDrawArrow.Click += new System.EventHandler(this.btDrawArrow_Click);
            // 
            // cbWidthLine
            // 
            this.cbWidthLine.FormattingEnabled = true;
            this.cbWidthLine.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbWidthLine.Location = new System.Drawing.Point(97, 81);
            this.cbWidthLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbWidthLine.Name = "cbWidthLine";
            this.cbWidthLine.Size = new System.Drawing.Size(98, 28);
            this.cbWidthLine.TabIndex = 2;
            this.cbWidthLine.SelectedIndexChanged += new System.EventHandler(this.cbWidthLine_SelectedIndexChanged);
            // 
            // lbDoDay
            // 
            this.lbDoDay.AutoSize = true;
            this.lbDoDay.BackColor = System.Drawing.Color.Transparent;
            this.lbDoDay.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbDoDay.Location = new System.Drawing.Point(32, 85);
            this.lbDoDay.Name = "lbDoDay";
            this.lbDoDay.Size = new System.Drawing.Size(52, 17);
            this.lbDoDay.TabIndex = 3;
            this.lbDoDay.Text = "Kích cỡ";
            this.lbDoDay.Click += new System.EventHandler(this.lbDoDay_Click);
            // 
            // cbDrawColor
            // 
            this.cbDrawColor.AutoSize = true;
            this.cbDrawColor.Location = new System.Drawing.Point(6, 117);
            this.cbDrawColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDrawColor.Name = "cbDrawColor";
            this.cbDrawColor.Size = new System.Drawing.Size(68, 24);
            this.cbDrawColor.TabIndex = 5;
            this.cbDrawColor.Text = "Color";
            this.cbDrawColor.UseVisualStyleBackColor = true;
            this.cbDrawColor.CheckedChanged += new System.EventHandler(this.cbDrawColor_CheckedChanged);
            // 
            // btFillColor
            // 
            this.btFillColor.BackColor = System.Drawing.SystemColors.Control;
            this.btFillColor.ForeColor = System.Drawing.Color.Red;
            this.btFillColor.Location = new System.Drawing.Point(294, 99);
            this.btFillColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFillColor.Name = "btFillColor";
            this.btFillColor.Size = new System.Drawing.Size(63, 77);
            this.btFillColor.TabIndex = 6;
            this.btFillColor.Text = "Fill Color\r\n";
            this.btFillColor.UseVisualStyleBackColor = false;
            this.btFillColor.Click += new System.EventHandler(this.btFillColor_Click);
            // 
            // btSymmetry
            // 
            this.btSymmetry.BackColor = System.Drawing.SystemColors.Control;
            this.btSymmetry.ForeColor = System.Drawing.Color.Red;
            this.btSymmetry.Location = new System.Drawing.Point(30, 27);
            this.btSymmetry.Name = "btSymmetry";
            this.btSymmetry.Size = new System.Drawing.Size(463, 39);
            this.btSymmetry.TabIndex = 12;
            this.btSymmetry.Text = "Đối xứng";
            this.btSymmetry.UseVisualStyleBackColor = false;
            this.btSymmetry.Click += new System.EventHandler(this.btSymmetry_Click);
            // 
            // btRotate
            // 
            this.btRotate.BackColor = System.Drawing.SystemColors.Control;
            this.btRotate.ForeColor = System.Drawing.Color.Red;
            this.btRotate.Location = new System.Drawing.Point(133, 28);
            this.btRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btRotate.Name = "btRotate";
            this.btRotate.Size = new System.Drawing.Size(95, 37);
            this.btRotate.TabIndex = 10;
            this.btRotate.Text = "Xoay";
            this.btRotate.UseVisualStyleBackColor = false;
            this.btRotate.Click += new System.EventHandler(this.btRotate_Click);
            // 
            // tbRotate
            // 
            this.tbRotate.Location = new System.Drawing.Point(133, 77);
            this.tbRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Size = new System.Drawing.Size(95, 27);
            this.tbRotate.TabIndex = 11;
            this.tbRotate.TextChanged += new System.EventHandler(this.tbRotate_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.buttonX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 60);
            this.panel1.TabIndex = 41;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonX
            // 
            this.buttonX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.ForeColor = System.Drawing.Color.Red;
            this.buttonX.Location = new System.Drawing.Point(1319, 0);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(61, 60);
            this.buttonX.TabIndex = 2;
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(912, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 1;
            this.label2.Visible = false;
            // 
            // btn_drawElip
            // 
            this.btn_drawElip.BackColor = System.Drawing.SystemColors.Control;
            this.btn_drawElip.Location = new System.Drawing.Point(232, 80);
            this.btn_drawElip.Name = "btn_drawElip";
            this.btn_drawElip.Size = new System.Drawing.Size(107, 48);
            this.btn_drawElip.TabIndex = 21;
            this.btn_drawElip.Text = "Hình Elip";
            this.btn_drawElip.UseVisualStyleBackColor = false;
            this.btn_drawElip.Click += new System.EventHandler(this.btn_drawElip_Click);
            // 
            // btn_DrawSquare
            // 
            this.btn_DrawSquare.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DrawSquare.Location = new System.Drawing.Point(6, 80);
            this.btn_DrawSquare.Name = "btn_DrawSquare";
            this.btn_DrawSquare.Size = new System.Drawing.Size(107, 49);
            this.btn_DrawSquare.TabIndex = 20;
            this.btn_DrawSquare.Text = "hình vuông";
            this.btn_DrawSquare.UseVisualStyleBackColor = false;
            this.btn_DrawSquare.Click += new System.EventHandler(this.btn_DrawSquare_Click);
            // 
            // btn_Quay
            // 
            this.btn_Quay.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Quay.ForeColor = System.Drawing.Color.Red;
            this.btn_Quay.Location = new System.Drawing.Point(24, 27);
            this.btn_Quay.Name = "btn_Quay";
            this.btn_Quay.Size = new System.Drawing.Size(103, 77);
            this.btn_Quay.TabIndex = 19;
            this.btn_Quay.Text = "Quay 60°";
            this.btn_Quay.UseVisualStyleBackColor = false;
            this.btn_Quay.Click += new System.EventHandler(this.btn_Quay_Click);
            // 
            // btn_DoiXungOy
            // 
            this.btn_DoiXungOy.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DoiXungOy.ForeColor = System.Drawing.Color.Red;
            this.btn_DoiXungOy.Location = new System.Drawing.Point(197, 73);
            this.btn_DoiXungOy.Name = "btn_DoiXungOy";
            this.btn_DoiXungOy.Size = new System.Drawing.Size(128, 53);
            this.btn_DoiXungOy.TabIndex = 18;
            this.btn_DoiXungOy.Text = "đối xứng qua Oy";
            this.btn_DoiXungOy.UseVisualStyleBackColor = false;
            this.btn_DoiXungOy.Click += new System.EventHandler(this.btn_DoiXungOy_Click);
            // 
            // btn_DoiXungOx
            // 
            this.btn_DoiXungOx.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DoiXungOx.ForeColor = System.Drawing.Color.Red;
            this.btn_DoiXungOx.Location = new System.Drawing.Point(30, 71);
            this.btn_DoiXungOx.Name = "btn_DoiXungOx";
            this.btn_DoiXungOx.Size = new System.Drawing.Size(128, 53);
            this.btn_DoiXungOx.TabIndex = 17;
            this.btn_DoiXungOx.Text = "đối xứng qua Ox";
            this.btn_DoiXungOx.UseVisualStyleBackColor = false;
            this.btn_DoiXungOx.Click += new System.EventHandler(this.btn_DoiXungOx_Click);
            // 
            // btn_DoiXungQuaO
            // 
            this.btn_DoiXungQuaO.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DoiXungQuaO.ForeColor = System.Drawing.Color.Red;
            this.btn_DoiXungQuaO.Location = new System.Drawing.Point(353, 73);
            this.btn_DoiXungQuaO.Name = "btn_DoiXungQuaO";
            this.btn_DoiXungQuaO.Size = new System.Drawing.Size(139, 52);
            this.btn_DoiXungQuaO.TabIndex = 16;
            this.btn_DoiXungQuaO.Text = "đối xứng qua O(0,0)";
            this.btn_DoiXungQuaO.UseVisualStyleBackColor = false;
            this.btn_DoiXungQuaO.Click += new System.EventHandler(this.btn_DoiXungQuaO_Click);
            // 
            // btn_drawCircle
            // 
            this.btn_drawCircle.BackColor = System.Drawing.SystemColors.Control;
            this.btn_drawCircle.Location = new System.Drawing.Point(120, 80);
            this.btn_drawCircle.Name = "btn_drawCircle";
            this.btn_drawCircle.Size = new System.Drawing.Size(106, 48);
            this.btn_drawCircle.TabIndex = 13;
            this.btn_drawCircle.Text = "Hình Tròn";
            this.btn_drawCircle.UseVisualStyleBackColor = false;
            this.btn_drawCircle.Click += new System.EventHandler(this.btn_drawCircle_Click);
            // 
            // btTatTiLe
            // 
            this.btTatTiLe.ForeColor = System.Drawing.Color.Red;
            this.btTatTiLe.Location = new System.Drawing.Point(427, 69);
            this.btTatTiLe.Name = "btTatTiLe";
            this.btTatTiLe.Size = new System.Drawing.Size(31, 29);
            this.btTatTiLe.TabIndex = 41;
            this.btTatTiLe.Text = "X";
            this.btTatTiLe.UseVisualStyleBackColor = true;
            this.btTatTiLe.Visible = false;
            this.btTatTiLe.Click += new System.EventHandler(this.btTatTiLe_Click);
            // 
            // btTatTinhTien
            // 
            this.btTatTinhTien.ForeColor = System.Drawing.Color.Red;
            this.btTatTinhTien.Location = new System.Drawing.Point(176, 72);
            this.btTatTinhTien.Name = "btTatTinhTien";
            this.btTatTinhTien.Size = new System.Drawing.Size(37, 29);
            this.btTatTinhTien.TabIndex = 40;
            this.btTatTinhTien.Text = "X";
            this.btTatTinhTien.UseVisualStyleBackColor = true;
            this.btTatTinhTien.Visible = false;
            this.btTatTinhTien.Click += new System.EventHandler(this.btTatTinhTien_Click);
            // 
            // cbIsStop
            // 
            this.cbIsStop.AutoSize = true;
            this.cbIsStop.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbIsStop.Location = new System.Drawing.Point(208, 79);
            this.cbIsStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbIsStop.Name = "cbIsStop";
            this.cbIsStop.Size = new System.Drawing.Size(73, 29);
            this.cbIsStop.TabIndex = 13;
            this.cbIsStop.Text = "Stop";
            this.cbIsStop.UseVisualStyleBackColor = true;
            this.cbIsStop.Visible = false;
            // 
            // btConLacCD
            // 
            this.btConLacCD.BackColor = System.Drawing.SystemColors.Control;
            this.btConLacCD.Location = new System.Drawing.Point(85, 27);
            this.btConLacCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConLacCD.Name = "btConLacCD";
            this.btConLacCD.Size = new System.Drawing.Size(235, 36);
            this.btConLacCD.TabIndex = 13;
            this.btConLacCD.Text = "Vẽ đồng hồ";
            this.btConLacCD.UseVisualStyleBackColor = false;
            this.btConLacCD.Click += new System.EventHandler(this.btConLacCD_Click);
            // 
            // BtXoa
            // 
            this.BtXoa.BackColor = System.Drawing.Color.Transparent;
            this.BtXoa.BackgroundImage = global::Paint.Properties.Resources.delete;
            this.BtXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtXoa.Location = new System.Drawing.Point(306, 712);
            this.BtXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtXoa.Name = "BtXoa";
            this.BtXoa.Size = new System.Drawing.Size(79, 71);
            this.BtXoa.TabIndex = 39;
            this.BtXoa.UseVisualStyleBackColor = false;
            this.BtXoa.Click += new System.EventHandler(this.BtXoa_Click);
            // 
            // tbTiLeY
            // 
            this.tbTiLeY.Location = new System.Drawing.Point(373, 71);
            this.tbTiLeY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTiLeY.Name = "tbTiLeY";
            this.tbTiLeY.Size = new System.Drawing.Size(34, 27);
            this.tbTiLeY.TabIndex = 38;
            this.tbTiLeY.Visible = false;
            // 
            // tbTiLeX
            // 
            this.tbTiLeX.Location = new System.Drawing.Point(297, 72);
            this.tbTiLeX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTiLeX.Name = "tbTiLeX";
            this.tbTiLeX.Size = new System.Drawing.Size(34, 27);
            this.tbTiLeX.TabIndex = 37;
            this.tbTiLeX.Visible = false;
            // 
            // lbTiLeY
            // 
            this.lbTiLeY.AutoSize = true;
            this.lbTiLeY.ForeColor = System.Drawing.Color.Red;
            this.lbTiLeY.Location = new System.Drawing.Point(341, 71);
            this.lbTiLeY.Name = "lbTiLeY";
            this.lbTiLeY.Size = new System.Drawing.Size(22, 20);
            this.lbTiLeY.TabIndex = 36;
            this.lbTiLeY.Text = "Y:";
            this.lbTiLeY.Visible = false;
            // 
            // lbTiLeX
            // 
            this.lbTiLeX.AutoSize = true;
            this.lbTiLeX.ForeColor = System.Drawing.Color.Red;
            this.lbTiLeX.Location = new System.Drawing.Point(267, 72);
            this.lbTiLeX.Name = "lbTiLeX";
            this.lbTiLeX.Size = new System.Drawing.Size(23, 20);
            this.lbTiLeX.TabIndex = 35;
            this.lbTiLeX.Text = "X:";
            this.lbTiLeX.Visible = false;
            // 
            // btTiLe
            // 
            this.btTiLe.BackColor = System.Drawing.SystemColors.Control;
            this.btTiLe.ForeColor = System.Drawing.Color.Red;
            this.btTiLe.Location = new System.Drawing.Point(259, 28);
            this.btTiLe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTiLe.Name = "btTiLe";
            this.btTiLe.Size = new System.Drawing.Size(216, 39);
            this.btTiLe.TabIndex = 34;
            this.btTiLe.Text = "Tỉ lệ:";
            this.btTiLe.UseVisualStyleBackColor = false;
            this.btTiLe.Click += new System.EventHandler(this.btTiLe_Click);
            // 
            // tbTinhTienY
            // 
            this.tbTinhTienY.Location = new System.Drawing.Point(120, 73);
            this.tbTinhTienY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTinhTienY.Name = "tbTinhTienY";
            this.tbTinhTienY.Size = new System.Drawing.Size(33, 27);
            this.tbTinhTienY.TabIndex = 33;
            this.tbTinhTienY.Visible = false;
            // 
            // lbTinhTienY
            // 
            this.lbTinhTienY.AutoSize = true;
            this.lbTinhTienY.ForeColor = System.Drawing.Color.Red;
            this.lbTinhTienY.Location = new System.Drawing.Point(96, 73);
            this.lbTinhTienY.Name = "lbTinhTienY";
            this.lbTinhTienY.Size = new System.Drawing.Size(22, 20);
            this.lbTinhTienY.TabIndex = 32;
            this.lbTinhTienY.Text = "Y:";
            this.lbTinhTienY.Visible = false;
            // 
            // tbTinhTienX
            // 
            this.tbTinhTienX.Location = new System.Drawing.Point(43, 75);
            this.tbTinhTienX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTinhTienX.Name = "tbTinhTienX";
            this.tbTinhTienX.Size = new System.Drawing.Size(33, 27);
            this.tbTinhTienX.TabIndex = 31;
            this.tbTinhTienX.Visible = false;
            // 
            // lbTinhTienX
            // 
            this.lbTinhTienX.AutoSize = true;
            this.lbTinhTienX.ForeColor = System.Drawing.Color.Red;
            this.lbTinhTienX.Location = new System.Drawing.Point(18, 75);
            this.lbTinhTienX.Name = "lbTinhTienX";
            this.lbTinhTienX.Size = new System.Drawing.Size(23, 20);
            this.lbTinhTienX.TabIndex = 30;
            this.lbTinhTienX.Text = "X:";
            this.lbTinhTienX.Visible = false;
            // 
            // btTinhTien
            // 
            this.btTinhTien.BackColor = System.Drawing.SystemColors.Control;
            this.btTinhTien.ForeColor = System.Drawing.Color.Red;
            this.btTinhTien.Location = new System.Drawing.Point(9, 27);
            this.btTinhTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTinhTien.Name = "btTinhTien";
            this.btTinhTien.Size = new System.Drawing.Size(217, 39);
            this.btTinhTien.TabIndex = 29;
            this.btTinhTien.Text = "Tịnh tiến";
            this.btTinhTien.UseVisualStyleBackColor = false;
            this.btTinhTien.Click += new System.EventHandler(this.btTinhTien_Click);
            // 
            // tbRongDay
            // 
            this.tbRongDay.Location = new System.Drawing.Point(43, 235);
            this.tbRongDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRongDay.Name = "tbRongDay";
            this.tbRongDay.Size = new System.Drawing.Size(49, 27);
            this.tbRongDay.TabIndex = 28;
            this.tbRongDay.Visible = false;
            this.tbRongDay.TextChanged += new System.EventHandler(this.tbRongDay_TextChanged);
            // 
            // tbChieuCao
            // 
            this.tbChieuCao.Location = new System.Drawing.Point(43, 199);
            this.tbChieuCao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbChieuCao.Name = "tbChieuCao";
            this.tbChieuCao.Size = new System.Drawing.Size(49, 27);
            this.tbChieuCao.TabIndex = 27;
            this.tbChieuCao.Visible = false;
            this.tbChieuCao.TextChanged += new System.EventHandler(this.tbChieuCao_TextChanged);
            // 
            // lbRongDay
            // 
            this.lbRongDay.AutoSize = true;
            this.lbRongDay.Location = new System.Drawing.Point(5, 237);
            this.lbRongDay.Name = "lbRongDay";
            this.lbRongDay.Size = new System.Drawing.Size(38, 20);
            this.lbRongDay.TabIndex = 26;
            this.lbRongDay.Text = "đáy:";
            this.lbRongDay.Visible = false;
            this.lbRongDay.Click += new System.EventHandler(this.lbRongDay_Click);
            // 
            // lbChieuCao
            // 
            this.lbChieuCao.AutoSize = true;
            this.lbChieuCao.Location = new System.Drawing.Point(6, 203);
            this.lbChieuCao.Name = "lbChieuCao";
            this.lbChieuCao.Size = new System.Drawing.Size(37, 20);
            this.lbChieuCao.TabIndex = 25;
            this.lbChieuCao.Text = "cao:";
            this.lbChieuCao.Visible = false;
            this.lbChieuCao.Click += new System.EventHandler(this.lbChieuCao_Click);
            // 
            // btTamGiac
            // 
            this.btTamGiac.BackColor = System.Drawing.SystemColors.Control;
            this.btTamGiac.Location = new System.Drawing.Point(6, 136);
            this.btTamGiac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTamGiac.Name = "btTamGiac";
            this.btTamGiac.Size = new System.Drawing.Size(95, 49);
            this.btTamGiac.TabIndex = 24;
            this.btTamGiac.Text = "Tam giác";
            this.btTamGiac.UseVisualStyleBackColor = false;
            this.btTamGiac.Click += new System.EventHandler(this.btTamGiac_Click);
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(287, 237);
            this.tbHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(44, 27);
            this.tbHeight.TabIndex = 23;
            this.tbHeight.Visible = false;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(287, 197);
            this.tbWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(44, 27);
            this.tbWidth.TabIndex = 22;
            this.tbWidth.Visible = false;
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(231, 243);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(50, 20);
            this.lbHeight.TabIndex = 21;
            this.lbHeight.Text = "Rộng:";
            this.lbHeight.Visible = false;
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(231, 203);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(36, 20);
            this.lbWidth.TabIndex = 20;
            this.lbWidth.Text = "Dài:";
            this.lbWidth.Visible = false;
            // 
            // btHCN
            // 
            this.btHCN.BackColor = System.Drawing.SystemColors.Control;
            this.btHCN.Location = new System.Drawing.Point(231, 136);
            this.btHCN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btHCN.Name = "btHCN";
            this.btHCN.Size = new System.Drawing.Size(109, 49);
            this.btHCN.TabIndex = 19;
            this.btHCN.Text = "HCN";
            this.btHCN.UseVisualStyleBackColor = false;
            this.btHCN.Click += new System.EventHandler(this.btHCN_Click);
            // 
            // txtCheoB
            // 
            this.txtCheoB.Location = new System.Drawing.Point(181, 235);
            this.txtCheoB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheoB.Name = "txtCheoB";
            this.txtCheoB.Size = new System.Drawing.Size(42, 27);
            this.txtCheoB.TabIndex = 18;
            this.txtCheoB.Visible = false;
            this.txtCheoB.TextChanged += new System.EventHandler(this.txtCheoB_TextChanged);
            // 
            // txtCheoA
            // 
            this.txtCheoA.Location = new System.Drawing.Point(181, 197);
            this.txtCheoA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheoA.Name = "txtCheoA";
            this.txtCheoA.Size = new System.Drawing.Size(42, 27);
            this.txtCheoA.TabIndex = 17;
            this.txtCheoA.Visible = false;
            this.txtCheoA.TextChanged += new System.EventHandler(this.txtCheoA_TextChanged);
            // 
            // lbCheoB
            // 
            this.lbCheoB.AutoSize = true;
            this.lbCheoB.Location = new System.Drawing.Point(113, 237);
            this.lbCheoB.Name = "lbCheoB";
            this.lbCheoB.Size = new System.Drawing.Size(61, 20);
            this.lbCheoB.TabIndex = 16;
            this.lbCheoB.Text = "Chéo b:";
            this.lbCheoB.Visible = false;
            this.lbCheoB.Click += new System.EventHandler(this.lbCheoB_Click);
            // 
            // lbCheoA
            // 
            this.lbCheoA.AutoSize = true;
            this.lbCheoA.Location = new System.Drawing.Point(114, 203);
            this.lbCheoA.Name = "lbCheoA";
            this.lbCheoA.Size = new System.Drawing.Size(60, 20);
            this.lbCheoA.TabIndex = 15;
            this.lbCheoA.Text = "Chéo a:";
            this.lbCheoA.Visible = false;
            this.lbCheoA.Click += new System.EventHandler(this.lbCheoA_Click);
            // 
            // btHinhThoi
            // 
            this.btHinhThoi.BackColor = System.Drawing.SystemColors.Control;
            this.btHinhThoi.Location = new System.Drawing.Point(107, 136);
            this.btHinhThoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btHinhThoi.Name = "btHinhThoi";
            this.btHinhThoi.Size = new System.Drawing.Size(117, 49);
            this.btHinhThoi.TabIndex = 14;
            this.btHinhThoi.Text = "Hình thoi";
            this.btHinhThoi.UseVisualStyleBackColor = false;
            this.btHinhThoi.Click += new System.EventHandler(this.btHinhThoi_Click);
            // 
            // btDrawLine
            // 
            this.btDrawLine.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawLine.Location = new System.Drawing.Point(6, 27);
            this.btDrawLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawLine.Name = "btDrawLine";
            this.btDrawLine.Size = new System.Drawing.Size(334, 45);
            this.btDrawLine.TabIndex = 13;
            this.btDrawLine.Text = "Đường thẳng";
            this.btDrawLine.UseVisualStyleBackColor = false;
            this.btDrawLine.Click += new System.EventHandler(this.btDrawLine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btn_DrawSquare);
            this.groupBox1.Controls.Add(this.btn_drawElip);
            this.groupBox1.Controls.Add(this.btTamGiac);
            this.groupBox1.Controls.Add(this.tbRongDay);
            this.groupBox1.Controls.Add(this.lbChieuCao);
            this.groupBox1.Controls.Add(this.lbRongDay);
            this.groupBox1.Controls.Add(this.tbChieuCao);
            this.groupBox1.Controls.Add(this.btHinhThoi);
            this.groupBox1.Controls.Add(this.lbCheoA);
            this.groupBox1.Controls.Add(this.lbCheoB);
            this.groupBox1.Controls.Add(this.txtCheoA);
            this.groupBox1.Controls.Add(this.txtCheoB);
            this.groupBox1.Controls.Add(this.btDrawLine);
            this.groupBox1.Controls.Add(this.btHCN);
            this.groupBox1.Controls.Add(this.btn_drawCircle);
            this.groupBox1.Controls.Add(this.lbWidth);
            this.groupBox1.Controls.Add(this.lbHeight);
            this.groupBox1.Controls.Add(this.tbWidth);
            this.groupBox1.Controls.Add(this.tbHeight);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(25, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 285);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hình 2D";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.cbColor);
            this.groupBox2.Controls.Add(this.btFillColor);
            this.groupBox2.Controls.Add(this.btConLacCD);
            this.groupBox2.Controls.Add(this.lbDoDay);
            this.groupBox2.Controls.Add(this.cbDrawColor);
            this.groupBox2.Controls.Add(this.cbWidthLine);
            this.groupBox2.Controls.Add(this.btDrawArrow);
            this.groupBox2.Controls.Add(this.cbIsStop);
            this.groupBox2.Controls.Add(this.btDrawPixel);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(25, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "                 Đồng Hồ Quả Lắc";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Black",
            "Green",
            "Blue",
            "Red",
            "Yellow",
            "Orange",
            "Brown"});
            this.cbColor.Location = new System.Drawing.Point(0, 140);
            this.cbColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(82, 28);
            this.cbColor.TabIndex = 42;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.btTinhTien);
            this.groupBox3.Controls.Add(this.lbTinhTienX);
            this.groupBox3.Controls.Add(this.tbTinhTienX);
            this.groupBox3.Controls.Add(this.lbTinhTienY);
            this.groupBox3.Controls.Add(this.tbTinhTienY);
            this.groupBox3.Controls.Add(this.btTatTiLe);
            this.groupBox3.Controls.Add(this.btTatTinhTien);
            this.groupBox3.Controls.Add(this.btTiLe);
            this.groupBox3.Controls.Add(this.lbTiLeX);
            this.groupBox3.Controls.Add(this.tbTiLeY);
            this.groupBox3.Controls.Add(this.tbTiLeX);
            this.groupBox3.Controls.Add(this.lbTiLeY);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(25, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 125);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phép Dịch";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.btSymmetry);
            this.groupBox5.Controls.Add(this.btn_DoiXungOx);
            this.groupBox5.Controls.Add(this.btn_DoiXungQuaO);
            this.groupBox5.Controls.Add(this.btn_DoiXungOy);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(869, 67);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(512, 125);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Phép Đối Xứng";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.btn_Quay);
            this.groupBox4.Controls.Add(this.tbRotate);
            this.groupBox4.Controls.Add(this.btRotate);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(571, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 125);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phép Xoay";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lbPoint);
            this.panel2.Location = new System.Drawing.Point(25, 712);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 70);
            this.panel2.TabIndex = 42;
            // 
            // lbPoint
            // 
            this.lbPoint.AutoSize = true;
            this.lbPoint.Location = new System.Drawing.Point(9, 9);
            this.lbPoint.Name = "lbPoint";
            this.lbPoint.Size = new System.Drawing.Size(50, 20);
            this.lbPoint.TabIndex = 0;
            this.lbPoint.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbDrawZone);
            this.Controls.Add(this.BtXoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDrawZone;
        private System.Windows.Forms.Button btDrawPixel;
        private System.Windows.Forms.Button btDrawArrow;
        private System.Windows.Forms.ComboBox cbWidthLine;
        private System.Windows.Forms.Label lbDoDay;
        private System.Windows.Forms.CheckBox cbDrawColor;
        private System.Windows.Forms.Button btFillColor;

        //private System.Windows.Forms.Button btRotate;
        //private System.Windows.Forms.TextBox tbRotate;

        //private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btSymmetry;


        //private System.Windows.Forms.Panel panel1;

        //private System.Windows.Forms.Button bt3D;
        //private System.Windows.Forms.Button button2;


        private System.Windows.Forms.Button btn_drawCircle;
        private System.Windows.Forms.Button btn_DoiXungQuaO;
        private System.Windows.Forms.Button btn_DoiXungOx;
        private System.Windows.Forms.Button btn_DoiXungOy;
        private System.Windows.Forms.Button btn_DrawSquare;
        private System.Windows.Forms.Button btn_drawElip;

        private System.Windows.Forms.Button btConLacCD;
        private System.Windows.Forms.CheckBox cbIsStop;
        private System.Windows.Forms.Button btDrawLine;
        private System.Windows.Forms.TextBox txtCheoB;
        private System.Windows.Forms.TextBox txtCheoA;
        private System.Windows.Forms.Label lbCheoB;
        private System.Windows.Forms.Label lbCheoA;
        private System.Windows.Forms.Button btHinhThoi;
        private System.Windows.Forms.Button btHCN;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Button btTamGiac;
        private System.Windows.Forms.TextBox tbRongDay;
        private System.Windows.Forms.TextBox tbChieuCao;
        private System.Windows.Forms.Label lbRongDay;
        private System.Windows.Forms.Label lbChieuCao;
        private System.Windows.Forms.Button btTinhTien;
        private System.Windows.Forms.TextBox tbTinhTienY;
        private System.Windows.Forms.Label lbTinhTienY;
        private System.Windows.Forms.TextBox tbTinhTienX;
        private System.Windows.Forms.Label lbTinhTienX;
        private System.Windows.Forms.TextBox tbTiLeY;
        private System.Windows.Forms.TextBox tbTiLeX;
        private System.Windows.Forms.Label lbTiLeY;
        private System.Windows.Forms.Label lbTiLeX;
        private System.Windows.Forms.Button btTiLe;
        private System.Windows.Forms.Button BtXoa;
        private System.Windows.Forms.Button btTatTiLe;
        private System.Windows.Forms.Button btTatTinhTien;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Quay;
        private System.Windows.Forms.TextBox tbRotate;
        private System.Windows.Forms.Button btRotate;
        private System.Windows.Forms.Panel panel1;
        private ElipseControl elipseControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPoint;
    }
}

