using Core.Utilities.Results.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByDailyPrice(int min, int max);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


    }
}
