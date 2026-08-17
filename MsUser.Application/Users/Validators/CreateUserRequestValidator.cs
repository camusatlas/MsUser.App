using FluentValidation;
using MsUser.Internal.Contract.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Application.Users.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.mail).NotEmpty().EmailAddress().WithMessage(ValidationMessages.Mail);
            RuleFor(x => x.password).NotEmpty();
        }
    }
}
