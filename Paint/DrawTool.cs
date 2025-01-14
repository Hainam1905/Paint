﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
//final

namespace Paint
{
    class DrawTool
    {
        public Bitmap bm, bmTemp, bmDefault;
        private Label Label;
        public PictureBox pbDrawZone = null;
        public int x0, y0;

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

            //hàm vẽ đồ thị
            DrawCoordinate(bm.Width, bm.Height);
            //Gọi hàm vẽ lưới pixel 
            //DrawCoordinate(bitmap.Width, bitmap.Height);
            //PutPixel(50, 50, Color.Black);
        }
        public DrawTool(PictureBox pbDrawZone, Label label)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.pbDrawZone = pbDrawZone;
            this.Label = label;
            int w = pbDrawZone.Width;
            int h = pbDrawZone.Height;

            //Bitmap chính
            bm = new Bitmap(w, h);

            //Bitmap Để tô màu
            bmTemp = new Bitmap(bm);

            //Bitmap mặc định, không phải để vẽ
            bmDefault = new Bitmap(bm);

            //Gọi hàm vẽ lưới pixel 
            //DrawCoordinate(pbDrawZone.Width, pbDrawZone.Height);
            //hàm vẽ đồ thị
            //DrawCoordinate(bm.Width, bm.Height);
        }

        // hàm vẽ lưới pixel
        private void DrawCoordinate(int x, int y)
        {
            //vẽ lưới dọc
            for (int i = 0; i < x; i += 5)
            {
                DrawLineBitmap(new Point(i, 0), new Point(i, y), new Pen(Color.White, 1f));
            }

            //vẽ lưới ngang
            for (int i = 0; i < y; i += 5)
            {
                DrawLineBitmap(new Point(0, i), new Point(x, i), new Pen(Color.White, 1f));
            }
            // vẽ trục Oxy
            x0 = ((x / 5) / 2) * 5;
            y0 = ((y / 5) / 2) * 5;
            DrawLineBitmap(new Point(x0, 0), new Point(x0, y), new Pen(Color.Black, 1.05f));
            DrawLineBitmap(new Point(0, y0), new Point(x, y0), new Pen(Color.Black, 1.05f));
        }

        private void DrawLineBitmap(Point A, Point B, Pen pen)
        {
            for (int i = A.X; i <= B.X; i++)
            {
                for (int j = A.Y; j <= B.Y; j++)
                {
                    if (i > 0 && i < bm.Width && j > 0 && j < bm.Height)
                    {
                        bm.SetPixel(i, j, pen.Color);
                    }
                }
            }
        }
        public void DrawLineBitmap3D(Point A, Point B, Pen pen, Bitmap bm3D)
        {
            for (int i = A.X; i <= B.X; i++)
            {
                for (int j = A.Y; j <= B.Y; j++)
                {
                    if (i > 0 && i < bm3D.Width && j > 0 && j < bm3D.Height)
                    {
                        bm3D.SetPixel(i, j, pen.Color);
                    }
                }
            }
        }
        public void PutPixel(int x, int y, Color color)
        {

            x = x - x % 5 + 1;
            y = y - y % 5 + 1;
            if (x > 0 && x < bm.Width && y > 0 && y < bm.Height)
            {
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (x + i > 0 && x + i < bm.Width && y + j > 0 && y + j < bm.Height)
                        {
                            bm.SetPixel(x + i, y + j, color);
                        }
                    }
                }

            }
        }

        private void PutPixel2(int x, int y, Color color)
        {
            if (x - 2 > 0 && x + 2 < bm.Width && y - 2 > 0 && y + 2 < bm.Height)
            {
                if (bm.GetPixel(x, y + 2) != Color.Gray && bm.GetPixel(x + 2, y) != Color.Gray)
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
        public Color SetPixel(int x, int y, Color color)
        {
            //x =x*5+ bm.Width / 2;
            //y =y*5+ bm.Height / 2;
            //if (x > 0 && x < bm.Width && y > 0 && y < bm.Height)
            //{
            ToMauDuongBienKhuDeQuy(x, y, color);
            x = x - x % 5 + 1;
            y = y - y % 5 + 1;
            if (x > 0 && x < bm.Width && y > 0 && y < bm.Height)
            {
                //x++;
                //y++;

                //if (bm.GetPixel(x, y) != Color.White)
                //{
                return bm.GetPixel(x, y);

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            //}
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

            bm.SetPixel(xa + i, ya + j, color);
            bm.SetPixel(xa - i, ya + j, color);
            bm.SetPixel(xa + i, ya - j, color);
            bm.SetPixel(xa - i, ya - j, color);
            bm.SetPixel(xa + j, ya + i, color);
            bm.SetPixel(xa - j, ya + i, color);
            bm.SetPixel(xa + j, ya - i, color);
            bm.SetPixel(xa - j, ya - i, color);
        }
        private void Draw8Pixel2(int xa, int ya, int i, int j, Color color)//(i,j) toa do 1 diem tren duong tron
        {
            //ToMauXungQuanh(new Point(xa + i, ya + j), color);
            //ToMauXungQuanh(new Point(xa - i, ya + j), color);
            //ToMauXungQuanh(new Point(xa + i, ya - j), color);
            //ToMauXungQuanh(new Point(xa - i, ya - j), color);
            //ToMauXungQuanh(new Point(xa + j, ya + i), color);
            //ToMauXungQuanh(new Point(xa - j, ya + i), color);
            //ToMauXungQuanh(new Point(xa + j, ya - i), color);
            //ToMauXungQuanh(new Point(xa - j, ya - i), color);

            PutPixel2(xa + i, ya + j, color);
            PutPixel2(xa - i, ya + j, color);
            PutPixel2(xa + i, ya - j, color);
            PutPixel2(xa - i, ya - j, color);
            PutPixel2(xa + j, ya + i, color);
            PutPixel2(xa - j, ya + i, color);
            PutPixel2(xa + j, ya - i, color);
            PutPixel2(xa - j, ya - i, color);
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


            //tamthoitat
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
        public void MidPointDrawCircle2(int x, int y, int R, Color color)
        {
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R



            while (i <= j)
            {


                Draw8Pixel2(x, y, i, j, color); //Vẽ tại vị trí (0,R)


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
            x = (x + 80) * 5;
            y = (80 - y) * 5;

            R = 5 * R;
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R


            int pxCount = 0;//BIẾN ĐẾM PUT PIXEL 
            while (i <= j)
            {

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


                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    j--;
                }

                i++;

                //pxCount++;
            }
        }
        public void drawElipIn3Horizontal(int x, int y, int a, int b, Color color)
        {
            x = (x + 80) * 5;
            y = (80 - y) * 5;

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
                draw4PointForEclip(x, y, k, d, color, check);
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
        private void draw4PointForEclip(int xc, int yc, int x, int y, Color color, int check)//ve 4 diem doi xung
        {
            PutPixel(xc + x, yc + y, color);
            PutPixel(xc - x, yc + y, color);
            if (check <= 10)
            {
                PutPixel(xc - x, yc - y, color);
                PutPixel(xc + x, yc - y, color);
            }

        }
        private void draw4PointForEclipIn3D(int xc, int yc, int x, int y, Color color, int check)//ve 4 diem doi xung
        {
            //tam thoi tat
            /*PutPixelGrid3D(xc + x, yc + y, color);
            PutPixelGrid3D(xc - x, yc + y, color);*/

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

        //Hàm vẽ hình tròn trên lưới pixel dùng thuật toán MidPoint
        public void draw8Point(int xc, int yc, int x, int y, Color color)
        {
            PutPixel(xc + x, yc + y, color);
            PutPixel(xc + y, yc + x, color);
            PutPixel(xc + y, yc - x, color);
            PutPixel(xc + x, yc - y, color);
            PutPixel(xc - x, yc - y, color);
            PutPixel(xc - y, yc - x, color);
            PutPixel(xc - y, yc + x, color);
            PutPixel(xc - x, yc + y, color);
        }

        public void circleMidPoint(int xc, int yc, int R, Color color)
        {
            float p;
            int y = R;
            int x = 0;
            p = 5 / 4 - R;
            draw8Point(xc, yc, x, y, color);
            while (x < y)
            {
                if (p < 0)
                {
                    p += 2 * x + 3;

                }
                else
                {
                    p += 2 * (x - y) + 5;
                    y -= 5;
                }
                x += 5;
                draw8Point(xc, yc, x, y, color);
            }
        }
        //thiếu trường hợp (bỏ)
        public void lineBresenham(int x1, int y1, int x2, int y2, Color color)
        {
            int x, y, Dx, Dy, p;
            Dx = Math.Abs(x2 - x1);
            Dy = Math.Abs(y2 - y1);
            p = 2 * Dy - Dx;
            x = x1;
            y = y1;


            int x_unit = 1, y_unit = 1;

            //xét trường hợp để cho y_unit và x_unit để vẽ tăng lên hay giảm xuống
            if (x2 - x1 < 0)
                x_unit = (-1) * x_unit;
            if (y2 - y1 < 0)
                y_unit = (-1) * y_unit;

            if (x1 == x2)   // trường hợp vẽ đường thẳng đứng
            {
                PutPixel(x, y, color);
                while (y != y2)
                {
                    y += y_unit;
                    PutPixel(x, y, color);
                }
            }

            else if (y1 == y2)  // trường hợp vẽ đường ngang
            {
                PutPixel(x, y, color);
                while (x != x2)
                {
                    x += x_unit;
                    PutPixel(x, y, color);
                }
            }
            // trường hợp vẽ các đường xiên
            else
            {
                PutPixel(x, y, color);
                while (x != x2)
                {

                    if (p < 0) p += 2 * Dy;
                    else
                    {
                        p += 2 * (Dy - Dx);
                        y += y_unit;
                    }
                    x += x_unit;
                    PutPixel(x, y, color);
                }
            }
        }
        //vẽ đường thẳng dùng thuật toán DDA
        public void drawLineDDA(int xA, int yA, int xB, int yB, Color color)
        {
            Point A = new Point(xA, yA);
            Point B = new Point(xB, yB);
            A = findFakePoint(A);
            B = findFakePoint(B);

            int dX = B.X - A.X;
            int dY = B.Y - A.Y;

            double steps = Math.Max(Math.Abs(dX), Math.Abs(dY));
            double x_inc = (dX / steps);
            double y_inc = (dY / steps);

            double x = A.X, y = A.Y;

            Point p = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            p = findRealPoint(p);

            PutPixel(p.X, p.Y, color);
            int k = 0;

            while (k < steps)
            {
                k++;
                x += x_inc;
                y += y_inc;

                p.X = Convert.ToInt32(Math.Round(x));
                p.Y = Convert.ToInt32(Math.Round(y));
                p = findRealPoint(p);

                PutPixel(p.X, p.Y, color);
            }
        }
        public Point findFakePoint(Point p)
        {
            p.X = (p.X - x0) / 5;
            p.Y = (y0 - p.Y) / 5;
            return p;
        }
        public Point findRealPoint(Point p)
        {
            p.X = p.X * 5 + x0;
            p.Y = y0 - (p.Y * 5);
            return p;
        }
        public void draw4Point(int xc, int yc, int x, int y, Color color)
        {
            Point R = new Point(x + xc, y + yc);
            R = findRealPoint(R);
            PutPixel(R.X, R.Y, color);

            R = new Point(x + xc, yc - y);
            R = findRealPoint(R);
            PutPixel(R.X, R.Y, color);

            R = new Point(xc - x, yc - y);
            R = findRealPoint(R);
            PutPixel(R.X, R.Y, color);

            R = new Point(xc - x, y + yc);
            R = findRealPoint(R);
            PutPixel(R.X, R.Y, color);

        }
        public void drawEllipsMidPoint(int xc, int yc, int a, int b, Color color)
        {
            Point F = new Point(xc, yc);
            F = findFakePoint(F);

            xc = F.X;
            yc = F.Y;
            a = a / 5;
            b = b / 5;

            int steps = 1;
            double p;
            int y = b;
            int x = 0;
            double xQ = a * a / (Math.Sqrt(a * a + b * b));
            p = b * b - a * a * b + a * a / 4;
            draw4Point(xc, yc, x, y, color);
            while (x <= xQ)
            {
                if (p < 0)
                {
                    p += (b * b) * (2 * x + 3);
                }
                else
                {
                    p += (b * b) * (2 * x + 3) - 2 * a * a * (y - 1);
                    y -= steps;
                }
                x += steps;
                draw4Point(xc, yc, x, y, color);
            }
            x = a;
            y = 0;
            p = a * a - b * b * a + b * b / 4;
            draw4Point(xc, yc, x, y, color);
            while (x >= xQ)
            {
                if (p < 0)
                {
                    p += (a * a) * (2 * y + 3);
                }
                else
                {
                    p += (a * a) * (2 * y + 3) - 2 * b * b * (x - 1);
                    x -= steps;
                }
                y += steps;
                draw4Point(xc, yc, x, y, color);
            }
        }
        public Point doiXungQuaO(Point p)
        {
            return new Point(p.X * (-1), p.Y * (-1));
        }
        public Point doiXungQuaOX(Point p)
        {
            return new Point(p.X, p.Y * (-1));
        }
        public Point doiXungQuaOY(Point p)
        {
            return new Point(p.X * (-1), p.Y);
        }
        public Point layDiemQuay(Point a)
        {
            double sin = Math.Sin(Math.PI * 60.0 / 180.0);
            double cos = Math.Cos(Math.PI * 60.0 / 180.0);

            Point p = new Point(a.X, a.Y);

            a.X = Convert.ToInt32(p.X * cos - sin * p.Y);
            a.Y = Convert.ToInt32(p.X * sin + cos * p.Y);

            return a;
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

            //if (bm.GetPixel(point.X, point.Y + i) != color)
            bm.SetPixel(point.X, point.Y + i, color);
            //if (bm.GetPixel(point.X, point.Y) != color)
            bm.SetPixel(point.X, point.Y, color);
            //if (bm.GetPixel(point.X, point.Y - i) != color)
            bm.SetPixel(point.X, point.Y - i, color);
            //if (bm.GetPixel(point.X + i, point.Y + i) != color)
            bm.SetPixel(point.X + i, point.Y + i, color);
            //if (bm.GetPixel(point.X + i, point.Y) != color)
            bm.SetPixel(point.X + i, point.Y, color);
            //if (bm.GetPixel(point.X + i, point.Y - i) != color)
            bm.SetPixel(point.X + i, point.Y - i, color);
            //if (bm.GetPixel(point.X - i, point.Y + i) != color)
            bm.SetPixel(point.X - i, point.Y + i, color);
            //if (bm.GetPixel(point.X - i, point.Y) != color)
            bm.SetPixel(point.X - i, point.Y, color);
            //if (bm.GetPixel(point.X - i, point.Y - i) != color)
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

            bm.SetPixel(x, y, pen.Color);
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
                        bm.SetPixel(x, y, pen.Color);
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
                        bm.SetPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        bm.SetPixel(x, y, pen.Color);
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
                        bm.SetPixel(x, y, pen.Color);
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
                        bm.SetPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //PutPixel(new Point(x, y), pen);
                            bm.SetPixel(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            bm.SetPixel(x, y, pen.Color);
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

                        PutPixelGrid3D(x, y, pen.Color);

                        // bitmap.SetPixel(x, y, pen.Color);

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


                        PutPixelGrid3D(x, y, pen.Color);


                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;


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


                        PutPixelGrid3D(x, y, pen.Color);

                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;


                            PutPixelGrid3D(x, y, pen.Color);

                        }
                    else
                        while (x < x2)
                        {
                            x++;

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

        // MidPoint theo Lưới
        public void MidPoint(int x1, int x2, int y1, int y2, Pen pen, Boolean luoi)
        {
            Point A = new Point();
            A = changeToFakePoint(new Point(x1, y1));
            x1 = A.X; y1 = A.Y;
            Point B = new Point();
            B = changeToFakePoint(new Point(x2, y2));
            x2 = B.X; y2 = B.Y;
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

            Point C = new Point();
            C = changeToRealPoint(new Point(x, y));
            PutPixel(C.X, C.Y, pen.Color);
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
                        C = changeToRealPoint(new Point(x, y));
                        PutPixel(C.X, C.Y, pen.Color);
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
                        C = changeToRealPoint(new Point(x, y));
                        PutPixel(C.X, C.Y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //PutPixel(new Point(x, y), pen);
                        C = changeToRealPoint(new Point(x, y));
                        PutPixel(C.X, C.Y, pen.Color);
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
                        C = changeToRealPoint(new Point(x, y));
                        PutPixel(C.X, C.Y, pen.Color);
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
                        C = changeToRealPoint(new Point(x, y));
                        PutPixel(C.X, C.Y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //PutPixel(new Point(x, y), pen);
                            C = changeToRealPoint(new Point(x, y));
                            PutPixel(C.X, C.Y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;

                            //PutPixel(new Point(x, y), pen);
                            C = changeToRealPoint(new Point(x, y));
                            PutPixel(C.X, C.Y, pen.Color);
                        }
                }
            }
        } 
        public void DrawTriangleByMidPoint(Point day1TGC, Point day2TGC, Point dinhTGC, Pen pen, Boolean drawColor)
        {
            if (drawColor == false)
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
                //DrawMidPoint(day1TGC, day2TGC, pen, bmTemp);
                //DrawMidPoint(day2TGC, dinhTGC, pen, bmTemp);
                //DrawMidPoint(dinhTGC, day1TGC, pen, bmTemp);

                ToMauDuongBienKhuDeQuy(diemToMau.X, diemToMau.Y, pen.Color, bm);
            }
        }

        private void DrawConLac(Point A, Point B, Point centerP, int R, Pen p, Boolean isColor)
        {
            DrawLineByMidPoint(A, B, p, isColor);
            DrawCircle(centerP, R, p, isColor);
            //if(pbDrawZone != null) pbDrawZone.Image = bm;
        }

        private void DrawClock(Point A, int height, Color color)
        {
            Point B, C, D, E, X, Y, Z, centerP;
            float radius;
            Pen p = new Pen(color, 1);

            B = new Point(A.X + height / 2, A.Y); C = new Point(A.X - height / 2, A.Y);
            D = new Point(B.X, B.Y - height); E = new Point(C.X, D.Y);

            X = new Point(A.X, A.Y - (2 * height) + height / 4);
            Y = new Point(D.X + (height / 2), D.Y); Z = new Point(E.X - (height / 2), E.Y);

            centerP = new Point(A.X, A.Y - (height / 2));
            radius = height / 2 - 5;

            Pen deleteP = new Pen(SystemColors.Control, 1);

            //DrawLineByMidPoint(B, C, p, false); DrawLineByMidPoint(C, E, p, false);
            //DrawLineByMidPoint(E, D, p, false); DrawLineByMidPoint(D, B, p, false);
            DrawLineByMidPoint(new Point(B.X, (B.Y + D.Y) / 2), new Point(C.X, (C.Y + E.Y) / 2), new Pen(Color.Black, height / 2), true);
            
            DrawTriangleByMidPoint(Y, Z, X, p, true);

            DrawCircle(centerP, (int)radius, deleteP, true);
            //FillColor(centerP, p.Color);
        }

        public void DrawConLacThang(Point A, int height, int R, Color color, Boolean isStop)
        {
            ChangeTool ct = new ChangeTool(Label);
            Point B = new Point(A.X, A.Y + height - R);
            Point centerP = new Point(B.X, B.Y + R);

            Point centerClockP = new Point(A.X, A.Y - (height / 2));
            int radiusClock = height / 2 - height / 5;
            Point lastClockP = new Point(centerClockP.X, centerClockP.Y - radiusClock);

            Point animB, animCenterP, animClock;
            Pen p = new Pen(color, 2);
            Pen deleteP = new Pen(SystemColors.Control, 2);
            float maxAngle = 30;
            float angle = maxAngle;
            float angleClock = 0;

            Boolean chieuDuong = true;

            DrawClock(A, height, color);
            animClock = lastClockP;
            int i = 0;
            while (isStop)
            {
                //Thread.Yield();
                Label.Text = i.ToString();
                i++;

                if (angle == maxAngle)
                {
                    chieuDuong = false;

                    DrawArrow(centerClockP, animClock, new Pen(SystemColors.Control, height / 50), false);
                    animClock = ct.RotateAroundPoint(centerClockP, lastClockP, angleClock, color);
                    DrawArrow(centerClockP, animClock, new Pen(color, height / 50), false);

                    angleClock = angleClock + 6;
                }
                else if (angle == -maxAngle)
                {
                    chieuDuong = true;

                    DrawArrow(centerClockP, animClock, new Pen(SystemColors.Control, height / 50), false);
                    animClock = ct.RotateAroundPoint(centerClockP, lastClockP, angleClock, color);
                    DrawArrow(centerClockP, animClock, new Pen(color, height / 50), false);

                    angleClock = angleClock + 6;
                }


                animB = ct.RotateAroundPoint(A, B, angle, color);
                animCenterP = ct.RotateAroundPoint(A, centerP, angle, color);

                DrawConLac(A, animB, animCenterP, R, p, true);

                pbDrawZone.Refresh();
                //pbDrawZone.Image = bm;
                Thread.Sleep(3);

                if (chieuDuong)
                {
                    animB = ct.RotateAroundPoint(A, B, angle - 1, color);
                    animCenterP = ct.RotateAroundPoint(A, centerP, angle - 1, color);
                }
                else
                {
                    animB = ct.RotateAroundPoint(A, B, angle + 1, color);
                    animCenterP = ct.RotateAroundPoint(A, centerP, angle + 1, color);
                }

                DrawConLac(A, animB, animCenterP, R, deleteP, true);

                if (chieuDuong)
                {
                    angle++;
                }
                else
                {
                    angle--;
                }
            }
        }

        public void ResetBitmap()
        {
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                    bm.SetPixel(i, j, SystemColors.Control);
            if (pbDrawZone != null) pbDrawZone.Image = bm;
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
            //PutPixelGrid3D(x, y, pen.Color);
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


                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        //PutPixelGrid3D(x, y, pen.Color);
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

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        //PutPixelGrid3D(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    while (y < y2)
                    {
                        y++;

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        //PutPixelGrid3D(x, y, pen.Color);
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

                        // ToMauXungQuanh(new Point(x, y), pen.Color);
                        //PutPixelGrid3D(x, y, pen.Color);
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

                        //ToMauXungQuanh(new Point(x, y), pen.Color);
                        //PutPixelGrid3D(x, y, pen.Color);
                        PutPixel(x, y, pen.Color);
                    }
                }
                else if (hsg == 0)
                {
                    if (a != 0)
                        while (y > y2)
                        {
                            y--;

                            //ToMauXungQuanh(new Point(x, y), pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
                            PutPixel(x, y, pen.Color);
                        }
                    else
                        while (x < x2)
                        {
                            x++;
                            //ToMauXungQuanh(new Point(x, y), pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
                            PutPixel(x, y, pen.Color);
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
                                //PutPixelGrid3D(x, y, pen.Color);
                                PutPixel(x, y, pen.Color);
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

            PutPixel(x, y, pen.Color);
            //PutPixelGrid3D(x, y, pen.Color);
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
                            PutPixel(x, y, pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
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
                            PutPixel(x, y, pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
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
                            PutPixel(x, y, pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
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
                            PutPixel(x, y, pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
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
                            PutPixel(x, y, pen.Color);
                            //PutPixelGrid3D(x, y, pen.Color);
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
                                PutPixel(x, y, pen.Color);
                                //PutPixelGrid3D(x, y, pen.Color);
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
                                PutPixel(x, y, pen.Color);
                                //PutPixelGrid3D(x, y, pen.Color);
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
                    //DrawMidPoint(A, B, pen, bm);
                    //DrawMidPoint(A, C, pen, bm);
                    //DrawMidPoint(B, D, pen, bm);
                    //DrawMidPoint(C, D, pen, bm);

                    //Tô màu hình chữ nhật
                    diemToMau = new Point(CongPoint(firstPoint, lastPoint).X / 2, CongPoint(firstPoint, lastPoint).Y / 2);
                    ToMauDuongBienKhuDeQuy(diemToMau.X, diemToMau.Y, pen.Color, bm);

                }
                //ToMauXungQuanh(diemToMau, pen);
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

        public void DrawCircle(Point centerPoint, int R, Pen pen, Boolean fillColor)
        {
            MidPointDrawCircle(centerPoint.X, centerPoint.Y, R, pen.Color);

            if (fillColor)
            {
                bmTemp.Dispose();
                bmTemp = new Bitmap(bmDefault);

                MidPointDrawCircle(centerPoint.X, centerPoint.Y, R, pen.Color, bm);

                ToMauDuongBienKhuDeQuy(centerPoint.X, centerPoint.Y, pen.Color, bm);
            }
        }
        //Trường BỔ SUNG
        //các hàm chuyển đổi tọa độ
        public Point changeToFakePoint(Point point)
        {
            point.X = (point.X - x0) / 5;
            point.Y = (y0 - point.Y) / 5;
            return point;
        }
        public Point changeToRealPoint(Point point)
        {
            point.X = point.X * 5 + x0;
            point.Y = y0 - (point.Y * 5);
            return point;
        }

        //Hàm vẽ đường thẳng bằng thuật toán DDA
        public void DDALineGrid(int x1, int x2, int y1, int y2, Pen pen)
        {
            //đổi các điểm và tọa độ người dùng
            Point A = new Point(x1, y1);
            A = changeToFakePoint(A);
            Point B = new Point(x2, y2);
            B = changeToFakePoint(B);

            int Dx = B.X - A.X, Dy = B.Y - A.Y;
            // tìm số điểm ảnh đc vẽ
            float steps = Math.Max(Math.Abs(Dx), Math.Abs(Dy));

            //tim giá trị cộng cho x,y dựa vào steps
            float x_inc = (Dx / steps);
            float y_inc = (Dy / steps);

            float x = A.X, y = A.Y;

            // put vị trí đầu
            Point p = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            p = changeToRealPoint(p);
            PutPixel(p.X, p.Y, pen.Color);

            //biến đếm
            int k = 0;
            while (k < steps)
            {
                k++;
                x += x_inc;
                y += y_inc;

                p.X = Convert.ToInt32(Math.Round(x));
                p.Y = Convert.ToInt32(Math.Round(y));
                p = changeToRealPoint(p);

                PutPixel(p.X, p.Y, pen.Color);
            }
        }

        //Hàm vẽ 8 điểm từ 1 điểm của đường tròn vẽ trên lưới pixel
        private void Draw8PixelGrid(int xa, int ya, int i, int j, Color color)//(i,j) toa do 1 diem tren duong tron
        {
            PutPixel(xa + i, ya + j, color);
            PutPixel(xa - i, ya + j, color);
            PutPixel(xa + i, ya - j, color);
            PutPixel(xa - i, ya - j, color);
            PutPixel(xa + j, ya + i, color);
            PutPixel(xa - j, ya + i, color);
            PutPixel(xa + j, ya - i, color);
            PutPixel(xa - j, ya - i, color);
        }
        public void tim3DiemTamGiac(Point centerPoint, ref Point A, ref Point B, ref Point C, int chieuCao, int doDaiDay)
        {
            chieuCao = chieuCao * 5;
            doDaiDay = doDaiDay * 5;
            A = new Point(centerPoint.X + doDaiDay / 2, centerPoint.Y);
            B = new Point(centerPoint.X - doDaiDay / 2, centerPoint.Y);
            C = new Point(centerPoint.X, centerPoint.Y - chieuCao);
        }

        //tìm 4 điểm HCN theo tâm
        public void tim4DiemHinhChuNhat(Point centerPoint, ref Point A, ref Point B, ref Point C, ref Point D, int width, int height)
        {
            width = width * 5;
            height = height * 5;
            A = new Point(centerPoint.X - width / 2, centerPoint.Y + height / 2);
            B = new Point(centerPoint.X + width / 2, centerPoint.Y + height / 2);
            C = new Point(centerPoint.X + width / 2, centerPoint.Y - height / 2);
            D = new Point(centerPoint.X - width / 2, centerPoint.Y - height / 2);
        }

        //tìm 4 điểm HCN theo 1 điểm cho trc
        public void tim4DiemHCN_Canh(Point A, ref Point B, ref Point C, ref Point D, int width, int height)
        {
            width = width * 5;
            height = height * 5;
            B = new Point(A.X + width, A.Y);
            C = new Point(A.X + width, A.Y - height);
            D = new Point(A.X , A.Y - height);
        }

        //tìm 4 điểm hình thoi theo tâm
        public void tim4DiemHinhThoi(Point centerPoint, ref Point A, ref Point B, ref Point C, ref Point D, int cheoA, int cheoB)
        {
            cheoA = cheoA * 5;
            cheoB = cheoB * 5;
            A = new Point(centerPoint.X - cheoA / 2, centerPoint.Y);
            B = new Point(centerPoint.X, centerPoint.Y - cheoB / 2);
            C = new Point(centerPoint.X + cheoA / 2, centerPoint.Y);
            D = new Point(centerPoint.X, centerPoint.Y + cheoB / 2);
        }

        //tìm 4 điểm Hình thoi theo 1 điểm cho trc
        public void tim4DiemHinhThoi_Canh(Point A, ref Point B, ref Point C, ref Point D, int cheoA, int cheoB)
        {
            cheoA = cheoA * 5;
            cheoB = cheoB * 5;
            B = new Point(A.X + cheoA/2, A.Y-cheoB/2);
            C = new Point(A.X, A.Y - cheoB);
            D = new Point(A.X-cheoA/2, A.Y - cheoB/2);
        }
        public void VeHinhTuGiac(Pen pen, Point A, Point B, Point C, Point D)
        {
            MidPoint(A.X, B.X, A.Y, B.Y, pen, true);
            MidPoint(B.X, C.X, B.Y, C.Y, pen, true);
            MidPoint(C.X, D.X, C.Y, D.Y, pen, true);
            MidPoint(A.X, D.X, A.Y, D.Y, pen, true);
        }
        public void veHinhTamGiac(Point day1TGC, Point day2TGC, Point dinhTGC, Pen pen)
        {
            MidPoint(day1TGC.X, day2TGC.X, day1TGC.Y, day2TGC.Y, pen,true);
            MidPoint(day2TGC.X, dinhTGC.X, day2TGC.Y, dinhTGC.Y, pen,true);
            MidPoint(dinhTGC.X, day1TGC.X, dinhTGC.Y, day1TGC.Y, pen,true);
        }
        public void veHinhTron(int x, int y, int R, Color color)
        {
            //đổi R về tọa độ thực của lưới Pixel
            R = R * 5;
            // Khởi tạo các giá trị cho thuật toán
            int i, j, d;
            i = 0;
            j = R;
            d = 1 - R; // thay cho 5/4 - R

            while (i <= j)
            {
                Draw8PixelGrid(x, y, i, j, color); //Vẽ tại vị trí (0,R)
                //=== Thuật toán Midpoint=======
                if (d < 0) d += 2 * i + 3; //Chọn y(i+1) = y(i)
                else
                {
                    d += 2 * i - 2 * j + 5; //Chọn y(i+1) = y(i) - 1
                    //tăng 5 do putPixel theo lưới 5 điểm put
                    j -= 5;
                }
                //tăng 5 do putPixel theo lưới 5 điểm put
                i += 5;
            }
        }

        //Đang làm 
        public void ToMauTheoLuoi(int x, int y, Color color)
        {

            Color clBackGround = bm.GetPixel(x, y);
            List<Point> Q = new List<Point>();
            Point m = new Point();
            Point tg = new Point();

            if (bm.GetPixel(x, y) == clBackGround && x < bm.Width && y < bm.Height && x > 0 && y > 0)
            {
                m.X = x;
                m.Y = y;
                bm.SetPixel(m.X, m.Y, color);
                Q.Add(m);

                while (Q != null)
                {
                    Q.RemoveAt(0);

                    //Xét điểm lân cận
                    if (bm.GetPixel(m.X + 5, m.Y) == clBackGround)
                    {
                        bm.SetPixel(m.X + 5, m.Y, color); //bmTemp.SetPixel(m.X + 5, m.Y, color);
                        tg.X = m.X + 5;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bm.GetPixel(m.X - 5, m.Y) == clBackGround)
                    {
                        bm.SetPixel(m.X - 5, m.Y, color); //bmTemp.SetPixel(m.X - 5, m.Y, color);
                        tg.X = m.X - 5;
                        tg.Y = m.Y;
                        Q.Add(tg);
                    }
                    if (bm.GetPixel(m.X, m.Y + 5) == clBackGround)
                    {
                        bm.SetPixel(m.X, m.Y + 5, color); //bmTemp.SetPixel(m.X, m.Y + 5, color);
                        tg.X = m.X;
                        tg.Y = m.Y + 5;
                        Q.Add(tg);
                    }
                    if (bm.GetPixel(m.X, m.Y - 5) == clBackGround)
                    {
                        bm.SetPixel(m.X, m.Y - 5, color); //bmTemp.SetPixel(m.X, m.Y - 5, color);
                        tg.X = m.X;
                        tg.Y = m.Y - 5;
                        Q.Add(tg);
                    }

                    if (Q.Count == 0) break;
                    //Đưa về giá trị đầu của Q
                    m = Q[0];
                }
            }
        }
    }

}
