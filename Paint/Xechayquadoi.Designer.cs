
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
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RunCar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pb2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.LightGray;
            this.pb1.Location = new System.Drawing.Point(-3, 105);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(974, 213);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Click += new System.EventHandler(this.pbDrawZone_Click);
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
            // pb2
            // 
            this.pb2.Location = new System.Drawing.Point(-3, 291);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(974, 230);
            this.pb2.TabIndex = 5;
            this.pb2.TabStop = false;
            this.pb2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Xechayquadoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(979, 760);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RunCar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb1);
            this.Name = "Xechayquadoi";
            this.Text = "Xechayquadoi";
            this.Load += new System.EventHandler(this.Xechayquadoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RunCar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb2;
    }
}