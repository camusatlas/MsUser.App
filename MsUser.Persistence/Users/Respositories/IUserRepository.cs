using System.Threading.Tasks;
using MsUser.Domain.Entities;

namespace MsUser.Persistence.Users.Respositories
{
    public interface IUserRepository
    {
        Task Create(Usuario usuario);
        Task Update(Usuario usuario);
    }
}