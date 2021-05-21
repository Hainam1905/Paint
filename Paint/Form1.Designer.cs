﻿namespace Paint
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbDrawColor = new System.Windows.Forms.CheckBox();
            this.btFillColor = new System.Windows.Forms.Button();
            this.btRotate = new System.Windows.Forms.Button();
            this.tbRotate = new System.Windows.Forms.TextBox();
            this.btSymmetry = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.bt3D = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDrawZone
            // 
            this.pbDrawZone.BackColor = System.Drawing.SystemColors.Control;
            this.pbDrawZone.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbDrawZone.Location = new System.Drawing.Point(1, 162);
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
            this.btDrawPixel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btDrawPixel.Location = new System.Drawing.Point(1, 0);
            this.btDrawPixel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawPixel.Name = "btDrawPixel";
            this.btDrawPixel.Size = new System.Drawing.Size(86, 33);
            this.btDrawPixel.TabIndex = 1;
            this.btDrawPixel.Text = "Draw Pixel";
            this.btDrawPixel.UseVisualStyleBackColor = false;
            this.btDrawPixel.Click += new System.EventHandler(this.btLine_Click);
            // 
            // btDrawArrow
            // 
            this.btDrawArrow.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDrawArrow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btDrawArrow.Location = new System.Drawing.Point(93, 1);
            this.btDrawArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawArrow.Name = "btDrawArrow";
            this.btDrawArrow.Size = new System.Drawing.Size(89, 53);
            this.btDrawArrow.TabIndex = 1;
            this.btDrawArrow.Text = "Draw Arrow";
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
            this.cbWidthLine.Location = new System.Drawing.Point(36, 50);
            this.cbWidthLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbWidthLine.Name = "cbWidthLine";
            this.cbWidthLine.Size = new System.Drawing.Size(44, 28);
            this.cbWidthLine.TabIndex = 2;
            this.cbWidthLine.SelectedIndexChanged += new System.EventHandler(this.cbWidthLine_SelectedIndexChanged);
            // 
            // lbDoDay
            // 
            this.lbDoDay.AutoSize = true;
            this.lbDoDay.BackColor = System.Drawing.SystemColors.Control;
            this.lbDoDay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDoDay.Location = new System.Drawing.Point(1, 48);
            this.lbDoDay.Name = "lbDoDay";
            this.lbDoDay.Size = new System.Drawing.Size(31, 38);
            this.lbDoDay.TabIndex = 3;
            this.lbDoDay.Text = "Độ\r\ndày";
            this.lbDoDay.Click += new System.EventHandler(this.lbDoDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(913, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // cbDrawColor
            // 
            this.cbDrawColor.AutoSize = true;
            this.cbDrawColor.Location = new System.Drawing.Point(17, 89);
            this.cbDrawColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDrawColor.Name = "cbDrawColor";
            this.cbDrawColor.Size = new System.Drawing.Size(67, 24);
            this.cbDrawColor.TabIndex = 5;
            this.cbDrawColor.Text = "Color";
            this.cbDrawColor.UseVisualStyleBackColor = true;
            this.cbDrawColor.CheckedChanged += new System.EventHandler(this.cbDrawColor_CheckedChanged);
            // 
            // btFillColor
            // 
            this.btFillColor.BackColor = System.Drawing.SystemColors.Control;
            this.btFillColor.Location = new System.Drawing.Point(188, 0);
            this.btFillColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFillColor.Name = "btFillColor";
            this.btFillColor.Size = new System.Drawing.Size(86, 60);
            this.btFillColor.TabIndex = 6;
            this.btFillColor.Text = "Fill Color\r\n(Red)";
            this.btFillColor.UseVisualStyleBackColor = false;
            this.btFillColor.Click += new System.EventHandler(this.btFillColor_Click);
            // 
            // btRotate
            // 
            this.btRotate.BackColor = System.Drawing.SystemColors.Control;
            this.btRotate.Location = new System.Drawing.Point(805, 0);
            this.btRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btRotate.Name = "btRotate";
            this.btRotate.Size = new System.Drawing.Size(65, 33);
            this.btRotate.TabIndex = 10;
            this.btRotate.Text = "Xoay";
            this.btRotate.UseVisualStyleBackColor = false;
            this.btRotate.Click += new System.EventHandler(this.btRotate_Click);
            // 
            // tbRotate
            // 
            this.tbRotate.Location = new System.Drawing.Point(805, 33);
            this.tbRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Size = new System.Drawing.Size(66, 27);
            this.tbRotate.TabIndex = 11;
            this.tbRotate.TextChanged += new System.EventHandler(this.tbRotate_TextChanged);
            // 
            // btSymmetry
            // 
            this.btSymmetry.BackColor = System.Drawing.SystemColors.Control;
            this.btSymmetry.Location = new System.Drawing.Point(805, 69);
            this.btSymmetry.Name = "btSymmetry";
            this.btSymmetry.Size = new System.Drawing.Size(81, 43);
            this.btSymmetry.TabIndex = 12;
            this.btSymmetry.Text = "Đối xứng";
            this.btSymmetry.UseVisualStyleBackColor = false;
            this.btSymmetry.Click += new System.EventHandler(this.btSymmetry_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbRotate);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lbDoDay);
            this.panel1.Controls.Add(this.cbDrawColor);
            this.panel1.Controls.Add(this.btRotate);
            this.panel1.Controls.Add(this.cbWidthLine);
            this.panel1.Controls.Add(this.bt3D);
            this.panel1.Controls.Add(this.btFillColor);
            this.panel1.Controls.Add(this.btn_drawElip);
            this.panel1.Controls.Add(this.btn_DrawSquare);
            this.panel1.Controls.Add(this.btn_Quay);
            this.panel1.Controls.Add(this.btn_DoiXungOy);
            this.panel1.Controls.Add(this.btDrawArrow);
            this.panel1.Controls.Add(this.btn_DoiXungOx);
            this.panel1.Controls.Add(this.btDrawPixel);
            this.panel1.Controls.Add(this.btn_DoiXungQuaO);
            this.panel1.Controls.Add(this.btn_drawCircle);
            this.panel1.Controls.Add(this.btTatTiLe);
            this.panel1.Controls.Add(this.btTatTinhTien);
            this.panel1.Controls.Add(this.cbIsStop);
            this.panel1.Controls.Add(this.btConLacCD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btSymmetry);
            this.panel1.Controls.Add(this.BtXoa);
            this.panel1.Controls.Add(this.tbTiLeY);
            this.panel1.Controls.Add(this.tbTiLeX);
            this.panel1.Controls.Add(this.lbTiLeY);
            this.panel1.Controls.Add(this.lbTiLeX);
            this.panel1.Controls.Add(this.btTiLe);
            this.panel1.Controls.Add(this.tbTinhTienY);
            this.panel1.Controls.Add(this.lbTinhTienY);
            this.panel1.Controls.Add(this.tbTinhTienX);
            this.panel1.Controls.Add(this.lbTinhTienX);
            this.panel1.Controls.Add(this.btTinhTien);
            this.panel1.Controls.Add(this.tbRongDay);
            this.panel1.Controls.Add(this.tbChieuCao);
            this.panel1.Controls.Add(this.lbRongDay);
            this.panel1.Controls.Add(this.lbChieuCao);
            this.panel1.Controls.Add(this.btTamGiac);
            this.panel1.Controls.Add(this.tbHeight);
            this.panel1.Controls.Add(this.tbWidth);
            this.panel1.Controls.Add(this.lbHeight);
            this.panel1.Controls.Add(this.lbWidth);
            this.panel1.Controls.Add(this.btHCN);
            this.panel1.Controls.Add(this.txtCheoB);
            this.panel1.Controls.Add(this.txtCheoA);
            this.panel1.Controls.Add(this.lbCheoB);
            this.panel1.Controls.Add(this.lbCheoA);
            this.panel1.Controls.Add(this.btHinhThoi);
            this.panel1.Controls.Add(this.btDrawLine);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 161);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Xe chạy giữa đồi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt3D
            // 
            this.bt3D.Location = new System.Drawing.Point(151, 132);
            this.bt3D.Name = "bt3D";
            this.bt3D.Size = new System.Drawing.Size(94, 29);
            this.bt3D.TabIndex = 13;
            this.bt3D.Text = "Vẽ 3D";
            this.bt3D.UseVisualStyleBackColor = true;
            this.bt3D.Click += new System.EventHandler(this.bt3D_Click);
            // 
            // btn_drawElip
            // 
            this.btn_drawElip.Location = new System.Drawing.Point(398, 6);
            this.btn_drawElip.Name = "btn_drawElip";
            this.btn_drawElip.Size = new System.Drawing.Size(98, 30);
            this.btn_drawElip.TabIndex = 21;
            this.btn_drawElip.Text = "hình elip";
            this.btn_drawElip.UseVisualStyleBackColor = true;
            this.btn_drawElip.Click += new System.EventHandler(this.btn_drawElip_Click);
            // 
            // btn_DrawSquare
            // 
            this.btn_DrawSquare.Location = new System.Drawing.Point(298, 7);
            this.btn_DrawSquare.Name = "btn_DrawSquare";
            this.btn_DrawSquare.Size = new System.Drawing.Size(94, 29);
            this.btn_DrawSquare.TabIndex = 20;
            this.btn_DrawSquare.Text = "hình vuông";
            this.btn_DrawSquare.UseVisualStyleBackColor = true;
            this.btn_DrawSquare.Click += new System.EventHandler(this.btn_DrawSquare_Click);
            // 
            // btn_Quay
            // 
            this.btn_Quay.Location = new System.Drawing.Point(393, 48);
            this.btn_Quay.Name = "btn_Quay";
            this.btn_Quay.Size = new System.Drawing.Size(103, 29);
            this.btn_Quay.TabIndex = 19;
            this.btn_Quay.Text = "Quay 60°";
            this.btn_Quay.UseVisualStyleBackColor = true;
            this.btn_Quay.Click += new System.EventHandler(this.btn_Quay_Click);
            // 
            // btn_DoiXungOy
            // 
            this.btn_DoiXungOy.Location = new System.Drawing.Point(655, 124);
            this.btn_DoiXungOy.Name = "btn_DoiXungOy";
            this.btn_DoiXungOy.Size = new System.Drawing.Size(128, 32);
            this.btn_DoiXungOy.TabIndex = 18;
            this.btn_DoiXungOy.Text = "đối xứng qua Oy";
            this.btn_DoiXungOy.UseVisualStyleBackColor = true;
            this.btn_DoiXungOy.Click += new System.EventHandler(this.btn_DoiXungOy_Click);
            // 
            // btn_DoiXungOx
            // 
            this.btn_DoiXungOx.Location = new System.Drawing.Point(523, 125);
            this.btn_DoiXungOx.Name = "btn_DoiXungOx";
            this.btn_DoiXungOx.Size = new System.Drawing.Size(128, 32);
            this.btn_DoiXungOx.TabIndex = 17;
            this.btn_DoiXungOx.Text = "đối xứng qua Ox";
            this.btn_DoiXungOx.UseVisualStyleBackColor = true;
            this.btn_DoiXungOx.Click += new System.EventHandler(this.btn_DoiXungOx_Click);
            // 
            // btn_DoiXungQuaO
            // 
            this.btn_DoiXungQuaO.Location = new System.Drawing.Point(804, 120);
            this.btn_DoiXungQuaO.Name = "btn_DoiXungQuaO";
            this.btn_DoiXungQuaO.Size = new System.Drawing.Size(153, 33);
            this.btn_DoiXungQuaO.TabIndex = 16;
            this.btn_DoiXungQuaO.Text = "đối xứng qua O(0,0)";
            this.btn_DoiXungQuaO.UseVisualStyleBackColor = true;
            this.btn_DoiXungQuaO.Click += new System.EventHandler(this.btn_DoiXungQuaO_Click);
            // 
            // btn_drawCircle
            // 
            this.btn_drawCircle.Location = new System.Drawing.Point(425, 130);
            this.btn_drawCircle.Name = "btn_drawCircle";
            this.btn_drawCircle.Size = new System.Drawing.Size(81, 29);
            this.btn_drawCircle.TabIndex = 13;
            this.btn_drawCircle.Text = "circle";
            this.btn_drawCircle.UseVisualStyleBackColor = true;
            this.btn_drawCircle.Click += new System.EventHandler(this.btn_drawCircle_Click);
            // 
            // btTatTiLe
            // 
            this.btTatTiLe.Location = new System.Drawing.Point(375, 99);
            this.btTatTiLe.Name = "btTatTiLe";
            this.btTatTiLe.Size = new System.Drawing.Size(17, 29);
            this.btTatTiLe.TabIndex = 41;
            this.btTatTiLe.Text = "X";
            this.btTatTiLe.UseVisualStyleBackColor = true;
            this.btTatTiLe.Visible = false;
            this.btTatTiLe.Click += new System.EventHandler(this.btTatTiLe_Click);
            // 
            // btTatTinhTien
            // 
            this.btTatTinhTien.Location = new System.Drawing.Point(228, 102);
            this.btTatTinhTien.Name = "btTatTinhTien";
            this.btTatTinhTien.Size = new System.Drawing.Size(17, 29);
            this.btTatTinhTien.TabIndex = 40;
            this.btTatTinhTien.Text = "X";
            this.btTatTinhTien.UseVisualStyleBackColor = true;
            this.btTatTinhTien.Visible = false;
            this.btTatTinhTien.Click += new System.EventHandler(this.btTatTinhTien_Click);
            // 
            // cbIsStop
            // 
            this.cbIsStop.AutoSize = true;
            this.cbIsStop.Location = new System.Drawing.Point(91, 132);
            this.cbIsStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbIsStop.Name = "cbIsStop";
            this.cbIsStop.Size = new System.Drawing.Size(62, 24);
            this.cbIsStop.TabIndex = 13;
            this.cbIsStop.Text = "Stop";
            this.cbIsStop.UseVisualStyleBackColor = true;
            this.cbIsStop.Visible = false;
            // 
            // btConLacCD
            // 
            this.btConLacCD.BackColor = System.Drawing.SystemColors.Control;
            this.btConLacCD.Location = new System.Drawing.Point(-2, 125);
            this.btConLacCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConLacCD.Name = "btConLacCD";
            this.btConLacCD.Size = new System.Drawing.Size(88, 36);
            this.btConLacCD.TabIndex = 13;
            this.btConLacCD.Text = "Con lắc";
            this.btConLacCD.UseVisualStyleBackColor = false;
            this.btConLacCD.Click += new System.EventHandler(this.btConLacCD_Click);
            // 
            // BtXoa
            // 
            this.BtXoa.Location = new System.Drawing.Point(406, 84);
            this.BtXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtXoa.Name = "BtXoa";
            this.BtXoa.Size = new System.Drawing.Size(69, 39);
            this.BtXoa.TabIndex = 39;
            this.BtXoa.Text = "Xóa";
            this.BtXoa.UseVisualStyleBackColor = true;
            this.BtXoa.Click += new System.EventHandler(this.BtXoa_Click);
            // 
            // tbTiLeY
            // 
            this.tbTiLeY.Location = new System.Drawing.Point(335, 101);
            this.tbTiLeY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTiLeY.Name = "tbTiLeY";
            this.tbTiLeY.Size = new System.Drawing.Size(34, 27);
            this.tbTiLeY.TabIndex = 38;
            this.tbTiLeY.Visible = false;
            // 
            // tbTiLeX
            // 
            this.tbTiLeX.Location = new System.Drawing.Point(280, 101);
            this.tbTiLeX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTiLeX.Name = "tbTiLeX";
            this.tbTiLeX.Size = new System.Drawing.Size(29, 27);
            this.tbTiLeX.TabIndex = 37;
            this.tbTiLeX.Visible = false;
            // 
            // lbTiLeY
            // 
            this.lbTiLeY.AutoSize = true;
            this.lbTiLeY.Location = new System.Drawing.Point(317, 107);
            this.lbTiLeY.Name = "lbTiLeY";
            this.lbTiLeY.Size = new System.Drawing.Size(20, 20);
            this.lbTiLeY.TabIndex = 36;
            this.lbTiLeY.Text = "Y:";
            this.lbTiLeY.Visible = false;
            // 
            // lbTiLeX
            // 
            this.lbTiLeX.AutoSize = true;
            this.lbTiLeX.Location = new System.Drawing.Point(262, 105);
            this.lbTiLeX.Name = "lbTiLeX";
            this.lbTiLeX.Size = new System.Drawing.Size(21, 20);
            this.lbTiLeX.TabIndex = 35;
            this.lbTiLeX.Text = "X:";
            this.lbTiLeX.Visible = false;
            // 
            // btTiLe
            // 
            this.btTiLe.Location = new System.Drawing.Point(251, 61);
            this.btTiLe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTiLe.Name = "btTiLe";
            this.btTiLe.Size = new System.Drawing.Size(107, 39);
            this.btTiLe.TabIndex = 34;
            this.btTiLe.Text = "Tỉ lệ:";
            this.btTiLe.UseVisualStyleBackColor = true;
            this.btTiLe.Click += new System.EventHandler(this.btTiLe_Click);
            // 
            // tbTinhTienY
            // 
            this.tbTinhTienY.Location = new System.Drawing.Point(190, 103);
            this.tbTinhTienY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTinhTienY.Name = "tbTinhTienY";
            this.tbTinhTienY.Size = new System.Drawing.Size(33, 27);
            this.tbTinhTienY.TabIndex = 33;
            this.tbTinhTienY.Visible = false;
            // 
            // lbTinhTienY
            // 
            this.lbTinhTienY.AutoSize = true;
            this.lbTinhTienY.Location = new System.Drawing.Point(171, 107);
            this.lbTinhTienY.Name = "lbTinhTienY";
            this.lbTinhTienY.Size = new System.Drawing.Size(20, 20);
            this.lbTinhTienY.TabIndex = 32;
            this.lbTinhTienY.Text = "Y:";
            this.lbTinhTienY.Visible = false;
            // 
            // tbTinhTienX
            // 
            this.tbTinhTienX.Location = new System.Drawing.Point(133, 101);
            this.tbTinhTienX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTinhTienX.Name = "tbTinhTienX";
            this.tbTinhTienX.Size = new System.Drawing.Size(31, 27);
            this.tbTinhTienX.TabIndex = 31;
            this.tbTinhTienX.Visible = false;
            // 
            // lbTinhTienX
            // 
            this.lbTinhTienX.AutoSize = true;
            this.lbTinhTienX.Location = new System.Drawing.Point(115, 105);
            this.lbTinhTienX.Name = "lbTinhTienX";
            this.lbTinhTienX.Size = new System.Drawing.Size(21, 20);
            this.lbTinhTienX.TabIndex = 30;
            this.lbTinhTienX.Text = "X:";
            this.lbTinhTienX.Visible = false;
            // 
            // btTinhTien
            // 
            this.btTinhTien.Location = new System.Drawing.Point(115, 53);
            this.btTinhTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTinhTien.Name = "btTinhTien";
            this.btTinhTien.Size = new System.Drawing.Size(107, 39);
            this.btTinhTien.TabIndex = 29;
            this.btTinhTien.Text = "Tịnh tiến";
            this.btTinhTien.UseVisualStyleBackColor = true;
            this.btTinhTien.Click += new System.EventHandler(this.btTinhTien_Click);
            // 
            // tbRongDay
            // 
            this.tbRongDay.Location = new System.Drawing.Point(539, 89);
            this.tbRongDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRongDay.Name = "tbRongDay";
            this.tbRongDay.Size = new System.Drawing.Size(57, 27);
            this.tbRongDay.TabIndex = 28;
            this.tbRongDay.Visible = false;
            // 
            // tbChieuCao
            // 
            this.tbChieuCao.Location = new System.Drawing.Point(539, 53);
            this.tbChieuCao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbChieuCao.Name = "tbChieuCao";
            this.tbChieuCao.Size = new System.Drawing.Size(57, 27);
            this.tbChieuCao.TabIndex = 27;
            this.tbChieuCao.Visible = false;
            // 
            // lbRongDay
            // 
            this.lbRongDay.AutoSize = true;
            this.lbRongDay.Location = new System.Drawing.Point(502, 93);
            this.lbRongDay.Name = "lbRongDay";
            this.lbRongDay.Size = new System.Drawing.Size(36, 20);
            this.lbRongDay.TabIndex = 26;
            this.lbRongDay.Text = "đáy:";
            this.lbRongDay.Visible = false;
            // 
            // lbChieuCao
            // 
            this.lbChieuCao.AutoSize = true;
            this.lbChieuCao.Location = new System.Drawing.Point(502, 59);
            this.lbChieuCao.Name = "lbChieuCao";
            this.lbChieuCao.Size = new System.Drawing.Size(36, 20);
            this.lbChieuCao.TabIndex = 25;
            this.lbChieuCao.Text = "cao:";
            this.lbChieuCao.Visible = false;
            // 
            // btTamGiac
            // 
            this.btTamGiac.BackColor = System.Drawing.SystemColors.Control;
            this.btTamGiac.Location = new System.Drawing.Point(502, 1);
            this.btTamGiac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTamGiac.Name = "btTamGiac";
            this.btTamGiac.Size = new System.Drawing.Size(95, 51);
            this.btTamGiac.TabIndex = 24;
            this.btTamGiac.Text = "Tam giác";
            this.btTamGiac.UseVisualStyleBackColor = false;
            this.btTamGiac.Click += new System.EventHandler(this.btTamGiac_Click);
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(755, 89);
            this.tbHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(28, 27);
            this.tbHeight.TabIndex = 23;
            this.tbHeight.Visible = false;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(755, 53);
            this.tbWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(28, 27);
            this.tbWidth.TabIndex = 22;
            this.tbWidth.Visible = false;
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(699, 92);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(57, 20);
            this.lbHeight.TabIndex = 21;
            this.lbHeight.Text = "Height:";
            this.lbHeight.Visible = false;
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(699, 55);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(52, 20);
            this.lbWidth.TabIndex = 20;
            this.lbWidth.Text = "Width:";
            this.lbWidth.Visible = false;
            // 
            // btHCN
            // 
            this.btHCN.BackColor = System.Drawing.SystemColors.Control;
            this.btHCN.Location = new System.Drawing.Point(709, 0);
            this.btHCN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btHCN.Name = "btHCN";
            this.btHCN.Size = new System.Drawing.Size(65, 52);
            this.btHCN.TabIndex = 19;
            this.btHCN.Text = "HCN";
            this.btHCN.UseVisualStyleBackColor = false;
            this.btHCN.Click += new System.EventHandler(this.btHCN_Click);
            // 
            // txtCheoB
            // 
            this.txtCheoB.Location = new System.Drawing.Point(678, 88);
            this.txtCheoB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheoB.Name = "txtCheoB";
            this.txtCheoB.Size = new System.Drawing.Size(26, 27);
            this.txtCheoB.TabIndex = 18;
            this.txtCheoB.Visible = false;
            // 
            // txtCheoA
            // 
            this.txtCheoA.Location = new System.Drawing.Point(677, 52);
            this.txtCheoA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheoA.Name = "txtCheoA";
            this.txtCheoA.Size = new System.Drawing.Size(27, 27);
            this.txtCheoA.TabIndex = 17;
            this.txtCheoA.Visible = false;
            // 
            // lbCheoB
            // 
            this.lbCheoB.AutoSize = true;
            this.lbCheoB.Location = new System.Drawing.Point(603, 92);
            this.lbCheoB.Name = "lbCheoB";
            this.lbCheoB.Size = new System.Drawing.Size(59, 20);
            this.lbCheoB.TabIndex = 16;
            this.lbCheoB.Text = "Chéo b:";
            this.lbCheoB.Visible = false;
            // 
            // lbCheoA
            // 
            this.lbCheoA.AutoSize = true;
            this.lbCheoA.Location = new System.Drawing.Point(605, 56);
            this.lbCheoA.Name = "lbCheoA";
            this.lbCheoA.Size = new System.Drawing.Size(58, 20);
            this.lbCheoA.TabIndex = 15;
            this.lbCheoA.Text = "Chéo a:";
            this.lbCheoA.Visible = false;
            // 
            // btHinhThoi
            // 
            this.btHinhThoi.BackColor = System.Drawing.SystemColors.Control;
            this.btHinhThoi.Location = new System.Drawing.Point(605, 3);
            this.btHinhThoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btHinhThoi.Name = "btHinhThoi";
            this.btHinhThoi.Size = new System.Drawing.Size(99, 49);
            this.btHinhThoi.TabIndex = 14;
            this.btHinhThoi.Text = "Hình thoi";
            this.btHinhThoi.UseVisualStyleBackColor = false;
            this.btHinhThoi.Click += new System.EventHandler(this.btHinhThoi_Click);
            // 
            // btDrawLine
            // 
            this.btDrawLine.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawLine.Location = new System.Drawing.Point(866, 3);
            this.btDrawLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawLine.Name = "btDrawLine";
            this.btDrawLine.Size = new System.Drawing.Size(108, 41);
            this.btDrawLine.TabIndex = 13;
            this.btDrawLine.Text = "Đường thẳng";
            this.btDrawLine.UseVisualStyleBackColor = false;
            this.btDrawLine.Click += new System.EventHandler(this.btDrawLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(973, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbDrawZone);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDrawZone;
        private System.Windows.Forms.Button btDrawPixel;
        private System.Windows.Forms.Button btDrawArrow;
        private System.Windows.Forms.ComboBox cbWidthLine;
        private System.Windows.Forms.Label lbDoDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbDrawColor;
        private System.Windows.Forms.Button btFillColor;
        private System.Windows.Forms.Button btRotate;
        private System.Windows.Forms.TextBox tbRotate;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btSymmetry;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button bt3D;
        private System.Windows.Forms.Button button2;


        private System.Windows.Forms.Button btn_drawCircle;
        private System.Windows.Forms.Button btn_DoiXungQuaO;
        private System.Windows.Forms.Button btn_DoiXungOx;
        private System.Windows.Forms.Button btn_DoiXungOy;
        private System.Windows.Forms.Button btn_Quay;
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

    }
}

