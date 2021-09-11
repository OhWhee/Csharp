using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Реализовать системы электрических источников и
приборов, соединенных между собой через шнуры. В
интерфейсах должны быть предусмотрена возможность
получения информации о напряжении и максимальной
мощности, которую поддерживает элемент. Прибор
должен иметь наименование, потребляемую мощность, а
источник и провод – списки подключенных приборов.

    Интерфейсы:
IElectricSource (источник тока)
IElectricAppliance (электрический прибор)
IElectricWire (электрический шнур)

    Классы:
SolarBattery (солнечная батарея)
DieselGenerator (дизельный генератор)
NuclearPowerPlant (атомная электростанция)
Kettle (чайник)
Iron (утюг)
Lathe (токарный станок)
Refrigerator (холодильник)
ElectricPowerStrip (электрический удлинитель)
HighLine (высоковольтная линия)
StepDownTransformer (понижающий трансформатор, должен реализовывать интерфейсы и потребителя и источника тока)*/

    /*Законы физики сугубо свои */

    /*Многое сделать не успел*/

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Iron testiron = new Iron("asdasd", 230);
            SolarBattery solarbat = new SolarBattery(200);
            DieselGenerator generator = new DieselGenerator(500);
            Iron testiron2 = new Iron("zzzz", 300);


            testiron.ConnectToPowerSource(generator);
            Console.WriteLine("{0}", generator.GetCurrentConsumption());


            HighLine wire1 = new HighLine(4);
            Console.WriteLine("{0}", wire1.Efficiency);
            wire1.AddLength(5);
            Console.WriteLine("{0}", wire1.Efficiency);
            wire1.AddLength(5);
            Console.WriteLine("{0}", wire1.Efficiency);
            wire1.AddLength(5);
            Console.WriteLine("{0}", wire1.Efficiency);

            Console.WriteLine("До удаления");
            generator.ShowConsumers();
            
            Console.WriteLine("После удаления");
            testiron.BrakeConnections();
            generator.ShowConsumers();

            StepDownTransformer transformer = new StepDownTransformer("transformer", 500);
            transformer.ConnectToPowerSource(solarbat);
            Console.WriteLine("Текущее потребление: {0}", solarbat.GetCurrentConsumption());
            solarbat.ShowConsumers();
            testiron2.ConnectToPowerSource(transformer);
            Console.WriteLine("Текущее потребление: {0}", solarbat.GetCurrentConsumption());
            solarbat.ShowConsumers();





            Console.ReadKey();
        }
    }
}
