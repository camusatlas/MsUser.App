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
        private static readonly string[] AllowedSortColumns =
        {
            "Name",
            "Mail",
            "Asset",
            "State",
            "CreatedDate"
        };
        private static readonly string[] AllowedSortDirections =
        {
            "ASC",
            "DESC"
        };
        public GetUserPaginationRequestValidator()
        {
            RuleFor(x => x.Paging.CurrentIndex).GreaterThan(0).WithMessage(ValidationMessages.IntPagination);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage(ValidationMessages.PageSizePagination);
            RuleFor(x =>x.SortColumn).Must(sortColumn => sortColumn is null || AllowedSortColumns.Contains(sortColumn))
                .WithMessage(ValidationMessages.SortColumnInvalid);
            RuleFor(x => x.SortDirection).Must(sortDirection => sortDirection is null || AllowedSortDirections.Contains(sortDirection))
                .WithMessage(ValidationMessages.SortDirectionInvalid);
        }
    }
}