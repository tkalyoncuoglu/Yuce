using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class PointValidator : AbstractValidator<int>
    {
        public PointValidator()
        {
            RuleFor(x => x).InclusiveBetween(0, 10).WithMessage("Point must be between 0 and 10 inclusive");


        }
    }
}
