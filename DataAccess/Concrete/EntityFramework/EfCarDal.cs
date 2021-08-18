using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
