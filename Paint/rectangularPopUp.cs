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

        private void rectangularPopUp_Load(object sender, EventArgs e)
        {

        }

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

            xOrec = Int32.Parse(xO.Text);
            yOrec = Int32.Parse(yO.Text);
            zOrec = Int32.Parse(zO.Text);

            checkDraw = true;
            this.Close(); 
        }
    }
}
