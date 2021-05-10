using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class globularPopUp : Form
    {
        public int xOGlo, yOGlo, zOGlo;
        public int rOGlo;
        public bool checkDrawGlo = false; 
        public globularPopUp()
        {
            InitializeComponent();
        }

        private void btDrawGlobular_Click(object sender, EventArgs e)
        {
            xOGlo = int.Parse(xO.Value.ToString());
            yOGlo = int.Parse(yO.Value.ToString());
            zOGlo = int.Parse(zO.Value.ToString());

            rOGlo = int.Parse(rO.Value.ToString());
            checkDrawGlo = true;
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void globularPopUp_Load(object sender, EventArgs e)
        {

        }
    }
}
