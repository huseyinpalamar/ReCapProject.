using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidate:AbstractValidator<Customer>
    {
        public CustomerValidate()
        {
            RuleFor(c=>c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).NotNull();
            
        }
    }
}
