using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Square
    {
        int iSide;
        public int GetSide() { return iSide; }
        public void SetSide(int s) { iSide = s; }


        public Square() {}
        public Square(int _side)
        {
            this.iSide = _side;
        }

    }
}
