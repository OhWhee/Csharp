using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Application
    {
        Dialog dialog;
        Config config;

        internal Config Config { get => config; set => config = value; }
        internal Dialog Dialog { get => dialog; }

        public void Init()
        {
            if (this.config.AppType == "Windows")
                dialog = new WindowsDialog();
            else if (this.config.AppType == "Web")
                dialog = new HTMLDialog();
            else
                throw new Exception("Error! Unknown application type.");
        }

    }
}
