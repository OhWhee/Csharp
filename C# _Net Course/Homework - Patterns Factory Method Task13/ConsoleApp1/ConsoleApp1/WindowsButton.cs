using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WindowsButton : IButton
    {
        public void render() { Console.WriteLine("Отрисовываем windows кнопку"); }
        public void onClick() { Console.WriteLine("Нажатие на windows кнопку"); }
    }
}
