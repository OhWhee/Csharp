using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EventManager
    {
        Dictionary<IEventListeners, string> listeners = new Dictionary<IEventListeners, string>();

        public void subscribe(IEventListeners subscriber, string type)
        {
            this.listeners.Add(subscriber, type);
        }

        public void updateDelivery(DateTime date, TradingCompany td)
        {
            foreach (KeyValuePair<IEventListeners, string> keyValue in this.listeners)
            {
                keyValue.Key.updateDelivery(date, td);

            }
        }
        public void updateSales(DateTime date, TradingCompany td)
        {
            foreach (KeyValuePair<IEventListeners, string> keyValue in this.listeners)
            {

                keyValue.Key.updateSales(date, td);
            }
        }
    }
}
