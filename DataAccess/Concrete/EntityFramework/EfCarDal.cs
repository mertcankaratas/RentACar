using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entites.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
           using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

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
                                 CarName = cr.CarName,
                                 BrandName = b.Name,
                                 ColorName= c.Name,
                                 DailyPrice = cr.DailyPrice
                             };
                return result.ToList();
            }
           
        }

        public Car GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public Car GetCarsColorId(Expression<Func<Car, bool>> filter)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
