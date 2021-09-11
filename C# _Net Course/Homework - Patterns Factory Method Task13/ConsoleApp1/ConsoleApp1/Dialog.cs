using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Dialog
    {
        public void render()
        {
            IButton button = createButton();
            button.render();
            button.onClick();
            
        }
        public abstract IButton createButton();

        
    }
}
