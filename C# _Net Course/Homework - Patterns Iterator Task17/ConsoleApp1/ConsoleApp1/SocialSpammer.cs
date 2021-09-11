using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SocialSpammer
    {
        public void send(IProfileIterator iterator, string message)
        {
            while (iterator.hasMore())
            {
                var profile = iterator.getNext();
                Console.WriteLine("На почту {0} отправлено сообщение {1}", profile.GetEmail, message);
            }

        }
    }
}
