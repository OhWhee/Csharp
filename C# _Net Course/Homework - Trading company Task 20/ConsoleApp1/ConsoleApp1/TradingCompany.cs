using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TradingCompany
    {
        Dictionary<Goods, int> storage = new Dictionary<Goods, int>();
        List<Sale> sales = new List<Sale>();
        List<Order> orders = new List<Order>();
        List<Delivery> deliveries = new List<Delivery>();
        public EventManager events = new EventManager();
        
        
        
        DateTime companyCurrentTime = new DateTime(2021, 1, 1);


        public void startTrading()
        {
            this.events = new EventManager();
            DateListener dateListener = new DateListener();
            this.events.subscribe(dateListener, "Обновление");
        }
        public List<Sale> Sales { get => sales;  }
        public List<Order> Orders { get => orders;  }
        public List<Delivery> Deliveries { get => deliveries;  }
        public DateTime CompanyCurrentTime
        {
            get => companyCurrentTime;
            set
            {
                this.events.updateDelivery(value, this);
                this.events.updateSales(value, this);
                this.companyCurrentTime = value;

            }

        }

        public Dictionary<Goods, int> Storage { get => storage; set => storage = value; }

        public void addGoods(Goods good, int amount)
        {
            if (this.storage.ContainsKey(good))
            {
                foreach (KeyValuePair<Goods, int> keyValue in this.storage)
                {
                    if (keyValue.Key == good)
                    {
                        this.storage[good] = this.storage[good] + amount;
                    }
                }
            }
            else
            {
                this.storage.Add(good, amount);
            }
        }

        public void deleteGoods(Goods good, int amount)
        {
            if (this.storage.ContainsKey(good))
            {
                foreach (KeyValuePair<Goods, int> keyValue in this.storage.ToArray())
                {
                    if (keyValue.Key == good)
                    {
                        this.storage[good] = this.storage[good] - amount;
                    }
                }
            }
        }
        public void addSales(Sale sale)
        {
            this.Sales.Add(sale);
        }
        public void addOrders(Order order)
        {
            
            this.Orders.Add(order);
        }
        public void addDeliveries(Delivery deliver)
        {
            this.Deliveries.Add(deliver);
        }

        public void getOrdersStatsByPeriod(DateTime dateStart, DateTime dateEnd)
        {
            double orders = 0;
            foreach(Order order in this.orders)
            {
                if(order.Date <= dateEnd && order.Date >= dateStart)
                 orders += order.TotalCost;
            }
            Console.WriteLine("Сумма заказов за период с {0} по {1}, составила: {2}", dateStart, dateEnd, orders);
        }
        public void getOrdersStatsSummary()
        {
            double orders = 0;
            foreach (Order order in this.orders)
            {
                    orders += order.TotalCost;
            }
            Console.WriteLine("Сумма заказов за все время, составила: {0}", orders);
        }
        public void getDeliveriesStatsSummary()
        {
            double deliveries = 0;
            foreach (Delivery deliver in this.deliveries)
            {
                deliveries += deliver.TotalCost;
            }
            Console.WriteLine("Сумма поставок за все время, составила: {0}", deliveries);
        }

        public void getDeliveriesStatsByPeriod(DateTime dateStart, DateTime dateEnd)
        {
            double deliveries = 0;
            foreach (Delivery deliver in this.deliveries)
            {
                if (deliver.Date <= dateEnd && deliver.Date >= dateStart)
                    deliveries += deliver.TotalCost;
            }
            Console.WriteLine("Сумма поставок за период с {0} по {1}, составила: {2}", dateStart, dateEnd, deliveries);
        }

        public void getSalesStatsSummary()
        {
            double sale = 0;
            foreach (Sale sales in this.sales)
            {
                sale += sales.TotalCost;
            }
            Console.WriteLine("Сумма продаж за все время, составила: {0}", sale);
        }

        public void getSalesStatsByPeriod(DateTime dateStart, DateTime dateEnd)
        {
            double sale = 0;
            foreach (Sale sales in this.sales)
            {
                if (sales.Date <= dateEnd && sales.Date >= dateStart)
                    sale += sales.TotalCost;
            }
            Console.WriteLine("Сумма продаж за период с {0} по {1}, составила: {2}", dateStart, dateEnd, sale);
        }







        public void checkStorage()
        {
            foreach (KeyValuePair<Goods, int> keyValue in this.storage)
            {
                Console.WriteLine("Товар {0}: количество на складе {1}", keyValue.Key.Name, keyValue.Value);
            }
        }
    }
}
