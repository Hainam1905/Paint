
namespace Paint
{
    partial class globularPopUp
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
            this.label4 = new System.Windows.Forms.Label();
            this.xO = new System.Windows.Forms.NumericUpDown();
            this.yO = new System.Windows.Forms.NumericUpDown();
            this.zO = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.rO = new System.Windows.Forms.NumericUpDown();
            this.btDrawGlobular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rO)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập vào tọa độ tâm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "xO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "yO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "zO";
            // 
            // xO
            // 
            this.xO.Location = new System.Drawing.Point(86, 118);
            this.xO.Name = "xO";
            this.xO.Size = new System.Drawing.Size(57, 27);
            this.xO.TabIndex = 4;
            // 
            // yO
            // 
            this.yO.Location = new System.Drawing.Point(253, 118);
            this.yO.Name = "yO";
            this.yO.Size = new System.Drawing.Size(57, 27);
            this.yO.TabIndex = 5;
            // 
            // zO
            // 
            this.zO.Location = new System.Drawing.Point(467, 118);
            this.zO.Name = "zO";
            this.zO.Size = new System.Drawing.Size(57, 27);
            this.zO.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhập vào bán kính hình cầu";
            // 
            // rO
            // 
            this.rO.Location = new System.Drawing.Point(241, 195);
            this.rO.Name = "rO";
            this.rO.Size = new System.Drawing.Size(57, 27);
            this.rO.TabIndex = 9;
            // 
            // btDrawGlobular
            // 
            this.btDrawGlobular.Location = new System.Drawing.Point(22, 306);
            this.btDrawGlobular.Name = "btDrawGlobular";
            this.btDrawGlobular.Size = new System.Drawing.Size(94, 29);
            this.btDrawGlobular.TabIndex = 10;
            this.btDrawGlobular.Text = "Bắt đầu vẽ";
            this.btDrawGlobular.UseVisualStyleBackColor = true;
            this.btDrawGlobular.Click += new System.EventHandler(this.btDrawGlobular_Click);
            // 
            // globularPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 446);
            this.Controls.Add(this.btDrawGlobular);
            this.Controls.Add(this.rO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zO);
            this.Controls.Add(this.yO);
            this.Controls.Add(this.xO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "globularPopUp";
            this.Text = "Nhập vào thông số của hình cầu";
            this.Load += new System.EventHandler(this.globularPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown xO;
        private System.Windows.Forms.NumericUpDown yO;
        private System.Windows.Forms.NumericUpDown zO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown rO;
        private System.Windows.Forms.Button btDrawGlobular;
    }
}