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
        public Htron htron;
        public Bitmap bm;
        public inputHtron()
        {
            InitializeComponent();
        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            xc = Int32.Parse(txt_xc.Text);
            yc = Int32.Parse(txt_yc.Text);
            R = Int32.Parse(txt_R.Text);
            /*xc = (bm.Width / 2) + (xc * 5);
            yc = (bm.Height / 2) - (yc * 5);
            R = R * 5;*/
            htron = new Htron(xc, yc, R);
            this.Close();
        }
    }
}
