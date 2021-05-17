using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class TankLeft: Vehicle
    {
        public TankLeft()
        {
            this.X = 10;
            this.Y = 195;
            this.Dicrection = 1; //trai; 
            this.Exist = true;
            this.Type = 3; 
        }
    }
}
