using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OutsourcingCompany : Company
    {
        public OutsourcingCompany(List<IEmployee> employees) : base(employees) { }
        public OutsourcingCompany(IEmployee employee) : base(employee) { }
    }
}
