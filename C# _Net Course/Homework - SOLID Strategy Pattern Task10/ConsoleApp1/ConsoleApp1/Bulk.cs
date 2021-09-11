using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bulk : IItems
    {
        double weight;
        double price = 50;

        public double Weight { get => weight; set => weight = value; }

        public void getDescription()
        {
            Console.WriteLine("Я сыпучий груз");
        }

        public Bulk(double weight) { this.weight = weight; }
        public double getWeight() { return this.weight; }
        public double getPrice()
        {
            return this.weight * this.price;
        }

    }
}
