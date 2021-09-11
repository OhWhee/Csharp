using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface ISocialNetwork
    {
        IProfileIterator createFriendsIterator(Profile profileId);
        IProfileIterator createCoworkersIterator(Profile profileId);
        void addProfile(Profile profile);
    }
}
