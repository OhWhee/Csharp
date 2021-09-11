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

            Bulk bulk = new Bulk(200);
            Liquid liquid = new Liquid(150);

            List<IItems> items = new List<IItems> { bulk, liquid };


            Order order1 = new Order(items, new Air());

            Console.WriteLine("Цена доставки: {0}", order1.getShippingCost());
            Console.WriteLine("Вес груза: {0}", order1.getTotalWeight());
            Console.WriteLine("Общая стоимость: {0}", order1.getTotal());

            Console.ReadKey();

        }
    }
}
