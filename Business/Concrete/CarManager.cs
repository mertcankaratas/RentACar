using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            _CarDal.Add(car);
        }

        //public void Add(Car car)
        //{
        //    if(car.DailyPrice >0 && car.Description.Length >= 2)
        //    {
        //        _CarDal.Add(car);

        //    }
        //    else
        //    {
        //        Console.WriteLine("Fiyat 0'dan büyük olmalı ve Ad 2 karakter veya daha uzun girilmeli ");
        //    }
        //}

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _CarDal.Get(c => c.BrandId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
