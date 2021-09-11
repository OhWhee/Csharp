using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Order
    {
        List<IItems> lineItems;
        IShipping shipping;

        public List<IItems> LineItems { get => lineItems; set => lineItems = value; }
        public IShipping Shipping { get => shipping; set => shipping = value; }
        public double getTotal()
        {
            double totalPrice = 0;
            totalPrice += getShippingCost();

            foreach(IItems item in this.lineItems)
            {
                totalPrice += item.getPrice();
            }
            return totalPrice;
        }

        public double getTotalWeight()
        {
            double totalWeight = 0;
            foreach (IItems item in this.lineItems)
            {
                totalWeight += item.getWeight();
            }
            return totalWeight;
        }

        public double getShippingCost()
        {
            if (this.shipping is Air)
                return Math.Max(20, getTotalWeight() * this.shipping.getCost());
            if (this.shipping is Ground)
                return Math.Max(10, getTotalWeight() * this.shipping.getCost());
            else
                return 0;
        }
        public string getShippingDate() { return this.shipping.getDate(); }




        public Order(List<IItems> items, IShipping shipping)
        {
            this.lineItems = items;
            this.shipping = shipping;
        }
    }
}
