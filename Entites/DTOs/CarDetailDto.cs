using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
   public class CarDetailDto :IDto
    {
        public int BrandId { get; set; }
                       
        public string BrandName { get; set; }
              
        public int ColorId{ get; set; }
        public string CarName{ get; set; }
        public string ColorName { get; set; }
        public float DailyPrice { get; set; }
        public string Description { get; set; }


    }
}
