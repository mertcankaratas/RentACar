﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice{ get; set; }

        public string Description { get; set; }
    }
}
