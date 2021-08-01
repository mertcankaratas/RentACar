using System;
using System.Collections.Generic;
using System.Text;
using Entites.Concrete;

namespace DataAccess.Abstract
{
   public interface ICarDal
    {
        List<Car> GetById(int categoryId);
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
