using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameDevCompany : Company
    {
        public GameDevCompany(List<IEmployee> employees):base(employees) { }
        public GameDevCompany(IEmployee employee) : base(employee) { }
    }
}
