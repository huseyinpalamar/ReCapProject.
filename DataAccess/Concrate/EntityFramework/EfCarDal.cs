using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCapContext reCapContext=new ReCapContext ())
            {
                var result = from c in reCapContext.Cars
                             join b in reCapContext.Brands
                             on c.BrandId equals b.BrandId
                             join r in reCapContext.Colors
                             on c.ColorId equals r.ColorId

                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarId = c.Id,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = r.ColorName,
                                 Dectription = c.Description,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
                             
            }
        }
    }
}
