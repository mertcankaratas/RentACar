using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entites.DTOs;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,SqlDatabaseContext>, ICarDal
    {
       

        public List<CarDetailDto> GetCarDetails()
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var result = from cr in context.Cars
                             join c in context.Colors
                             on cr.ColorId equals c.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 ColorId = c.Id,
                                 CarName = cr.CarName,
                                 BrandName = b.BrandName,
                                 BrandId = b.Id,
                                 ColorName= c.ColorName,
                                 DailyPrice = cr.DailyPrice
                             };
                return result.ToList();
            }
           
        }

        

       
    }
}
