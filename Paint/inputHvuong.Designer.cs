
namespace Paint
{
    partial class inputHvuong
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_draw = new System.Windows.Forms.Button();
            this.txt_a = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_yA = new System.Windows.Forms.TextBox();
            this.txt_xA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "độ dài cạnh: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nhập tọa độ điểm đầu A:";
            // 
            // btn_draw
            // 
            this.btn_draw.Location = new System.Drawing.Point(71, 291);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(117, 42);
            this.btn_draw.TabIndex = 17;
            this.btn_draw.Text = "Draw";
            this.btn_draw.UseVisualStyleBackColor = true;
            this.btn_draw.Click += new System.EventHandler(this.btn_draw_Click);
            // 
            // txt_a
            // 
            this.txt_a.Location = new System.Drawing.Point(123, 228);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(62, 27);
            this.txt_a.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "a:";
            // 
            // txt_yA
            // 
            this.txt_yA.Location = new System.Drawing.Point(123, 163);
            this.txt_yA.Name = "txt_yA";
            this.txt_yA.Size = new System.Drawing.Size(62, 27);
            this.txt_yA.TabIndex = 14;
            // 
            // txt_xA
            // 
            this.txt_xA.Location = new System.Drawing.Point(123, 115);
            this.txt_xA.Name = "txt_xA";
            this.txt_xA.Size = new System.Drawing.Size(62, 27);
            this.txt_xA.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "yA: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "xA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nhập thông tin hình vuông ";
            // 
            // inputHvuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 387);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_draw);
            this.Controls.Add(this.txt_a);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_yA);
            this.Controls.Add(this.txt_xA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "inputHvuong";
            this.Text = "inputHvuong";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_draw;
        private System.Windows.Forms.TextBox txt_a;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_yA;
        private System.Windows.Forms.TextBox txt_xA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}