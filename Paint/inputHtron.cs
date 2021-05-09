using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class inputHtron : Form
    {
        public int xc;
        public int yc;
        public int R;
        public int x0;
        public int y0;
        public Boolean checkchange;
        public inputHtron(int x0, int y0)
        {
            InitializeComponent();
            this.x0 = x0;
            this.y0 = y0;
        }
        private void btn_draw_Click(object sender, EventArgs e)
        {
            xc = Int32.Parse(txt_xc.Text);
            yc = Int32.Parse(txt_yc.Text);
            R = Int32.Parse(txt_R.Text);
       
            xc = x0 + (xc * 5);
            yc = y0 - (yc * 5);
            R = R * 5;
            checkchange = true;
            this.Close();
        }
    }
}
