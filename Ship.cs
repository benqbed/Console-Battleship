using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbittlesBattleship
{
    /// <summary>
    /// Ship class that has length, ship type, and bow properties
    /// Author: Ben Bittles
    /// </summary>
    class Ship
    {
        //declare ship variables
        public int shipLength;
        public char shipType;
        public int bowx, bowy;
        //set ship length and type as part of constructor
        public Ship(int len, char type)
        {
            this.shipLength = len;
            this.shipType = type;
        }
    }
}
