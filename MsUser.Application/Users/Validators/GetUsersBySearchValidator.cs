using FluentValidation;
using MsUser.Internal.Contract.Users.Queries;

namespace MsUser.Application.Users.Validators
{
    public class GetUsersBySearchValidator : AbstractValidator<GetUserBySearch>
    {
        public GetUsersBySearchValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).When(x => x.id.HasValue).WithMessage(ValidationMessages.IdGreaterZero);
            RuleFor(x => x.mail).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.mail)).WithMessage(ValidationMessages.Mail);
        }
    }
}