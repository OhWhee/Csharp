using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MongoDB : IDatabase
    {
        public void insert() { Console.WriteLine("Вставляю строку в MongoDB"); }
        public void update() { Console.WriteLine("Обновляю строку в MongoDB"); }
        public void delete() { Console.WriteLine("Удаляю строку из MongoDB"); }
    }
}
