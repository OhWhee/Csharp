using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Задание: Реализовать иерархию классов, содержащих поля, свойства и
методы, согласно варианту задания (Таблица №1). Создать программу
демонстрирующую работу классов.
Выполненная работа должна включать исходный текст работоспособной
программы в репозитории на GitLab.*/

/* Вариант 3. Строение, комната, мебель, стул, холодильник, многоэтажка, кухня, лампа */


namespace ConsoleApp1
{
class Program
{
    static void Main(string[] args)
    {

            MultiStoryBuilding house = new MultiStoryBuilding("какой-то адрес", 3, Building.RoofMaterials.Brick, Building.WallMaterials.Brick);

            Console.WriteLine(@"Адрес дома: {0}", house.Address);

            house.AddFlat(new Flat(1));

            Console.WriteLine(@"Количество квартир в доме: {0}", house.GetFlatsCount());
            Console.WriteLine("\nСписок квартир");
            house.ShowFlats();
            Console.WriteLine("\n");

            house.FlatList[0].AddRoom(new LivingRoom());
            house.FlatList[0].AddRoom(new LivingRoom());
            house.FlatList[0].AddRoom(new Kitchen());

            Console.WriteLine(@"Жилых комнат в квартире: {0}", house.FlatList[0].GetLivingRooms(house.FlatList[0].RoomList));
            Console.WriteLine(@"Кухонных комнат в квартире: {0}", house.FlatList[0].GetKitchens(house.FlatList[0].RoomList));

            house.FlatList[0].RoomList[0].AddFurniture(new Stool("KAEI"));
            house.FlatList[0].RoomList[0].AddFurniture(new Stool("IAKE"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa2"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa3"));

            house.FlatList[0].RoomList[2].AddFurniture(new Stool("KAEI"));
            house.FlatList[0].RoomList[2].AddFurniture(new Stool("KAEI"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa4"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa5"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa6"));
            house.FlatList[0].RoomList[0].AddElectronics(new Lamp("lampa7"));
            house.FlatList[0].RoomList[0].AddElectronics(new Fridge("BORSH", 2));

            house.ShowStatistics(0);
            house.ShowStatistics(1);

            Console.ReadKey();


        }
}
}
