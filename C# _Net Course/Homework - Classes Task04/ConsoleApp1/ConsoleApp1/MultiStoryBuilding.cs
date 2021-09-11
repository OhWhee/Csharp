using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MultiStoryBuilding : Building
    {
        private List<Flat> flatList = new List<Flat>();

        internal List<Flat> FlatList { get => flatList; set => flatList = value; }

        public void ShowFlats()
        {
            foreach (Flat _flat in FlatList) Console.WriteLine(_flat.FlatNumber);
        }
        public void AddFlat(Flat flat)
        {
            FlatList.Add(flat);
        }
        public int GetFlatsCount()
        {
            return FlatList.Count;
        }

        public void ShowStatistics(int number)
        {
            try
            {
                Flat flat = FlatList[number];

                Console.WriteLine("Квартира номер: {0}", flat.FlatNumber);
                Console.WriteLine("Количество комнат в квартире: {0}\n", flat.RoomList.Count);    
                for(int i = 0; i < flat.RoomList.Count; i++)
                {
                    Console.WriteLine("Комната номер: {0}", i);
                }

                for (int i = 0; i < flat.RoomList.Count; i++)
                {
                    Console.WriteLine("\nКомната номер: {0}", i);
                    Console.WriteLine("\nСписок электроники:");
                    flat.RoomList[i].GetElectronics(flat.RoomList[i].ElectronicsList);
                    Console.WriteLine("\nСписок мебели:");
                    flat.RoomList[i].GetFurniture(flat.RoomList[i].FurnitureList);

                }


            }
            catch
            {
                Console.WriteLine("\nТакой номер квартиры отсутствует в доме");
            }
        }



        public MultiStoryBuilding(string address, int numFloors, RoofMaterials roof, WallMaterials wall) : base(address, numFloors, roof, wall) { }
            
    }
}
