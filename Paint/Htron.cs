using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class Htron
    {
        public int R;
        public int xc;
        public int yc;
        public Bitmap bm;

        public Htron(int xc, int yc, int R)
        {
            this.xc = xc;
            this.yc = yc;
            this.R = R;
        }
        public void draw8Point(int xc,int yc, int x, int y, Color color)
        {
            bm.SetPixel(xc + x, yc + y,color);
            bm.SetPixel(xc + y, yc + x, color);
            bm.SetPixel(xc + y, yc - x, color);
            bm.SetPixel(xc + x, yc - y, color);
            bm.SetPixel(xc - x, yc - y, color);
            bm.SetPixel(xc - y, yc - x, color);
            bm.SetPixel(xc - y, yc + x, color);
            bm.SetPixel(xc - x, yc + y, color);
        }
        public void circleMidPoint(int xc,int yc,int R, Color color)
        {
            float p;
            int y = R;
            int x = 0;
            p = 5 / 4 - R;
            draw8Point(xc, yc, x, y, color);
            while (x<y)
            {
                if (p < 0)
                {
                    p += 2 * x + 3;

                }
                else
                {
                    p += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                draw8Point(xc, yc, x, y, color);
            }
        }
        public void circleMidPoint(Color color)
        {
            int xc = this.xc;
            int yc = this.yc;
            int R = this.R;
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
                    y--;
                }
                x++;
                draw8Point(xc, yc, x, y, color);
            }
        }
    }
}
