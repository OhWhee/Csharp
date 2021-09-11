using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DeliveryByLand : IDelivery
    {
        public double calculateCost(double weight)
        {
            return Math.Max(300, weight * 1.2);
        }

        public void deliver() { }
    }
}
