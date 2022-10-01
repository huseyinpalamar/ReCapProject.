using Core.Entities.Concrate;
using Core.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserOperationClaimDal: EfEntityRepositoryBase<UserOperationClaim,ReCapContext>,IUserOperationClaimDal
    {
    }
}
