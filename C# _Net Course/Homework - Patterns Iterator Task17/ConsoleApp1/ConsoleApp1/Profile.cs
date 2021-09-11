using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Profile
    {
        int id;
        string email;

        List<Profile> coworkers = new List<Profile>();
        List<Profile> friends = new List<Profile>();

        public int GetID { get => id;}
        public string GetEmail { get => email; }
        internal List<Profile> Coworkers { get => coworkers; set => coworkers = value; }
        internal List<Profile> Friends { get => friends; set => friends = value; }

        public void addFriend(Profile profile)
        {
            this.friends.Add(profile);
        }
        public void addCoworker(Profile profile)
        {
            this.coworkers.Add(profile);
        }

        public Profile(int id, string email) { this.id = id; this.email = email; }
    }
}
