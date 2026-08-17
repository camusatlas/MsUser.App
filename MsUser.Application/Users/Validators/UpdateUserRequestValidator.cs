using FluentValidation;
using MsUser.Internal.Contract.Users.Commands;
using MsUser.Persistence.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Application.Users.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUsuarioQuery? _usuarioQuery;
        public UpdateUserRequestValidator()
        {
            AddBasicRules();
        }

        private void AddBasicRules()
        {
            RuleFor(x => x.id).GreaterThan(0).WithMessage(ValidationMessages.IdGreaterZero);
        }

        public UpdateUserRequestValidator(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;
            AddBasicRules();

            RuleFor(x => x).MustAsync(async (command, ct) =>
            {
                var user = await _usuarioQuery.GetById(command.id);
                return user is not null;
            }).WithMessage(ValidationMessages.UserNotExist);
            RuleFor(x => x).MustAsync(async (command, ct) =>
            {
                var user = await _usuarioQuery.GetById(command.id);
                if (user is null)
                    return true;
                return user.asset == false;
            }).WithMessage(ValidationMessages.UserValidationAcceptance);
        }
    }
}