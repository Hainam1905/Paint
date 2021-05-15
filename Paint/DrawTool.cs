﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    class DrawTool
    {
        private Bitmap bm, bmTemp, bmDefault;
        private Label Label;
        
        //Constructor
        public DrawTool(Bitmap bitmap, Label label)
        {
            this.Label = label;

            //Bitmap chính
            bm = bitmap;

            //Bitmap Để tô màu
            bmTemp = new Bitmap(bm);

            //Bitmap mặc định, không phải để vẽ
            bmDefault = new Bitmap(bm);

            //DrawCoordinate(bitmap.Width, bitmap.Height);
          //  PutPixel(bitmap.Width/2+7, bitmap.Height/2+7, Color.Blue);
        }
        private void DrawCoordinate(int x, int y)
        {
            //vẽ lưới dọc
            for (int i = 0; i < x; i+=5)
            {
                DrawLineBitmap(new Point(i, 0), new Point(i, y), new Pen(Color.Gray, 1f));
            }

            //vẽ lưới ngang
            for (int i = 0; i < y; i+=5)
            {
                DrawLineBitmap(new Point(0, i), new Point(x, i), new Pen(Color.Gray, 1f));
            }
            // vẽ trục Oxy
            int x0 = ((x / 5) / 2) * 5;
            int y0 = ((y / 5) / 2) * 5;
            DrawLineBitmap(new Point(x0, 0), new Point(x0, y), new Pen(Color.Black, 1.05f));
            DrawLineBitmap(new Point(0, y0), new Point(x, y0), new Pen(Color.Black, 1.05f));

        }

        private void DrawLineBitmap(Point A, Point B, Pen pen)
        {
            for(int i = A.X; i<= B.X; i++)
            {
                for(int j = A.Y; j <= B.Y; j++)
                {
                    if (i- 1 > 0 && i + 1 < bm.Width && j - 1 > 0 && j + 1 < bm.Height)
                    {
                        bm.SetPixel(i, j, pen.Color);


                    }
                }
            }
        }
        private void PutPixel(int x, int y, Color color)
        {
            if (x -2> 0 && x+2 < bm.Width && y-2 > 0 && y+2 < bm.Height )
            {
                if(bm.GetPixel(x, y+2) != Color.Gray && bm.GetPixel(x+2, y ) != Color.Gray)
                {
                    bm.SetPixel(x, y, color);
                    for (int i = 1; i <= 2; i++)
                    {

                        bm.SetPixel(x, y + i, color);
                        bm.SetPixel(x - i, y + i, color);
                        bm.SetPixel(x - i, y, color);
                        bm.SetPixel(x - i, y - i, color);
                        bm.SetPixel(x, y - i, color);
                        bm.SetPixel(x + i, y - i, color);
                        bm.SetPixel(x + i, y + 1, color);
                        bm.SetPixel(x, y + i, color);

                    }
                    //ToMauXungQuanh(new Point(x, y), color);
                    //FillColor(new Point(x,y), color);
                }

            }
        }
        private void PutPixelGrid(int x, int y, Color color)
        {
            //x =x*5+ bm.Width / 2;
            //y =y*5+ bm.Height / 2;
            if (x - 1 > 0 && x + 1 < bm.Width && y - 1 > 0 && y + 1 < bm.Height)
            {
                bm.SetPixel(x, y, color);
                                

            }
        }
        private void PutPixelGrid3D(int x, int y, Color color)
        {
            int xFake = x / 5;
            int yFake = y / 5;
            xFake = xFake * 5;
            yFake = yFake * 5;
            Graphics gp = Graphics.FromImage(bm);
            SolidBrush brush = new SolidBrush(color);
            gp.FillRectangle(brush, xFake, yFake, 5, 5);
            //bm.SetPixel(xFake, yFake, color) ;
                
        }
        //Vẽ 8 điểm từ 1 điểm trên đường tròn
        private void Draw8Pixel(int xa, int ya, int i, int j, Color color)//(i,j) toa do 1 diem tren duong tron
        {
            //ToMauXungQuanh(new Point(xa + i, ya + j), color);
            //ToMauXungQuanh(new Point(xa - i, ya + j), color);
            //ToMauXungQuanh(new Point(xa + i, ya - j), color);
            //ToMauXungQuanh(new Point(xa - i, ya - j), color);
            //ToMauXungQuanh(new Point(xa + j, ya + i), color);
            //ToMauXungQuanh(new Point(xa - j, ya + i), color);
            //ToMauXungQuanh(new Point(xa + j, ya - i), color);
            //ToMauXungQuanh(new Point(xa - j, ya - i), color);

            PutPixel(xa + i, ya + j, color);
            PutPixel(xa - i, ya + j, color);
            PutPixel(xa + i, ya - j, color);
            PutPixel(xa - i, ya - j, color);
            PutPixel(xa + j, ya + i, color);
            PutPixel(xa - j, ya + i, color);
            PutPixel(xa + j, ya - i, color);
            PutPixel(xa - j, ya - i, color);
        }
        //dung cho ham drawMidPointHaftCircle
        private void Draw4Pixel(int xa, int ya, int i, int j, Color color)//(i,j) toa do 1 diem tren duong tron
        {
            //ToMauXungQuanh(new Point(xa + i, ya + j), color);
            //ToMauXungQuanh(new Point(xa - i, ya + j), color);
            //ToMauXungQuanh(new Point(xa + i, ya - j), color);
            //ToMauXungQuanh(new Point(xa - i, ya - j), color);
            //ToMauXungQuanh(new Point(xa + j, ya + i), color);
            //ToMauXungQuanh(new Point(xa - j, ya + i), color);
            //ToMauXungQuanh(new Point(xa + j, ya - i), color);
            //ToMauXungQuanh(new Point(xa - j, ya - i), color);

            PutPixelGrid3D(xa + i, ya + j, color);
            //PutPixel(xa - i, ya + j, color);
            PutPixelGrid3D(xa + i, ya - j, color);
            //PutPixel(xa - i, ya - j, color);
            PutPixelGrid3D(xa + j, ya + i, color);
            //PutPixel(xa - j, ya + i, color);
            PutPixelGrid3D(xa + j, ya - i, color);
            //PutPixel(xa - j, ya - i, color);
        }
        private void Draw8PixelIn3D(int xa, int ya, int i, int j, Color color)//(i,j) toa do 1 diem tren duong tron
        {
            //ToMauXungQuanh(new Point(xa + i, ya + j), color);
            //ToMauXungQuanh(new Point(xa - i, ya + j), color);
            //ToMauXungQuanh(new Point(xa + i, ya - j), color);
            //ToMauXungQuanh(new Point(xa - i, ya - j), color);
            //ToMauXungQuanh(new Point(xa + j, ya + i), color);
            //ToMauXungQuanh(new Point(xa - j, ya + i), color);
            //ToMauXungQuanh(new Point(xa + j, ya - i), color);
            //ToMauXungQuanh(new Point(xa - j, ya - i), color);

            PutPixelGrid3D(xa + i, ya + j, color);
            PutPixelGrid3D(xa - i, ya + j, color);
            PutPixelGrid3D(xa + i, ya - j, color);
            PutPixelGrid3D(xa - i, ya - j, color);
            PutPixelGrid3D(xa + j, ya + i, color);
            PutPixelGrid3D(xa - j, ya + i, color);
            PutPixelGrid3D(xa + j, ya - i, color);
            PutPixelGrid3D(xa - j, ya - i, color);
        }
        private void Draw8Pixel(int xa, int ya, int i, int j, Color color, Bitmap temp)
        {
            temp.SetPixel(xa + i, ya + j, color);
            temp.SetPixel(xa - i, ya + j, color);
            temp.SetPixel(xa + i, ya - j, color);
            temp.SetPixel(xa - i, ya - j, color);
            temp.SetPixel(xa + j, ya + i, color);
            temp.SetPixel(xa - j, ya + i, color);
            temp.SetPixel(xa + j, ya - i, color);
            temp.SetPixel(xa - j, ya - i, color);
        }

        //Vẽ đường tròn bằng MidPoints
        public void MidPointDrawCircle(int x, int y, int R, Color color)
        {
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R


            
            while (i <= j)
            {

                
                    Draw8Pixel(x, y, i, j, color); //Vẽ tại vị trí (0,R)
                

                //=== Thuật toán Midpoint=======
                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    j--;
                }

                i++;

              
            }
        }
        
        //Vẽ đường tròn bằng MidPoints
        public void MidPointDrawHaftCircle(int x, int y, int R, Color color)
        {
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R


         
            while (i <= j)
            {

                
                    Draw4Pixel(x, y, i, j, color); //Vẽ tại vị trí (0,R)
                

                //=== Thuật toán Midpoint=======
                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    j--;
                }

                i++;

                
            }
        }


        public void MidPointDrawCircleIn3D(int x, int y, int R, Color color)
        {
            R = 5 * R; 
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R


            int pxCount = 0;//BIẾN ĐẾM PUT PIXEL 
            while (i <= j)
            {
                //Draw8Pixel(x, y, i, j, color); //Vẽ tại vị trí (0,R)
                Draw8PixelIn3D(x, y, i, j, color);
                
                //=== Thuật toán Midpoint=======
                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    j--;
                }

                i++;

                pxCount++;
            }
        }
        public void MidPointDrawCircleAnimation(int x, int y, int R, Color color)
        {
            
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R


            int pxCount = 0;//BIẾN ĐẾM PUT PIXEL 
            while (i <= j)
            {
                //Draw8Pixel(x, y, i, j, color); //Vẽ tại vị trí (0,R)
                Draw8PixelIn3D(x, y, i, j, color);

                //=== Thuật toán Midpoint=======
                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    j--;
                }

                i++;

                pxCount++;
            }
        }
        public void drawElipIn3Horizontal(int x, int y, int a, int b, Color color)
        {
            

            a = a * 5;
            b = b * 5; 
            double p;
            int k, d;
            k = 0;//x
            d = b;//y

            p = Math.Pow(a, 2) * (1 - 2 * b) + Math.Pow(b, 2);
            double xQ = Math.Pow(a, 2) / (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
            int check = 0;
            //ve nhanh thu 1(tu tren xuong )
            while (k < xQ + 1)
            {
                check++;
                draw4PointForEclipIn3D(x, y, k, d, color, check);
                if (p < 0)
                {
                    p = p + 2 * Math.Pow(b, 2) * (2 * k + 3);
                }
                else
                {
                    p = p + 2 * Math.Pow(b, 2) * (2 * k + 3) + 4 * Math.Pow(a, 2) * (1 - d);
                    d--;
                }
                k++;
                if (check > 20) check = 0;
            }
            //ve nhanh thu 2(tu duoi len )
            d = 0;
            k = a;
            p = Math.Pow(b, 2) * (1 - 2 * a) + Math.Pow(a, 2);
            double yQ = Math.Pow(b, 2) / (Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2)));
            check = 0;
            while (d < yQ + 1)
            {
                check++;
                draw4PointForEclip(x, y, k, d, color,check);
                if (p < 0)
                {
                    p = p + 2 * Math.Pow(a, 2) * (2 * d + 3);
                }
                else
                {
                    p = p + 2 * Math.Pow(a, 2) * (2 * d + 3) + 4 * Math.Pow(b, 2) * (1 - k);
                    k--;
                }
                d++;
                if (check > 20) check = 0;
            }
        }
        public void drawHaftElip(int x, int y, int a, int b, Color color)
        {


            
            double p;
            int k, d;
            k = 0;//x
            d = b;//y

            p = Math.Pow(a, 2) * (1 - 2 * b) + Math.Pow(b, 2);
            double xQ = Math.Pow(a, 2) / (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
           
            //ve nhanh thu 1(tu tren xuong )
            while (k < xQ + 1)
            {
                
                draw2PointForHaftElip(x, y, k, d, color);
                if (p < 0)
                {
                    p = p + 2 * Math.Pow(b, 2) * (2 * k + 3);
                }
                else
                {
                    p = p + 2 * Math.Pow(b, 2) * (2 * k + 3) + 4 * Math.Pow(a, 2) * (1 - d);
                    d--;
                }
                k++;
                
            }
            //ve nhanh thu 2(tu duoi len )
            d = 0;
            k = a;
            p = Math.Pow(b, 2) * (1 - 2 * a) + Math.Pow(a, 2);
            double yQ = Math.Pow(b, 2) / (Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2)));
            
            while (d < yQ + 1)
            {
               
                draw2PointForHaftElip(x, y, k, d, color);
                if (p < 0)
                {
                    p = p + 2 * Math.Pow(a, 2) * (2 * d + 3);
                }
                else
                {
                    p = p + 2 * Math.Pow(a, 2) * (2 * d + 3) + 4 * Math.Pow(b, 2) * (1 - k);
                    k--;
                }
                d++;
                
            }
        }
        private void draw4PointForEclip(int xc, int yc, int x, int y,Color color, int check)//ve 4 diem doi xung
        {
            PutPixel(xc + x, yc + y,color);
            PutPixel(xc - x, yc + y,color);
            if (check <= 10)
            {
                PutPixel(xc - x, yc - y,color);
                PutPixel(xc + x, yc - y,color);
            }

        }
        private void draw4PointForEclipIn3D(int xc, int yc, int x, int y, Color color, int check)//ve 4 diem doi xung
        {
            PutPixelGrid3D(xc + x, yc + y, color);
            PutPixelGrid3D(xc - x, yc + y, color);
            if (check <= 10)
            {
                PutPixelGrid3D(xc - x, yc - y, color);
                PutPixelGrid3D(xc + x, yc - y, color);
            }

        }
        private void draw2PointForHaftElip(int xc, int yc, int x, int y, Color color)//ve 4 diem doi xung
        {
            PutPixelGrid3D(xc + x, yc + y, color);
            //PutPixel(xc - x, yc + y, color);
            //PutPixel(xc - x, yc - y, color);
            PutPixelGrid3D(xc + x, yc - y, color);
            

        }
        private void MidPointDrawCircle(int x, int y, int R, Color color, Bitmap temp)
        {
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R;
            while (i <= j)
            {
                Draw8Pixel(x, y, i, j, color, temp);
                if (d < 0) d += 2 * i + 3;
                else
                {
                    d += 2 * i - 2 * j + 5;
                    j--;
                }
                i++;
            }
        }

        private Point CongPoint(Point A, Point B)
        {
            return new Point(A.X + B.X, A.Y + B.Y);
        }
        private Point CongPoint(PointF A, PointF B)
        {
            return new Point((int)(A.X + B.X), (int)(A.Y + B.Y));
        }

        private Point TruPoint(Point A, Point B)
        {
            return new Point(A.X - B.X, A.Y - B.Y);
        }
        private Point TruPoint(PointF A, PointF B)
        {
            return new Point((int)(A.X - B.X), (int)(A.Y - B.Y));
        }

        private void GanPoint(ref Point A, ref Point B)
        {
            A.X = B.X;
            A.Y = B.Y;
        }

        public void ToMauXungQuanh(Point point, Color color)
        {
            int i = 1;

            if (bm.GetPixel(point.X, point.Y + i) != color)
                bm.SetPixel(point.X, point.Y + i, color);
            if (bm.GetPixel(point.X, point.Y) != color)
                bm.SetPixel(point.X, point.Y, color);
            if (bm.GetPixel(point.X, point.Y - i) != color)
                bm.SetPixel(point.X, point.Y - i, color);
            if (bm.GetPixel(point.X + i, point.Y + i) != color)
                bm.SetPixel(point.X + i, point.Y + i, color);
            if (bm.GetPixel(point.X + i, point.Y) != color)
                bm.SetPixel(point.X + i, point.Y, color);
            if (bm.GetPixel(point.X + i, point.Y - i) != color)
                bm.SetPixel(point.X + i, point.Y - i, color);
            if (bm.GetPixel(point.X - i, point.Y + i) != color)
                bm.SetPixel(point.X - i, point.Y + i, color);
            if (bm.GetPixel(point.X - i, point.Y) != color)
                bm.SetPixel(point.X - i, point.Y, color);
            if (bm.GetPixel(point.X - i, point.Y - i) != color)
                bm.SetPixel(point.X - i, point.Y - i, color);
        }

        public void ToMauDuongBienDeQuy(int x, int y, Color color)
        {
            Color c = bm.GetPixel(x, y);


            if (x <= 1 || y <= 1) return;
            else if (bm.GetPixel(x, y) == c && x < bm.Width && y < bm.Height && x > 0 && y > 0)
            {
                bm.SetPixel(x, y, color);
                ToMauDuongBienDeQuy(x - 1, y, color);
                ToMauDuongBienDeQuy(x, y - 1, color);
                ToMauDuongBienDeQuy(x + 1, y, color);
                ToMauDuongBienDeQuy(x, y + 1, color);
                x = x / 0;
            }
        }

        public void ToMauDuongBienKhuDeQuy(int x, int y, Color color)
        {
            Color clBackGround = bmTemp.GetPixel(x, y);
            List<Point> Q = new List<Point>();
            Point m = new Point();
            Point tg = new Point();

            if (bmTemp.GetPixel(x, y) == clBackGround && x < bmTemp.Width && y < bmTemp.Height && x > 0 && y > 0)
            {
                m.X = x;
                m.Y = y;
                bm.SetPixel(m.X, m.Y, color);
                Q.Add(m);

                while (Q != null)
                {
                    Q.RemoveAt(0);

                    //Xét điểm lân cận
                    if (bmTemp.GetPixel(m.X + 1, m.Y) == clBackGround)
                    {
                        bm.SetPixel(m.X + 1, m.Y, color); bmTemp.SetPixel(m.X + 1, m.Y, color);
                        tg.X = m.X + 1;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bmTemp.GetPixel(m.X - 1, m.Y) == clBackGround)
                    {
                        bm.SetPixel(m.X - 1, m.Y, color); bmTemp.SetPixel(m.X - 1, m.Y, color);
                        tg.X = m.X - 1;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bmTemp.GetPixel(m.X, m.Y + 1) == clBackGround)
                    {
                        bm.SetPixel(m.X, m.Y + 1, color); bmTemp.SetPixel(m.X, m.Y + 1, color);
                        tg.X = m.X;
                        tg.Y = m.Y + 1;
                        Q.Add(tg);
                    }
                    if (bmTemp.GetPixel(m.X, m.Y - 1) == clBackGround)
                    {
                        bm.SetPixel(m.X, m.Y - 1, color); bmTemp.SetPixel(m.X, m.Y - 1, color);
                        tg.X = m.X;
                        tg.Y = m.Y - 1;
                        Q.Add(tg);
                    }

                    if (Q.Count == 0) break;
                    //Đưa về giá trị đầu của Q
                    m = Q[0];
                }
            }
        }

        private void ToMauDuongBienKhuDeQuy(int x, int y, Color color, Bitmap bitmap)
        {
            Color clBackGround = bm.GetPixel(x, y);
            List<Point> Q = new List<Point>();
            Point m = new Point();
            Point tg = new Point();

            /*if (bitmap.GetPixel(x, y) == clBackGround) Label.Text = "bang";
            else Label.Text = "khac";*/

            if (bitmap.GetPixel(x, y) == clBackGround && x < bitmap.Width && y < bitmap.Height && x > 0 && y > 0)
            {
                m.X = x;
                m.Y = y;
                bitmap.SetPixel(m.X, m.Y, color);
                Q.Add(m);

                while (Q != null)
                {
                    Q.RemoveAt(0);

                    //Xét điểm lân cận
                    if (bitmap.GetPixel(m.X + 1, m.Y) == clBackGround)
                    {
                        bitmap.SetPixel(m.X + 1, m.Y, color); //bmTemp.SetPixel(m.X + 1, m.Y, color);
                        tg.X = m.X + 1;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bitmap.GetPixel(m.X - 1, m.Y) == clBackGround)
                    {
                        bitmap.SetPixel(m.X - 1, m.Y, color); //bmTemp.SetPixel(m.X - 1, m.Y, color);
                        tg.X = m.X - 1;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bitmap.GetPixel(m.X, m.Y + 1) == clBackGround)
                    {
                        bitmap.SetPixel(m.X, m.Y + 1, color); //bmTemp.SetPixel(m.X, m.Y + 1, color);
                        tg.X = m.X;
                        tg.Y = m.Y + 1;
                        Q.Add(tg);
                    }
                    if (bitmap.GetPixel(m.X, m.Y - 1) == clBackGround)
                    {
                        bitmap.SetPixel(m.X, m.Y - 1, color); //bmTemp.SetPixel(m.X, m.Y - 1, color);
                        tg.X = m.X;
                        tg.Y = m.Y - 1;
                        Q.Add(tg);
                    }

                    if (Q.Count == 0) break;
                    //Đưa về giá trị đầu của Q
                    m = Q[0];
                }
            }
        }
        //Tô màu
        public void ToMauTheoDuongBien(Point point, Pen pen)
        {
            if (bm.GetPixel(point.X, point.Y) != pen.Color) bm.SetPixel(point.X, point.Y, pen.Color);
            if (bm.GetPixel(point.X, point.Y + 1) != pen.Color && point.Y + 1 < bm.Height - 1)
                ToMauTheoDuongBien(new Point(point.X, point.Y + 1), pen);
            if (bm.GetPixel(point.X, point.Y - 1) != pen.Color && point.Y - 1 > 0)
                ToMauTheoDuongBien(new Point(point.X, point.Y - 1), pen);
            if (bm.GetPixel(point.X + 1, point.Y + 1) != pen.Color && point.Y + 1 < bm.Height - 1 && point.X + 1 < bm.Width - 1)
                ToMauTheoDuongBien(new Point(point.X + 1, point.Y + 1), pen);
            if (bm.GetPixel(point.X + 1, point.Y) != pen.Color && point.X + 1 < bm.Width - 1)
                ToMauTheoDuongBien(new Point(point.X + 1, point.Y), pen);
            if (bm.GetPixel(point.X + 1, point.Y - 1) != pen.Color && point.X + 1 < bm.Width - 1 && point.Y - 1 > 0)
                ToMauTheoDuongBien(new Point(point.X + 1, point.Y - 1), pen);
            if (bm.GetPixel(point.X - 1, point.Y + 1) != pen.Color && point.X - 1 > 0 && point.Y + 1 < bm.Height - 1)
                ToMauTheoDuongBien(new Point(point.X - 1, point.Y + 1), pen);
            if (bm.GetPixel(point.X - 1, point.Y) != pen.Color && point.X - 1 > 0)
                ToMauTheoDuongBien(new Point(point.X - 1, point.Y), pen);
            if (bm.GetPixel(point.X - 1, point.Y - 1) != pen.Color && point.X - 1 > 0 && point.Y - 1 > 0)
                ToMauTheoDuongBien(new Point(point.X - 1, point.Y + 1), pen);

            //    int i = 1;
            //while (bm.GetPixel(point.X, point.Y + i) != pen.Color
            //    || bm.GetPixel(point.X, point.Y) != pen.Color
            //    || bm.GetPixel(point.X, point.Y - i) != pen.Color
            //    || bm.GetPixel(point.X + i, point.Y + i) != pen.Color
            //    || bm.GetPixel(point.X + i, point.Y) != pen.Color
            //    || bm.GetPixel(point.X + i, point.Y - i) != pen.Color
            //    || bm.GetPixel(point.X - i, point.Y + i) != pen.Color
            //    || bm.GetPixel(point.X - i, point.Y) != pen.Color
            //    || bm.GetPixel(point.X - i, point.Y - i) != pen.Color)
            //{
            //    ToMauXungQuanh(point, pen);
            //
            //    if (point.X + i < 0
            //        || point.X - i < 0
            //        || point.Y + i < 0
            //        || point.Y - i < 0)
            //        return;
            //}
        }

        //private int UCLN(int a, int b)
        //{
        //    while (a != b && b >= 0 && a >= 0)
        //    {
        //        if (a > b)
        //            a = a - b;
        //        else
        //            b = b - a;
        //    }
        //    return a;
        //}

        //private Point rutGonP(Point point)
        //{
        //    int UC;
        //    UC = UCLN(point.X, point.Y);

        //    if(UC > 0)
        //    {
        //        point.X = point.X / UC;
        //        point.Y = point.Y / UC;
        //    }

        //    return point;
        //}

        private Point timVTPT(Point A, Point B, int lenght)
        {
            Point VTPT = new Point();

            VTPT.X = B.Y - A.Y;
            VTPT.Y = -(B.X - A.X);

            if (VTPT.X == 0)
            {
                if (VTPT.Y > 0) VTPT.Y = lenght;
                else if (VTPT.Y < 0) VTPT.Y = -lenght;
                else VTPT.Y = 0;
            }
            else if (VTPT.Y == 0)
            {
                if (VTPT.X > 0) VTPT.X = lenght;
                else if (VTPT.X < 0) VTPT.X = -lenght;
                else VTPT.X = 0;
                //VTPT.X = lenght;
            }
            else
            {
                int x, y;
                double a;

                x = VTPT.X;
                y = VTPT.Y;
                a = ((float)lenght / Math.Sqrt((double)(1 + (y * y) / (x * x))));

                if (VTPT.X > 0) VTPT.X = (int)a;
                else VTPT.X = -(int)a;

                //if (VTPT.Y > 0) VTPT.Y = (int)(a * y / x);
                //else 
                VTPT.Y = (int)(a * y / Math.Abs(x));

            }

            return VTPT;
            //rutGonP(VTPT);
        }
        private PointF timVTPT(PointF A, PointF B, int lenght)
        {
            PointF VTPT = new PointF();

            VTPT.X = B.Y - A.Y;
            VTPT.Y = -(B.X - A.X);

            if (VTPT.X == 0)
            {
                if (VTPT.Y > 0) VTPT.Y = lenght;
                else if (VTPT.Y < 0) VTPT.Y = -lenght;
                else VTPT.Y = 0;
            }
            else if (VTPT.Y == 0)
            {
                if (VTPT.X > 0) VTPT.X = lenght;
                else if (VTPT.X < 0) VTPT.X = -lenght;
                else VTPT.X = 0;
                //VTPT.X = lenght;
            }
            else
            {
                float x, y;
                double a;

                x = VTPT.X;
                y = VTPT.Y;
                a = ((float)lenght / Math.Sqrt((double)(1 + (y * y) / (x * x))));

                if (VTPT.X > 0) VTPT.X = (int)a;
                else VTPT.X = -(int)a;

                //if (VTPT.Y > 0) VTPT.Y = (int)(a * y / x);
                //else 
                VTPT.Y = (int)(a * y / Math.Abs(x));

            }

            return VTPT;
        }

        private Point timVTCP(Point A, Point B, int lenght)
        {
            Point VTCP = new Point();

            VTCP.X = B.X - A.X;
            VTCP.Y = B.Y - A.Y;

            if (VTCP.X == 0)
            {
                //VTCP.Y = lenght;
                if (VTCP.Y > 0) VTCP.Y = lenght;
                else if (VTCP.Y < 0) VTCP.Y = -lenght;
                else VTCP.Y = 0;
            }
            else if (VTCP.Y == 0)
            {
                if (VTCP.X > 0) VTCP.X = lenght;
                else if (VTCP.X < 0) VTCP.X = -lenght;
                else VTCP.X = 0;
                //VTCP.X = lenght;
            }
            else
            {
                int x, y;
                double a;

                x = VTCP.X;
                y = VTCP.Y;
                a = ((float)lenght / Math.Sqrt((double)(1 + (y * y) / (x * x))));


                if (VTCP.X > 0) VTCP.X = (int)a;
                else VTCP.X = -(int)a;

                VTCP.Y = (int)(a * y / Math.Abs(x));
            }

            return VTCP;
        }

        public void DrawMidPoint(Point A, Point B, Pen pen)
        {
            MidPoint(A.X, B.X, A.Y, B.Y, pen);
        }
        public void DrawMidPointAnimation(Point A, Point B, Pen pen)
        {
            MidPointAnimation(A.X, B.X, A.Y, B.Y, pen);
        }
        public void DrawMidPoint(Point A, Point B, Pen pen, Bitmap bitmap)
        {
            MidPoint(A.X, B.X, A.Y, B.Y, pen, bitmap);
        }
        public void DrawMidPoint(Point A, Point B, Pen pen, int width)
        {
            MidPoint(A.X, B.X, A.Y, B.Y, pen, width);
        }
        public void DrawMidPointIn3D(Point A, Point B, Pen pen, int width)
        {
            MidPointIn3D(A.X, B.X, A.Y, B.Y, pen, width);
        }
        public void drawMidPointDeCrete(Point A, Point B, Pen pen, int width)
        {
            MidPointDecrete(A.X, B.X, A.Y, B.Y, pen, width);
        }
        public void drawMidPointDeCreteIn3D(Point A, Point B, Pen pen, int width)
        {
            MidPointDecreteIn3D(A.X, B.X, A.Y, B.Y, pen, width);
        }
        //Thuật toán Mid Point
        //MidPoint vẽ vào main Bitmap
        private void MidPoint(int x1, int x2, int y1, int y2, Pen pen)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;

            PutPixel(x, y, pen.Color);
            //PutPixel(new Point(x, y), pen);

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {
                if (hsg < 1 && hsg > 0)
                {
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg >= 1)
                {
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixel(x, y, pen.Color);
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg <= -1)
                {
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        //PutPixel(new Point(x, y), pen);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //PutPixel(new Point(x, y), pen);
                            PutPixel(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            PutPixel(x, y, pen.Color);
                        }
                }
            }
        }
        private void MidPointAnimation(int x1, int x2, int y1, int y2, Pen pen)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;

            PutPixelGrid3D(x, y, pen.Color);
            //PutPixel(new Point(x, y), pen);

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {
                if (hsg < 1 && hsg > 0)
                {
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg >= 1)
                {
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg <= -1)
                {
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        //PutPixel(new Point(x, y), pen);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //PutPixel(new Point(x, y), pen);
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                }
            }
        }
        private void MidPoint(int x1, int x2, int y1, int y2, Pen pen, Bitmap bitmap)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;

            //bitmap.SetPixel(x, y, pen.Color);
            PutPixel(x, y, pen.Color);

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {
                if (hsg < 1 && hsg > 0)
                {
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bitmap.SetPixel(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg >= 1)
                {
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bitmap.SetPixel(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bitmap.SetPixel(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bitmap.SetPixel(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg <= -1)
                {
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        //PutPixel(new Point(x, y), pen);
                        //bitmap.SetPixel(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //PutPixel(new Point(x, y), pen);
                           // bitmap.SetPixel(x, y, pen.Color);
                            PutPixel(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            //bitmap.SetPixel(x, y, pen.Color);
                            PutPixel(x, y, pen.Color);
                        }
                }
            }
        }
        private void MidPoint(int x1, int x2, int y1, int y2, Pen pen, int width)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;

            ToMauXungQuanh(new Point(x, y), pen.Color);
            
            

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {
                if (hsg < 1 && hsg > 0)
                {
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;


                        ToMauXungQuanh(new Point(x, y), pen.Color);
                        
                    }
                }
                else if (hsg >= 1)
                {
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        ToMauXungQuanh(new Point(x, y), pen.Color);
                        
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;


                        ToMauXungQuanh(new Point(x, y), pen.Color);
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        ToMauXungQuanh(new Point(x, y), pen.Color);
                        
                    }
                }
                else if (hsg <= -1)
                {
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        ToMauXungQuanh(new Point(x, y), pen.Color);
                        
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            ToMauXungQuanh(new Point(x, y), pen.Color);
                            
                        }
                    else
                        while (x < x2)
                        {
                            x++;
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                            
                        }
                }
            }
        }
        private void MidPointIn3D(int x1, int x2, int y1, int y2, Pen pen, int width)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;

            //ToMauXungQuanh(new Point(x, y), pen.Color);
            PutPixelGrid3D(x, y, pen.Color);


            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {
                if (hsg < 1 && hsg > 0)
                {
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;


                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg >= 1)
                {
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        // ToMauXungQuanh(new Point(x, y), pen.Color);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg <= -1)
                {
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        PutPixelGrid3D(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //ToMauXungQuanh(new Point(x, y), pen.Color);
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;
                            //ToMauXungQuanh(new Point(x, y), pen.Color);
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                }
            }
        }
        private void MidPointDecrete(int x1, int x2, int y1, int y2, Pen pen, int width)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;


            ToMauXungQuanh(new Point(x, y), pen.Color);
            //bm.SetPixel(x, y, pen.Color);
            //PutPixel(new Point(x, y), pen);

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {

                if (hsg < 1 && hsg > 0)
                {
                    int count = 1;
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg >= 1)
                {
                    int count = 1;
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg == 0)
                {
                    int count = 1;
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    int count = 0;
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg <= -1)
                {
                    int count = 0;
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        if (count <= 20)
                        {
                            ToMauXungQuanh(new Point(x, y), pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg == 0)
                {
                    int count = 0;
                    if (a != 0)

                        while (y > y2)
                        {

                            y--;

                            if (count <= 20)
                            {
                                PutPixelGrid3D(x, y, pen.Color);
                            }
                            if (count == 30)
                            {
                                count = 0;
                            }
                            count++;
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            //bm.SetPixel(x, y, pen.Color);
                            if (count <= 20)
                            {
                                ToMauXungQuanh(new Point(x, y), pen.Color);
                            }
                            if (count == 30)
                            {
                                count = 0;
                            }
                            count++;
                        }
                }
            }
        }
        private void MidPointDecreteIn3D(int x1, int x2, int y1, int y2, Pen pen, int width)
        {
            //Khởi tạo biến
            int a, b, x, y, p, temp;
            float hsg;

            //Vẽ theo hướng vào gần trục Oy
            if (x2 - x1 < 0)
            {
                //Hoán đổi (x1,y1) và (x2,y2)
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            a = y2 - y1;
            b = -(x2 - x1);
            y = y1;
            x = x1;

            //Tính hệ số góc
            if (b == 0) hsg = 0;
            else hsg = -(float)a / b;


            PutPixelGrid3D(x, y, pen.Color);
            //bm.SetPixel(x, y, pen.Color);
            //PutPixel(new Point(x, y), pen);

            //Vẽ theo hướng ra xa trục Ox
            if (a > 0)
            {

                if (hsg < 1 && hsg > 0)
                {
                    int count = 1;
                    p = 2 * a + b;

                    while (x < x2)
                    {
                        if (p < 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y++;
                            p += 2 * (a + b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg >= 1)
                {
                    int count = 1;
                    p = a + 2 * b;

                    while (y < y2)
                    {
                        if (p > 0)
                        {
                            p += 2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a + b);
                        }

                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg == 0)
                {
                    int count = 1;
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
            }
            // Vẽ theo hướng về gần trục Ox
            else if (a <= 0)
            {
                if (hsg > -1 && hsg < 0)
                {
                    int count = 0;
                    p = 2 * a - b;

                    while (x < x2)
                    {
                        if (p > 0)
                        {
                            p += 2 * a;
                        }
                        else
                        {
                            y--;
                            p += 2 * (a - b);
                        }

                        x++;

                        //PutPixel(new Point(x, y), pen);
                        //bm.SetPixel(x, y, pen.Color);
                        if (count <= 20)
                        {
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg <= -1)
                {
                    int count = 0;
                    p = a - 2 * b;

                    while (y > y2)
                    {
                        if (p < 0)
                        {
                            p += -2 * b;
                        }
                        else
                        {
                            x++;
                            p += 2 * (a - b);
                        }

                        y--;

                        if (count <= 20)
                        {
                            PutPixelGrid3D(x, y, pen.Color);
                        }
                        if (count == 30)
                        {
                            count = 0;
                        }
                        count++;
                    }
                }
                else if (hsg == 0)
                {
                    int count = 0;
                    if (a != 0)

                        while (y > y2)
                        {

                            y--;

                            if (count <= 20)
                            {
                                PutPixelGrid3D(x, y, pen.Color);
                            }
                            if (count == 30)
                            {
                                count = 0;
                            }
                            count++;
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            //bm.SetPixel(x, y, pen.Color);
                            if (count <= 20)
                            {
                                PutPixelGrid3D(x, y, pen.Color);
                            }
                            if (count == 30)
                            {
                                count = 0;
                            }
                            count++;
                        }
                }
            }
        }
        public void DrawLineByMidPoint(Point firstPoint, Point lastPoint, Pen pen, Boolean drawColor)
        {
            if (pen.Width == 1) MidPoint(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, pen);
            else if (pen.Width == 2)
            {
                Point A, B, C, D;
                PointF VTPT = timVTPT((PointF)firstPoint, (PointF)lastPoint, (int)pen.Width);

                A = CongPoint(firstPoint, VTPT);
                B = TruPoint(firstPoint, VTPT);
                C = CongPoint(lastPoint, VTPT);
                D = TruPoint(lastPoint, VTPT);

                DrawMidPoint(A, B, pen);
                DrawMidPoint(A, C, pen);
                DrawMidPoint(B, D, pen);
                DrawMidPoint(C, D, pen);
                if (drawColor == true) DrawMidPoint(firstPoint, lastPoint, pen, 1);
            }
            else
            {
                bmTemp.Dispose();
                bmTemp = new Bitmap(bmDefault);

                Point A, B, C, D, diemToMau;
                PointF VTPT = timVTPT((PointF)firstPoint, (PointF)lastPoint, (int)pen.Width);

                A = CongPoint(firstPoint, VTPT);
                B = TruPoint(firstPoint, VTPT);
                C = CongPoint(lastPoint, VTPT);
                D = TruPoint(lastPoint, VTPT);

                //Vẽ hình Chữ nhật có width đã nhập
                DrawMidPoint(A, B, pen);
                DrawMidPoint(A, C, pen);
                DrawMidPoint(B, D, pen);
                DrawMidPoint(C, D, pen);

                if (drawColor == true)
                {
                    //Vẽ vào bitmap tạm để tô màu
                    DrawMidPoint(A, B, pen, bmTemp);
                    DrawMidPoint(A, C, pen, bmTemp);
                    DrawMidPoint(B, D, pen, bmTemp);
                    DrawMidPoint(C, D, pen, bmTemp);

                    //Tô màu hình chữ nhật
                    diemToMau = new Point(CongPoint(firstPoint, lastPoint).X / 2, CongPoint(firstPoint, lastPoint).Y / 2);
                    ToMauDuongBienKhuDeQuy(diemToMau.X, diemToMau.Y, pen.Color);
                }
                //ToMauXungQuanh(diemToMau, pen);
            }
        }

        private void DrawTriangleByMidPoint(Point day1TGC, Point day2TGC, Point dinhTGC, Pen pen, Boolean drawColor)
        {
            if (pen.Width == 1 || drawColor == false)
            {
                DrawMidPoint(day1TGC, day2TGC, pen);
                DrawMidPoint(day2TGC, dinhTGC, pen);
                DrawMidPoint(dinhTGC, day1TGC, pen);
            }
            else
            {
                //Rest lại bmTemp để tô màu
                bmTemp.Dispose();
                bmTemp = new Bitmap(bmDefault);

                Point diemToMau = new Point((day1TGC.X + day2TGC.X + dinhTGC.X) / 3,
                    (day1TGC.Y + day2TGC.Y + dinhTGC.Y) / 3);

                //Vẽ tam giác vào main bitmap
                DrawMidPoint(day1TGC, day2TGC, pen);
                DrawMidPoint(day2TGC, dinhTGC, pen);
                DrawMidPoint(dinhTGC, day1TGC, pen);

                //Vẽ tam giác vào bmTemp để tô màu
                DrawMidPoint(day1TGC, day2TGC, pen, bmTemp);
                DrawMidPoint(day2TGC, dinhTGC, pen, bmTemp);
                DrawMidPoint(dinhTGC, day1TGC, pen, bmTemp);

                ToMauDuongBienKhuDeQuy(diemToMau.X, diemToMau.Y, pen.Color);
            }
        }

        public void DrawArrow(Point firstPoint, Point lastPoint, Pen pen, Boolean drawColor)
        {
            Point dinhTGC = new Point();
            Point day1TGC = new Point();
            Point day2TGC = new Point();

            dinhTGC = lastPoint;

            //Tìm VTCP và VTPT
            Point VTCP = timVTCP(firstPoint, lastPoint, (int)pen.Width * 3);
            Point VTPT = timVTPT(firstPoint, lastPoint, (int)pen.Width * 3);

            //Tìm chân đường cao và điểm của tam giác
            lastPoint.X = lastPoint.X - VTCP.X; lastPoint.Y = lastPoint.Y - VTCP.Y;
            day1TGC.X = dinhTGC.X - VTCP.X + VTPT.X; day1TGC.Y = dinhTGC.Y - VTCP.Y + VTPT.Y;
            day2TGC.X = dinhTGC.X - VTCP.X - VTPT.X; day2TGC.Y = dinhTGC.Y - VTCP.Y - VTPT.Y;


            DrawLineByMidPoint(firstPoint, lastPoint, pen, drawColor);

            DrawTriangleByMidPoint(day1TGC, day2TGC, dinhTGC, pen, drawColor);
        }

        public void FillColor(Point fillPoint, Color color)
        {
            ToMauDuongBienKhuDeQuy(fillPoint.X, fillPoint.Y, color, bm);
        }

        public void DrawCircle(Point centerPoint, int R, Pen pen)
        {
            MidPointDrawCircle(centerPoint.X, centerPoint.Y, R, pen.Color);

            //if (fillColor)
            //{
            //    bmTemp.Dispose();
            //    bmTemp = new Bitmap(bmDefault);

            //    MidPointDrawCircle(centerPoint.X, centerPoint.Y, R, pen.Color, bmTemp);

            //    ToMauDuongBienKhuDeQuy(centerPoint.X, centerPoint.Y, pen.Color);
            //}
        }
    }

}
