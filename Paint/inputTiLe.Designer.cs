
namespace Paint
{
    partial class inputTiLe
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ip_Sx = new System.Windows.Forms.NumericUpDown();
            this.ip_Sy = new System.Windows.Forms.NumericUpDown();
            this.btn_TiLe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ip_Sx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_Sy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin về tỉ lệ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sx:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sy:";
            // 
            // ip_Sx
            // 
            this.ip_Sx.DecimalPlaces = 1;
            this.ip_Sx.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ip_Sx.Location = new System.Drawing.Point(137, 90);
            this.ip_Sx.Name = "ip_Sx";
            this.ip_Sx.Size = new System.Drawing.Size(53, 27);
            this.ip_Sx.TabIndex = 3;
            this.ip_Sx.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // ip_Sy
            // 
            this.ip_Sy.DecimalPlaces = 1;
            this.ip_Sy.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ip_Sy.Location = new System.Drawing.Point(137, 151);
            this.ip_Sy.Name = "ip_Sy";
            this.ip_Sy.Size = new System.Drawing.Size(53, 27);
            this.ip_Sy.TabIndex = 4;
            this.ip_Sy.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // btn_TiLe
            // 
            this.btn_TiLe.Location = new System.Drawing.Point(77, 226);
            this.btn_TiLe.Name = "btn_TiLe";
            this.btn_TiLe.Size = new System.Drawing.Size(88, 33);
            this.btn_TiLe.TabIndex = 5;
            this.btn_TiLe.Text = "Tỉ lệ";
            this.btn_TiLe.UseVisualStyleBackColor = true;
            this.btn_TiLe.Click += new System.EventHandler(this.btn_TiLe_Click);
            // 
            // inputTiLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 343);
            this.Controls.Add(this.btn_TiLe);
            this.Controls.Add(this.ip_Sy);
            this.Controls.Add(this.ip_Sx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "inputTiLe";
            this.Text = "inputTiLe";
            ((System.ComponentModel.ISupportInitialize)(this.ip_Sx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_Sy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ip_Sx;
        private System.Windows.Forms.NumericUpDown ip_Sy;
        private System.Windows.Forms.Button btn_TiLe;
    }
}