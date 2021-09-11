using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Producer : IElectricSource
    {
        ArrayList consumers = new ArrayList();
        double maxPowerConsumption;
        double currentConsumption = 0;

        public double MaxPowerConsumption { get => maxPowerConsumption; set => maxPowerConsumption = value; }
        public double GetCurrentConsumption()
        {
            return currentConsumption;

        }
        public ArrayList Consumers
        {
            get { return consumers; }
            set {

                foreach(var cons in value)
                {
                    
                        var consumercast = cons as Consumer;
                        var stepdowncast = cons as StepDownTransformer;
                    


                        if (consumercast != null)
                            if (consumercast.PowerConsumption > maxPowerConsumption - currentConsumption)
                            {
                                Console.WriteLine("Нехватает мощности для подключения. Максимальная мощность: {0}., Текущая мощность: {1}., Мощность подключаемого потребителя: {2}", maxPowerConsumption, currentConsumption, consumercast.PowerConsumption);
                            }

                            else
                            {
                                currentConsumption += consumercast.PowerConsumption;
                                this.consumers.Add(consumercast);
                            }
                        else
                        {
                            if (stepdowncast.PowerConsumption > maxPowerConsumption - currentConsumption)
                            {
                                Console.WriteLine("Нехватает мощности для подключения. Максимальная мощность: {0}., Текущая мощность: {1}., Мощность подключаемого потребителя: {2}", maxPowerConsumption, currentConsumption, stepdowncast.PowerConsumption);
                            }
                            else
                            {
                                currentConsumption += stepdowncast.PowerConsumption;
                                this.consumers.Add(stepdowncast);
                            }
                        }

                }

            }
        }

        public void ShowConsumers()
        {
            foreach(var consumer in consumers)
            {
                var consumercast = consumer as Consumer;
                var stepdowncast = consumer as StepDownTransformer;
                if (consumercast != null)
                    Console.WriteLine("Потребитель - {0}; Потребляемая мощность - {1}", consumercast.Name, consumercast.PowerConsumption);
                if(stepdowncast != null)
                    Console.WriteLine("Потребитель - {0}; Потребляемая мощность - {1}", stepdowncast.Name, stepdowncast.PowerConsumption);
            }
        }

        public Producer(double maxpower)
        {
            this.maxPowerConsumption = maxpower;
        }
    }
}
