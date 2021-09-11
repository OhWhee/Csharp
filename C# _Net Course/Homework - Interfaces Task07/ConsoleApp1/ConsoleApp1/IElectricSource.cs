using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
источник и провод – списки подключенных приборов.*/


namespace ConsoleApp1
{
    interface IElectricSource
    {
        double MaxPowerConsumption { get; set; }
        double GetCurrentConsumption();

    }
}
