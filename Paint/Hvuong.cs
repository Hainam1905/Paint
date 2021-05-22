using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class Hvuong
    {
        public int xA;
        public int xB;
        public int xC;
        public int xD;
        public int yA;
        public int yB;
        public int yC;
        public int yD;
        public int a; // độ dài cạnh của hình vuông

        public Hvuong(int xA, int yA, int a)
        {
            this.xA = xA;
            this.yA = yA;
            this.a = a;
            this.xB = xA + a;
            this.yB = yA;
            this.xC = xA + a;
            this.yC = yA + a;
            this.xD = xA;
            this.yD = yA + a;
        }
    }
}
