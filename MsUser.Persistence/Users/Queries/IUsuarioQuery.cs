

namespace MsUser.Persistence.Users.Queries
{
    public interface IUsuarioQuery
    {
        Task<UserDto> GetById(int id);
        Task<IEnumerable<UserDto>> GetBySearch(int? id, string? name, string? mail, bool? asset, int? state);
        Task<IEnumerable<UserPaginationDto>> GetUserPagination(string? name, int page, int pageSize, string? sortColumn, string? sortDirection);
    }
}