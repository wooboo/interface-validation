using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;

namespace WebApplication4.Validation
{
    public class AggregateValidatorDescriptor : IValidatorDescriptor
    {
        private readonly IEnumerable<IValidatorDescriptor> _descriptors;

        public AggregateValidatorDescriptor(IEnumerable<IValidatorDescriptor> descriptors)
        {
            _descriptors = descriptors;
        }

        public string GetName(string property)
        {
            foreach (var validatorDescriptor in _descriptors)
            {
                var name = validatorDescriptor.GetName(property);
                if (name != null)
                {
                    return name;
                }
            }
            return null;
        }

        public ILookup<string, IPropertyValidator> GetMembersWithValidators()
        {
            return _descriptors.SelectMany(o => o.GetMembersWithValidators()).ToLookup(o => o.Key, o => o.First());
        }

        public IEnumerable<IPropertyValidator> GetValidatorsForMember(string name)
        {
            foreach (var validatorDescriptor in _descriptors)
            {
                foreach (var propertyValidator in validatorDescriptor.GetValidatorsForMember(name))
                {
                    yield return propertyValidator;
                }
            }
        }

        public IEnumerable<IValidationRule> GetRulesForMember(string name)
        {
            foreach (var validatorDescriptor in _descriptors)
            {
                foreach (var rule in validatorDescriptor.GetRulesForMember(name))
                {
                    yield return rule;
                }
            }
        }
    }
}