using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TradingCompany TC = new TradingCompany();
            TC.startTrading();
            Goods good1 = new Goods(10000, "China", "PhoneI", "Mobile", 0.2);
            //Goods good2 = new Goods(15000, "South Korea", "GL", "Monitor", 3.5);
            //Goods good3 = new Goods(25000, "China", "Xerx", "Printer", 20.0);
            //Goods good4 = new Goods(10000000, "Russia", "Fedor", "Robot", 85.0);

            Order order1 = new Order(new DateTime(2021, 1, 9), 1);
            //Order order2 = new Order(new DateTime(2021, 1, 10), 2);
            //Order order3 = new Order(new DateTime(2021, 2, 7), 3);
            //Order order4 = new Order(new DateTime(2021, 2, 20), 4);
            //Order order5 = new Order(new DateTime(2021, 2, 25), 5);
            //Order order6 = new Order(new DateTime(2021, 3, 11), 6);


            order1.addGood(good1, 5, new DeliveryBySelf());
            //order1.addGood(good2, 15, new DeliveryByAir());

            //order2.addGood(good3, 2, new DeliveryByLand());

            //order3.addGood(good1, 1, new DeliveryBySelf());
            //order3.addGood(good2, 13, new DeliveryByAir());
            //order3.addGood(good3, 2, new DeliveryByAir());

            //order4.addGood(good4, 1, new DeliveryBySelf());
            //order4.addGood(good1, 8, new DeliveryBySelf());

            //order5.addGood(good1, 9, new DeliveryByAir());
            //order5.addGood(good2, 10, new DeliveryByAir());

            //order6.addGood(good3, 5, new DeliveryBySelf());
            //order6.addGood(good1, 5, new DeliveryBySelf());

            TC.addOrders(order1);
            //TC.addOrders(order2);
            //TC.addOrders(order3);
            //TC.addOrders(order4);
            //TC.addOrders(order5);
            //TC.addOrders(order6);
            Delivery delivery1 = new Delivery(new DateTime(2021, 1, 9), 1);
            delivery1.addGood(good1, 5, new DeliveryBySelf());
            TC.addDeliveries(delivery1);
            Console.WriteLine("Проверим хранилище до изменения даты");
            TC.checkStorage();

                
            TC.CompanyCurrentTime = new DateTime(2021, 1, 12);
            Console.WriteLine("Проверим хранилище после изменения даты и получении поставки");
            TC.checkStorage();
            


            Sale sale1 = new Sale(new DateTime(2021, 1, 15), 1);
            sale1.addGood(good1, 3, new DeliveryBySelf());
            TC.addSales(sale1);
            TC.CompanyCurrentTime = new DateTime(2021, 1, 18);
            Console.WriteLine("Проверим хранилище после изменения даты и продажи");
            TC.checkStorage();






            TC.getOrdersStatsByPeriod(new DateTime(2021, 3, 1), new DateTime(2021, 3, 31));
            TC.getOrdersStatsSummary();
            TC.getDeliveriesStatsByPeriod(new DateTime(2021, 3, 1), new DateTime(2021, 3, 31));
            TC.getDeliveriesStatsSummary();
            TC.getSalesStatsByPeriod(new DateTime(2021, 3, 1), new DateTime(2021, 3, 31));
            TC.getSalesStatsSummary();
            Console.ReadKey();
            

        }
    }
}
