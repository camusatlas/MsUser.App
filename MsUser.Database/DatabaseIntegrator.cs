using EvolveDb;
using EvolveDb.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MsUser.Database
{
    [ExcludeFromCodeCoverage]
    public class DatabaseIntegrator
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseIntegrator> _logger;

        public DatabaseIntegrator(IConfiguration configuration, ILogger<DatabaseIntegrator> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private TransactionKind GetTransactionKind(string strategyText)
        {
            return strategyText switch
            {
                "each" => TransactionKind.CommitEach,
                "rollback" => TransactionKind.RollbackAll,
                _ => TransactionKind.CommitAll
            };
        }

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(Run, cancellationToken);
        }

        public void Run()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString(MigrationConstants.ConnectionStringKey);
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";

                _logger.LogInformation("Iniciando migraciones de base de datos...");

                foreach (var source in MigrationConstants.Sources)
                {
                    var sourceDirectory = Path.Combine(directoryName, source);
                    _logger.LogInformation("Procesando migraciones desde el directorio: {sourceDirectory}", sourceDirectory);

                    using var connection = new NpgsqlConnection(connectionString);
                    var evolve = new Evolve(connection)
                    {
                        Locations = new[] { sourceDirectory },
                        IsEraseDisabled = true,
                        SqlMigrationPrefix = MigrationConstants.ScriptPrefix,
                        SqlRepeatableMigrationPrefix = MigrationConstants.RepeatableScriptPrefix,
                        CommandTimeout = 60,
                        TransactionMode = GetTransactionKind(MigrationConstants.Strategy)
                    };

                    foreach (var command in MigrationConstants.Commands)
                    {
                        _logger.LogInformation("Ejecutando comando: {command}", command);
                        switch (command)
                        {
                            case "migrate":
                                evolve.Migrate();
                                _logger.LogInformation("Migración completada exitosamente.");
                                break;
                            case "repair":
                                evolve.Repair();
                                _logger.LogInformation("Reparación completada exitosamente.");
                                break;
                            case "info":
                                evolve.Info();
                                _logger.LogInformation("Información completada exitosamente.");
                                break;
                        }
                    }
                }
                _logger.LogInformation("Migraciones de base de datos completadas.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error durante las migraciones de base de datos.");
                throw;
            }
        }
    }
}