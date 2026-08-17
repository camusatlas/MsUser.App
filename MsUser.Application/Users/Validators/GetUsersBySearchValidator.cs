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
        }
    }
}