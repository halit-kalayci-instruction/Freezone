using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(i => i.Id).NotEmpty().NotNull().Must(i=>i > 0);
            RuleFor(i => i.Name).NotEmpty().NotNull();
        }
    }
}
