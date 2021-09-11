using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IElectricWire
    {
        double MaxLength { get; set; }
        double Efficiency { get; }

        

        void Connect(Consumer consumer);
        void Connect(Producer consumer);
        void AddLength(double length);
        void RecalculateEfficiency();
    }
}
