using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EmailAlertsListener : IEventListeners
    {
        string email;
        string message;

        public EmailAlertsListener(string email, string message)
        {
            this.email = email;
            this.message = message;
        }
        public void update(string filename) { Console.WriteLine("Отправка на почту {0}, {1}", this.email, this.message); }

    }
}
