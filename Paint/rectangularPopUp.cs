using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class rectangularPopUp : Form
    {

        public int lengthRec, heightRec, widthRec; 
        public int xOrec, yOrec, zOrec;

        private void width_ValueChanged(object sender, EventArgs e)
        {

        }

        public bool checkDraw = false; 
        public rectangularPopUp()
        {
            InitializeComponent();
        }

        private void btGetValue_Click(object sender, EventArgs e)
        {
            lengthRec = int.Parse(length.Value.ToString());
            heightRec = int.Parse(height.Value.ToString());
            widthRec = int.Parse(width.Value.ToString());

            xOrec = int.Parse(xO.Value.ToString());
            yOrec = int.Parse(yO.Value.ToString());
            zOrec = int.Parse(zO.Value.ToString());
            checkDraw = true;
            this.Close(); 
        }
    }
}
