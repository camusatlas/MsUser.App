using Dapper;
using MsUser.Domain.Entities;
using Npgsql;
using RealPlaza.Core.Core.Configuration;
using RealPlaza.Core.Core.Persistence;
using System.Data;

namespace MsUser.Persistence.Users.Respositories
{
    public class UserRepositiry : IUserRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly IGenericTransaction _transaction;

        public UserRepositiry(
            NpgsqlConnection connection,
            IGenericTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task Create(Usuario usuario)
        {
            var parameters = new DynamicParameters();

            parameters.Add("p_name", usuario.Name ?? string.Empty, DbType.String);
            parameters.Add("p_mail", usuario.Mail ?? string.Empty, DbType.String);
            parameters.Add("p_password", usuario.Password ?? string.Empty, DbType.String);
            parameters.Add("p_asset", usuario.Asset, DbType.Boolean);
            parameters.Add("p_state", usuario.State, DbType.Int32);
            parameters.Add("p_created_id", usuario.CreateId, DbType.Int32);
            parameters.Add("p_created_user", usuario.CreateUser ?? string.Empty, DbType.String);
            parameters.Add("p_created_date", usuario.CreateDate, DbType.DateTime);
            parameters.Add("p_verified_date", usuario.VerifiedDate, DbType.DateTime);

            await _transaction.ExecuteAsync("public.create_user_login", parameters);
        }

        public async Task Update(Usuario usuario)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_id", usuario.Id, DbType.Int32);
                parameters.Add("p_asset", usuario.Asset, DbType.Boolean);
                parameters.Add("p_update_id", usuario.UpdateId, DbType.Int32);
                parameters.Add("p_update_user", usuario.UpdateUser ?? string.Empty, DbType.String);
                parameters.Add("p_update_date", usuario.UpdateDate, DbType.DateTimeOffset);
                parameters.Add("p_verified_date", usuario.VerifiedDate, DbType.DateTimeOffset);

                await _transaction.ExecuteAsync("public.update_users_login", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
