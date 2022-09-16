using Core.Entities.Concrate;
using Core.Utilities.Results.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByUserName(string firstName);
        IDataResult<List<OperationClaim>> GetByClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);  
        IResult Delete(User user);

    }
}
