using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
namespace Paint
{
    class CarLeftToRight
    {
        int xStartFromLeftToRight = 10;
        int yStartFromLeftToRight = 375;
        private Color clLine = Color.Black;
        private int widthLine = 1;
        DrawTool dt;
        Bitmap bm;
        Image img;
        public void setConfig(DrawTool dt0, Bitmap bm0, Image img0)
        {
            this.dt = dt0;
            this.bm = bm0;
            this.img = img0;
        }
        public void drawCarLeftToRight(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x + 120, y), p);
            dt.DrawMidPointAnimation(new Point(x, y), new Point(x, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x + 120, y), new Point(x + 120, y - 15), p);

            dt.DrawMidPointAnimation(new Point(x, y - 30), new Point(x + 20, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x + 120, y - 15), new Point(x + 80, y - 30), p);
            dt.DrawMidPointAnimation(new Point(x + 20, y - 30), new Point(x + 30, y - 40), p);
            dt.DrawMidPointAnimation(new Point(x + 80, y - 30), new Point(x + 80, y - 40), p);
            dt.DrawMidPointAnimation(new Point(x + 30, y - 40), new Point(x + 80, y - 40), p);

            //cua so: 
            dt.DrawMidPointAnimation(new Point(x + 15, y - 7), new Point(x + 15, y - 20), p);
            dt.DrawMidPointAnimation(new Point(x + 15, y - 20), new Point(x + 80, y - 20), p);
            dt.DrawMidPointAnimation(new Point(x + 80, y - 20), new Point(x + 80, y - 7), p);
            dt.DrawMidPointAnimation(new Point(x + 80, y - 7), new Point(x + 15, y - 7), p);
            dt.DrawMidPointAnimation(new Point(x + 60, y - 20), new Point(x + 40, y - 7), p);
            //banh xe
            dt.MidPointDrawCircle(x + 20, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 20, y + 10, 3, Color.Black);
            dt.MidPointDrawCircle(x + 90, y + 10, 10, Color.Black);
            dt.MidPointDrawCircle(x + 90, y + 10, 3, Color.Black);

            dt.FillColor(new Point(x + 5, y - 5), Color.Pink);
            dt.FillColor(new Point(x + 30, y - 15), Color.Blue);
            dt.FillColor(new Point(x + 70, y - 15), Color.Orange);
            //img = bm;

        }

        public void translatingCarLeftToRight()
        {
            int y = yStartFromLeftToRight;
            int x = xStartFromLeftToRight;
            for (int i = 0; i < 100; i++)
            {
                //xoa xe vi tri cu: 
                x = xStartFromLeftToRight;
                dt.FillColor(new Point(x + 5, y - 5), Color.Gray);
                dt.FillColor(new Point(x + 30, y - 15), Color.Gray);
                dt.FillColor(new Point(x + 70, y - 15), Color.Gray);

                Pen p = new Pen(Color.Gray, widthLine);

                dt.DrawMidPoint(new Point(x, y), new Point(x + 120, y), p);
                dt.DrawMidPoint(new Point(x, y), new Point(x, y - 30), p);
                dt.DrawMidPoint(new Point(x + 120, y), new Point(x + 120, y - 15), p);

                dt.DrawMidPoint(new Point(x, y - 30), new Point(x + 20, y - 30), p);
                dt.DrawMidPoint(new Point(x + 120, y - 15), new Point(x + 80, y - 30), p);
                dt.DrawMidPoint(new Point(x + 20, y - 30), new Point(x + 30, y - 40), p);
                dt.DrawMidPoint(new Point(x + 80, y - 30), new Point(x + 80, y - 40), p);
                dt.DrawMidPoint(new Point(x + 30, y - 40), new Point(x + 80, y - 40), p);

                //cua so: 
                dt.DrawMidPoint(new Point(x + 15, y - 7), new Point(x + 15, y - 20), p);
                dt.DrawMidPoint(new Point(x + 15, y - 20), new Point(x + 80, y - 20), p);
                dt.DrawMidPoint(new Point(x + 80, y - 20), new Point(x + 80, y - 7), p);
                dt.DrawMidPoint(new Point(x + 80, y - 7), new Point(x + 15, y - 7), p);
                dt.DrawMidPoint(new Point(x + 60, y - 20), new Point(x + 40, y - 7), p);
                //banh xe
                dt.MidPointDrawCircle(x + 20, y + 10, 10, Color.Gray);
                dt.MidPointDrawCircle(x + 20, y + 10, 3, Color.Gray);
                dt.MidPointDrawCircle(x + 90, y + 10, 10, Color.Gray);
                dt.MidPointDrawCircle(x + 90, y + 10, 3, Color.Gray);

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

                img = bm; 
                Thread.Sleep(100);
            }


        }
    }
}
