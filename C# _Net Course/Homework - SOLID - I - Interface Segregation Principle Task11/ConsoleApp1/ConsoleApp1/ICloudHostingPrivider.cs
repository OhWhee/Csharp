using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface ICloudHostingPrivider
    {
        void createServer(Region region, string ip);
        void listServers(Region region);
    }
}
