using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            Profile profile1 = new Profile(1, "test1");
            Profile profile2 = new Profile(2, "test2");
            Profile profile3 = new Profile(3, "test3");
            Profile profile4 = new Profile(4, "test4");
            Profile profile5 = new Profile(5, "test5");
            Profile profile6 = new Profile(6, "test6");

            app.Network.addProfile(profile1);

            profile1.addFriend(profile2);
            profile1.addFriend(profile3);
            profile1.addCoworker(profile3);
            profile1.addCoworker(profile5);
            profile1.addCoworker(profile6);

            app.sendSpamToFriends(profile1);
            app.sendSpamToCoworkers(profile1);

            Console.ReadKey();
            
        }
    }
}
