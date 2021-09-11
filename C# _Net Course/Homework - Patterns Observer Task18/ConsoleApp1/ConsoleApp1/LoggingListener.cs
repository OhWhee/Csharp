using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoggingListener : IEventListeners
    {
        File log;
        string message;

        public LoggingListener(string filename, string message)
        {
            this.log = new File(filename);
            this.message = message;
        }
        public void update(string filename) { log.write(); }
    }
}
