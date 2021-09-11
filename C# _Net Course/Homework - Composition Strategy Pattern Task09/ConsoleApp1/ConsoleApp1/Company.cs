using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Company
    {
        List<IEmployee> employees = new List<IEmployee>();

        public List<IEmployee> getEmployees() { return this.employees; }
        public void createSoftware() { }

        public Company(IEmployee employee)
        {
            this.employees.Add(employee);
        }
        public Company(List<IEmployee> employees)
        {
            foreach(IEmployee employee in employees) { this.employees.Add(employee); }
            
        }
    }
}
