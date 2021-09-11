using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Order
    {
        DateTime date;
        int orderNumber;
        List<OrderedGood> orders = new List<OrderedGood>();
        bool isShipped = false;
        double totalCost = 0;


        public Order(DateTime date, int number) { this.date = date; this.orderNumber = number; }
        public DateTime Date { get => date; set => date = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public List<OrderedGood> Orders { get => orders; set => orders = value; }
        public double TotalCost
        {
            get { return this.totalCost; }
        }

        public bool IsShipped { get => isShipped; set => isShipped = value; }

        public void addGood(Goods good, int quantity, IDelivery delivery)
        {
            OrderedGood orderedGood = new OrderedGood(good, quantity, delivery);
            this.orders.Add(orderedGood);
            this.totalCost += orderedGood.Cost;
        }
        public void deleteGood(OrderedGood good)
        {
            this.orders.Remove(good);
            this.totalCost -= good.Cost;
        }

    }
}
