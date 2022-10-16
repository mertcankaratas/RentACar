using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
       IDataResult<Car> GetById(int id);

       IDataResult <List<Car>> GetAll();

       IDataResult<List<Car>> GetAllColorId(int id);
       IDataResult<List<Car>> GetAllBrandId(int id);
       IResult Add(Car car);
       IResult Update(Car car);
       IResult Delete(Car car);
       IDataResult <List<CarDetailDto>> GetCarDetails();
       IDataResult <List<CarDetailDto>> GetCarDetailsByCarId(int carId);
    }
}
