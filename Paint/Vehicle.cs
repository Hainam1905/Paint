using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    abstract class Vehicle
    {
        int x;
        int y;
        int dicrection;
        int type; 
        bool exist;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Dicrection { get => dicrection; set => dicrection = value; }
        public bool Exist { get => exist; set => exist = value; }
        public int Type { get => type; set => type = value; }
    }
}
