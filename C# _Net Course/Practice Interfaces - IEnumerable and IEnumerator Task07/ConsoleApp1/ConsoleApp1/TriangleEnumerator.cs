using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TriangleEnumerator : IEnumerator
    {
        int[] sides;
        int position = -1;

        public TriangleEnumerator(int[] sides)
        {   
            this.sides = sides;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= sides.Length)
                    throw new InvalidOperationException();
                return sides[position];
            }
        }

        public bool MoveNext()
        {
            if (position < sides.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

    }
}
