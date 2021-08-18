using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
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
            if(car.DailyPrice >0 && car.Description.Length >= 2)
            {
                _CarDal.Add(car);

            }
            else
            {
                Console.WriteLine("Fiyat 0'dan büyük olmalı ve Ad 2 karakter veya daha uzun girilmeli ");
            }
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
