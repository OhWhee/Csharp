using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GoodsOperations
    {
        double cost;
        int quantity;
        double totalWeight;
        IDelivery deliveryType;
        Goods good;
        double margin = 1.3;

        public GoodsOperations(Goods good, int quantity, IDelivery delivery)
        {
            this.good = good;
            this.quantity = quantity;
            this.deliveryType = delivery;
        }
        public double Cost { get => cost; set => cost = value; }
        public IDelivery DeliveryType { get => deliveryType; set => deliveryType = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double TotalWeight { get => totalWeight; set => totalWeight = value; }
        public Goods Good { get => good; set => good = value; }
        public double Margin { get => margin; set => margin = value; }
    }
}
