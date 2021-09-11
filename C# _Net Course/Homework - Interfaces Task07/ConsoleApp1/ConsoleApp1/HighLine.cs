using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HighLine : Provider
    {
        ArrayList objectList = new ArrayList();

        public HighLine(double maxlength) : base(maxlength) { }

        public ArrayList ObjectList { get => objectList; set => objectList = value; }

        public override void Connect(Consumer consumer)
        {
            this.objectList.Add(consumer);
        }





    }
}
