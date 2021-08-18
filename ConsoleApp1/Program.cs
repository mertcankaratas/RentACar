using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car addCar = new Car { Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 4548575, ModelYear = "2004", Description = "Aile Dostu" };

            carManager.Add(addCar);
            foreach (var car  in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
