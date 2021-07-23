using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            
            RuleFor(c => c.Password).NotNull().WithMessage("Şifre boş olamaz!");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
        }
    }
}