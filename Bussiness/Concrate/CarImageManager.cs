using Business.Abstract;
using Business.Constants;

using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using DataAccess.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
       

        public CarImageManager(ICarImageDal carImageDal , IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
          

        }

        public IResult Add(IFormFile file, CarImage carImage)
        {

            var result = BusinessRules.Run(CheckImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }



            var resultOfUpload = _fileHelper.Upload(file,PathConstans.ImagePath);

            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            carImage.ImagePath = resultOfUpload.Message;
             carImage.Date = DateTime.Now;
            _carImageDal    .Add(carImage); ;
            return new SuccessResult(Messages.AddSuccessful);
        }

        public IResult Delete(CarImage carImage)
        {
            var result= _fileHelper.Delete(PathConstans.ImagePath+ carImage.ImagePath);
            if (!result.Success)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _fileHelper.Update(file,PathConstans.ImagePath+carImage.ImagePath,PathConstans.ImagePath);
            if (!result.Success)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = result.Message;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdateSuccessful);

        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

        }

        private IResult CheckImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId).Count();
            if ( result>=5 )
            {
                return new ErrorResult("En Fazla 5 resim eklenebilir");
            }
            return new SuccessResult();
          
        }


        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();

            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\images\\DefaultImage.jpg}" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }
}
