using FluentValidation;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class LoginValidator : AbstractValidator<UserForAuthenticationDto>
    {
        public LoginValidator() { 
            RuleFor(x => x.UserName).Length(3, 10).WithMessage("Toooooo small");
           
        }
    }
}
