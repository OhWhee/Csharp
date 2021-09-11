using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class FillingStation
    {
        Queue<Car> ai92 = new Queue<Car>();
        Queue<Car> ai95 = new Queue<Car>();
        Queue<Car> ai98 = new Queue<Car>();
        Queue<Car> diesel = new Queue<Car>();
        double fillingRate = 5;


        public Queue<Car> Ai92 { get => ai92; set => ai92 = value; }
        public Queue<Car> Ai95 { get => ai95; set => ai95 = value; }
        public Queue<Car> Ai98 { get => ai98; set => ai98 = value; }
        public Queue<Car> Diesel { get => diesel; set => diesel = value; }
        public double FillingRate { get => fillingRate; set => fillingRate = value; }

        public void AddCarToQueue(Car car)
        {
            switch (car.FuelType)
            {
                case "ai92":
                    ai92.Enqueue(car);
                    break;
                case "ai95":
                    ai95.Enqueue(car);
                    break;
                case "ai98":
                    ai98.Enqueue(car);
                    break;
                case "diesel":
                    diesel.Enqueue(car);
                    break;
            }
        }

        public  void fillAi92()
        {
            while (this.ai92.Count > 0)
            {
                Car currentCar = this.ai92.Peek();
                Console.WriteLine("Заправляю авто: {0} с колонки АИ-92", currentCar.Number);
                int sleepTime = Convert.ToInt32((currentCar.FuelLimit / this.fillingRate)) * 1000;
                Thread.Sleep(sleepTime);
                Console.WriteLine("Авто: {0} заправлено с колонки АИ-92", currentCar.Number);
                this.ai92.Dequeue();
            }
        }

        public  void fillAi95()
        {
            while (this.ai95.Count > 0)
            {
                Car currentCar = this.ai95.Peek();
                Console.WriteLine("Заправляю авто: {0} с колонки АИ-95", currentCar.Number);
                int sleepTime = Convert.ToInt32((currentCar.FuelLimit / this.fillingRate)) * 1000;
                Thread.Sleep(sleepTime);
                Console.WriteLine("Авто: {0} заправлено с колонки АИ-95", currentCar.Number);
                this.ai95.Dequeue();
            }
        }

        public  void fillAi98()
        {
            while (this.ai98.Count > 0)
            {
                Car currentCar = this.ai98.Peek();
                Console.WriteLine("Заправляю авто: {0} с колонки АИ-98", currentCar.Number);
                int sleepTime = Convert.ToInt32((currentCar.FuelLimit / this.fillingRate)) * 1000;
                Thread.Sleep(sleepTime);
                Console.WriteLine("Авто: {0} заправлено с колонки АИ-98", currentCar.Number);
                this.ai98.Dequeue();
            }
        }

        public  void fillDiesel()
        {
            while (this.diesel.Count > 0)
            {
                Car currentCar = this.diesel.Peek();
                Console.WriteLine("Заправляю авто: {0} с колонки для дизеля", currentCar.Number);
                int sleepTime = Convert.ToInt32((currentCar.FuelLimit / this.fillingRate)) * 1000;
                Thread.Sleep(sleepTime);
                Console.WriteLine("Авто: {0} заправлено с колонки для дизеля", currentCar.Number);
                this.diesel.Dequeue();
            }
        }


        public void fillCars()
        {
            
            var task1 = Task.Run(() => fillAi92());
            var task2 = Task.Run(() => fillAi95());
            var task3 = Task.Run(() => fillAi98());
            var task4 = Task.Run(() => fillDiesel());

            Task.WaitAll(task1, task2, task3, task4);

        }
    }
}
