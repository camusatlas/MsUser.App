using RealPlaza.Core.Common.Contracts;

namespace MsUser.Internal.Contract.Users.Queries
{
    public record GetUserPagination(string? name, Paging Paging, string SortColumn, string SortDirection);
}