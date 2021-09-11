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
            BudgetReport report = new BudgetReport();
            MySQL mysql = new MySQL();
            MongoDB mongodb = new MongoDB();
            Data data = new Data();
            data.addInfo("Текст");

            report.open(data);
            report.save();
            report.connectToDB(mysql);
            report.DataBase.delete();
            report.DataBase.update();
            report.DataBase.insert();

            report.connectToDB(mongodb);
            report.DataBase.delete();
            report.DataBase.update();
            report.DataBase.insert();

            Console.ReadKey();




        }
    }
}
