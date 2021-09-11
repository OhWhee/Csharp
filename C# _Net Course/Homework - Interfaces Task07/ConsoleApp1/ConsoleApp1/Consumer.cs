using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Consumer : IElectricAppliance
    {
        string name;
        double powerConsumption;
        Producer connectedPowerSource;
        bool steppedDown = false;
        StepDownTransformer middleman;

        public string Name { get => name; set => name = value; }
        public double PowerConsumption { get => powerConsumption; set => powerConsumption = value; }
        public Producer ConnectedPowerSource { get => connectedPowerSource; }
        public bool SteppedDown { get => steppedDown; set => steppedDown = value; }
        internal StepDownTransformer Middleman { get => middleman; set => middleman = value; }

        public Consumer(string name, double consumpion)
        {
            Name = name;
            PowerConsumption = consumpion;
        }


        public void ConnectToPowerSource(Producer producer)
        {
            ArrayList newConsumers = new ArrayList();
            newConsumers.Add(this);
            producer.Consumers = newConsumers;
            this.connectedPowerSource = producer;
        }

        public void ConnectToPowerSource(StepDownTransformer stepdown)
        {
            stepdown.ConnectedConsumer = this;
            this.connectedPowerSource = stepdown.ConnectedPowerSource;
            ArrayList newConsumers = new ArrayList();
            newConsumers.Add(this);
            if(!this.steppedDown)
                this.PowerConsumption /= stepdown.StepDown;
            stepdown.ConnectedPowerSource.Consumers = newConsumers;
            this.middleman = stepdown;
        }

        public void BrakeConnections()
        {
            if (this.connectedPowerSource != null)
            {
                this.connectedPowerSource.Consumers.Remove(this);
                this.connectedPowerSource = null;
                if (this.steppedDown)
                {
                    this.steppedDown = false;
                    this.powerConsumption *= this.middleman.StepDown;
                }
            }
        }

    }
}
