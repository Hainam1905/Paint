
namespace Paint
{
    partial class Xechayquadoi
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
            this.pbDrawZone = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RunCar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrawZone
            // 
            this.pbDrawZone.BackColor = System.Drawing.Color.LightGray;
            this.pbDrawZone.Location = new System.Drawing.Point(-3, 105);
            this.pbDrawZone.Name = "pbDrawZone";
            this.pbDrawZone.Size = new System.Drawing.Size(974, 650);
            this.pbDrawZone.TabIndex = 0;
            this.pbDrawZone.TabStop = false;
            this.pbDrawZone.Click += new System.EventHandler(this.pbDrawZone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(911, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tinh tuyen xe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunCar
            // 
            this.RunCar.Location = new System.Drawing.Point(164, 22);
            this.RunCar.Name = "RunCar";
            this.RunCar.Size = new System.Drawing.Size(94, 30);
            this.RunCar.TabIndex = 3;
            this.RunCar.Text = "Xe chạy";
            this.RunCar.UseVisualStyleBackColor = true;
            this.RunCar.Click += new System.EventHandler(this.RunCar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(783, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // Xechayquadoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(979, 760);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RunCar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbDrawZone);
            this.Name = "Xechayquadoi";
            this.Text = "Xechayquadoi";
            this.Load += new System.EventHandler(this.Xechayquadoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDrawZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RunCar;
        private System.Windows.Forms.Label label2;
    }
}