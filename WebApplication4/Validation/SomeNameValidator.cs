using FluentValidation;
using WebApplication4.Models;

namespace WebApplication4.Validation
{
    public class SomeNameValidator : AbstractValidator<INameModel>
    {
        public SomeNameValidator()
        {
            RuleFor(o => o.Name).NotNull();
        }
    }
}