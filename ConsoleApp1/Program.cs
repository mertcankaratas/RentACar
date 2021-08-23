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

            
            //CarAdd(carManager);
            //CarDelete(carManager);
            //CarUpdate(carManager);
            CarDetails();



            
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true) {

                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.BrandName} {car.ColorName} {car.CarName} {car.DailyPrice}  ");
                }
            }
           
        }

        private static void CarUpdate(CarManager carManager)
        {
            carManager.Update(new Car { Id = 1002, BrandId = 5, ColorId = 4, CarName="Sedan", ModelYear = "2018", DailyPrice = 705000, Description = "Jantlar yeni değişti" });
        }

        private static void CarDelete(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 1003 });
        }

        private static void CarAdd(CarManager carManager)
        {
            carManager.Add(new Car { BrandId = 1, ColorId = 5, ModelYear = "2018", DailyPrice = 337500, Description = "15000 Km'de" });
        }
    }
}
