using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Facebook : ISocialNetwork
    {
        Profile[] profiles;

        public Profile[] Profiles { get => profiles; set => profiles = value; }
        public void addProfile(Profile profile)
        {
            if (this.profiles == null)
            {
                this.profiles = new Profile[] { profile };
            }
            else { this.profiles[this.profiles.Length] = profile; }
        }
        public void addProfile(Profile[] profile)
        {
            Profiles = profile;
        }

        public IProfileIterator createFriendsIterator(Profile profile)
        {

            return new FacebookIterator(this, profile, "friends");
        }
       public IProfileIterator createCoworkersIterator(Profile profile)
        {
            return new FacebookIterator(this, profile, "coworkers"); 
        }

    }
}
