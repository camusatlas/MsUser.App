using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MsUser.Application.Users.Validators;
using MsUser.Domain.Entities;
using MsUser.Internal.Contract.User.Commands.CommandResult;
using MsUser.Internal.Contract.Users.Commands;
using MsUser.Persistence;
using RealPlaza.Core.Common.Contracts;
using RealPlaza.Core.Core.Configuration;
using System.Text.Json;

namespace MsUser.Application.Users.Handlers
{
    public class CreateUserHandler
    {
        private readonly ILogger<CreateUserHandler> _logger;
        private readonly TryCommand<CreateUserCommand, CreateUserRequestValidator, CreateUserResult> _tryCommand;
        private readonly CreateUserRequestValidator _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        public CreateUserHandler(
            ILogger<CreateUserHandler> logger,
            CreateUserRequestValidator validator,
            IUnitOfWork unitOfWork,
            IPasswordHasher<Usuario> passwordHasher)
        {
            _logger = logger;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tryCommand = new TryCommand<CreateUserCommand, CreateUserRequestValidator, CreateUserResult>(_logger, async (command, ct) =>
            {
                try
                {
                    _unitOfWork.Begin();
                    _logger.LogInformation("Request {MethodName}: {Request}",
                        nameof(CreateUserHandler),
                        JsonSerializer.Serialize(command, ApplicationJsonOptions.Default));

                    var dateUtc = DateTime.UtcNow;
                    var usuario = new Usuario
                    {
                        Name = command.name,
                        Mail = command.mail,
                        Password = command.password,
                        Asset = false,
                        State = 1,
                        CreateId = 0,
                        CreateUser = "SYSTEM",
                        CreateDate = dateUtc
                    };
                    usuario.Password = _passwordHasher.HashPassword(usuario, command.password);

                    await _unitOfWork.UserRepository.Create(usuario);
                    _unitOfWork.Commit();
                    var result = new CreateUserResult(true, usuario.Id);
                    _logger.LogInformation("Resultado {MethodName}: {Result}", nameof(CreateUserHandler), JsonSerializer.Serialize(result, ApplicationJsonOptions.Default));
                    return result;
                }
                catch (Exception e)
                {
                    _unitOfWork.Rollback();
                    _logger.LogError(e, LogConstants.LogErrorSL, nameof(CreateUserHandler));
                    throw;
                }
            },
            () => Task.FromResult(_validator));
        }
        public async Task<CommandResult<CreateUserResult>> HandleAsync(CreateUserCommand command, CancellationToken ct)
        {
            _logger.LogInformation(ConstantsRP.HANDLER_STARTED_SL, nameof(CreateUserHandler));
            var result = await _tryCommand.ExecuteAsync(command, ct);
            _logger.LogInformation(ConstantsRP.HANDLER_FINISHED_SL, nameof(CreateUserHandler));
            return result;
        }
    }
}
