using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MacFactory: IGUIFactory
    {
        public IButton createButton() { return new MacButton(); }
        public ICheckBox createCheckBox() { return new MacCheckBox(); }
    }
}
