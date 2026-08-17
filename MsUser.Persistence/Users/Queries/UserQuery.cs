using Dapper;
using RealPlaza.Core.Core.Persistence;
using RealPlaza.Core.Common.Utils;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace MsUser.Persistence.Users.Queries
{
    public class UserQuery : IUsuarioQuery
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserQuery(IDbConnectionFactory iDbConnectionFactory)
        {
            _connectionFactory = iDbConnectionFactory ?? throw new ArgumentNullException(nameof(iDbConnectionFactory));
        }
        public async Task<UserDto> GetById(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("p_id", id);

            return await connection.QuerySingleFunctionAsync<UserDto>("get_user_by_id", parameters);
        }
        public async Task<IEnumerable<UserDto>> GetBySearch(int id, string name, string mail, bool asset, int state)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("pi_id", id);
                parameters.Add("pi_name", name);
                parameters.Add("pi_mail", mail);
                parameters.Add("pi_asset", asset);
                parameters.Add("pi_state", state);

                return await connection.QueryFunctionAsync<UserDto>("get_user_search", parameters);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<UserPaginationDto>> GetUserPagination(string name, int currentIndex, int pageSize, string sortColumn, string sortDirection)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("pi_name", name);
                parameters.Add("p_page_index", currentIndex);
                parameters.Add("p_page_size", pageSize);
                parameters.Add("p_sort_column", sortColumn);
                parameters.Add("p_sort_direction", sortDirection);

                return await connection.QueryFunctionAsync<UserPaginationDto>("get_user_pagination", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}