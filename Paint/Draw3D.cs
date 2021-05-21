using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint

{
    public partial class Draw3D : Form
    {
        DrawTool dt;
        Graphics g;
        Bitmap bm3D;
        int i = 0;
        int Ox = 200;
        int Oy = 200;
        public Draw3D()
        {
            InitializeComponent();
            start3D(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void start3D()
        {
            bm3D = new Bitmap(pb3D.Width, pb3D.Height);
            g = Graphics.FromImage(bm3D);
            dt = new DrawTool(bm3D, label13);
            g.Clear(Color.LightGray); 
            tructoado();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rectangularPopUp rectangular = new rectangularPopUp();
            rectangular.ShowDialog();
            if (rectangular.checkDraw == false) return;
            else
            {

                int length = rectangular.lengthRec;
                int height = rectangular.heightRec;
                int width = rectangular.widthRec;

                int xO = rectangular.xOrec;
                int yO = rectangular.yOrec;
                int zO = rectangular.zOrec; 

               int xa, ya, za;
               int xb, yb, zb;
               int xc, yc, zc;
               int xd, yd, zd;
               int xe, ye, ze;
               int xf, yf, zf;
               int xg, yg, zg;
               int xh, yh, zh;

               if (length % 2 == 1)
               {
                   xa = xO - length / 2;

               }
               else
               {
                   xa = xO - (length / 2 - 1);
               }
               if (width % 2 == 1)
               {
                   ya = yO - width / 2;
               }
               else
               {
                   ya = yO - (width / 2 - 1);
               }
               //toa do E: 
               xe = xa;
               ye = ya;
               //toa do B: 
               xb = xO + length / 2;
               yb = ya;
               //toa do F: 
               xf = xb;
               yf = yb;

               //toa do C: 
               xc = xb;
               yc = yO + width / 2;
               //toa do G: 
               xg = xc;
               yg = yc;
               //toa do D: 
               xd = xa;
               yd = yc;
               //toa do H: 
               xh = xd;
               yh = yd;

               za = zb = zc = zd = zO;
               ze = zf = zg = zh = zO + height;

               drawLineDecreteIn3D(xa, ya, za, xb, yb, zb);
               drawLine( xb, yb, zb, xc, yc, zc);
               drawLineIn3D( xc, yc, zc, xd, yd, zd);
               drawLineDecrete(xd, yd, zd,xa,ya,za);

               drawLineDecreteIn3D(xa, ya, za, xe, ye, ze);
               drawLineIn3D(xb, yb, zb, xf, yf, zf);
               drawLineIn3D(xc, yc, zc, xg, yg, zg);
               drawLineIn3D(xd, yd, zd, xh, yh, zh);

               drawLineIn3D(xe, ye, ze,xf,yf,zf);
               drawLine(xf, yf, zf,xg,yg,zg);
               drawLineIn3D(xg, yg, zg,xh,yh,zh);
               drawLine(xh, yh, zh, xe, ye, ze);
           
            }


        }
        void tructoado()
        {
            int temp2 = 0;
            for (int i = 40; i <= 140; i++)
            {
                g.DrawLine(new Pen(Color.White), 5 * i, 0, 5 * i, 200);//doc
                if (i * 5 <= 400)
                {
                    g.DrawLine(new Pen(Color.White), 200, temp2, 0, i * 5);//cheo

                }
                g.DrawLine(new Pen(Color.White), 5 * i, 200, 0 + temp2, 400);//cheo
                g.DrawLine(new Pen(Color.White), (i - 40) * 5, 400 - temp2, 600, 400 - temp2);//ngang
                temp2 += 5;
            }

            int temp = 10;
            for (int i = 0; i <= 40; i++)
            {

                g.DrawLine(new Pen(Color.White), 200, 5 * i, 600, 5 * i);//ngang
                g.DrawLine(new Pen(Color.White), i * 5, 0, 5 * i, 400 - i * 5);//doc


                if (i > 20)
                {
                    g.DrawLine(new Pen(Color.White), 200, temp, 0, i * 10);//cheo oy
                    g.DrawLine(new Pen(Color.White), i * 5, 0, 0, i * 5);//cheo oz
                    temp += 10;
                }
                else
                {
                    g.DrawLine(new Pen(Color.White), i * 10, 0, 0, i * 10);
                    g.DrawLine(new Pen(Color.White), i * 5, 0, 0, i * 5);
                }

            }

            //goc toa do ao: (200,200)
            //3 truc
            g.DrawLine(new Pen(Color.Red), 200, 200, 600, 200);//ox
            g.DrawLine(new Pen(Color.Red), 200, 0, 200, 200);//oz
            g.DrawLine(new Pen(Color.Red), 200, 200, 0, 400);//oy
            
            pb3D.Image = bm3D;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void setPixelAtSpecificPosition(int x, int y,int z)
        {
            
            
            

            int xr = Ox - 5 * y + 5 * x;
            int yr = Oy + 5 * y - z * 5;
            g.FillRectangle(Brushes.Blue, xr , yr , 5, 5);
            pb3D.Image = bm3D;
        }
        void drawLine(int x1, int y1, int z1, int x2,int y2, int z2)
        {
            

            int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;

            //width không tác động: 
            dt.DrawMidPoint(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 10);
            pb3D.Image = bm3D;
        }
        void drawLineIn3D(int x1, int y1, int z1, int x2, int y2, int z2)
        {


            int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;

            dt.DrawMidPointIn3D(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 1);
            pb3D.Image = bm3D;
        }
        void drawLineDecreteIn3D(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            


            int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;
            dt.drawMidPointDeCreteIn3D(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 1);
            pb3D.Image = bm3D;
        }
        void drawLineDecrete(int x1, int y1, int z1, int x2, int y2, int z2)
        {



            int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;
            dt.drawMidPointDeCrete(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 1);
            pb3D.Image = bm3D;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public void putPosition(int x, int y,int z,int xr,int yr)
        {

            Brush ve = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 10);
            PointF drawPoint = new PointF(xr, yr);
            g.DrawString("(" + x + "," + y + "," + z + ")", font, ve, drawPoint);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                                    
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btDrawElip_Click(object sender, EventArgs e)
        {
            globularPopUp globular = new globularPopUp();
            globular.ShowDialog();

            if (globular.checkDrawGlo == false) return;
            else
            {
                int xO = globular.xOGlo;
                int yO = globular.yOGlo;
                int zO = globular.zOGlo;
                int rO = globular.rOGlo;

                int xr = Ox - 5 * yO + 5 * xO;
                int yr = Oy + 5 * yO - zO * 5;
                setPixelAtSpecificPosition(xO,yO,zO);
                dt.MidPointDrawCircleIn3D(xr, yr, rO, Color.Black);
                dt.drawElipIn3Horizontal(xr, yr, rO, rO / 2, Color.Black);
                pb3D.Image = bm3D;
            }
            
            

        }

        private void pb3D_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.LightGray);
            tructoado();
        }
    }
}
