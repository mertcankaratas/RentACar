using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService
    {
        IDataResult <Color> GetById(int id);

       IDataResult <List<Color>> GetAll();

       IResult Add(Color color);
       IResult Update(Color color);
       IResult Delete(Color color);
    }
}
