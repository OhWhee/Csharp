using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Goods
    {
        double price;
        string manufacturer;
        string name;
        string category;
        double weight;


        public Goods(double price, string manufacturer, string name, string category, double weight)
        {
            this.price = price;
            this.manufacturer = manufacturer;
            this.name = name;
            this.category = category;
            this.Weight = weight;
        }

        public double Price { get => price; set => price = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public double Weight { get => weight; set => weight = value; }
    }
}
