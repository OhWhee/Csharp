using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Car
    {
        string number;
        string fuelType;
        double fuelLimit;

        public string Number { get => number; set => number = value; }
        public string FuelType { get => fuelType; set => fuelType = value; }
        public double FuelLimit { get => fuelLimit; set => fuelLimit = value; }

        public Car(string number, string fuelType, double fuelLimit) { this.number = number; this.fuelType = fuelType; this.fuelLimit = fuelLimit; }
    }
}
