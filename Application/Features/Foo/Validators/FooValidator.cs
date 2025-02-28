using Application.Features.Foo.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foo.Validators
{
    public class FooValidator : AbstractValidator<FooDTO>
    {
        public FooValidator() {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Max 50 characters");

            RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be more than zero")
            .LessThanOrEqualTo(120).WithMessage("Age must be less than 120");
        }
    }
}
