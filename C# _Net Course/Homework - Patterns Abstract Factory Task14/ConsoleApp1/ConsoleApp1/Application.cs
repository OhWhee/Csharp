using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Application
    {
        IGUIFactory guiFactory;
        IButton button;
        Config config;

        public Application(IGUIFactory factory) { this.guiFactory = factory; }
        public void createUI()
        {
            
            this.button = this.guiFactory.createButton();
        }
        public void paint() { this.button.paint(); }
        public void setConfig(Config config) { this.config = config; }
    }
}
