
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Draw3D));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDrawRec = new System.Windows.Forms.Button();
            this.pb3D = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btDrawElip = new System.Windows.Forms.Button();
            this.bnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb3D)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oz";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Oy";
            // 
            // btnDrawRec
            // 
            this.btnDrawRec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDrawRec.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRec.Image")));
            this.btnDrawRec.Location = new System.Drawing.Point(182, 465);
            this.btnDrawRec.Name = "btnDrawRec";
            this.btnDrawRec.Size = new System.Drawing.Size(232, 173);
            this.btnDrawRec.TabIndex = 10;
            this.btnDrawRec.Text = "Vẽ hộp chữ nhật";
            this.btnDrawRec.UseVisualStyleBackColor = false;
            this.btnDrawRec.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb3D
            // 
            this.pb3D.BackColor = System.Drawing.Color.LightGray;
            this.pb3D.Location = new System.Drawing.Point(163, 59);
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
            this.label13.Size = new System.Drawing.Size(58, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // btDrawElip
            // 
            this.btDrawElip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btDrawElip.Image = ((System.Drawing.Image)(resources.GetObject("btDrawElip.Image")));
            this.btDrawElip.Location = new System.Drawing.Point(453, 465);
            this.btDrawElip.Name = "btDrawElip";
            this.btDrawElip.Size = new System.Drawing.Size(232, 173);
            this.btDrawElip.TabIndex = 22;
            this.btDrawElip.Text = "Vẽ hình cầu";
            this.btDrawElip.UseVisualStyleBackColor = false;
            this.btDrawElip.Click += new System.EventHandler(this.btDrawElip_Click);
            // 
            // bnClear
            // 
            this.bnClear.BackColor = System.Drawing.Color.Red;
            this.bnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bnClear.Location = new System.Drawing.Point(27, 626);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(94, 29);
            this.bnClear.TabIndex = 23;
            this.bnClear.Text = "Xóa hết";
            this.bnClear.UseVisualStyleBackColor = false;
            this.bnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Draw3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(973, 667);
            this.Controls.Add(this.bnClear);
            this.Controls.Add(this.btDrawElip);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pb3D);
            this.Controls.Add(this.btnDrawRec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Draw3D";
            this.Text = "Vẽ 3D";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb3D)).EndInit();
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
    }
}

