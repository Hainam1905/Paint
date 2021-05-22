using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Paint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Draw3D draw3D = new Draw3D();
            draw3D.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Xechayquadoi xechayquadoi = new Xechayquadoi();
            xechayquadoi.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
