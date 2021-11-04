using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (SqlDatabaseContext context = new SqlDatabaseContext())
            {
                var result = from rt in context.Rentals
                             join cr in context.Cars
                             on rt.CarId equals cr.CarId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join ct in context.Customers
                             on rt.CustomerId equals ct.CustomerId
                             join us in context.Users
                             on ct.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = rt.RentalId,
                                 BrandName = br.BrandName,
                                 FullName = us.FirstName +" " + us.LastName,
                                 RentDate=rt.RentDate,
                                 ReturnDate=rt.ReturnDate
                             };
                 return result.ToList();
            }
        }
    }
}
