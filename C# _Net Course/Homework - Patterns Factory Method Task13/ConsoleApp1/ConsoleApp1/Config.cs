using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Config
    {
        string appType;

        public string AppType { get => appType; set => appType = value; }
        public Config(string appType) { this.appType = appType; }
    }
}
