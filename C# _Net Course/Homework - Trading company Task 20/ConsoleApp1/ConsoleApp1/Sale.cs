using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Sale
    {
        DateTime date;
        int orderNumber;
        List<SoldGood> sales = new List<SoldGood>();
        bool isSold = false;
        double totalCost = 0;

        public Sale(DateTime date, int orderNumber)
        {
            this.date = date;
            this.orderNumber = orderNumber;
        }

        public DateTime Date { get => date; set => date = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public bool IsSold { get => isSold; set => isSold = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        internal List<SoldGood> Sales { get => sales; set => sales = value; }

        public void addGood(Goods good, int quantity, IDelivery delivery)
        {
            SoldGood soldGood = new SoldGood(good, quantity, delivery);
            this.sales.Add(soldGood);
            this.TotalCost += soldGood.Cost;
        }
        public void deleteGood(SoldGood good)
        {
            this.Sales.Remove(good);
            this.totalCost -= good.Cost;
        }
    }
}
