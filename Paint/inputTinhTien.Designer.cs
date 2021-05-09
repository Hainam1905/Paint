
namespace Paint
{
    partial class inputTinhTien
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
            this.tx = new System.Windows.Forms.NumericUpDown();
            this.ty = new System.Windows.Forms.NumericUpDown();
            this.btn_TinhTien = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông số của Vecto tịnh tiến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "x:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "y:";
            // 
            // tx
            // 
            this.tx.Location = new System.Drawing.Point(137, 112);
            this.tx.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(67, 27);
            this.tx.TabIndex = 3;
            // 
            // ty
            // 
            this.ty.Location = new System.Drawing.Point(137, 196);
            this.ty.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.ty.Name = "ty";
            this.ty.Size = new System.Drawing.Size(67, 27);
            this.ty.TabIndex = 4;
            // 
            // btn_TinhTien
            // 
            this.btn_TinhTien.Location = new System.Drawing.Point(76, 273);
            this.btn_TinhTien.Name = "btn_TinhTien";
            this.btn_TinhTien.Size = new System.Drawing.Size(94, 29);
            this.btn_TinhTien.TabIndex = 5;
            this.btn_TinhTien.Text = "tịnh tiến";
            this.btn_TinhTien.UseVisualStyleBackColor = true;
            this.btn_TinhTien.Click += new System.EventHandler(this.btn_TinhTien_Click);
            // 
            // inputTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 361);
            this.Controls.Add(this.btn_TinhTien);
            this.Controls.Add(this.ty);
            this.Controls.Add(this.tx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "inputTinhTien";
            this.Text = "inputTinhTien";
            ((System.ComponentModel.ISupportInitialize)(this.tx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tx;
        private System.Windows.Forms.NumericUpDown ty;
        private System.Windows.Forms.Button btn_TinhTien;
    }
}