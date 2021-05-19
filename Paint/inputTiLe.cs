using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class inputTiLe : Form
    {
        public double Sx;
        public double Sy;
        public Boolean checkchange = false;

        public inputTiLe()
        {
            InitializeComponent();
        }

        private void btn_TiLe_Click(object sender, EventArgs e)
        {
            
            Sx = (double)this.ip_Sx.Value;
            Sy = (double)this.ip_Sy.Value;
            checkchange = true;
            this.Close();
        }
    }
}
