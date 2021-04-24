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
            this.button1 = new System.Windows.Forms.Button();
            this.tbRotate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrawZone
            // 
            this.pbDrawZone.BackColor = System.Drawing.SystemColors.Control;
            this.pbDrawZone.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbDrawZone.Location = new System.Drawing.Point(0, 51);
            this.pbDrawZone.Name = "pbDrawZone";
            this.pbDrawZone.Size = new System.Drawing.Size(855, 507);
            this.pbDrawZone.TabIndex = 0;
            this.pbDrawZone.TabStop = false;
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
            this.btDrawPixel.Location = new System.Drawing.Point(0, 0);
            this.btDrawPixel.Name = "btDrawPixel";
            this.btDrawPixel.Size = new System.Drawing.Size(75, 25);
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
            this.btDrawArrow.Location = new System.Drawing.Point(91, 0);
            this.btDrawArrow.Name = "btDrawArrow";
            this.btDrawArrow.Size = new System.Drawing.Size(78, 25);
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
            this.cbWidthLine.Location = new System.Drawing.Point(816, 2);
            this.cbWidthLine.Name = "cbWidthLine";
            this.cbWidthLine.Size = new System.Drawing.Size(39, 23);
            this.cbWidthLine.TabIndex = 2;
            this.cbWidthLine.SelectedIndexChanged += new System.EventHandler(this.cbWidthLine_SelectedIndexChanged);
            // 
            // lbDoDay
            // 
            this.lbDoDay.AutoSize = true;
            this.lbDoDay.BackColor = System.Drawing.SystemColors.Control;
            this.lbDoDay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDoDay.Location = new System.Drawing.Point(785, 2);
            this.lbDoDay.Name = "lbDoDay";
            this.lbDoDay.Size = new System.Drawing.Size(25, 26);
            this.lbDoDay.TabIndex = 3;
            this.lbDoDay.Text = "Độ\r\ndày";
            this.lbDoDay.Click += new System.EventHandler(this.lbDoDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // cbDrawColor
            // 
            this.cbDrawColor.AutoSize = true;
            this.cbDrawColor.Location = new System.Drawing.Point(800, 31);
            this.cbDrawColor.Name = "cbDrawColor";
            this.cbDrawColor.Size = new System.Drawing.Size(55, 19);
            this.cbDrawColor.TabIndex = 5;
            this.cbDrawColor.Text = "Color";
            this.cbDrawColor.UseVisualStyleBackColor = true;
            this.cbDrawColor.CheckedChanged += new System.EventHandler(this.cbDrawColor_CheckedChanged);
            // 
            // btFillColor
            // 
            this.btFillColor.Location = new System.Drawing.Point(184, 0);
            this.btFillColor.Name = "btFillColor";
            this.btFillColor.Size = new System.Drawing.Size(75, 45);
            this.btFillColor.TabIndex = 6;
            this.btFillColor.Text = "Fill Color\r\n(Red)";
            this.btFillColor.UseVisualStyleBackColor = true;
            this.btFillColor.Click += new System.EventHandler(this.btFillColor_Click);
            // 
            // btDrawCircle
            // 
            this.btDrawCircle.Location = new System.Drawing.Point(279, 0);
            this.btDrawCircle.Name = "btDrawCircle";
            this.btDrawCircle.Size = new System.Drawing.Size(102, 24);
            this.btDrawCircle.TabIndex = 7;
            this.btDrawCircle.Text = "Draw Circle";
            this.btDrawCircle.UseVisualStyleBackColor = true;
            this.btDrawCircle.Click += new System.EventHandler(this.btDrawCircle_Click);
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(338, 22);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(43, 23);
            this.tbRadius.TabIndex = 8;
            this.tbRadius.TextChanged += new System.EventHandler(this.tbRadius_TextChanged);
            // 
            // lbRadius
            // 
            this.lbRadius.AutoSize = true;
            this.lbRadius.Location = new System.Drawing.Point(279, 25);
            this.lbRadius.Name = "lbRadius";
            this.lbRadius.Size = new System.Drawing.Size(59, 15);
            this.lbRadius.TabIndex = 9;
            this.lbRadius.Text = "Bán kính :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(736, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "Xoay";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRotate
            // 
            this.tbRotate.Location = new System.Drawing.Point(736, 27);
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Size = new System.Drawing.Size(43, 23);
            this.tbRotate.TabIndex = 11;
            this.tbRotate.TextChanged += new System.EventHandler(this.tbRotate_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(851, 555);
            this.Controls.Add(this.tbRotate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRadius);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.btDrawCircle);
            this.Controls.Add(this.btFillColor);
            this.Controls.Add(this.cbDrawColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDoDay);
            this.Controls.Add(this.cbWidthLine);
            this.Controls.Add(this.btDrawArrow);
            this.Controls.Add(this.btDrawPixel);
            this.Controls.Add(this.pbDrawZone);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbRotate;
    }
}

