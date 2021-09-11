using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Room
    {
        private List<Furniture> furnitureList = new List<Furniture>();
        private List<Electronics> electronicsList = new List<Electronics>();

        public List<Furniture> FurnitureList { get => furnitureList; set => furnitureList = value; }
        public List<Electronics> ElectronicsList { get => electronicsList; set => electronicsList = value; }

        public void AddFurniture(Furniture furniture)
        {
            FurnitureList.Add(furniture);
        }

        public void AddElectronics(Electronics electronics)
        {
            ElectronicsList.Add(electronics);
        }

        public void GetFurniture(List<Furniture> furnitureList)
        {
            foreach(Furniture _furniture in furnitureList) { Console.WriteLine("Элемент мебели: {0} {1}",  _furniture.Whatis, _furniture.Brand); }
        }

        public void GetElectronics(List<Electronics> electronicsList)
        {
            foreach (Electronics _electronics in electronicsList) { Console.WriteLine("Элемент электроники: {0} {1}", _electronics.Whatis, _electronics.Brand); }
        }
    }
}
