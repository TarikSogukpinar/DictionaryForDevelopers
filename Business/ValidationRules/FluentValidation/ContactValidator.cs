using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.FirstName).NotNull();
            RuleFor(c => c.FirstName).NotEmpty();

            RuleFor(c => c.LastName).NotNull();
            RuleFor(c => c.LastName).NotEmpty();

            RuleFor(c => c.Message).NotNull();
            RuleFor(c => c.Message).NotEmpty();
            RuleFor(c => c.Message).MinimumLength(2);
        }
    }
}