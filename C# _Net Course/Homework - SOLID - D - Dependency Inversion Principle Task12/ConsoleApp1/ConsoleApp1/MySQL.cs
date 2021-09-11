using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MySQL : IDatabase
    {
        public void insert() { Console.WriteLine("Вставляю строку в MYSQL"); }
        public void update() { Console.WriteLine("Обновляю строку в MYSQL"); }
        public void delete() { Console.WriteLine("Удаляю строку из MYSQL"); }
    }
}
