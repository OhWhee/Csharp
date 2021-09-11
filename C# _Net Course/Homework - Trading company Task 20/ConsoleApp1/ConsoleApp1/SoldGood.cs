using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SoldGood : GoodsOperations
    {

        public SoldGood(Goods good, int quantity, IDelivery delivery):base(good, quantity, delivery)
        {
            this.Good = good;
            this.Quantity = quantity;
            this.TotalWeight = this.Good.Weight * this.Quantity;
            this.DeliveryType = delivery;
            this.Cost = this.DeliveryType.calculateCost(this.TotalWeight) + this.Good.Price * this.Quantity * this.Margin;
        }

    }
}
