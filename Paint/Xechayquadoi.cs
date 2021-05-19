using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Collections;
using System.Diagnostics; 
namespace Paint
{
    public partial class Xechayquadoi : Form
    {
        private Bitmap bm1;
        private Bitmap bm2;
        private Bitmap bm3;
        DrawTool dt1;
        DrawTool dt2;
        DrawTool dt3;
        private Graphics gp1;
        private Graphics gp2;
        private Graphics gp3;
        private Color clLine = Color.Black;
        private int widthLine = 1;
        int xPlane = 30;
        int yPlane = 200; 
       
        int xStartFromRightToLeft = 920;
        
        int yStartFromRightToLeft = 80;
        int xSun = 590;
        int ySun = 80;
        int tempySun = 80;
        bool check = false;
        List<Vehicle> listVehicle; 


        public Xechayquadoi()
        {
            InitializeComponent();
           // Control.CheckForIllegalCrossThreadCalls = false;
            start();
        }
        private void start()
        {
          

            bm1  = new Bitmap(pb1.Width, pb1.Height);
            dt1 = new DrawTool(bm1, label1);
            gp1 = Graphics.FromImage(bm1);
            pb1.Image = bm1;

            bm2 = new Bitmap(pb2.Width, pb2.Height);
            dt2 = new DrawTool(bm2, label1);
            gp2 = Graphics.FromImage(bm2);


            bm3 = new Bitmap(pb3.Width, pb3.Height);
            dt3 = new DrawTool(bm3, label1);
            gp3 = Graphics.FromImage(bm3);

            gp1.Clear(Color.LightGray);
            drawBorder1();
            drawSun(xSun, ySun);
            paintSun(xSun, ySun, Color.Red);
            drawHill(Color.Black);
            paintHill(Color.Brown);
            paintSkyandSoid(Color.LightBlue, Color.LightYellow);
            pb1.Image = bm1;

            gp2.Clear(Color.LightGray);
            drawBorder2();
            drawStreet();
            paintStreet();

            gp3.Clear(Color.LightGray);
            drawBorder3(); 


            listVehicle = new List<Vehicle>();

            CarLeft car1 = new CarLeft();
            listVehicle.Add(car1);
            

            CarRight car2 = new CarRight();
            listVehicle.Add(car2);

            LorryRight lorry3 = new LorryRight();
            listVehicle.Add(lorry3);

            

            AmbulanceRight ambulance4 = new AmbulanceRight();
            listVehicle.Add(ambulance4);


            TankLeft tank5 = new TankLeft();
            listVehicle.Add(tank5);

            PoliceCarRight policeCar6 = new PoliceCarRight();
            listVehicle.Add(policeCar6);
            
            
            
            //final:
            PoliceCarLeft policecar7 = new PoliceCarLeft();
            listVehicle.Add(policecar7);

            PoliceCarRight policecar12 = new PoliceCarRight();
            listVehicle.Add(policecar12);
            
            AmbulanceLeft ambulance8 = new AmbulanceLeft();
            listVehicle.Add(ambulance8);

            AmbulanceRight ambulance13 = new AmbulanceRight();
            listVehicle.Add(ambulance13);

            LorryLeft lorry9 = new LorryLeft();
            listVehicle.Add(lorry9);

            TankRight tank14 = new TankRight();
            listVehicle.Add(tank14);


            

            pb2.Image = bm2; 

        }
        private void Xechayquadoi_Load(object sender, EventArgs e)
        {



            clearStreet();
            drawAirplane(xPlane, yPlane);

            

            /*gp.Clear(Color.LightGray);*/

            

            drawHouses();

            pb3.Image = bm3; 
            pb2.Image = bm2; 

        }
        void drawAmbulanceLefttoRight(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x , y-45), p);
            dt2.DrawMidPointAnimation(new Point(x, y-45), new Point(x+90, y - 45), p);

            //ve chu thap 
            dt2.DrawMidPointAnimation(new Point(x + 15, y -20), new Point(x + 25, y-20), p);
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 15, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 30), new Point(x + 25, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 30), new Point(x + 25, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 40), new Point(x + 35, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 35, y - 40), new Point(x + 35, y - 30), p);
           dt2.DrawMidPointAnimation(new Point(x + 35, y - 30), new Point(x + 45, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 45, y - 30), new Point(x + 45, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 45, y - 20), new Point(x + 35, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 35, y - 20), new Point(x + 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 10), new Point(x + 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 20), new Point(x + 25, y - 10), p);
            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x+70, y - 45), new Point(x + 70, y), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 25), new Point(x + 120, y), p);
            //phan kho to 
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 45), new Point(x + 120, y-25), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 25), new Point(x + 70, y - 25), p);

            //banh xe: 
            //banh xe
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);

            //to mau xe: 
            dt2.FillColor(new Point(x + 10, y - 10), Color.White);
            dt2.FillColor(new Point(x + 30, y - 20), Color.Red);
            dt2.FillColor(new Point(x + 90, y - 10), Color.White);
            dt2.FillColor(new Point(x + 78, y - 30), Color.White);
        }
        void translatingAmbulanceFromLeftToRight(int x, int y)
        {
            clearAmbulanceLefttoRight(x, y); 
            x += 20;
            drawAmbulanceLefttoRight(x, y);

        }
        void drawHouses()
        {
            drawHouse(160, 50);
            drawHouse(480, 50);
            drawHouse(800, 50);
            check = false;
            fillColorHouse(160, 50, check);
            fillColorHouse(480, 50, check);
            fillColorHouse(800, 50, check);
            dt3.FillColor(new Point(10, 10), Color.Gainsboro);
        }

        //hàm vẽ một căn nhà
        void drawHouse(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);

            dt3.DrawMidPointAnimation(new Point(x, y), new Point(x - 50, y + 20), p);
            dt3.DrawMidPointAnimation(new Point(x, y), new Point(x + 50, y + 20), p);
            dt3.DrawMidPointAnimation(new Point(x, y), new Point(x, y + 70), p);
            dt3.DrawMidPointAnimation(new Point(x - 50, y + 20), new Point(x - 50, y + 100), p);
            dt3.DrawMidPointAnimation(new Point(x + 50, y + 20), new Point(x + 50, y + 100), p);
            dt3.DrawMidPointAnimation(new Point(x - 50, y + 100), new Point(x, y + 70), p);
            dt3.DrawMidPointAnimation(new Point(x + 50, y + 100), new Point(x, y + 70), p);

            dt3.DrawMidPointAnimation(new Point(x - 47, y + 97), new Point(x - 47, y + 135), p);
            dt3.DrawMidPointAnimation(new Point(x + 47, y + 97), new Point(x + 47, y + 135), p);
            dt3.DrawMidPointAnimation(new Point(x - 47, y + 135), new Point(x + 47, y + 135), p);

            //ve cua so
            dt3.DrawMidPointAnimation(new Point(x - 25, y + 100), new Point(x + 25, y + 100), p);
            dt3.DrawMidPointAnimation(new Point(x + 25, y + 100), new Point(x + 25, y + 125), p);
            dt3.DrawMidPointAnimation(new Point(x + 25, y + 125), new Point(x - 25, y + 125), p);
            dt3.DrawMidPointAnimation(new Point(x - 25, y + 125), new Point(x - 25, y + 100), p);

            dt3.DrawMidPointAnimation(new Point(x, y + 100), new Point(x, y + 125), p);
            //ve den
            dt3.DrawMidPointAnimation(new Point(x + 120, y + 15), new Point(x + 120, y + 75), p);
            dt3.DrawMidPointAnimation(new Point(x + 120, y + 15), new Point(x + 150, y + 15), p);
            dt3.DrawMidPointAnimation(new Point(x + 120, y + 15), new Point(x + 90, y + 15), p);

            //ve cay
            drawTree(x - 120, y + 100);

        }
        //tô màu lại căn nhà khi sáng hoặc tối
        void fillColorHouse(int x, int y, Boolean check)
        {
            Pen p = new Pen(clLine, widthLine);
            if (check == false)
            {
                //to mau nha ban ngay
                dt3.FillColor(new Point(x - 10, y + 10), Color.Tomato);
                dt3.FillColor(new Point(x + 10, y + 10), Color.Tomato);

                dt3.FillColor(new Point(x, y + 80), Color.White);

                dt3.FillColor(new Point(x - 10, y + 110), Color.White);
                dt3.FillColor(new Point(x + 10, y + 110), Color.White);

                //tat den
                p = new Pen(Color.Black, widthLine);
                dt3.DrawMidPointAnimation(new Point(x + 85, y + 20), new Point(x + 100, y + 20), p);
                dt3.DrawMidPointAnimation(new Point(x + 85, y + 15), new Point(x + 85, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 140, y + 20), new Point(x + 151, y + 20), p);
                dt3.DrawMidPointAnimation(new Point(x + 151, y + 15), new Point(x + 151, y + 20), p);

                p = new Pen(Color.Gainsboro, widthLine);
                dt3.DrawMidPointAnimation(new Point(x + 80, y + 15), new Point(x + 80, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 80, y + 25), new Point(x + 105, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 105, y + 25), new Point(x + 105, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 156, y + 15), new Point(x + 156, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 135, y + 25), new Point(x + 156, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 135, y + 20), new Point(x + 135, y + 25), p);


                dt3.DrawMidPointAnimation(new Point(x + 75, y + 15), new Point(x + 75, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 75, y + 30), new Point(x + 110, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 110, y + 30), new Point(x + 110, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 161, y + 15), new Point(x + 161, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 130, y + 30), new Point(x + 161, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 130, y + 20), new Point(x + 130, y + 30), p);
            }
            else
            {
                //to mau nha ban dem
                dt3.FillColor(new Point(x - 10, y + 10), Color.DarkRed);
                dt3.FillColor(new Point(x + 10, y + 10), Color.DarkRed);

                dt3.FillColor(new Point(x, y + 80), Color.Gainsboro);

                dt3.FillColor(new Point(x - 10, y + 110), Color.Yellow);
                dt3.FillColor(new Point(x + 10, y + 110), Color.Yellow);

                //ve den phat sang
                p = new Pen(Color.DarkOrange, widthLine);
                dt3.DrawMidPointAnimation(new Point(x + 85, y + 20), new Point(x + 100, y + 20), p);
                dt3.DrawMidPointAnimation(new Point(x + 85, y + 15), new Point(x + 85, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 140, y + 20), new Point(x + 151, y + 20), p);
                dt3.DrawMidPointAnimation(new Point(x + 151, y + 15), new Point(x + 151, y + 20), p);

                p = new Pen(Color.Gold, widthLine);
                dt3.DrawMidPointAnimation(new Point(x + 80, y + 15), new Point(x + 80, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 80, y + 25), new Point(x + 105, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 105, y + 25), new Point(x + 105, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 156, y + 15), new Point(x + 156, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 135, y + 25), new Point(x + 156, y + 25), p);
                dt3.DrawMidPointAnimation(new Point(x + 135, y + 20), new Point(x + 135, y + 25), p);

                p = new Pen(Color.Yellow, widthLine);
                dt3.DrawMidPointAnimation(new Point(x + 75, y + 15), new Point(x + 75, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 75, y + 30), new Point(x + 110, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 110, y + 30), new Point(x + 110, y + 20), p);

                dt3.DrawMidPointAnimation(new Point(x + 161, y + 15), new Point(x + 161, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 130, y + 30), new Point(x + 161, y + 30), p);
                dt3.DrawMidPointAnimation(new Point(x + 130, y + 20), new Point(x + 130, y + 30), p);

            }
        }


       
         void houseDayandNight()
        {
            ThreadStart threadStartOfHouse = new ThreadStart(loopOfHouse);
            Thread threadHouse = new Thread(threadStartOfHouse);
            threadHouse.IsBackground = true;
            threadHouse.Start();
        }

        //hàm trong luồng
        void loopOfHouse()
        {
            for (int i = 1; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    dt3.FillColor(new Point(10, 10), Color.LightGreen);
                }
                else
                {
                    dt3.FillColor(new Point(10, 10), Color.Cornsilk);
                }
                pb3.Image = bm3;
                Thread.Sleep(100); 
            }

            Boolean day = true;
            while (true)
            {
                if (check == false && day == false)
                {
                    fillColorHouse(160, 50, check);
                    fillColorHouse(480, 50, check);
                    fillColorHouse(800, 50, check);

                    dt3.FillColor(new Point(10, 10), Color.Gainsboro);

                    pb3.Image = bm3;
                    Thread.Sleep(TimeSpan.FromSeconds(8));
                    day = true;
                }
                else if (check == true && day == true)
                {
                    fillColorHouse(160, 50, check);
                    fillColorHouse(480, 50, check);
                    fillColorHouse(800, 50, check);

                    dt3.FillColor(new Point(10, 10), Color.DarkSlateGray);

                    pb3.Image = bm3;
                    Thread.Sleep(TimeSpan.FromSeconds(2.5));
                    day = false;
                }
            }
            
        }



        void clearAmbulanceLefttoRight(int x, int y)
        {

            //to mau xe: 
            dt2.FillColor(new Point(x + 10, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 30, y - 20), Color.Gray);
            dt2.FillColor(new Point(x + 90, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 78, y - 30), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 45), new Point(x + 90, y - 45), p);

            //ve chu thap 
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 25, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 15, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 15, y - 30), new Point(x + 25, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 30), new Point(x + 25, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 40), new Point(x + 35, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 35, y - 40), new Point(x + 35, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 35, y - 30), new Point(x + 45, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x + 45, y - 30), new Point(x + 45, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 45, y - 20), new Point(x + 35, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 35, y - 20), new Point(x + 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 10), new Point(x + 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 25, y - 20), new Point(x + 25, y - 10), p);
            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 45), new Point(x + 70, y), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 25), new Point(x + 120, y), p);
            //phan kho to 
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 45), new Point(x + 120, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 25), new Point(x + 70, y - 25), p);

            //banh xe: 
            //banh xe
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);

        }
        void translatingAmbulanceRightoLeft(int x, int y)
        {
            clearAmbulanceRightToLeft(x, y);
            x -= 20;
            drawAmbulanceRighttoLeft(x, y);
            
        }
        void clearAmbulanceRightToLeft(int x, int y)
        {
            //to mau xe: 
            dt2.FillColor(new Point(x - 10, y - 10), Color.Gray);
            dt2.FillColor(new Point(x - 30, y - 20), Color.Gray);
            dt2.FillColor(new Point(x - 90, y - 10), Color.Gray);
            dt2.FillColor(new Point(x - 78, y - 30), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 45), new Point(x - 90, y - 45), p);

            //ve chu thap 
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 25, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 15, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 30), new Point(x - 25, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 30), new Point(x - 25, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 40), new Point(x - 35, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 40), new Point(x - 35, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 30), new Point(x - 45, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 45, y - 30), new Point(x - 45, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 45, y - 20), new Point(x - 35, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 20), new Point(x - 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 10), new Point(x - 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 20), new Point(x - 25, y - 10), p);
            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x - 70, y - 45), new Point(x - 70, y), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 25), new Point(x - 120, y), p);
            //phan kho to 
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 45), new Point(x - 120, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 25), new Point(x - 70, y - 25), p);

            //banh xe: 
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);

        }
        void drawAmbulanceRighttoLeft(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 45), new Point(x - 90, y - 45), p);

            //ve chu thap 
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 25, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 15, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 30), new Point(x - 25, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 30), new Point(x - 25, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 40), new Point(x - 35, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 40), new Point(x - 35, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 30), new Point(x - 45, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 45, y - 30), new Point(x - 45, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 45, y - 20), new Point(x - 35, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 35, y - 20), new Point(x - 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 10), new Point(x - 35, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x - 25, y - 20), new Point(x - 25, y - 10), p);
            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x - 70, y - 45), new Point(x - 70, y), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 25), new Point(x- 120, y), p);
            //phan kho to 
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 45), new Point(x - 120, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 25), new Point(x - 70, y - 25), p);

            //banh xe: 
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);

            //to mau xe: 
            dt2.FillColor(new Point(x - 10, y - 10), Color.White);
            dt2.FillColor(new Point(x - 30, y - 20), Color.Red);
            dt2.FillColor(new Point(x - 90, y - 10), Color.White);
            dt2.FillColor(new Point(x - 78, y - 30), Color.White);
        }
        public void drawBorder3()
        {
            Pen p = new Pen(clLine, widthLine);
            //load duong vien
            dt3.DrawMidPointAnimation(new Point(3, 3), new Point(bm3.Width - 3, 3), p);
            dt3.DrawMidPointAnimation(new Point(3, 3), new Point(3, bm3.Height - 3), p);
            dt3.DrawMidPointAnimation(new Point(bm3.Width - 3, 3), new Point(bm3.Width - 3, bm3.Height - 3), p);
            dt3.DrawMidPointAnimation(new Point(3, bm3.Height - 3), new Point(bm3.Width - 3, bm3.Height - 3), p);
        }
        public void drawBorder1()
        {
            Pen p = new Pen(clLine, widthLine);
            dt1.DrawMidPointAnimation(new Point(0, 3), new Point(1000, 3), p);
            dt1.DrawMidPointAnimation(new Point(0, 210), new Point(1000, 210),p);

            dt1.DrawMidPointAnimation(new Point(3, 3), new Point(3, 210), p);
            dt1.DrawMidPointAnimation(new Point(970, 3), new Point(970, 210), p);

        }
        public void drawBorder2()
        {
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(0, 3), new Point(970, 3), p);
            dt2.DrawMidPointAnimation(new Point(0, 225), new Point(970, 225), p);

            dt2.DrawMidPointAnimation(new Point(3, 3), new Point(3, 225), p);
            dt2.DrawMidPointAnimation(new Point(970, 3), new Point(970, 225), p);


        }

        public void drawAirplane(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
    
            dt2.DrawMidPointAnimation(new Point(x+20, y-30), new Point(x + 100, y-30), p);


            //duoi may bay
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x-10, y-60), p);
            dt2.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x -10, y - 60), p);

            dt2.DrawMidPointAnimation(new Point(x + 100, y - 30), new Point(x + 70, y - 90), p);
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 90), new Point(x + 90, y - 90), p);

            dt2.DrawMidPointAnimation(new Point(x + 90, y - 90), new Point(x + 150, y -30), p);

            //canh kho to 
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 30), new Point(x + 50, y - 75), p);
            dt2.DrawMidPointAnimation(new Point(x + 50, y - 75), new Point(x + 60, y - 75), p);
            dt2.DrawMidPointAnimation(new Point(x + 60, y - 75), new Point(x + 100, y - 30), p);

            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x + 150, y - 30), new Point(x + 200, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 250, y), p);
            dt2.DrawMidPointAnimation(new Point(x + 200, y - 30), new Point(x + 230, y-15), p);
            dt2.DrawMidPointAnimation(new Point(x + 230, y - 15), new Point(x + 250, y), p);

            dt2.DrawMidPointAnimation(new Point(x + 30, y - 10), new Point(x + 170, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 20), new Point(x + 170, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 10), new Point(x + 30, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 170, y - 10), new Point(x + 170, y - 20), p);

            dt2.MidPointDrawCircle(x + 100, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 100, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 80, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 80, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 180, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 180, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 160, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 160, y + 10, 3, Color.Black);

            // to mau: 
            dt2.FillColor(new Point(x + 10, y - 10), Color.OrangeRed);
            dt2.FillColor(new Point(x + 80, y - 40), Color.OrangeRed);
            dt2.FillColor(new Point(x + 50, y - 15), Color.Red);
        }

        public void clearAirPlane(int x, int y)
        {
            // to mau: 
            dt2.FillColor(new Point(x + 10, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 80, y - 40), Color.Gray);
            dt2.FillColor(new Point(x + 50, y - 15), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);


            dt2.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x + 100, y - 30), p);


            //duoi may bay
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 10, y - 60), p);
            dt2.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x - 10, y - 60), p);

            dt2.DrawMidPointAnimation(new Point(x + 100, y - 30), new Point(x + 70, y - 90), p);
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 90), new Point(x + 90, y - 90), p);

            dt2.DrawMidPointAnimation(new Point(x + 90, y - 90), new Point(x + 150, y - 30), p);

            //canh kho to 
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 30), new Point(x + 50, y - 75), p);
            dt2.DrawMidPointAnimation(new Point(x + 50, y - 75), new Point(x + 60, y - 75), p);
            dt2.DrawMidPointAnimation(new Point(x + 60, y - 75), new Point(x + 100, y - 30), p);

            //phan dau: 
            dt2.DrawMidPointAnimation(new Point(x + 150, y - 30), new Point(x + 200, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 250, y), p);
            dt2.DrawMidPointAnimation(new Point(x + 200, y - 30), new Point(x + 230, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x + 230, y - 15), new Point(x + 250, y), p);

            dt2.DrawMidPointAnimation(new Point(x + 30, y - 10), new Point(x + 170, y - 10), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 20), new Point(x + 170, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 10), new Point(x + 30, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x + 170, y - 10), new Point(x + 170, y - 20), p);

            dt2.MidPointDrawCircle(x + 100, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 100, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 180, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 180, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 160, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 160, y + 10, 3, Color.Gray);

         
        }
        public void moveAirPlane()
        {
            /* int x = xStartFromLeftToRight;
             int y = yStartFromLeftToRight;
             for (int i = 0; i < 100; i++)
             {
                 translatingPoliceCarLeftToRight(x, y);
                 x += 5;
                 drawPoliceCarLeftToRight(x, y);
                 pb2.Image = bm2;
                 Thread.Sleep(100);
             }*/
            int x = xStartFromRightToLeft;
            int y = yStartFromRightToLeft;
            for (int i = 0; i < 100; i++)
            {
                translatingPoliceCarRightToLeft(x, y);
                x -= 5;
                drawPoliceCarRightToLeft(x, y);
                pb2.Image = bm2;
                Thread.Sleep(100);
            }

        }
        public void drawCarLeftToRight(int x, int y)
        {

            
            
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
        public void drawPoliceCarLeftToRight(int x, int y)
        {



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
            //den bao: 
            dt2.DrawMidPointAnimation(new Point(x + 40, y - 40), new Point(x + 40, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x + 40, y - 50), new Point(x + 70, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 50), new Point(x + 70, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 55, y - 50), new Point(x + 55, y - 40), p);
            //banh xe
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x + 5, y - 5), Color.LightBlue);
            dt2.FillColor(new Point(x + 30, y - 12), Color.White);
            dt2.FillColor(new Point(x + 70, y - 12), Color.White);
            dt2.FillColor(new Point(x + 50, y - 45), Color.Blue);
            dt2.FillColor(new Point(x + 60, y - 45), Color.Red);

        }
        void translatingPoliceCarLeftToRight(int x, int y)
        {
            clearPoliceCarLeftToRight(x, y);
            x += 25;
            drawPoliceCarLeftToRight(x, y);
        }
        void clearPoliceCarLeftToRight(int x, int y)
        {
            dt2.FillColor(new Point(x + 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x + 30, y - 12), Color.Gray);
            dt2.FillColor(new Point(x + 70, y - 12), Color.Gray);
            dt2.FillColor(new Point(x + 50, y - 45), Color.Gray);
            dt2.FillColor(new Point(x + 60, y - 45), Color.Gray);

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
            dt2.DrawMidPointAnimation(new Point(x + 60, y - 20), new Point(x + 40, y - 7), p);
            //den bao: 
            dt2.DrawMidPointAnimation(new Point(x + 40, y - 40), new Point(x + 40, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x + 40, y - 50), new Point(x + 70, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x + 70, y - 50), new Point(x + 70, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x + 55, y - 50), new Point(x + 55, y - 40), p);
            //banh xe
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);


        }
        public void drawPoliceCarRightToLeft(int x, int y)
        {



            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);

            //cua so: 
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
            //den bao: 
            dt2.DrawMidPointAnimation(new Point(x - 40, y - 40), new Point(x - 40, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x - 40, y - 50), new Point(x - 70, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x - 70, y - 50), new Point(x - 70, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 55, y - 50), new Point(x - 55, y - 40), p);
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x - 5, y - 5), Color.LightYellow);
            dt2.FillColor(new Point(x - 30, y - 12), Color.White);
            dt2.FillColor(new Point(x - 70, y - 12), Color.White);
            dt2.FillColor(new Point(x - 50, y - 45), Color.Blue);
            dt2.FillColor(new Point(x - 60, y - 45), Color.Red);

        }
        void translatingPoliceCarRightToLeft(int x, int y)
        {
            clearPolicCarRightToLeft(x, y);
            x -= 25;
            drawPoliceCarRightToLeft(x, y); 
        }
        public void clearPolicCarRightToLeft(int x, int y)
        {
            dt2.FillColor(new Point(x - 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x - 30, y - 12), Color.Gray);
            dt2.FillColor(new Point(x - 70, y - 12), Color.Gray);
            dt2.FillColor(new Point(x - 50, y - 45), Color.Gray);
            dt2.FillColor(new Point(x - 60, y - 45), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);

            //cua so: 
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
            //den bao: 
            dt2.DrawMidPointAnimation(new Point(x - 40, y - 40), new Point(x - 40, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x - 40, y - 50), new Point(x - 70, y - 50), p);
            dt2.DrawMidPointAnimation(new Point(x - 70, y - 50), new Point(x - 70, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 55, y - 50), new Point(x - 55, y - 40), p);
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);


        }
        public void translatingCarLeftToRight(int x, int y)
        {
            //LEFT TO RIGHT

                Pen p = new Pen(Color.Gray, widthLine);
            //xoa xe vi tri cu: 
            dt2.FillColor(new Point(x + 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x + 30, y - 12), Color.Gray);
            dt2.FillColor(new Point(x + 70, y - 12), Color.Gray);



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
               dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
               dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
               dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
               dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);


               //ve lai xe: 
               x += 10;
               drawCarLeftToRight(x, y);
       }
        public void clearCarLeftToRight(int x, int y)
        {
            //LEFT TO RIGHT

            Pen p = new Pen(Color.Gray, widthLine);
            //xoa xe vi tri cu: 
            dt2.FillColor(new Point(x + 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x + 30, y - 12), Color.Gray);
            dt2.FillColor(new Point(x + 70, y - 12), Color.Gray);



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
            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);


        }

        public void mainMove()
       {
            int x = xPlane;
            int y = yPlane;
            int distance = 10;

            for (int i = 0; i < 135; i++)
            {
                if (i < 115)
                {
                    clearAirPlane(x, y);
                    x += 5;
                    drawAirplane(x, y);
                }

                else
                {
                    clearAirPlane(x, y);
                    x += 5;
                    y -= 5;
                    drawAirplane(x, y);
                }

                if (i / 15 == 1 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    Font font2 = new Font("Arial", 20);
                    PointF drawPoint = new PointF(distance, 80);
                    PointF drawPoint20 = new PointF(20, 10);
                    PointF drawPoint30 = new PointF(20, 40);

                    gp2.DrawString("MÔN KỸ THUẬT ĐỒ HỌA", font2, ve, drawPoint20);
                    gp2.DrawString("Giảng viên: Dương Thanh Thảo", font2, ve, drawPoint30);

                    distance += 60;
                    gp2.DrawString("N", font, ve, drawPoint);
                }
                else if (i / 15 == 2 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    PointF drawPoint = new PointF(distance, 80);
                    distance += 60;
                    gp2.DrawString("H", font, ve, drawPoint);
                }
                else if (i / 15 == 3 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    PointF drawPoint = new PointF(distance, 80);
                    PointF drawPoint20 = new PointF(distance + 50, 60);
                    distance += 60;
                    gp2.DrawString("Ó", font, ve, drawPoint);
                    //gp2.DrawString("'", font, ve, drawPoint20);
                }
                else if (i / 15 == 4 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    PointF drawPoint = new PointF(distance, 80);
                    distance += 120;
                    gp2.DrawString("M", font, ve, drawPoint);


                }
                else if (i / 15 == 6 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    PointF drawPoint = new PointF(distance, 80);
                    distance += 40;
                    gp2.DrawString("1", font, ve, drawPoint);


                }
                else if (i / 15 == 7 && i % 15 == 0)
                {
                    Brush ve = new SolidBrush(Color.Red);
                    Font font = new Font("Arial", 50);
                    PointF drawPoint = new PointF(distance, 80);
                    distance += 60;
                    gp2.DrawString("0", font, ve, drawPoint);


                }

                pb2.Image = bm2;
                Thread.Sleep(100);


            }
            clearAirPlane(x, y);

            Brush ve0 = new SolidBrush(Color.Red);
            Font font0 = new Font("Arial", 15);
            PointF drawPoint0 = new PointF(580, 15);
            gp2.DrawString("Thành viên", font0, ve0, drawPoint0);


            Font font1 = new Font("Arial", 12);
            PointF drawPoint1 = new PointF(600, 40);
            gp2.DrawString("Nguyễn Hải Nam", font1, ve0, drawPoint1);
            PointF drawPoint2 = new PointF(600, 60);
            gp2.DrawString("Nguyễn Văn Chung", font1, ve0, drawPoint2);
            PointF drawPoint3 = new PointF(600, 80);
            gp2.DrawString("Huỳnh Phước Sang", font1, ve0, drawPoint3);
            PointF drawPoint4 = new PointF(600, 100);
            gp2.DrawString("Nguyễn Tá Huy", font1, ve0, drawPoint4);
            PointF drawPoint5 = new PointF(600, 120);
            gp2.DrawString("Lù Vĩnh Trường", font1, ve0, drawPoint5);
            pb2.Image = bm2;
            Thread.Sleep(1000);

            gp2 = Graphics.FromImage(bm2);
            gp2.Clear(Color.LightGray);
            drawBorder2();
            drawStreet();
            paintStreet();
            pb2.Image = bm2;
            Thread.Sleep(100);
            int count = 0;
            int limit = 0;
            bool checkStop = false; 
            while (true)
           {
                if (checkStop == true) break;
               for (int i = 0; i <limit; i++)
               {
                    if(limit == 13)
                    {
                        checkStop = true; 
                        break;

                    }
                    if (listVehicle[i].Exist == true)
                    {
                        //left to right
                        if (listVehicle[i].Dicrection == 1)
                        {
                            //car
                            if (listVehicle[i].Type == 1)
                            {
                                //can move more
                                if ( (listVehicle[i].X + 150) >=970)
                                {

                                    clearCarLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingCarLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X += 10;
                                }
                            }
                            //Lorry
                           else if (listVehicle[i].Type == 2)
                            {
                                //can move more
                                if ((listVehicle[i].X + 165) >= 970)
                                {

                                    clearLorryFromLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingLorryLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X += 10;
                                }
                            }

                            //Tank
                            else if (listVehicle[i].Type == 3)
                            {
                                //can move more
                                if ((listVehicle[i].X + 150) >= 970)
                                {

                                    clearTankLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingTankLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X += 10;
                                }
                            }


                            //Ambulance
                            else if (listVehicle[i].Type == 4)
                            {
                                //can move more
                                if ((listVehicle[i].X + 150) >= 970)
                                {

                                    clearAmbulanceLefttoRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingAmbulanceFromLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X += 20;
                                }
                            }
                            //Police Car:
                            else if (listVehicle[i].Type == 5)
                            {
                                //can move more
                                if ((listVehicle[i].X + 150) >= 970)
                                {

                                    clearPoliceCarLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingPoliceCarLeftToRight(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X += 25;
                                }
                            }
                        }
                        else //right to left
                        {

                            //car
                            if (listVehicle[i].Type == 1)
                            {
                                //can move more
                                if ((listVehicle[i].X - 150)<=0)
                                {

                                    clearCarRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingCarRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X -= 10;
                                }
                            }
                            //lorry
                            else if (listVehicle[i].Type == 2)
                            {
                                //can move more
                                if ((listVehicle[i].X - 165) <= 0)
                                {

                                    clearLorryRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingLorryRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X -= 10;
                                }
                            }

                            //tank
                            else if (listVehicle[i].Type == 3)
                            {
                                //can move more
                                if ((listVehicle[i].X - 150) <= 0)
                                {

                                    clearTankRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingTankRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X -= 10;
                                }
                            }
                            //ambulance
                            else if (listVehicle[i].Type == 4)
                            {
                                //can move more
                                if ((listVehicle[i].X - 150) <= 0)
                                {

                                    clearAmbulanceRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingAmbulanceRightoLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X -= 20;
                                }
                            }

                            //police car: 
                            else if (listVehicle[i].Type == 5)
                            {
                                //can move more
                                if ((listVehicle[i].X - 150) <= 0)
                                {

                                    clearPolicCarRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].Exist = false;
                                }
                                else
                                {
                                    translatingPoliceCarRightToLeft(listVehicle[i].X, listVehicle[i].Y);
                                    listVehicle[i].X -= 25;
                                }
                            }
                        }
                    }
                    pb2.Image = bm2;
                    Thread.Sleep(50);


               }
                count++;
                if (count == 1)
                {
                    limit++;
                    drawCarLeftToRight(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 5)
                {
                    limit++;
                    drawCarRightToLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if(count == 40)
                {
                    limit++;
                    drawLorryRightToLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                
                else if (count == 120)
                {
                    limit++;
                    drawAmbulanceRighttoLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 190)
                {
                    limit++;
                    drawTankLeftToRight(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 250)
                {
                    limit++;
                    drawPoliceCarRightToLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 290)
                {
                    limit++;
                    drawPoliceCarLeftToRight(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 293)
                {
                    limit++;
                    drawPoliceCarRightToLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 298)
                {
                    limit++;
                    drawAmbulanceLefttoRight(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 300)
                {
                    limit++;
                    drawAmbulanceRighttoLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 310)
                {
                    limit++;
                    drawLorryLeftToRight(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if (count == 312)
                {
                    limit++;
                    drawTankRightToLeft(listVehicle[limit - 1].X, listVehicle[limit - 1].Y);
                }
                else if(count == 340)
                {
                    limit++; 
                }
                
                
            }
            gp2.Clear(Color.Yellow);
            Brush veend = new SolidBrush(Color.Red);
            Font fontend = new Font("Arial", 33);
            PointF drawPointend = new PointF(150, 80);
            gp2.DrawString("TẠM BIỆT CÔ VÀ CÁC BẠN!!!", fontend, veend, drawPointend);

            pb2.Image = bm2;
            Thread.Sleep(1000);

        }
            void drawSun(int x, int y)
        {
        
            dt1.MidPointDrawCircleAnimation(x, y, 65, Color.Yellow);
        }
        void paintSun(int x, int y, Color color)
        {
            dt1.FillColor(new Point(x, y), color);
        }
        void drawMoon(int x, int y,Color color)
        {
            
            
            dt1.MidPointDrawHaftCircle(x, y, 65, Color.Black);
            dt1.drawHaftElip(x - 10, y, 30, 65, Color.Black);
            dt1.FillColor(new Point(x + 60, y), Color.Yellow);
        }
        void clearMoon(int x, int y)
        {


            dt1.MidPointDrawHaftCircle(x, y, 65, Color.DarkSlateGray);
            dt1.drawHaftElip(x - 10, y, 30, 65, Color.DarkSlateGray);
            dt1.FillColor(new Point(x + 60, y), Color.DarkSlateGray);
        }
        public void sunGoDown()
        {

            for (int i = 1; i <= 70; i++)
            {
                if (i % 2 == 0)
                {
                    paintSun(xSun, ySun, Color.Cyan);
                    paintSkyandSoid(Color.LightGreen, Color.Chocolate);
                    
                }
                else
                {
                    paintSun(xSun, ySun, Color.Violet);
                    paintSkyandSoid(Color.Cornsilk, Color.Cornsilk);
                }
                pb1.Image = bm1;
                Thread.Sleep(100);
            }
            paintSun(xSun, ySun, Color.Red);
            paintSkyandSoid(Color.LightBlue, Color.LightBlue);
            pb1.Image = bm1;
            Thread.Sleep(100);

            while (true)
            {
                
                if (check == false)
                {
                    

                    //xoa mat troi cu: 
                    dt1.MidPointDrawCircleAnimation(xSun, tempySun, 65, Color.LightBlue);
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
                        drawMoon(xSun, ySun,Color.Yellow);
                        paintSkyandSoid(Color.DarkSlateGray, Color.DarkSalmon);
                        check = true;
                    }

                    pb1.Image = bm1;
                    Thread.Sleep(400);
                }
                
                else
                {
                    
                     Thread.Sleep(3000);
                    clearMoon(xSun,ySun);
                    
                    paintSkyandSoid(Color.LightBlue, Color.LightYellow);
                    drawSun(xSun, ySun);
                    paintSun(xSun, ySun, Color.Red);
                    tempySun = ySun;
                    check = false;
                    pb1.Image = bm1;
                    Thread.Sleep(100); 
                }
               
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
            dt2.DrawMidPoint(new Point(x, y), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x + 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x + 100, y - 50), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x + 100, y), new Point(x + 150, y), p);
            dt2.DrawMidPoint(new Point(x + 150, y), new Point(x + 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 40), new Point(x + 100, y - 50), p);

            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 80, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 80, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 130, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 130, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x + 50, y - 20), Color.Cyan);
            dt2.FillColor(new Point(x + 120, y - 10), Color.DarkGreen);
            dt2.FillColor(new Point(x + 105, y - 43), Color.Pink);
        }
        void drawLorryRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPoint(new Point(x, y), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x - 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x - 100, y - 50), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x - 100, y), new Point(x - 150, y), p);
            dt2.DrawMidPoint(new Point(x - 150, y), new Point(x - 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 40), new Point(x - 100, y - 50), p);

            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 80, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 80, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 130, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 130, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x - 50, y - 20), Color.Violet);
            dt2.FillColor(new Point(x - 120, y - 10), Color.LightCoral);
            dt2.FillColor(new Point(x - 105, y - 43), Color.Red);
        }

        void drawCarRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);

            dt2.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
           
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x - 5, y - 5), Color.Cyan);
            dt2.FillColor(new Point(x - 30, y - 15), Color.Green);
            dt2.FillColor(new Point(x - 70, y - 15), Color.Chocolate);

        }
        void drawTankLeftToRight(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 15), new Point(x + 10, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 10, y - 25), new Point(x + 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 25), new Point(x + 30, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 25), new Point(x + 90, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 45), new Point(x + 130, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 35), new Point(x + 130, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x + 130, y - 45), new Point(x + 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt2.MidPointDrawCircle(x + 10, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 10, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 30, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 30, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 50, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 50, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 70, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 70, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x + 110, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x + 110, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x + 20, y - 10), Color.DarkGreen);
            dt2.FillColor(new Point(x + 35, y - 35), Color.DarkGreen);
        }
        void drawTankRightToLeft(int x, int y)
        {
            
            Pen p = new Pen(clLine, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 15), new Point(x - 10, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 10, y - 25), new Point(x - 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 25), new Point(x - 30, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 25), new Point(x - 90, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 45), new Point(x - 130, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 35), new Point(x - 130, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x - 130, y - 45), new Point(x - 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt2.MidPointDrawCircle(x - 10, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 10, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 30, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 30, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 50, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 50, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 70, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 70, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Black);
            dt2.MidPointDrawCircle(x - 110, y + 10, 10, Color.Black);
            dt2.MidPointDrawCircle(x - 110, y + 10, 3, Color.Black);

            dt2.FillColor(new Point(x - 20, y - 10), Color.DarkGreen);
            dt2.FillColor(new Point(x - 35, y - 35), Color.DarkGreen);
        }
        void paintSkyandSoid(Color colorSky, Color colorSoid)
        {
           
            //to bau troi
            dt1.FillColor(new Point(20, 20), colorSky);
            //dt1.FillColor(new Point(20, 630), colorSoid);
        }
        void drawStreet()
        {
            
            Pen p = new Pen(clLine, widthLine);
            /*//ve khung vien
            dt2.DrawMidPointAnimation(new Point(3, 10), new Point(3, 210), p);
            dt2.DrawMidPointAnimation(new Point(3, 10), new Point(970, 10), p);
            dt2.DrawMidPointAnimation(new Point(970, 10), new Point(970, 210), p);
            dt2.DrawMidPointAnimation(new Point(3, 210), new Point(3, 640), p);
            dt2.DrawMidPointAnimation(new Point(3, 640), new Point(970, 640), p);
            dt2.DrawMidPointAnimation(new Point(970, 210), new Point(970, 640), p);

            dt2.DrawMidPointAnimation(new Point(0, 400), new Point(1000, 400), p);
            dt2.DrawMidPointAnimation(new Point(3, 210), new Point(3, 400), p);
            dt2.DrawMidPointAnimation(new Point(970, 210), new Point(970, 400), p);*/
            /*desparateLine(100, 300);
            desparateLine(300, 300);
            desparateLine(500, 300);
            desparateLine(700, 300);
            desparateLine(900, 300);*/

            desparateLine(100, 120);
            desparateLine(300, 120);
            desparateLine(500, 120);
            desparateLine(700, 120);
            desparateLine(900, 120);
        }
        void clearStreet()
        {
            Pen p = new Pen(clLine, widthLine);
            dt2.FillColor(new Point(110, 130), Color.Gray);
            dt2.FillColor(new Point(310, 130), Color.Gray);
            dt2.FillColor(new Point(510, 130), Color.Gray);
            dt2.FillColor(new Point(710, 130), Color.Gray);
            dt2.FillColor(new Point(910, 130), Color.Gray);

            
            CleardesparateLine(100, 120);
            CleardesparateLine(300, 120);
            CleardesparateLine(500, 120);
            CleardesparateLine(700, 120);
            CleardesparateLine(900, 120);

            dt2.DrawMidPointAnimation(new Point(970, 3), new Point(970, 225), p);

            //dt2.FillColor(new Point(110, 130), Color.Gray);

        }
        void paintStreet()
        {
            
            //to mau duong
            dt2.FillColor(new Point(10, 10), Color.Gray);
            dt2.FillColor(new Point(110, 130), Color.Yellow);
            dt2.FillColor(new Point(310, 130), Color.Yellow);
            dt2.FillColor(new Point(510, 130), Color.Yellow);
            dt2.FillColor(new Point(710, 130), Color.Yellow);
            dt2.FillColor(new Point(910, 130), Color.Yellow);
            //to mau vach phan cach
            /*dt3.FillColor(new Point(120, 310), Color.Yellow);
            dt3.FillColor(new Point(340, 310), Color.Yellow);
            dt3.FillColor(new Point(540, 310), Color.Yellow);
            dt3.FillColor(new Point(740, 310), Color.Yellow);
            dt3.FillColor(new Point(940, 310), Color.Yellow);*/
        }
        void paintStreetFake()
        {
           
            //to mau duong
            dt3.FillColor(new Point(500, 390), Color.LightGray);

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

            dt2.DrawMidPointAnimation(new Point(xtop, ytop), new Point(xbottom, ybottom), p);
            dt2.DrawMidPointAnimation(new Point(xtop, ytop), new Point(tempxtop, ytop), p);
            dt2.DrawMidPointAnimation(new Point(xbottom, ybottom), new Point(tempxbottom, ybottom), p);
            dt2.DrawMidPointAnimation(new Point(tempxbottom, ybottom), new Point(tempxtop, ytop), p);

        }
        void CleardesparateLine(int x, int y)
        {
            int xtop = x;
            int ytop = y;
            int xbottom = xtop - 20;
            int ybottom = ytop + 20;
            int tempxtop = xtop + 100;
            int tempxbottom = xbottom + 100;




            Pen p = new Pen(Color.Gray, widthLine);

            dt2.DrawMidPointAnimation(new Point(xtop, ytop), new Point(xbottom, ybottom), p);
            dt2.DrawMidPointAnimation(new Point(xtop, ytop), new Point(tempxtop, ytop), p);
            dt2.DrawMidPointAnimation(new Point(xbottom, ybottom), new Point(tempxbottom, ybottom), p);
            dt2.DrawMidPointAnimation(new Point(tempxbottom, ybottom), new Point(tempxtop, ytop), p);

        }
        void drawHill(Color color)
        {
            
            
            Pen p = new Pen(color, widthLine);
            
            //hill 1
            dt1.DrawMidPointAnimation(new Point(0, 210), new Point(100, 100),p);
            dt1.DrawMidPointAnimation(new Point(100, 100), new Point(250, 210), p);


            //hill 2
            dt1.DrawMidPointAnimation(new Point(140, 130), new Point(220, 50), p);
            dt1.DrawMidPointAnimation(new Point(220, 50), new Point(300, 130), p);


            //hill 3
            dt1.DrawMidPointAnimation(new Point(250, 210), new Point(330, 80), p);
            dt1.DrawMidPointAnimation(new Point(330, 80), new Point(410, 210), p);

            //hill 4
            dt1.DrawMidPointAnimation(new Point(380, 155), new Point(440, 100), p);
            dt1.DrawMidPointAnimation(new Point(440, 100), new Point(480, 150), p);
            //hill 5
            dt1.DrawMidPointAnimation(new Point(405, 210), new Point(520, 120), p);
            dt1.DrawMidPointAnimation(new Point(520, 120), new Point(580, 210), p);

            //hill 6
            dt1.DrawMidPointAnimation(new Point(605, 210), new Point(655, 130), p);
            dt1.DrawMidPointAnimation(new Point(655, 130), new Point(700, 210), p);
            //hill 7
            dt1.DrawMidPointAnimation(new Point(675, 160), new Point(735, 90), p);
            dt1.DrawMidPointAnimation(new Point(735, 90), new Point(780, 210), p);

            //hill 8
            dt1.DrawMidPointAnimation(new Point(755, 140), new Point(860, 70), p);
            dt1.DrawMidPointAnimation(new Point(860, 70), new Point(970, 210), p);

           
        }
        void paintHill(Color color)
        {



            //to mau doi nui
            dt1.FillColor(new Point(125, 200), color);
            dt1.FillColor(new Point(200, 120), color);
            dt1.FillColor(new Point(300, 180), color);
            dt1.FillColor(new Point(430, 140), color);
            dt1.FillColor(new Point(500, 200), color);
            dt1.FillColor(new Point(680, 200), color);
            dt1.FillColor(new Point(700, 200), color);
            dt1.FillColor(new Point(850, 200), color);

        }
        void paintHillFake()
        {
           
            //to mau doi nui
            dt3.FillColor(new Point(125, 200), Color.Purple);
            dt3.FillColor(new Point(200, 120), Color.Purple);
            dt3.FillColor(new Point(300, 180), Color.Purple);
            dt3.FillColor(new Point(430, 140), Color.Purple);
            dt3.FillColor(new Point(500, 200), Color.Purple);
            dt3.FillColor(new Point(680, 200), Color.Purple);
            dt3.FillColor(new Point(700, 200), Color.Purple);
            dt3.FillColor(new Point(850, 200), Color.Purple);
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
            dt3.DrawMidPointAnimation(new Point(xleft, yleft), new Point(xright, yright), p);
            dt3.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt3.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 30;
            tempxRight += 30;

            //dt.DrawMidPoint(new Point(xleft, yleft),, p);
            dt3.DrawMidPointAnimation(new Point(tempxLeft, tempyLeft), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            tempxLeft += 20;
            tempxRight -= 20;
            tempyLeft -= 20;
            tempyRight -= 20;
            dt3.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt3.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 20;
            tempxRight += 20;

            dt3.DrawMidPointAnimation(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt3.DrawMidPointAnimation(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            x += 10;
            tempyLeft -= 35;
            tempyRight -= 35;
            dt3.DrawMidPointAnimation(new Point(xleft, yleft), new Point(x, tempyLeft), p);
            dt3.DrawMidPointAnimation(new Point(xright, yright), new Point(x, tempyRight), p);

            int ypaint = y - 40;
            int xpaint = x + 10;
            dt3.FillColor(new Point(xpaint, ypaint), Color.Green);

            ypaint = y - 15;
            xpaint = x + 5;
            dt3.FillColor(new Point(xpaint, ypaint), Color.RosyBrown);
            //pbDrawZone.Image = bm; 
        }


        void translatingTankLeftToRight(int x, int y)
        {

            clearTankLeftToRight(x,y); 


            //ve lai xe tank: 
            x += 10;
            drawTankLeftToRight(x, y);
        }
        void clearTankLeftToRight(int x, int y)
        {

            dt2.FillColor(new Point(x + 20, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 35, y - 35), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 15), new Point(x + 10, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 10, y - 25), new Point(x + 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 25), new Point(x + 30, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 25), new Point(x + 90, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x + 30, y - 45), new Point(x + 130, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x + 90, y - 35), new Point(x + 130, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x + 130, y - 45), new Point(x + 130, y - 35), p);


            //banh xe: 

            dt2.MidPointDrawCircle(x + 10, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 10, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 30, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 30, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 50, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 50, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 70, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 70, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 110, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 110, y + 10, 3, Color.Gray);


        }
        void translatingTankRightToLeft(int x, int y)
        {


            clearTankRightToLeft(x, y); 
            //ve lai xe tank: 
            x -= 10;
            drawTankRightToLeft(x, y);
        }
        void clearTankRightToLeft(int x, int y)
        {

            dt2.FillColor(new Point(x - 20, y - 10), Color.Gray);
            dt2.FillColor(new Point(x - 35, y - 35), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);
            dt2.DrawMidPointAnimation(new Point(x, y - 15), new Point(x - 10, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 10, y - 25), new Point(x - 110, y - 25), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 25), new Point(x - 30, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 25), new Point(x - 90, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 45), new Point(x - 130, y - 45), p);
            dt2.DrawMidPointAnimation(new Point(x - 90, y - 35), new Point(x - 130, y - 35), p);
            dt2.DrawMidPointAnimation(new Point(x - 130, y - 45), new Point(x - 130, y - 35), p);


            //banh xe: 
            /*dt.DrawMidPoint(new Point(x + 15, y), new Point(x +15, y +20), p);
            dt.DrawMidPoint(new Point(x + 110, y), new Point(x +110, y + 20), p);
            dt.DrawMidPoint(new Point(x + 15, y+20), new Point(x + 110, y + 20), p);*/
            dt2.MidPointDrawCircle(x - 10, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 10, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 30, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 30, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 50, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 50, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 70, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 70, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 110, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 110, y + 10, 3, Color.Gray);





        }
        void translatingLorryLeftToRight(int x, int y)
        {
           
            dt2.FillColor(new Point(x + 50, y - 20), Color.Gray);
            dt2.FillColor(new Point(x + 120, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 105, y - 43), Color.Gray);


            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPoint(new Point(x, y), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x + 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x + 100, y - 50), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x + 100, y), new Point(x + 150, y), p);
            dt2.DrawMidPoint(new Point(x + 150, y), new Point(x + 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 40), new Point(x + 100, y - 50), p);

            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 130, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 130, y + 10, 3, Color.Gray);

            //ve lai xe: 
            x += 10;
            drawLorryLeftToRight(x, y);
        }
        void clearLorryFromLeftToRight(int x, int y)
        {
            dt2.FillColor(new Point(x + 50, y - 20), Color.Gray);
            dt2.FillColor(new Point(x + 120, y - 10), Color.Gray);
            dt2.FillColor(new Point(x + 105, y - 43), Color.Gray);


            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPoint(new Point(x, y), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x + 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x + 100, y - 50), new Point(x + 100, y), p);
            dt2.DrawMidPoint(new Point(x + 100, y), new Point(x + 150, y), p);
            dt2.DrawMidPoint(new Point(x + 150, y), new Point(x + 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 35), new Point(x + 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x + 150, y - 40), new Point(x + 100, y - 50), p);

            dt2.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 80, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x + 130, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x + 130, y + 10, 3, Color.Gray);

        }
        void translatingCarRightToLeft(int x, int y)
        {

            dt2.FillColor(new Point(x - 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x - 30, y - 15), Color.Gray);
            dt2.FillColor(new Point(x - 70, y - 15), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);


            dt2.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);

            //ve lai xe: 
            x -= 10;
            drawCarRightToLeft(x, y);

        }
        void clearCarRightToLeft(int x, int y)
        {
            dt2.FillColor(new Point(x - 5, y - 5), Color.Gray);
            dt2.FillColor(new Point(x - 30, y - 15), Color.Gray);
            dt2.FillColor(new Point(x - 70, y - 15), Color.Gray);

            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x - 120, y), p);
            dt2.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y), new Point(x - 120, y - 15), p);

            dt2.DrawMidPointAnimation(new Point(x, y - 30), new Point(x - 20, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 120, y - 15), new Point(x - 80, y - 30), p);
            dt2.DrawMidPointAnimation(new Point(x - 20, y - 30), new Point(x - 30, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 30), new Point(x - 80, y - 40), p);
            dt2.DrawMidPointAnimation(new Point(x - 30, y - 40), new Point(x - 80, y - 40), p);


            dt2.DrawMidPointAnimation(new Point(x - 15, y - 7), new Point(x - 15, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 15, y - 20), new Point(x - 80, y - 20), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 20), new Point(x - 80, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 80, y - 7), new Point(x - 15, y - 7), p);
            dt2.DrawMidPointAnimation(new Point(x - 60, y - 20), new Point(x - 40, y - 7), p);
            //banh xe
            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 90, y + 10, 3, Color.Gray);

        }
        void translatingLorryRightToLeft(int x, int y)
        {
            
            dt2.FillColor(new Point(x - 50, y - 20), Color.Gray);
            dt2.FillColor(new Point(x - 120, y - 10), Color.Gray);
            dt2.FillColor(new Point(x - 105, y - 43), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPoint(new Point(x, y), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x - 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x - 100, y - 50), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x - 100, y), new Point(x - 150, y), p);
            dt2.DrawMidPoint(new Point(x - 150, y), new Point(x - 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 40), new Point(x - 100, y - 50), p);

            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 80, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 80, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 130, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 130, y + 10, 3, Color.Gray);

            //ve lai xe: 
            x -= 10;
            drawLorryRightToLeft(x, y);

        }
        void clearLorryRightToLeft(int x, int y)
        {
            dt2.FillColor(new Point(x - 50, y - 20), Color.Gray);
            dt2.FillColor(new Point(x - 120, y - 10), Color.Gray);
            dt2.FillColor(new Point(x - 105, y - 43), Color.Gray);
            Pen p = new Pen(Color.Gray, widthLine);
            dt2.DrawMidPoint(new Point(x, y), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x, y), new Point(x, y - 50), p);
            dt2.DrawMidPoint(new Point(x, y - 50), new Point(x - 100, y - 50), p);
            dt2.DrawMidPoint(new Point(x - 100, y - 50), new Point(x - 100, y), p);
            dt2.DrawMidPoint(new Point(x - 100, y), new Point(x - 150, y), p);
            dt2.DrawMidPoint(new Point(x - 150, y), new Point(x - 150, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 100, y - 35), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 35), new Point(x - 150, y - 40), p);
            dt2.DrawMidPoint(new Point(x - 150, y - 40), new Point(x - 100, y - 50), p);

            dt2.MidPointDrawCircle(x - 20, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 20, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 80, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 80, y + 10, 3, Color.Gray);
            dt2.MidPointDrawCircle(x - 130, y + 10, 10, Color.Gray);
            dt2.MidPointDrawCircle(x - 130, y + 10, 3, Color.Gray);

        }
        private void StartDraw_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("audio.wav");
            
            simpleSound.Play();
           moveSun();   
           moveVehicle();
           houseDayandNight(); 
          //movePlane(); 
           
        }
        void moveSun()
        {
            ThreadStart threadstart = new ThreadStart(sunGoDown);
            Thread threadSun = new Thread(threadstart);
            threadSun.IsBackground = true;
            threadSun.Start();

            

        }
        void movePlane()
        {
            ThreadStart threadstart = new ThreadStart(moveAirPlane);
            Thread threadAirPlane = new Thread(threadstart);
            threadAirPlane.IsBackground = true;
            threadAirPlane.Start();
        }
        void moveVehicle()
        {
            ThreadStart threadStartOfVehicle = new ThreadStart(mainMove) ;
            Thread threadVehicle = new Thread(threadStartOfVehicle);
            threadVehicle.IsBackground = true; 
            threadVehicle.Start(); 
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
            moveVehicle(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
