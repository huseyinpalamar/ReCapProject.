using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrate
{
    public class UserOperationClaim:IEntity
    {
        // kendi ıd
        public int Id { get; set; }
        //hangi kullanıcı
        public int UserId { get; set; }
        //hangi claim
        public int OperaitonClaimId { get; set; }
    }
}
