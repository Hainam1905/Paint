﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class LorryLeft: Vehicle
    {
        public LorryLeft()
        {
            this.X = 10;
            this.Y = 200;
            this.Dicrection = 1; //left; 
            this.Exist = true;
            this.Type = 2; 
        }
    }
}
