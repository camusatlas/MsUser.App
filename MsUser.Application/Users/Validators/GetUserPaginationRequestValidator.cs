using FluentValidation;
using MsUser.Internal.Contract.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Application.Users.Validators
{
    public class GetUserPaginationRequestValidator : AbstractValidator<GetUserPagination>
    {
        public GetUserPaginationRequestValidator()
        {
            RuleFor(x => x.Paging.CurrentIndex).GreaterThan(0).WithMessage(ValidationMessages.IntPagination);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage(ValidationMessages.PageSizePagination);
        }
    }
}