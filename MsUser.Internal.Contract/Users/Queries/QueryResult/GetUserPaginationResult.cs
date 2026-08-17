using RealPlaza.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Internal.Contract.Users.Queries.QueryResult
{
    public record GetUserPaginationResult(IEnumerable<UserItemResult> Data, PagingResult Paging);
    public record UserItemResult
    (
        int id,
        string name,
        string mail,
        bool asset,
        int state
    );
}