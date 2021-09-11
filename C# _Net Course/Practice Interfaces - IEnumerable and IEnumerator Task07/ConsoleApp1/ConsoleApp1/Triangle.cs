using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Triangle : IEnumerable
    {
        int[] sides = new int[3];

        public Triangle(int aSide,int bSide,int cSide)
        {
            sides[0] = aSide;
            sides[1] = bSide;
            sides[2] = cSide;
        }

        public IEnumerator GetEnumerator()
        {
            return new TriangleEnumerator(sides);
        }

    }
}
