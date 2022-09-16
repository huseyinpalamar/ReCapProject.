using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
           _colorDal.Add(color);
            return new SuccessResult(Messages.AddSuccessful);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.DeleteFailed);
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.ColorId == id),Messages.ListingSuccessful);
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ListingSuccessful);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.UpdateSuccessful);
        }
    }
}
