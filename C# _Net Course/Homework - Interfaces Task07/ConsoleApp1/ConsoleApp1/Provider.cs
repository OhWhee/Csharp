using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Provider : IElectricWire
    {
        double maxLength = 0.0;
        double efficiency = 1.0;
        double powerLeakStep = 5.0;
        double powerLeakLoss = 0.01;



        public Provider(double maxlength) { this.MaxLength = maxlength; this.efficiency = (this.efficiency - (maxLength / this.powerLeakStep * this.powerLeakLoss)) < 0 ? 0 : this.efficiency - (maxLength / this.powerLeakStep * this.powerLeakLoss); }
        public double MaxLength{get => maxLength;set => maxLength = value; }
        public double Efficiency { get => efficiency; }
        public void AddLength(double length) { this.maxLength += length; RecalculateEfficiency(); }
        public void RecalculateEfficiency() { this.efficiency = (this.efficiency - (maxLength / this.powerLeakStep * this.powerLeakLoss)) < 0 ? 0 : this.efficiency - (maxLength / this.powerLeakStep * this.powerLeakLoss); }
        public virtual void Connect(Consumer consumer) { }
        public virtual void Connect(Producer producer) { }

    }
}
