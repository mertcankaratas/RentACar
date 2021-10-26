using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetailDtos();
    }
}
