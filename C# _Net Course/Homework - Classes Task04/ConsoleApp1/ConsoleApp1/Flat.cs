using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Flat
    {
        int flatNumber;
        private List<Room> roomList = new List<Room>();

        public int FlatNumber { get => flatNumber; set => flatNumber = value; }
        public List<Room> RoomList { get => roomList; set => roomList = value; }

        public void AddRoom(Room room)
        {
            RoomList.Add(room);
        }
        public void AddRoom(Kitchen kitchen)
        {
            RoomList.Add(kitchen);
        }

        public int GetLivingRooms(List<Room>  roomList)
        {
            int roomcounter = 0;
            foreach(object room in roomList)
            {
                if (room.GetType() == typeof(LivingRoom)) roomcounter++;
            }
            return roomcounter;
        }

        public int GetKitchens(List<Room> roomList)
        {
            int roomcounter = 0;
            foreach (object room in roomList)
            {
                if (room.GetType() == typeof(Kitchen)) roomcounter++;
            }
            return roomcounter;
        }

        public Flat(int flatNumber)
        {
            FlatNumber = flatNumber;
        }
    }
}
