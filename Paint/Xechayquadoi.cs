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
    public partial class Xechayquadoi : Form
    {
        private Bitmap bm;
        private Bitmap bm2;
        
        DrawTool dt;
        DrawTool dt2;
        private Graphics gp;
        private Color clLine = Color.Black;
        private int widthLine = 1;
        int xStartFromLeftToRight = 10;
        int xLorryStartFromLeftToRight = 150;
        int yStartFromLeftToRight = 375;
        int xStartFromRightToLeft = 580;
        int xLorryStartFromRightToLeft = 750;
        int yStartFromRightToLeft = 270;
        int xTankStartFromLeftToRight = 320;
        int xTankStartFromRightToLeft = 400;
        ThreadStart threadstart;
        int xSun = 590;
        int ySun = 80;
        int tempySun = 80;
        bool check = false;


        public Xechayquadoi()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            start();
        }
        private void start()
        {
            bm = new Bitmap(pbDrawZone.Width, pbDrawZone.Height);
            bm2 = new Bitmap(pbDrawZone.Width, pbDrawZone.Height);
            bm2 = bm; 
            dt = new DrawTool(bm, label1);
            dt2 = new DrawTool(bm2, label1);
            gp = Graphics.FromImage(bm);
            pbDrawZone.Image = bm;
        }
        private void Xechayquadoi_Load(object sender, EventArgs e)
        {
            
            gp.Clear(Color.LightGray);
            drawHill(Color.Black);
            paintHill(Color.Brown);
            drawStreet();
            drawForest();
            drawSun(590, 80);
            paintSun(xSun, ySun, Color.Red);



            ////drawMoon(590, 80);


            paintSkyandSoid(Color.LightBlue, Color.LightYellow);
            paintStreet();

            drawCarLeftToRight(xStartFromLeftToRight, yStartFromLeftToRight);

            pbDrawZone.Image = bm; 
            /*car.setConfig(dt, bm, pbDrawZone.Image);
            car.drawCarLeftToRight(10, 375);*/
        }
        public void drawCarLeftToRight(int x, int y)
        {

            //bm2 = bm; 
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x + 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x + 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 80, y - 30), new Point(x + 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 40), new Point(x + 80, y - 40), p);

            //cua so: 
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 7), new Point(x + 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 80, y - 20), new Point(x + 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x + 80, y - 7), new Point(x + 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x + 60, y - 20), new Point(x + 40, y - 7), p);
            //banh xe
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x + 5, y - 5), Color.Pink);
            dt2.FillColor(new Point(x + 30, y - 12), Color.Blue);
            dt2.FillColor(new Point(x + 70, y - 12), Color.Orange);

           
        }

        public void translatingCarLeftToRight()
        {


            //bm2 = bm; 
            int y = yStartFromLeftToRight;
            int x = xStartFromLeftToRight;
            for (int i = 0; i < 100; i++)
            {
                //xoa xe vi tri cu: 
                x = xStartFromLeftToRight;
                dt2.FillColor(new Point(x + 5, y - 5), Color.Gray);
                dt2.FillColor(new Point(x + 30, y - 12), Color.Gray);
                dt2.FillColor(new Point(x + 70, y - 12), Color.Gray);

                Pen p = new Pen(Color.Gray, widthLine);

                dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
                dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
                dt2.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);

                dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x + 20, y - 30), p);
                dt2.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 80, y - 30), p);
                dt2.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x + 30, y - 40), p);
                dt2.DrawMidPointAnimation(new Point(x + 80, y - 30), new Point(x + 80, y - 40), p);
                dt2.DrawMidPointAnimation(new Point(x + 30, y - 40), new Point(x + 80, y - 40), p);

                //cua so: 
                dt2.DrawMidPointAnimation(new Point(x + 15, y - 7), new Point(x + 15, y - 20), p);
                dt2.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 80, y - 20), p);
                dt2.DrawMidPointAnimation(new Point(x + 80, y - 20), new Point(x + 80, y - 7), p);
                dt2.DrawMidPointAnimation(new Point(x + 80, y - 7), new Point(x + 15, y - 7), p);
                dt.DrawMidPointAnimation(new Point(x + 60, y - 20), new Point(x + 40, y - 7), p);
                //banh xe
                dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
                dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
                dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
                dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);

                //ve lai xe: 
                xStartFromLeftToRight += 5;
                drawCarLeftToRight(xStartFromLeftToRight, yStartFromLeftToRight);

                /*//ve xe vi tri moi
                dt.DrawMidPoint(new Point(x, y), new Point(x + 120, y), p);
                dt.DrawMidPoint(new Point(x, y), new Point(x, y - 30), p);
                dt.DrawMidPoint(new Point(x + 120, y), new Point(x + 120, y - 15), p);

                dt.DrawMidPoint(new Point(x, y - 30), new Point(x + 20, y - 30), p);
                dt.DrawMidPoint(new Point(x + 120, y - 15), new Point(x + 80, y - 30), p);
                dt.DrawMidPoint(new Point(x + 20, y - 30), new Point(x + 30, y - 40), p);
                dt.DrawMidPoint(new Point(x + 80, y - 30), new Point(x + 80, y - 40), p);
                dt.DrawMidPoint(new Point(x + 30, y - 40), new Point(x + 80, y - 40), p);

                //cua so: 
                dt.DrawMidPoint(new Point(x + 15, y - 7), new Point(x + 15, y - 23), p);
                dt.DrawMidPoint(new Point(x + 15, y - 23), new Point(x + 80, y - 23), p);
                dt.DrawMidPoint(new Point(x + 80, y - 23), new Point(x + 80, y - 7), p);
                dt.DrawMidPoint(new Point(x + 80, y - 7), new Point(x + 15, y - 7), p);
                dt.DrawMidPoint(new Point(x + 60, y - 23), new Point(x + 40, y - 7), p);
                //banh xe
                dt.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
                dt.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
                dt.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
                dt.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);

                dt.FillColor(new Point(x + 5, y - 5), Color.Pink);
                dt.FillColor(new Point(x + 30, y - 15), Color.Blue);
                dt.FillColor(new Point(x + 70, y - 15), Color.Orange);*/
                //bm = bm2; 
                pbDrawZone.Image = bm;
                Thread.Sleep(100);
            }


        }
        void drawSun(int x, int y)
        {
        
            dt.MidPointDrawCircleAnimation(x, y, 65, Color.Yellow);
        }
        void paintSun(int x, int y, Color color)
        {
            dt.FillColor(new Point(x, y), color);
        }
        void drawMoon(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.MidPointDrawHaftCircle(x, y, 65, Color.Black);
            dt.drawHaftElip(x - 10, y, 30, 65, Color.Black);
            dt.FillColor(new Point(x + 60, y), Color.Yellow);
        }

        public void sunGoDown()
        {

            for (int i = 1; i < 15; i++)
            {
                if (check == false)
                {
                    //xoa mat troi cu: 
                    dt.MidPointDrawCircleAnimation(xSun, tempySun, 65, Color.LightBlue);
                    paintSun(xSun, tempySun, Color.LightBlue);

                    //xoa doi va ve lai:
                    clearHill();
                    drawHill(Color.Black);
                    paintHill(Color.Brown);

                    //mat troi tai vi tri moi: 
                    tempySun += 5;



                    if (tempySun < (ySun + 60))
                    {
                        drawSun(xSun, tempySun);
                        paintSun(xSun, tempySun, Color.Red);

                    }
                    else
                    {
                        //clearHill();

                        drawMoon(xSun, ySun);
                        paintSkyandSoid(Color.DarkViolet, Color.DarkSalmon);
                        check = true;
                    }
                    //drawStreet();
                    pbDrawZone.Image = bm;
                    Thread.Sleep(100);

                }
                else return; 

            }

        }
        void drawForest()
        {
            //drawTree(30, 500);
            drawTree(70, 600);
            drawTree(150, 550);
            drawTree(180, 630);
            //drawTree(280, 490);
            drawTree(320, 560);
            drawTree(380, 620);
            drawTree(440, 570);
            drawTree(525, 504);
            drawTree(578, 620);
            drawTree(650, 597);
            drawTree(700, 510);
            drawTree(800, 610);
            drawTree(900, 510);



        }
        void drawLorryLeftToRight(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x + 100, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt.DrawMidPoint(new Point(x, y - 50), new Point(x + 100, y - 50), p);
            dt.DrawMidPoint(new Point(x + 100, y - 50), new Point(x + 100, y), p);
            dt.DrawMidPoint(new Point(x + 100, y), new Point(x + 150, y), p);
            dt.DrawMidPoint(new Point(x + 150, y), new Point(x + 150, y - 35), p);
            dt.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 100, y - 35), p);
            dt.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 150, y - 40), p);
            dt.DrawMidPoint(new Point(x + 150, y - 40), new Point(x + 100, y - 50), p);

            dt.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 80, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 80, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 130, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 130, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x + 50, y - 20), Color.Cyan);
            dt.FillColor(new Point(x + 120, y - 10), Color.DarkGreen);
            dt.FillColor(new Point(x + 105, y - 43), Color.Pink);
        }
        void drawLorryRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x - 100, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt.DrawMidPoint(new Point(x, y - 50), new Point(x - 100, y - 50), p);
            dt.DrawMidPoint(new Point(x - 100, y - 50), new Point(x - 100, y), p);
            dt.DrawMidPoint(new Point(x - 100, y), new Point(x - 150, y), p);
            dt.DrawMidPoint(new Point(x - 150, y), new Point(x - 150, y - 35), p);
            dt.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 100, y - 35), p);
            dt.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 150, y - 40), p);
            dt.DrawMidPoint(new Point(x - 150, y - 40), new Point(x - 100, y - 50), p);

            dt.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 80, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 80, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 130, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 130, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x - 50, y - 20), Color.Cyan);
            dt.FillColor(new Point(x - 120, y - 10), Color.DarkGreen);
            dt.FillColor(new Point(x - 105, y - 43), Color.Pink);
        }

        void drawCarRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);


            dt.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt.DrawMidPointAnimation(new Point(x - 60, y - 23), new Point(x - 40, y - 7), p);
            //banh xe
            dt.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x - 5, y - 5), Color.Pink);
            dt.FillColor(new Point(x - 30, y - 15), Color.Blue);
            dt.FillColor(new Point(x - 70, y - 15), Color.Orange);

        }
        void drawTankLeftToRight(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);
            dt.DrawMidPointAnimation(new Point(x, y - 15), new Point(x + 10, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 110, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x + 10, y - 25), new Point(x + 110, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x + 30, y - 25), new Point(x + 30, y - 45), p);
            dt.DrawMidPointAnimation(new Point(x + 90, y - 25), new Point(x + 90, y - 35), p);
            dt.DrawMidPointAnimation(new Point(x + 30, y - 45), new Point(x + 130, y - 45), p);
            dt.DrawMidPointAnimation(new Point(x + 90, y - 35), new Point(x + 130, y - 35), p);
            dt.DrawMidPointAnimation(new Point(x + 130, y - 45), new Point(x + 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt.MidPointDrawCircle(x + 10, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 10, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 30, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 30, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 50, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 50, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 70, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 70, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 110, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 110, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x + 20, y - 10), Color.DarkGreen);
            dt.FillColor(new Point(x + 35, y - 35), Color.DarkGreen);
        }
        void drawTankRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);
            dt.DrawMidPointAnimation(new Point(x, y - 15), new Point(x - 10, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 110, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x - 10, y - 25), new Point(x - 110, y - 25), p);
            dt.DrawMidPointAnimation(new Point(x - 30, y - 25), new Point(x - 30, y - 45), p);
            dt.DrawMidPointAnimation(new Point(x - 90, y - 25), new Point(x - 90, y - 35), p);
            dt.DrawMidPointAnimation(new Point(x - 30, y - 45), new Point(x - 130, y - 45), p);
            dt.DrawMidPointAnimation(new Point(x - 90, y - 35), new Point(x - 130, y - 35), p);
            dt.DrawMidPointAnimation(new Point(x - 130, y - 45), new Point(x - 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt.MidPointDrawCircle(x - 10, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 10, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 30, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 30, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 50, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 50, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 70, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 70, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x - 110, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x - 110, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x - 20, y - 10), Color.DarkGreen);
            dt.FillColor(new Point(x - 35, y - 35), Color.DarkGreen);
        }
        void paintSkyandSoid(Color colorSky, Color colorSoid)
        {
           
            //to bau troi
            dt.FillColor(new Point(20, 20), colorSky);
            dt.FillColor(new Point(20, 630), colorSoid);
        }
        void drawStreet()
        {
            
            Pen p = new Pen(clLine, widthLine);
            //ve khung vien
            dt.DrawMidPointAnimation(new Point(3, 10), new Point(3, 210), p);
            dt.DrawMidPointAnimation(new Point(3, 10), new Point(970, 10), p);
            dt.DrawMidPointAnimation(new Point(970, 10), new Point(970, 210), p);
            dt.DrawMidPointAnimation(new Point(3, 210), new Point(3, 640), p);
            dt.DrawMidPointAnimation(new Point(3, 640), new Point(970, 640), p);
            dt.DrawMidPointAnimation(new Point(970, 210), new Point(970, 640), p);

            dt.DrawMidPointAnimation(new Point(0, 400), new Point(1000, 400), p);
            dt.DrawMidPointAnimation(new Point(3, 210), new Point(3, 400), p);
            dt.DrawMidPointAnimation(new Point(970, 210), new Point(970, 400), p);
            desparateLine(100, 300);
            desparateLine(300, 300);
            desparateLine(500, 300);
            desparateLine(700, 300);
            desparateLine(900, 300);
        }
        void paintStreet()
        {
            
            //to mau duong
            dt.FillColor(new Point(500, 390), Color.Gray);
            //to mau vach phan cach
            dt.FillColor(new Point(120, 310), Color.Yellow);
            dt.FillColor(new Point(340, 310), Color.Yellow);
            dt.FillColor(new Point(540, 310), Color.Yellow);
            dt.FillColor(new Point(740, 310), Color.Yellow);
            dt.FillColor(new Point(940, 310), Color.Yellow);
        }
        void paintStreetFake()
        {
           
            //to mau duong
            dt.FillColor(new Point(500, 390), Color.LightGray);

        }
        void desparateLine(int x, int y)
        {
            int xtop = x;
            int ytop = y;
            int xbottom = xtop - 20;
            int ybottom = ytop + 20;
            int tempxtop = xtop + 100;
            int tempxbottom = xbottom + 100;



            
            Pen p = new Pen(clLine, widthLine);

            dt.DrawMidPointAnimation(new Point(xtop, ytop), new Point(xbottom, ybottom), p);
            dt.DrawMidPointAnimation(new Point(xtop, ytop), new Point(tempxtop, ytop), p);
            dt.DrawMidPointAnimation(new Point(xbottom, ybottom), new Point(tempxbottom, ybottom), p);
            dt.DrawMidPointAnimation(new Point(tempxbottom, ybottom), new Point(tempxtop, ytop), p);

        }
        void drawHill(Color color)
        {
            bm2 = bm; 
            Pen p = new Pen(color, widthLine);
            dt2.DrawMidPointAnimation(new Point(0, 210), new Point(1000, 210), p);
            
            //hill 1
            dt2.DrawMidPointAnimation(new Point(0, 210), new Point(100, 100),p);
            dt2.DrawMidPointAnimation(new Point(100, 100), new Point(250, 210), p);


            //hill 2
            dt2.DrawMidPointAnimation(new Point(140, 130), new Point(220, 50), p);
            dt2.DrawMidPointAnimation(new Point(220, 50), new Point(300, 130), p);


            //hill 3
            dt2.DrawMidPointAnimation(new Point(250, 210), new Point(330, 80), p);
            dt2.DrawMidPointAnimation(new Point(330, 80), new Point(410, 210), p);

            //hill 4
            dt2.DrawMidPointAnimation(new Point(380, 155), new Point(440, 100), p);
            dt2.DrawMidPointAnimation(new Point(440, 100), new Point(480, 150), p);
            //hill 5
            dt2.DrawMidPointAnimation(new Point(405, 210), new Point(520, 120), p);
            dt2.DrawMidPointAnimation(new Point(520, 120), new Point(580, 210), p);

            //hill 6
            dt2.DrawMidPointAnimation(new Point(605, 210), new Point(655, 130), p);
            dt2.DrawMidPointAnimation(new Point(655, 130), new Point(700, 210), p);
            //hill 7
            dt2.DrawMidPointAnimation(new Point(675, 160), new Point(735, 90), p);
            dt2.DrawMidPointAnimation(new Point(735, 90), new Point(780, 210), p);

            //hill 8
            dt2.DrawMidPointAnimation(new Point(755, 140), new Point(860, 70), p);
            dt2.DrawMidPointAnimation(new Point(860, 70), new Point(970, 210), p);

            bm = bm2; 
            //pbDrawZone.Image = bm2;
        }
        void paintHill(Color color)
        {
            bm2 = bm; 
            //to mau doi nui
            dt2.FillColor(new Point(125, 200), color);
            dt2.FillColor(new Point(200, 120), color);
            dt2.FillColor(new Point(300, 180), color);
            dt2.FillColor(new Point(430, 140), color);
            dt2.FillColor(new Point(500, 200), color);
            dt2.FillColor(new Point(680, 200), color);
            dt2.FillColor(new Point(700, 200), color);
            dt2.FillColor(new Point(850, 200), color);

            bm = bm2; 
            //pbDrawZone.Image = bm2; 
        }
        void paintHillFake()
        {
           
            //to mau doi nui
            dt.FillColor(new Point(125, 200), Color.Purple);
            dt.FillColor(new Point(200, 120), Color.Purple);
            dt.FillColor(new Point(300, 180), Color.Purple);
            dt.FillColor(new Point(430, 140), Color.Purple);
            dt.FillColor(new Point(500, 200), Color.Purple);
            dt.FillColor(new Point(680, 200), Color.Purple);
            dt.FillColor(new Point(700, 200), Color.Purple);
            dt.FillColor(new Point(850, 200), Color.Purple);
        }
        void drawTree(int x, int y)
        {
            
            
            Pen p = new Pen(clLine, widthLine);
            int xleft = x;
            int yleft = y;
            int xright = xleft + 20;
            int yright = yleft;

            int tempxLeft = xleft;
            int tempyLeft = yleft - 30;

            int tempxRight = xright;
            int tempyRight = yright - 30;
            dt.DrawMidPointAnimation(new Point(xleft, yleft), new Point(xright, yright), p);
            dt.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 30;
            tempxRight += 30;

            //dt.DrawMidPoint(new Point(xleft, yleft),, p);
            dt.DrawMidPointAnimation(new Point(tempxLeft, tempyLeft), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            tempxLeft += 20;
            tempxRight -= 20;
            tempyLeft -= 20;
            tempyRight -= 20;
            dt.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 20;
            tempxRight += 20;

            dt.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            x += 10;
            tempyLeft -= 35;
            tempyRight -= 35;
            dt.DrawMidPointAnimation(new Point(xleft, yleft), new Point(x, tempyLeft), p);
            dt.DrawMidPointAnimation(new Point(xright, yright), new Point(x, tempyRight), p);

            int ypaint = y - 40;
            int xpaint = x + 10;
            dt.FillColor(new Point(xpaint, ypaint), Color.Green);

            ypaint = y - 15;
            xpaint = x + 5;
            dt.FillColor(new Point(xpaint, ypaint), Color.RosyBrown);
            pbDrawZone.Image = bm; 
        }


        void translatingTankLeftToRight(int x, int y)
        {
            
            dt.FillColor(new Point(x + 20, y - 10), Color.Gray);
            dt.FillColor(new Point(x + 35, y - 35), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x + 120, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 15), p);
            dt.DrawMidPoint(new Point(x + 120, y), new Point(x + 120, y - 15), p);
            dt.DrawMidPoint(new Point(x, y - 15), new Point(x + 10, y - 25), p);
            dt.DrawMidPoint(new Point(x + 120, y - 15), new Point(x + 110, y - 25), p);
            dt.DrawMidPoint(new Point(x + 10, y - 25), new Point(x + 110, y - 25), p);
            dt.DrawMidPoint(new Point(x + 30, y - 25), new Point(x + 30, y - 45), p);
            dt.DrawMidPoint(new Point(x + 90, y - 25), new Point(x + 90, y - 35), p);
            dt.DrawMidPoint(new Point(x + 30, y - 45), new Point(x + 130, y - 45), p);
            dt.DrawMidPoint(new Point(x + 90, y - 35), new Point(x + 130, y - 35), p);
            dt.DrawMidPoint(new Point(x + 130, y - 45), new Point(x + 130, y - 35), p);


            //banh xe: 
            
            dt.MidPointDrawCircle(x + 10, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 10, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 30, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 30, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 50, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 50, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 70, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 70, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 110, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 110, y + 10, 3, Color.Gray);


            //ve lai xe tank: 
            xTankStartFromLeftToRight += 5;
            drawTankLeftToRight(xTankStartFromLeftToRight, yStartFromLeftToRight);
        }
        void translatingTankRightToLeft(int x, int y)
        {
            
            dt.FillColor(new Point(x - 20, y - 10), Color.Gray);
            dt.FillColor(new Point(x - 35, y - 35), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x - 120, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 15), p);
            dt.DrawMidPoint(new Point(x - 120, y), new Point(x - 120, y - 15), p);
            dt.DrawMidPoint(new Point(x, y - 15), new Point(x - 10, y - 25), p);
            dt.DrawMidPoint(new Point(x - 120, y - 15), new Point(x - 110, y - 25), p);
            dt.DrawMidPoint(new Point(x - 10, y - 25), new Point(x - 110, y - 25), p);
            dt.DrawMidPoint(new Point(x - 30, y - 25), new Point(x - 30, y - 45), p);
            dt.DrawMidPoint(new Point(x - 90, y - 25), new Point(x - 90, y - 35), p);
            dt.DrawMidPoint(new Point(x - 30, y - 45), new Point(x - 130, y - 45), p);
            dt.DrawMidPoint(new Point(x - 90, y - 35), new Point(x - 130, y - 35), p);
            dt.DrawMidPoint(new Point(x - 130, y - 45), new Point(x - 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt.MidPointDrawCircle(x - 10, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 10, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 30, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 30, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 50, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 50, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 70, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 70, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 110, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 110, y + 10, 3, Color.Gray);




            //ve lai xe tank: 
            xTankStartFromRightToLeft -= 5;
            drawTankRightToLeft(xTankStartFromRightToLeft, yStartFromRightToLeft);
        }
        void translatingLorryLeftToRight(int x, int y)
        {
           
            dt.FillColor(new Point(x + 50, y - 20), Color.Gray);
            dt.FillColor(new Point(x + 120, y - 10), Color.Gray);
            dt.FillColor(new Point(x + 105, y - 43), Color.Gray);


            Pen p = new Pen(Color.Gray, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x + 100, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt.DrawMidPoint(new Point(x, y - 50), new Point(x + 100, y - 50), p);
            dt.DrawMidPoint(new Point(x + 100, y - 50), new Point(x + 100, y), p);
            dt.DrawMidPoint(new Point(x + 100, y), new Point(x + 150, y), p);
            dt.DrawMidPoint(new Point(x + 150, y), new Point(x + 150, y - 35), p);
            dt.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 100, y - 35), p);
            dt.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 150, y - 40), p);
            dt.DrawMidPoint(new Point(x + 150, y - 40), new Point(x + 100, y - 50), p);

            dt.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 80, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 80, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x + 130, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x + 130, y + 10, 3, Color.Gray);

            //ve lai xe: 
            xLorryStartFromLeftToRight += 5;
            drawLorryLeftToRight(xLorryStartFromLeftToRight, yStartFromLeftToRight);
        }
        void translatingCarRightToLeft(int x, int y)
        {
            
            dt.FillColor(new Point(x - 5, y - 5), Color.Gray);
            dt.FillColor(new Point(x - 30, y - 15), Color.Gray);
            dt.FillColor(new Point(x - 70, y - 15), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x - 120, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 30), p);
            dt.DrawMidPoint(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt.DrawMidPoint(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt.DrawMidPoint(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt.DrawMidPoint(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt.DrawMidPoint(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt.DrawMidPoint(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);


            dt.DrawMidPoint(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt.DrawMidPoint(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt.DrawMidPoint(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt.DrawMidPoint(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt.DrawMidPoint(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
            //banh xe
            dt.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);

            //ve lai xe: 
            xStartFromRightToLeft -= 5;
            drawCarRightToLeft(xStartFromRightToLeft, yStartFromRightToLeft);

        }
        void translatingLorryRightToLeft(int x, int y)
        {
            
            dt.FillColor(new Point(x - 50, y - 20), Color.Gray);
            dt.FillColor(new Point(x - 120, y - 10), Color.Gray);
            dt.FillColor(new Point(x - 105, y - 43), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt.DrawMidPoint(new Point(x, y), new Point(x - 100, y), p);
            dt.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt.DrawMidPoint(new Point(x, y - 50), new Point(x - 100, y - 50), p);
            dt.DrawMidPoint(new Point(x - 100, y - 50), new Point(x - 100, y), p);
            dt.DrawMidPoint(new Point(x - 100, y), new Point(x - 150, y), p);
            dt.DrawMidPoint(new Point(x - 150, y), new Point(x - 150, y - 35), p);
            dt.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 100, y - 35), p);
            dt.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 150, y - 40), p);
            dt.DrawMidPoint(new Point(x - 150, y - 40), new Point(x - 100, y - 50), p);

            dt.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 80, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 80, y + 10, 3, Color.Gray);
            dt.MidPointDrawCircle(x - 130, y + 10, 10, Color.Gray);
            dt.MidPointDrawCircle(x - 130, y + 10, 3, Color.Gray);

            //ve lai xe: 
            xLorryStartFromRightToLeft -= 5;
            drawLorryRightToLeft(xLorryStartFromRightToLeft, yStartFromRightToLeft);

        }
        private void StartDraw_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            move();
            //sunGoDown(); 
            //moveCar(); 
        }
        void move()
        {
             threadstart = new ThreadStart(sunGoDown);
            Thread threadSun = new Thread(threadstart);
            threadSun.Start(); 
            //sunGoDown(); 
        }
        void moveCar()
        {
            ThreadStart threadStartOfCar = new ThreadStart(translatingCarLeftToRight);
            Thread threadCar = new Thread(threadStartOfCar);
            threadCar.Start(); 
        }

        void clearHill()
        {
            drawHill(Color.LightBlue);
            paintHill(Color.LightBlue);
            

        }
        void clearTheSun(int x, int y)
        {

        }
        private void pbDrawZone_Click(object sender, EventArgs e)
        {

        }

        private void RunCar_Click(object sender, EventArgs e)
        {
            moveCar(); 
        }
    }
}
