using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
   public class CarDetailDto :IDto
    {
       
        public int carId { get; set; }
                       
        public string BrandName { get; set; }

        public string ColorName { get; set; }
        public string CarName{ get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }



    }
}
