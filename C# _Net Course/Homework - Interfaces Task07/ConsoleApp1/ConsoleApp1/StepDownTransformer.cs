using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StepDownTransformer :IElectricAppliance, IElectricSource
    {
        string name;
        double powerConsumption;
        Producer connectedPowerSource;
        Consumer connectedConsumer;
        double maxPowerConsumption;
        double currentConsumption = 0;
        double stepDown = 2.0;


        public string Name { get => name; set => name = value; }
        public double PowerConsumption { get => powerConsumption; set => powerConsumption = value; }
        public Producer ConnectedPowerSource { get => connectedPowerSource; set => connectedPowerSource = value; }
        public double MaxPowerConsumption { get => maxPowerConsumption; set => maxPowerConsumption = value; }
        public Consumer ConnectedConsumer { get => connectedConsumer; set => connectedConsumer = value; }
        public double StepDown { get => stepDown;}

        public void ConnectToPowerSource(Producer source)
        {
            if (this.connectedPowerSource == null) {
                ArrayList newConsumers = new ArrayList();
                newConsumers.Add(this);
                source.Consumers = newConsumers;
                this.connectedPowerSource = source;
            };
        }


        public double GetCurrentConsumption() {

            return this.currentConsumption;
        }

        public StepDownTransformer(string name, double maxpower)
        {
            this.name = name;
            this.maxPowerConsumption = maxpower;
        }

    }
}
