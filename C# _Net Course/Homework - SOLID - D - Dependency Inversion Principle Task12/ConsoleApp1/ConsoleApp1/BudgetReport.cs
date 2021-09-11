using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BudgetReport
    {
        IDatabase dataBase;

        internal IDatabase DataBase { get => dataBase; }

        public void open(Data data) { Console.WriteLine("Открываю файл: {0}", data.getInfo());}
        public void save() { Console.WriteLine("Сохранение"); }
        public void connectToDB(IDatabase db) { this.dataBase = db; }
    }
}
