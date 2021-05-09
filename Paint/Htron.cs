using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class Htron
    {
        private int xc;
        private int yc;
        private int R;

        public Htron(int xc, int yc, int R)
        {
            this.xc = xc;
            this.yc = yc;
            this.R = R;
        }
        public int getx()
        {
            return this.xc;
        }
        public int gety()
        {
            return this.yc;
        }
        public int getR()
        {
            return this.R;
        }
        public void setx(int xc)
        {
            this.xc = xc;
        }
        public void sety(int yc)
        {
            this.yc = yc;
        }
        public void setR(int R)
        {
            this.R = R;
        }
    }
}
