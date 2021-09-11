using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DateListener : IEventListeners
    {
        public void updateDelivery(DateTime date, TradingCompany td)
        {
            /*Обновляем список товаров на складе. Ищем товары в доставках и смотрим в заказы,
             если товары совпадают, то добавляем их на склад*/
            foreach (Delivery delivery in td.Deliveries)
            {
                if (date < delivery.Date)
                    continue;
                else
                {
                    foreach (DeliveredGood deliveredGood in delivery.Delivers)
                    {
                        //deliveredGood.Good;
                        foreach (Order order in td.Orders)
                        {
                            if (order.IsShipped)//Если заказ уже был отгружен, то идем дальше
                                continue;
                            foreach (OrderedGood orderedGood in order.Orders)
                            {
                                if (deliveredGood.Good == orderedGood.Good) //Нашли товар
                                    td.addGoods(orderedGood.Good, orderedGood.Quantity);
                            }
                            order.IsShipped = true;
                        }
                    }
                }
            }
        }
         
        
        public void updateSales(DateTime date, TradingCompany td)
        { 
            foreach(Sale sale in td.Sales)
            {
                if (date < sale.Date || sale.IsSold)
                    continue;
                else
                {
                    foreach(SoldGood soldGood in sale.Sales)
                    {
                        Goods goodToDelete = null;
                        Dictionary<Goods, int> storage = td.Storage;
                        foreach (KeyValuePair<Goods, int> keyValuePair in storage)
                        {
                            if (soldGood.Good == keyValuePair.Key)
                                goodToDelete = soldGood.Good;       
                        }
                        if(goodToDelete != null)
                            td.deleteGoods(goodToDelete, soldGood.Quantity);
                    }
                }
            }
        }
    }
}
