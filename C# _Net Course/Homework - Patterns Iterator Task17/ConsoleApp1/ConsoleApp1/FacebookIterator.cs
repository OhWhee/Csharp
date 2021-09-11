using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class FacebookIterator : IProfileIterator
    {
        Facebook facebook;
        int profileID;
        string type;

        int currentPosition = 0;
        List<Profile> cache = new List<Profile>();

        public Profile getNext()
        {
            if (hasMore())
            {
                currentPosition++;
            }
            return cache[currentPosition - 1];
                

        }
        public bool hasMore()
        {
            return currentPosition < cache.Count;
        }


        public FacebookIterator(Facebook facebook, Profile profile, string type)
        {
            this.facebook = facebook;
            this.profileID = profile.GetID;
            this.type = type;

            if(this.type == "friends")
            {
                cache = profile.Friends;
            }
            else
            {
                cache = profile.Coworkers;
            }
            
        }
    }
}
