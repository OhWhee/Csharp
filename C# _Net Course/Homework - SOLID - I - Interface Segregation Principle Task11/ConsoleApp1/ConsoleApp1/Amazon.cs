using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Amazon : ICloudHostingPrivider, ICloudStorageProvider, ICDNProvider
    {
        List<File> files = new List<File>();
        List<Server> servers = new List<Server>();
        string CDNAdress;


        public void storeFile(File filename) { files.Add(filename); }
        public File getFile(File filename)
        {
            File file = null;
            foreach (File _file in this.files)
            {
                if (_file == filename)
                    file = _file;
            }

            return file;
        }
        public void createServer(Region region, string ip)
        {
            servers.Add(new Server(region, ip));
        }
        public void listServers(Region region)
        {
            foreach(Server server in this.servers)
            {
                if (server.Region.Location == region.Location)
                    Console.WriteLine(server.getIP());
            }
        }

        public void listFiles() { foreach (File file in this.files) Console.WriteLine(file.FileName); }
        public string getCDNAdress() { return this.CDNAdress; }
        
        public Amazon(string CDNAdress) { this.CDNAdress = CDNAdress; }


    }
}
