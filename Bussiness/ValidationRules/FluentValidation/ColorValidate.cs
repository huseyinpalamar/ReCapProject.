using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidate:AbstractValidator<Color>
    {
        public ColorValidate()
        {
            RuleFor(c=>c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).NotNull();
            RuleFor(c => c.ColorName).MaximumLength(2);
           
        }
    }
}
