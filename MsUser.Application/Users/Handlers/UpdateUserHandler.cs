using Microsoft.Extensions.Logging;
using MsUser.Application.Users.Validators;
using MsUser.Domain.Entities;
using MsUser.Internal.Contract.User.Commands.CommandResult;
using MsUser.Internal.Contract.Users.Commands;
using MsUser.Persistence;
using RealPlaza.Core.Common.Contracts;
using RealPlaza.Core.Core.Configuration;

namespace MsUser.Application.Users.Handlers
{
    public class UpdateUserHandler
    {
        private readonly ILogger<UpdateUserHandler> _logger;
        private readonly TryCommand<UpdateUserCommand, UpdateUserRequestValidator, UpdateUserResult> _tryCommand;
        private readonly UpdateUserRequestValidator _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(
            ILogger<UpdateUserHandler> logger,
            UpdateUserRequestValidator validator,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _validator = validator;
            _unitOfWork = unitOfWork;

            _tryCommand = new TryCommand<UpdateUserCommand, UpdateUserRequestValidator, UpdateUserResult>(
                _logger,
                async (command, ct) =>
                {
                    try
                    {
                        _unitOfWork.Begin();
                        var dateUtc = DateTime.UtcNow;
                        var usuario = new Usuario
                        {
                            Id = command.id,
                            Asset = command.asset,
                            UpdateId = 0,
                            UpdateUser = "SYSTEM",
                            UpdateDate = dateUtc,
                            VerifiedDate = dateUtc
                        };
                        await _unitOfWork.UserRepository.Update(usuario);
                        _unitOfWork.Commit();
                        return new UpdateUserResult(true, usuario.Id);
                    }
                    catch
                    {
                        _unitOfWork.Rollback();
                        throw;
                    }
                },
                () => Task.FromResult(_validator));
        }
        public async Task<CommandResult<UpdateUserResult>> HandleAsync(UpdateUserCommand command, CancellationToken ct)
        {
            return await _tryCommand.ExecuteAsync(command, ct);
        }
    }
}
