using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace WebApplication4.Validation
{
    public class AggregateValidator<T> : AggregateValidator, IValidator<T>
    {
        public AggregateValidator(IEnumerable<IValidator> validators) : base(validators)
        {
        }

        public ValidationResult Validate(T instance)
        {
            return base.Validate(instance);
        }

        public Task<ValidationResult> ValidateAsync(T instance)
        {
            return base.ValidateAsync(instance);
        }

        public CascadeMode CascadeMode { get; set; }
    }
    public class AggregateValidator : List<IValidationRule>, IValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public AggregateValidator(IEnumerable<IValidator> validators)
        {
            _validators = validators;
            this.AddRange(_validators.SelectMany(o=>o));
        }


        public ValidationResult Validate(object instance)
        {
            var validationFailures = new List<ValidationFailure>();
            foreach (var validator in _validators)
            {
                var result = validator.Validate(instance);
                validationFailures.AddRange(result.Errors);
            }
            return new ValidationResult(validationFailures);
        }

        public Task<ValidationResult> ValidateAsync(object instance)
        {
            var resultTasks = new List<Task<ValidationResult>>();
            foreach (var validator in _validators)
            {
                var validationTask = validator.ValidateAsync(instance);
                resultTasks.Add(validationTask);
            }
            Task.WaitAll(resultTasks.ToArray());
            var validationFailures = new List<ValidationFailure>();

            foreach (var resultTask in resultTasks)
            {
                validationFailures.AddRange(resultTask.Result.Errors);
            }
            return Task.FromResult(new ValidationResult(validationFailures));
        }

        public ValidationResult Validate(ValidationContext context)
        {
            var validationFailures = new List<ValidationFailure>();
            foreach (var validator in _validators)
            {
                var result = validator.Validate(context);
                validationFailures.AddRange(result.Errors);
            }
            return new ValidationResult(validationFailures);
        }

        public Task<ValidationResult> ValidateAsync(ValidationContext context)
        {
            var resultTasks = new List<Task<ValidationResult>>();
            foreach (var validator in _validators)
            {
                var validationTask = validator.ValidateAsync(context);
                resultTasks.Add(validationTask);
            }
            Task.WaitAll(resultTasks.ToArray());
            var validationFailures = new List<ValidationFailure>();

            foreach (var resultTask in resultTasks)
            {
                validationFailures.AddRange(resultTask.Result.Errors);
            }
            return Task.FromResult(new ValidationResult(validationFailures));
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            return new AggregateValidatorDescriptor(_validators.Select(o => o.CreateDescriptor()));
        }

        public bool CanValidateInstancesOfType(Type type)
        {
            return _validators.Any(o => o.CanValidateInstancesOfType(type));
        }
    }
}