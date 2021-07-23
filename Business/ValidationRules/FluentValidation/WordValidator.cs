using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(w => w.WordName).NotNull();
            RuleFor(w => w.WordName).NotEmpty();

            RuleFor(w => w.WordDescription).NotNull();
            RuleFor(w => w.WordDescription).NotEmpty();
            RuleFor(w => w.WordDescription).MinimumLength(10);
            
            RuleFor(w => w.WordUseArea).NotNull();
            RuleFor(w => w.WordUseArea).NotEmpty();
            RuleFor(w => w.WordUseArea).MinimumLength(5);
        }
    }
}