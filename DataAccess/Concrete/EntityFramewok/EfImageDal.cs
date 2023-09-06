﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramewok
{ 
    public class EfImageDal: EfEntityRepositoryBase<Image, CarContext>, IImageDal
    {
    }
}
