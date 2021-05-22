using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class inputHelip : Form
    {
        public int xc;
        public int yc;
        public int a;
        public int b;
        public int x0;
        public int y0;
        public Boolean checkchange = false;
        public inputHelip(int x0,int y0)
        {
            InitializeComponent();
            this.x0 = x0;
            this.y0 = y0;
        }

        private void txt_a_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            this.xc = Int32.Parse(txt_xc.Text);
            this.yc = Int32.Parse(txt_yc.Text);
            this.a = Int32.Parse(txt_a.Text);
            this.b = Int32.Parse(txt_b.Text);

            a = a * 5;
            b = b * 5;

            xc = x0 + (xc * 5);
            yc = y0 - (yc * 5);

            this.checkchange = true;
            this.Close();
        }
    }
}
