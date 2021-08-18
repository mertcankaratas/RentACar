using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entites.Concrete;

namespace DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car>
    {
        Car GetCarsByBrandId(Expression<Func<Car, bool>> filter);
        Car GetCarsColorId(Expression<Func<Car, bool>> filter);
    }
}
