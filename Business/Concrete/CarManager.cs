using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Penformance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        
        public IResult Add(Car car)
        {
         
            _CarDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
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

        public IResult Delete(Car car)
        {

            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult <List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_CarDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ColorId == id));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car> (_CarDal.Get(c => c.BrandId == id));
        }

        public  IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_CarDal.GetCarDetails());
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
