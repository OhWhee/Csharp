using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Application
    {
        public void config()
        {
            TextEditor editor = new TextEditor();
            LoggingListener logger = new LoggingListener( "/path/to/log.txt", "Someone has opened file: %s");
            editor.events.subscribe(logger, "Open");

            EmailAlertsListener emailAlerts = new EmailAlertsListener("admin@example.com", "Someone has changed the file: %s");
            editor.events.subscribe(emailAlerts, "Save");

        }
    }
}
