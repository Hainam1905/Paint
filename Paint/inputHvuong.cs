using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class inputHvuong : Form
    {
        public int xA;
        public int xB;
        public int xC;
        public int xD;
        public int yA;
        public int yB;
        public int yC;
        public int yD;
        public int a; // độ dài cạnh của hình vuông

        public int x0;
        public int y0;
        public Boolean checkchange = false;
        public inputHvuong(int x0,int y0)
        {
            InitializeComponent();
            this.x0 = x0;
            this.y0 = y0;
        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            this.xA = Int32.Parse(txt_xA.Text);
            this.yA = Int32.Parse(txt_yA.Text);
            this.a = Int32.Parse(txt_a.Text);
            a = a * 5;
            xA = x0 + (xA * 5);
            yA = y0 - (yA * 5);

            this.xB = xA + a;
            this.yB = yA;
            this.xC = xA + a;
            this.yC = yA + a;
            this.xD = xA;
            this.yD = yA + a;
            checkchange = true;
            this.Close();
        }
    }
}
