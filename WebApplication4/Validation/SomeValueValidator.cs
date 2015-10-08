using FluentValidation;
using WebApplication4.Models;

namespace WebApplication4.Validation
{
    public class SomeValueValidator : AbstractValidator<IValueModel>
    {
        public SomeValueValidator()
        {
            RuleFor(o => o.Value).NotNull().GreaterThan(3);
        }
    }
}