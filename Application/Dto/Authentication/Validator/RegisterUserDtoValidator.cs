using Application.Dto.Authentication.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Authentication.Validator
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(6);
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);

        }
    }
}
