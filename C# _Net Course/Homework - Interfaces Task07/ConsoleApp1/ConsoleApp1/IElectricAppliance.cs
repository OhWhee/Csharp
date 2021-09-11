using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Прибор
должен иметь наименование, потребляемую мощность*/
namespace ConsoleApp1
{
    interface IElectricAppliance
    {
        string Name { get; set; }
        double PowerConsumption { get; set; }
        Producer ConnectedPowerSource { get; }
        void ConnectToPowerSource(Producer producer);


    }
}
