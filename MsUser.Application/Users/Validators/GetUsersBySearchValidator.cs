using FluentValidation;
using MsUser.Internal.Contract.Users.Queries;
using MsUser.Persistence.Users.Queries;

namespace MsUser.Application.Users.Validators
{
    public class GetUsersBySearchValidator : AbstractValidator<GetUserBySearch>
    {
        private readonly IUsuarioQuery _usuarioQuery;
        public GetUsersBySearchValidator(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;

            RuleFor(x => x.id).GreaterThan(0).When(x => x.id.HasValue).WithMessage(ValidationMessages.IdGreaterZero);
            RuleFor(x => x).MustAsync(async (query, ct) =>
            {
                if (!query.id.HasValue)
                    return true;
                var users = await _usuarioQuery.GetBySearch(
                    query.id,
                    null,
                    null,
                    null,
                    null);
                return users.Any();
            }).WithMessage(ValidationMessages.IdExist);

            RuleFor(x => x.mail).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.mail)).WithMessage(ValidationMessages.Mail);
            RuleFor(x => x).MustAsync(async (query, ct) =>
            {
                if (string.IsNullOrWhiteSpace(query.name))
                    return true;
                var users = await _usuarioQuery.GetBySearch(
                    null,
                    query.name,
                    null,
                    null,
                    null);
                return users.Any();
            }).WithMessage(ValidationMessages.UserName);
        }
    }
}