using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class AmbulanceLeft: Vehicle
    {
            public AmbulanceLeft()
        {
            this.X = 10;
            this.Y = 195;
            this.Dicrection = 1; //left; 
            this.Exist = true;
            this.Type = 4;
        }
    }
}
