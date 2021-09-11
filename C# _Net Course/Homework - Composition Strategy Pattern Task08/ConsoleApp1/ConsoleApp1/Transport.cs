using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Transport
    {
        IEngine engine;
        IDriver driver;

        internal IEngine Engine { get => engine; set => engine = value; }
        internal IDriver Driver { get => driver; set => driver = value; }
        public void deliver(string destination, string cargo) { }
        public Transport()
        {
            /*Судя по картинке, здесь используется композиция 
             т.е. внутри класса создается объект двигателя.
             По умолчанию ДВС с возможностью замены.
             */
            this.engine = new CombustionEngine();
        }

    }
}
