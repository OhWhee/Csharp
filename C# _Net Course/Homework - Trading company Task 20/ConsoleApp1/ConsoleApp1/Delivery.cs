using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Delivery
    {
        DateTime date;
        int orderNumber;
        List<DeliveredGood> delivers = new List<DeliveredGood>();
        bool isModified = true;
        double totalCost = 0;

        public Delivery(DateTime date, int orderNumber)
        {
            this.date = date;
            this.orderNumber = orderNumber;
        }

        public DateTime Date { get => date; set => date = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public List<DeliveredGood> Delivers { get => delivers; set => delivers = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }


        public void addGood(Goods good, int quantity, IDelivery delivery)
        {
            DeliveredGood deliveredGood = new DeliveredGood(good, quantity, delivery);
            this.delivers.Add(deliveredGood);
            this.totalCost += deliveredGood.Cost;
        }
        public void deleteGood(DeliveredGood good)
        {
            this.delivers.Remove(good);
            this.totalCost -= good.Cost;
        }
    }
}
