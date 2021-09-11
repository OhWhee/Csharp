using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Application
    {
        SocialSpammer spammer = new SocialSpammer();
        ISocialNetwork network = new Facebook();

        public ISocialNetwork Network { get => network; set => network = value; }

        public void sendSpamToFriends(Profile profile)
        {
            IProfileIterator iterator = Network.createFriendsIterator(profile);
            spammer.send(iterator, "Важное сообщение");
        }
        public void sendSpamToCoworkers(Profile profile)
        {
            IProfileIterator iterator = Network.createCoworkersIterator(profile);
            spammer.send(iterator, "очень важное сообщение для сотрудников");
        }

    }
}
