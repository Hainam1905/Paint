
namespace Paint
{
    partial class Draw3D
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDrawRec = new System.Windows.Forms.Button();
            this.pb3D = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btDrawElip = new System.Windows.Forms.Button();
            this.bnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.elipseControl1 = new Paint.ElipseControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb3D)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oz";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Oy";
            // 
            // btnDrawRec
            // 
            this.btnDrawRec.BackColor = System.Drawing.Color.Red;
            this.btnDrawRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawRec.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDrawRec.ForeColor = System.Drawing.Color.Yellow;
            this.btnDrawRec.Image = global::Paint.Properties.Resources.HCN3dFis;
            this.btnDrawRec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawRec.Location = new System.Drawing.Point(831, 138);
            this.btnDrawRec.Name = "btnDrawRec";
            this.btnDrawRec.Size = new System.Drawing.Size(373, 155);
            this.btnDrawRec.TabIndex = 10;
            this.btnDrawRec.Text = "                    Vẽ hộp chữ nhật";
            this.btnDrawRec.UseVisualStyleBackColor = false;
            this.btnDrawRec.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb3D
            // 
            this.pb3D.BackColor = System.Drawing.Color.LightGray;
            this.pb3D.Location = new System.Drawing.Point(114, 120);
            this.pb3D.Name = "pb3D";
            this.pb3D.Size = new System.Drawing.Size(534, 400);
            this.pb3D.TabIndex = 19;
            this.pb3D.TabStop = false;
            this.pb3D.Click += new System.EventHandler(this.pb3D_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(778, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 20);
            this.label13.TabIndex = 21;
            this.label13.Visible = false;
            // 
            // btDrawElip
            // 
            this.btDrawElip.BackColor = System.Drawing.Color.Red;
            this.btDrawElip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDrawElip.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btDrawElip.ForeColor = System.Drawing.Color.Yellow;
            this.btDrawElip.Image = global::Paint.Properties.Resources.HCaufis;
            this.btDrawElip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDrawElip.Location = new System.Drawing.Point(831, 335);
            this.btDrawElip.Name = "btDrawElip";
            this.btDrawElip.Size = new System.Drawing.Size(373, 160);
            this.btDrawElip.TabIndex = 22;
            this.btDrawElip.Text = "               Vẽ hình cầu";
            this.btDrawElip.UseVisualStyleBackColor = false;
            this.btDrawElip.Click += new System.EventHandler(this.btDrawElip_Click);
            // 
            // bnClear
            // 
            this.bnClear.BackColor = System.Drawing.SystemColors.Control;
            this.bnClear.BackgroundImage = global::Paint.Properties.Resources.delete;
            this.bnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bnClear.Location = new System.Drawing.Point(973, 534);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(94, 105);
            this.bnClear.TabIndex = 23;
            this.bnClear.UseVisualStyleBackColor = false;
            this.bnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 69);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = global::Paint.Properties.Resources.XBT;
            this.button1.Location = new System.Drawing.Point(1172, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 57);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 40;
            this.elipseControl1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Paint.Properties.Resources._74522308_2519290034858047_5559712401621778432_o;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(30, 565);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 124);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Paint.Properties.Resources.ptit_logo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(174, 565);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 124);
            this.panel3.TabIndex = 26;
            // 
            // Draw3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Paint.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1296, 724);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bnClear);
            this.Controls.Add(this.btDrawElip);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pb3D);
            this.Controls.Add(this.btnDrawRec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Draw3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vẽ 3D";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb3D)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDrawRec;
        private System.Windows.Forms.TextBox txtzA;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.PictureBox pb3D;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btDrawElip;
        private System.Windows.Forms.Button bnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private ElipseControl elipseControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}

