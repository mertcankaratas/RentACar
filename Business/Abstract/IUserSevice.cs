using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserSevice
    {
        IDataResult<User> GetById(int id);

        IDataResult<List<User>> GetAll();

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
