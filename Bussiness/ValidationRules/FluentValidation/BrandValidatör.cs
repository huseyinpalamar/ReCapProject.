using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidatör:AbstractValidator<Brand>
    {
        public BrandValidatör()
        {
            RuleFor(b=>b.BrandName).NotEmpty().WithMessage("Marka ismi boş olamaz.");
            RuleFor(b => b.BrandName).NotNull().WithMessage("Marka ismi boş olamaz.");

        }
    }
}
