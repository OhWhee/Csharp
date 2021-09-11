using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DeliveryBySelf:IDelivery
    {
        public double calculateCost(double weight)
        {
            return 0.0;
        }
        public void deliver() { }
    }
}
