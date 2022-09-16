using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal=customerDal; 
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddSuccessful);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        public IDataResult<List<Customer>> GetAll()
        {
             return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.ListingSuccessful);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.CustomerId == id);
            if (result!=null)
            {
                return new SuccessDataResult<Customer>( Messages.ListingSuccessful);
            }
            return new SuccessDataResult<Customer>(Messages.ListingFailed);
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Messages.UpdateSuccessful);
        }
    }
}
