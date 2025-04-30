using Api.Domain.Repositories;
using FluentValidation;
using Shared.DTOs;

namespace Validation
{
    public class RegisterValidator : AbstractValidator<UserForRegistrationDto>
    {
        public RegisterValidator(IUnitOfWork unitOfWork) {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            //RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\d{3}-\d{3}$");
            RuleFor(x => x.Roles)
                .NotEmpty()
                .Must(roles => roles.All(r => new[] { "User", "Administrator" }.Contains(r)))
                .WithMessage("Invalid role provided.");

        }
    }
}
