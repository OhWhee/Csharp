using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DeliveryByAir : IDelivery
    {
        public double calculateCost(double weight)
        {
            return Math.Max(2000, weight * 20);
        }
        public void deliver() { }
    }
}
