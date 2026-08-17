using MsUser.Persistence.Users.Respositories;
using RealPlaza.Core.Core.Persistence;
using System.Diagnostics.CodeAnalysis;
using RealPlaza.Core.Core.Configuration;


namespace MsUser.Persistence
{
    [ExcludeFromCodeCoverage]
    public sealed class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public UnitOfWork(
            TransactionManager transactionManager,
            IServiceProvider serviceProvider,
            IUserRepository userRepository
            ) : base(serviceProvider, transactionManager)
        {
            UserRepository = userRepository;
        }
    }
}
