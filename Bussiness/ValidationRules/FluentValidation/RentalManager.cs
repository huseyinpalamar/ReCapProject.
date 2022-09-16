using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalManager:AbstractValidator<Rental>
    {
        public RentalManager()
        {
            RuleFor(r=>r.RentDate).NotEmpty();
            RuleFor(r=>r.RentDate).NotNull();
           
        }
    }
}
