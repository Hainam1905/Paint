using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class inputTinhTien : Form
    {
        public int x;
        public int y;
        public Boolean checkchange = false;
        public inputTinhTien()
        {
            InitializeComponent();
        }

        private void btn_TinhTien_Click(object sender, EventArgs e)
        {
            x = Int32.Parse(tx.Value.ToString());
            y = Int32.Parse(ty.Value.ToString());

            x *= 5;
            y *= -5;

            if (x==0 && y == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông số Vecto tịnh tiến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                checkchange = true;
                this.Close();
            }
                
        }
    }
}
