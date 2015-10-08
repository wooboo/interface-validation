using WebApplication4.Models;
using WebApplication4.Validation;

namespace WebApplication4.Controllers
{
    public class CommandHandler
    {
        public void Execute<T>(T command)
            where T: ICommand
        {
            var valFact = new MyValidatorFactory();
            var validator = valFact.GetValidator<CreateCommand>();
            var result = validator.Validate(command);
            if (result.IsValid)
            {
                //find handler and execute
            }
            else
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}