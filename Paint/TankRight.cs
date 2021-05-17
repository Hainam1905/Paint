using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class TankRight: Vehicle
    {
        public TankRight()
        {
            this.X = 920;
            this.Y = 80;
            this.Dicrection = 2; //phai 
            this.Exist = true;
            this.Type = 3; 
        }
    }
}
