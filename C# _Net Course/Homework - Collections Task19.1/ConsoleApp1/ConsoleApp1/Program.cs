using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Написать программу, использующую очередь для моделирования автозаправочной станции. На
станции имеется 4-е колонки с 92, 95, 98 бензином и дизельным топливом.Организовать
поступление заявок (автомобилей) на заправку тем или иным типом топлива. Каждый автомобиль
может находится в 2-состояниях – заправлен и ожидает.Если к колонке заправочной станции
более 1-й машины, то формируется очередь.*/

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            FillingStation zapravka = new FillingStation();

            Car car1 = new Car("екх666", "ai92", 80);
            Car car2 = new Car("екх777", "ai95", 30);
            Car car3 = new Car("екх888", "ai98", 90);
            Car car4 = new Car("екх999", "diesel", 100);
            Car car5 = new Car("екх111", "diesel", 120);
            Car car6 = new Car("екх222", "ai92", 40);
            Car car7 = new Car("екх333", "ai92", 15);
            Car car8 = new Car("екх444", "ai95", 80);
            Car car9 = new Car("екх555", "ai92", 70);
            Car car10 = new Car("екх123", "diesel", 80);
            Car car11 = new Car("екх321", "ai92", 60);
            Car car12 = new Car("екх159", "ai92", 60);
            Car car13 = new Car("екх951", "ai92", 80);
            Car car14 = new Car("екх753", "ai95", 80);

            zapravka.AddCarToQueue(car1);
            zapravka.AddCarToQueue(car2);
            zapravka.AddCarToQueue(car3);
            zapravka.AddCarToQueue(car4);
            zapravka.AddCarToQueue(car5);
            zapravka.AddCarToQueue(car6);
            zapravka.AddCarToQueue(car7);
            zapravka.AddCarToQueue(car8);
            zapravka.AddCarToQueue(car9);
            zapravka.AddCarToQueue(car10);
            zapravka.AddCarToQueue(car11);
            zapravka.AddCarToQueue(car12);
            zapravka.AddCarToQueue(car13);
            zapravka.AddCarToQueue(car14);

            zapravka.fillCars();

            Console.ReadKey();

        }
    }
}
