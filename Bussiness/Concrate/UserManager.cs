using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities.Concrate;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using DataAccess.Abstract;
using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           
            
            _userDal.Add(user);
            return new SuccessResult(Messages.AddSuccessful);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.ListingSuccessful);
        }

        public IDataResult<List<OperationClaim>> GetByClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==id), Messages.ListingSuccessful);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<User> GetByUserName(string firstName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.FirstName== firstName),Messages.ListingSuccessful);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateSuccessful);
        }
    }
}
