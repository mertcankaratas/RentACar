using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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

            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 1, ColorId = 5, ModelYear="2018", DailyPrice=337500,Description="15000 Km'de" });
            //carManager.Delete(new Car { Id = 1003 });
            //carManager.Update(new Car {Id=1002 ,BrandId=5,ColorId=4, ModelYear = "2018", DailyPrice = 705000, Description="Jantlar yeni değişti"});

           foreach (var cr in carManager.GetCarDetails() )
           {
                Console.WriteLine(cr.BrandName);
            }


            //Car addCar = new Car { Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 4548575, ModelYear = "2004", Description = "Aile Dostu" };

            //carManager.Add(addCar);
            //foreach (var car  in carManager.GetAll())
            //{
            //    Console.WriteLine(car.BrandId);
            //}
            //Console.WriteLine("Hello World!");
        }
    }
}
