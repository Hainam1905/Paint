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
            this.label2 = new System.Windows.Forms.Label();
            this.cbDrawColor = new System.Windows.Forms.CheckBox();
            this.btFillColor = new System.Windows.Forms.Button();
            this.btDrawCircle = new System.Windows.Forms.Button();
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.lbRadius = new System.Windows.Forms.Label();
            this.btRotate = new System.Windows.Forms.Button();
            this.tbRotate = new System.Windows.Forms.TextBox();
            this.btSymmetry = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_DrawSquare = new System.Windows.Forms.Button();
            this.btn_Quay = new System.Windows.Forms.Button();
            this.btn_DoiXungOy = new System.Windows.Forms.Button();
            this.btn_DoiXungOx = new System.Windows.Forms.Button();
            this.btn_DoiXungQuaO = new System.Windows.Forms.Button();
            this.btn_TiLe = new System.Windows.Forms.Button();
            this.btn_tinhtien = new System.Windows.Forms.Button();
            this.btn_drawCircle = new System.Windows.Forms.Button();
            this.btn_drawElip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDrawZone
            // 
            this.pbDrawZone.BackColor = System.Drawing.SystemColors.Control;
            this.pbDrawZone.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbDrawZone.Location = new System.Drawing.Point(0, 103);
            this.pbDrawZone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbDrawZone.Name = "pbDrawZone";
            this.pbDrawZone.Size = new System.Drawing.Size(974, 642);
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
            this.btDrawPixel.Location = new System.Drawing.Point(-3, 0);
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
            this.btDrawArrow.Location = new System.Drawing.Point(101, 0);
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
            this.cbWidthLine.Location = new System.Drawing.Point(930, 3);
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
            this.lbDoDay.Location = new System.Drawing.Point(895, 0);
            this.lbDoDay.Name = "lbDoDay";
            this.lbDoDay.Size = new System.Drawing.Size(31, 38);
            this.lbDoDay.TabIndex = 3;
            this.lbDoDay.Text = "Độ\r\ndày";
            this.lbDoDay.Click += new System.EventHandler(this.lbDoDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // cbDrawColor
            // 
            this.cbDrawColor.AutoSize = true;
            this.cbDrawColor.Location = new System.Drawing.Point(911, 41);
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
            this.btFillColor.Location = new System.Drawing.Point(207, 0);
            this.btFillColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFillColor.Name = "btFillColor";
            this.btFillColor.Size = new System.Drawing.Size(86, 60);
            this.btFillColor.TabIndex = 6;
            this.btFillColor.Text = "Fill Color\r\n(Red)";
            this.btFillColor.UseVisualStyleBackColor = false;
            this.btFillColor.Click += new System.EventHandler(this.btFillColor_Click);
            // 
            // btDrawCircle
            // 
            this.btDrawCircle.BackColor = System.Drawing.SystemColors.Control;
            this.btDrawCircle.Location = new System.Drawing.Point(315, 0);
            this.btDrawCircle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDrawCircle.Name = "btDrawCircle";
            this.btDrawCircle.Size = new System.Drawing.Size(117, 32);
            this.btDrawCircle.TabIndex = 7;
            this.btDrawCircle.Text = "Draw Circle";
            this.btDrawCircle.UseVisualStyleBackColor = false;
            this.btDrawCircle.Click += new System.EventHandler(this.btDrawCircle_Click);
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(384, 27);
            this.tbRadius.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(49, 27);
            this.tbRadius.TabIndex = 8;
            // 
            // lbRadius
            // 
            this.lbRadius.AutoSize = true;
            this.lbRadius.Location = new System.Drawing.Point(317, 29);
            this.lbRadius.Name = "lbRadius";
            this.lbRadius.Size = new System.Drawing.Size(72, 20);
            this.lbRadius.TabIndex = 9;
            this.lbRadius.Text = "Bán kính :";
            // 
            // btRotate
            // 
            this.btRotate.BackColor = System.Drawing.SystemColors.Control;
            this.btRotate.Location = new System.Drawing.Point(822, 0);
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
            this.tbRotate.Location = new System.Drawing.Point(822, 33);
            this.tbRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Size = new System.Drawing.Size(66, 27);
            this.tbRotate.TabIndex = 11;
            this.tbRotate.TextChanged += new System.EventHandler(this.tbRotate_TextChanged);
            // 
            // btSymmetry
            // 
            this.btSymmetry.BackColor = System.Drawing.SystemColors.Control;
            this.btSymmetry.Location = new System.Drawing.Point(667, 3);
            this.btSymmetry.Name = "btSymmetry";
            this.btSymmetry.Size = new System.Drawing.Size(130, 57);
            this.btSymmetry.TabIndex = 12;
            this.btSymmetry.Text = "Đối xứng";
            this.btSymmetry.UseVisualStyleBackColor = false;
            this.btSymmetry.Click += new System.EventHandler(this.btSymmetry_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_drawElip);
            this.panel1.Controls.Add(this.btn_DrawSquare);
            this.panel1.Controls.Add(this.btn_Quay);
            this.panel1.Controls.Add(this.btn_DoiXungOy);
            this.panel1.Controls.Add(this.btn_DoiXungOx);
            this.panel1.Controls.Add(this.btn_DoiXungQuaO);
            this.panel1.Controls.Add(this.btn_TiLe);
            this.panel1.Controls.Add(this.btn_tinhtien);
            this.panel1.Controls.Add(this.btn_drawCircle);
            this.panel1.Controls.Add(this.btSymmetry);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 103);
            this.panel1.TabIndex = 12;
            // 
            // btn_DrawSquare
            // 
            this.btn_DrawSquare.Location = new System.Drawing.Point(439, 27);
            this.btn_DrawSquare.Name = "btn_DrawSquare";
            this.btn_DrawSquare.Size = new System.Drawing.Size(94, 29);
            this.btn_DrawSquare.TabIndex = 20;
            this.btn_DrawSquare.Text = "hình vuông";
            this.btn_DrawSquare.UseVisualStyleBackColor = true;
            this.btn_DrawSquare.Click += new System.EventHandler(this.btn_DrawSquare_Click);
            // 
            // btn_Quay
            // 
            this.btn_Quay.Location = new System.Drawing.Point(742, 65);
            this.btn_Quay.Name = "btn_Quay";
            this.btn_Quay.Size = new System.Drawing.Size(103, 29);
            this.btn_Quay.TabIndex = 19;
            this.btn_Quay.Text = "Quay 60°";
            this.btn_Quay.UseVisualStyleBackColor = true;
            this.btn_Quay.Click += new System.EventHandler(this.btn_Quay_Click);
            // 
            // btn_DoiXungOy
            // 
            this.btn_DoiXungOy.Location = new System.Drawing.Point(595, 64);
            this.btn_DoiXungOy.Name = "btn_DoiXungOy";
            this.btn_DoiXungOy.Size = new System.Drawing.Size(128, 32);
            this.btn_DoiXungOy.TabIndex = 18;
            this.btn_DoiXungOy.Text = "đối xứng qua Oy";
            this.btn_DoiXungOy.UseVisualStyleBackColor = true;
            this.btn_DoiXungOy.Click += new System.EventHandler(this.btn_DoiXungOy_Click);
            // 
            // btn_DoiXungOx
            // 
            this.btn_DoiXungOx.Location = new System.Drawing.Point(461, 65);
            this.btn_DoiXungOx.Name = "btn_DoiXungOx";
            this.btn_DoiXungOx.Size = new System.Drawing.Size(128, 32);
            this.btn_DoiXungOx.TabIndex = 17;
            this.btn_DoiXungOx.Text = "đối xứng qua Ox";
            this.btn_DoiXungOx.UseVisualStyleBackColor = true;
            this.btn_DoiXungOx.Click += new System.EventHandler(this.btn_DoiXungOx_Click);
            // 
            // btn_DoiXungQuaO
            // 
            this.btn_DoiXungQuaO.Location = new System.Drawing.Point(298, 65);
            this.btn_DoiXungQuaO.Name = "btn_DoiXungQuaO";
            this.btn_DoiXungQuaO.Size = new System.Drawing.Size(153, 33);
            this.btn_DoiXungQuaO.TabIndex = 16;
            this.btn_DoiXungQuaO.Text = "đối xứng qua O(0,0)";
            this.btn_DoiXungQuaO.UseVisualStyleBackColor = true;
            this.btn_DoiXungQuaO.Click += new System.EventHandler(this.btn_DoiXungQuaO_Click);
            // 
            // btn_TiLe
            // 
            this.btn_TiLe.Location = new System.Drawing.Point(207, 65);
            this.btn_TiLe.Name = "btn_TiLe";
            this.btn_TiLe.Size = new System.Drawing.Size(75, 33);
            this.btn_TiLe.TabIndex = 15;
            this.btn_TiLe.Text = "tỉ lệ";
            this.btn_TiLe.UseVisualStyleBackColor = true;
            this.btn_TiLe.Click += new System.EventHandler(this.btn_TiLe_Click);
            // 
            // btn_tinhtien
            // 
            this.btn_tinhtien.Location = new System.Drawing.Point(101, 66);
            this.btn_tinhtien.Name = "btn_tinhtien";
            this.btn_tinhtien.Size = new System.Drawing.Size(83, 31);
            this.btn_tinhtien.TabIndex = 14;
            this.btn_tinhtien.Text = "tịnh tiến";
            this.btn_tinhtien.UseVisualStyleBackColor = true;
            this.btn_tinhtien.Click += new System.EventHandler(this.btn_tinhtien_Click);
            // 
            // btn_drawCircle
            // 
            this.btn_drawCircle.Location = new System.Drawing.Point(2, 67);
            this.btn_drawCircle.Name = "btn_drawCircle";
            this.btn_drawCircle.Size = new System.Drawing.Size(81, 29);
            this.btn_drawCircle.TabIndex = 13;
            this.btn_drawCircle.Text = "circle";
            this.btn_drawCircle.UseVisualStyleBackColor = true;
            this.btn_drawCircle.Click += new System.EventHandler(this.btn_drawCircle_Click);
            // 
            // btn_drawElip
            // 
            this.btn_drawElip.Location = new System.Drawing.Point(551, 26);
            this.btn_drawElip.Name = "btn_drawElip";
            this.btn_drawElip.Size = new System.Drawing.Size(98, 30);
            this.btn_drawElip.TabIndex = 21;
            this.btn_drawElip.Text = "hình elip";
            this.btn_drawElip.UseVisualStyleBackColor = true;
            this.btn_drawElip.Click += new System.EventHandler(this.btn_drawElip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(973, 740);
            this.Controls.Add(this.tbRotate);
            this.Controls.Add(this.btRotate);
            this.Controls.Add(this.lbRadius);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.btDrawCircle);
            this.Controls.Add(this.btFillColor);
            this.Controls.Add(this.cbDrawColor);
            this.Controls.Add(this.lbDoDay);
            this.Controls.Add(this.cbWidthLine);
            this.Controls.Add(this.btDrawArrow);
            this.Controls.Add(this.btDrawPixel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbDrawZone);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDrawZone;
        private System.Windows.Forms.Button btDrawPixel;
        private System.Windows.Forms.Button btDrawArrow;
        private System.Windows.Forms.ComboBox cbWidthLine;
        private System.Windows.Forms.Label lbDoDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbDrawColor;
        private System.Windows.Forms.Button btFillColor;
        private System.Windows.Forms.Button btDrawCircle;
        private System.Windows.Forms.TextBox tbRadius;
        private System.Windows.Forms.Label lbRadius;
        private System.Windows.Forms.Button btRotate;
        private System.Windows.Forms.TextBox tbRotate;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btSymmetry;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_drawCircle;
        private System.Windows.Forms.Button btn_tinhtien;
        private System.Windows.Forms.Button btn_TiLe;
        private System.Windows.Forms.Button btn_DoiXungQuaO;
        private System.Windows.Forms.Button btn_DoiXungOx;
        private System.Windows.Forms.Button btn_DoiXungOy;
        private System.Windows.Forms.Button btn_Quay;
        private System.Windows.Forms.Button btn_DrawSquare;
        private System.Windows.Forms.Button btn_drawElip;
    }
}

