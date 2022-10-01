using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("Car.Add")]
        public IResult Add(Car car)
        {
            

            _carDal.Add(car);
            return new SuccessResult(Messages.AddSuccessful); 
        }

        public IResult Delete(Car car)
        {
            // iş kodları yazılıcak
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccessful);
        }
        [SecuredOperation("Product.List")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListingSuccessful);

        }

        public IDataResult<Car> GetById(int id)
        {
            var result=(_carDal.Get(c=>c.Id==id));
            if (result!=null)
            {
                return new  SuccessDataResult<Car>(Messages.ListingSuccessful);
            }
            return new ErrorDataResult<Car>(Messages.ListingFailed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(int min, int max)
        {
            var result= (_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max));
            if (result!=null)
            {
                return new SuccessDataResult<List<Car>>(Messages.ListingSuccessful);
            }
            return new ErrorDataResult<List<Car>>(Messages.CeheckProductPrice);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId), Messages.ListingSuccessful);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId==colorId), Messages.ListingSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(),Messages.ListingSuccessful);
        }

        

    }

}
