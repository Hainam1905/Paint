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
        Double a = Math.Sqrt(2.0) / 4;
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
            //dung phep chieu cabinet: 
            rectangularPopUp rectangular = new rectangularPopUp();
            rectangular.ShowDialog();
            if (rectangular.checkDraw == false) return;
            else
            {

                int length = rectangular.lengthRec;
                int height = rectangular.heightRec;
                int width = rectangular.widthRec;
                
                int x = rectangular.xOrec; //xO
                int y = rectangular.yOrec;//yO
                int z = rectangular.zOrec; //zO

                int xO = rectangular.xOrec; //xO
                int yO = rectangular.yOrec;//yO
                int zO = rectangular.zOrec; //zO

                int xa, ya;
               int xb, yb;
               int xc, yc;
               int xd, yd;
               int xe, ye;
               int xf, yf;
               int xg, yg;
               int xh, yh;

                int xa0, ya0, za0;
                int xb0, yb0, zb0;
                int xc0, yc0, zc0;
                int xd0, yd0, zd0;
                int xe0, ye0, ze0;
                int xf0, yf0, zf0;
                int xg0, yg0, zg0;
                int xh0, yh0, zh0;

                //in toa do: 
                if (length % 2 == 1)
                {
                    xa0 = xO - length / 2;

                }
                else
                {
                    xa0 = xO - (length / 2 - 1);
                }
                if (width % 2 == 1)
                {
                    ya0 = yO - width / 2;
                }
                else
                {
                    ya0 = yO - (width / 2 - 1);
                }
                //toa do E: 
                xe0 = xa0;
                ye0 = ya0;
                //toa do B: 
                xb0 = xO + length / 2;
                yb0 = ya0;
                //toa do F: 
                xf0 = xb0;
                yf0 = yb0;

                //toa do C: 
                xc0 = xb0;
                yc0 = yO + width / 2;
                //toa do G: 
                xg0 = xc0;
                yg0 = yc0;
                //toa do D: 
                xd0 = xa0;
                yd0 = yc0;
                //toa do H: 
                xh0 = xd0;
                yh0 = yd0;

                za0 = zb0 = zc0 = zd0 = zO;
                ze0 = zf0 = zg0 = zh0 = zO + height;
                //ket thuc in toa do
                

                //tien xu ly: 
                xa = (int)((x + length / 2) - (y + width / 2) * a);
                ya = (int)(z - (y + width / 2) * a);

                
                xb = (int)((x - length / 2) - (y + width / 2) * a);
                yb = ya;

                
                xc = (int)((x - length / 2) - (y - width / 2) * a);
                yc = (int)(z - (y - width / 2) * a);

                
                xd = (int)((x + length / 2) - (y - width / 2) * a);
                yd = yc;

                
                xe = (int)((x + length / 2) - (y + width / 2) * a);
                ye = (int)(z + height - (y + width / 2) * a);

                
                xf = (int)((x - length / 2) - (y + width / 2) * a);
                yf = (int)(z + height - (y + width / 2) * a);

                
                xg = (int)((x - length / 2) - (y - width / 2) * a);
                yg = (int)(z + height - (y - width / 2) * a);

                
                xh = (int)((x + length / 2) - (y - width / 2) * a);
                yh = (int)(z + height - (y - width / 2) * a);

                /*if (length % 2 == 0)
                {
                    xb++;
                    xc++;
                    xf++;
                    xg++;
                }

                if (width % 2 == 0)
                {
                    yc++;
                    yd++;
                    yg++;
                    yh++;

                }*/

                drawPosition(xa0, ya0,za0, xc, yc);
                drawPosition(xb0, yb0, zb0, xd, yd);
                drawPosition(xc0, yc0, zc0, xa, ya);
                drawPosition(xd0, yd0, zd0, xb, yb);
                drawPosition(xe0, ye0, ze0, xg, yg);
                drawPosition(xf0, yf0, zf0, xh, yh);
                drawPosition(xg0, yg0, zg0, xe, ye);
                drawPosition(xh0, yh0, zh0, xf, yf);

                drawLineIn3D(xa, ya, xb, yb);
                drawLineDecrete(xb, yb, xc, yc);
                drawLineDecreteIn3D(xc, yc, xd, yd);
                drawLine(xd, yd, xa, ya);

                drawLineIn3D(xa, ya, xe, ye);
                drawLineIn3D(xb, yb, xf, yf);
                drawLineDecreteIn3D(xc, yc, xg, yg);
                drawLineIn3D(xd, yd, xh, yh);

                drawLineIn3D(xe, ye, xf, yf);
                drawLine(xf, yf, xg, yg);
                drawLineIn3D(xg, yg, xh, yh);
                drawLine(xh, yh, xe, ye);



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




            /*int xr = Ox - 5 * y + 5 * x;
            int yr = Oy + 5 * y - z * 5;*/

            int xr = (x + 40) * 5;
            int yr = (40-y) * 5; 
            Brush ve = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 10);
            PointF drawPoint = new PointF(xr, yr);

            g.DrawString("(" + x + "," + y + "," + z + ")", font, ve, drawPoint);
            g.FillRectangle(Brushes.Blue, xr , yr , 5, 5);
            pb3D.Image = bm3D;
        }
        void drawLine(int x1, int y1, int x2,int y2)
        {


            

            int xr1 = (x1 + 40) * 5;
            int yr1 = (40 - y1) * 5;

            int xr2 = (x2 + 40) * 5;
            int yr2 = (40 - y2) * 5;

            

            //width không tác động: 
            dt.DrawMidPoint(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 10);
            pb3D.Image = bm3D;
        }
        void drawPosition(int x0, int y0, int z0, int x,int y)
        {
            int xr1 = (x + 40) * 5;
            int yr1 = (40 - y) * 5;

            
            Brush ve = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 10);
            PointF drawPoint = new PointF(xr1, yr1);

            g.DrawString("("+x0+","+y0+","+z0+")", font, ve, drawPoint);
        }
        void drawLineIn3D(int x1, int y1, int x2, int y2)
        {


            /*int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;*/
            int xr1 = (x1 + 40) * 5;
            int yr1 = (40 - y1) * 5;

            int xr2 = (x2 + 40) * 5;
            int yr2 = (40 - y2) * 5;

            dt.DrawMidPointIn3D(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 1);
            pb3D.Image = bm3D;
        }
        void drawLineDecreteIn3D(int x1, int y1, int x2, int y2)
        {



            /*int xr1 = Ox - 5 * y1 + 5 * x1;
            int yr1 = Oy + 5 * y1 - z1 * 5;

            int xr2 = Ox - 5 * y2 + 5 * x2;
            int yr2 = Oy + 5 * y2 - z2 * 5;*/

            int xr1 = (x1 + 40) * 5;
            int yr1 = (40 - y1) * 5; 

            int xr2 = (x2 + 40) * 5;
            int yr2 = (40 - y2) * 5;

            dt.drawMidPointDeCreteIn3D(new Point(xr1, yr1), new Point(xr2, yr2), new Pen(Color.Black), 1);
            pb3D.Image = bm3D;
        }
        void drawLineDecrete(int x1, int y1, int x2, int y2)
        {


            /*
                        int xr1 = Ox - 5 * y1 + 5 * x1;
                        int yr1 = Oy + 5 * y1 - z1 * 5;

                        int xr2 = Ox - 5 * y2 + 5 * x2;
                        int yr2 = Oy + 5 * y2 - z2 * 5;*/

            int xr1 = (x1 + 40) * 5;
            int yr1 = (40 - y1) * 5;

            int xr2 = (x2 + 40) * 5;
            int yr2 = (40 - y2) * 5;

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
            double a = Math.Sqrt(2) / 4; 
            if (globular.checkDrawGlo == false) return;
            else
            {
                int xO = globular.xOGlo;
                int yO = globular.yOGlo;
                int zO = globular.zOGlo;
                int rO = globular.rOGlo;


                int xr =(int) (xO- yO * a);
                int yr = (int) (zO -yO * a);

                setPixelAtSpecificPosition(xO,yO,zO);
                dt.MidPointDrawCircleIn3D(xr, yr, rO, Color.Black);
                dt.drawElipIn3Horizontal(xr, yr, rO, rO / 2, Color.Black);
                //drawPosition(xO, yO, zO, xO, yO);
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
