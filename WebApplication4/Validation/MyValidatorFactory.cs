using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace WebApplication4.Validation
{
    public class MyValidatorFactory : IValidatorFactory
    {
        private readonly List<IValidator> _validators = new List<IValidator>();

        public MyValidatorFactory()
        {
            _validators.Add(new SomeNameValidator());
            _validators.Add(new SomeValueValidator());
        }

        public IValidator<T> GetValidator<T>()
        {
            return new AggregateValidator<T>(GetValidators(typeof (T)));
        }

        public IValidator GetValidator(Type type)
        {
            return new AggregateValidator(GetValidators(type));
        }

        private IEnumerable<IValidator> GetValidators(Type type)
        {
            return _validators.Where(o => type.GetInterfaces().Any(o.CanValidateInstancesOfType));
        }
    }
}