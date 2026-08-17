
namespace MsUser.Internal.Contract.User.Queries.QueryResult
{
    public record GetUserBySearchResult(IEnumerable<UserItem> Data);
    public record UserItem(
        int id,
        string  name,
        string mail,
        bool asset,
        int state
    );
}