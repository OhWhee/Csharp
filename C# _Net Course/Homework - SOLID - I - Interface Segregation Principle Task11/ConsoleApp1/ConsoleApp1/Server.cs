using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Server
    {
        Region region;
        string ipAdress;

        public Region Region { get => region; set => region = value; }
        public Server(Region region, string ipAdress) { this.region = region; this.ipAdress = ipAdress; }
        public string getIP() { return this.ipAdress; }

    }
}
