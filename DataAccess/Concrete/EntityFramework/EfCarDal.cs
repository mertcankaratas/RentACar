﻿using DataAccess.Abstract;
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
                             on cr.ColorId equals c.ColorId
                             join b in context.Brands
                             on cr.BrandId equals b.BrandId
                             join img in context.CarImages
                             on cr.CarId equals img.CarId
                             select new CarDetailDto
                             {
                                 carId = cr.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 CarName = cr.CarName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ImagePath = (from i in context.CarImages where i.CarId == cr.CarId select i.ImagePath).ToList()

                             };
                return result.ToList();
            }
           
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var result = from cr in context.Cars
                             join c in context.Colors
                             on cr.ColorId equals c.ColorId
                             join b in context.Brands
                             on cr.BrandId equals b.BrandId
                             join img in context.CarImages
                             on cr.CarId equals img.CarId
                             where cr.CarId == carId
                             select new CarDetailDto
                             {
                                 carId = cr.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 CarName = cr.CarName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ImagePath = (from i in context.CarImages where i.CarId == cr.CarId select i.ImagePath).ToList()

                             };
                return result.ToList();
            }
        }
    }
}
