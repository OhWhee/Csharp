using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IEventListeners
    {
        void updateDelivery(DateTime date, TradingCompany td);
        void updateSales(DateTime date, TradingCompany td);
    }
}
