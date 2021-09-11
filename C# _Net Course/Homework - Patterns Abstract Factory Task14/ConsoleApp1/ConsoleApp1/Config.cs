using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Config
    {
        string OS;

        public string getOS() { return this.OS; }
        public Config(string os) { this.OS = os; }
        public IGUIFactory main()
        {
            if (this.OS == "Windows")
                return new WindowsFactory();
            else if (this.OS == "Mac")
                return new MacFactory();
            else
                return null;

        }
    }
}
