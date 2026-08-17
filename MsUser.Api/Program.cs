using Microsoft.AspNetCore.Identity;
using MsUser.Api;
using MsUser.Application.Users.Handlers;
using MsUser.Application.Users.Validators;
using MsUser.Domain.Entities;
using MsUser.Persistence;
using MsUser.Persistence.Users.Queries;
using MsUser.Persistence.Users.Respositories;
using Npgsql;
using RealPlaza.Core.Core.Configuration;
using RealPlaza.Core.Core.Persistence;
using System.Data;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseWolverine(options =>
{
    options.Discovery.IncludeAssembly(typeof(GetUserBySearchHandler).Assembly);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No connection string found for DefaultConnection.");

builder.Services.ConfigureConnectionFactory(connectionString);

builder.Services.AddScoped(_ => new NpgsqlConnection(connectionString));

builder.Services.AddScoped<Func<IDbTransaction>>(sp => () =>
{
    var transactionManager = sp.GetRequiredService<TransactionManager>();

    if (transactionManager.CurrentTransaction is not null)
        return transactionManager.CurrentTransaction;

    var connection = sp.GetRequiredService<NpgsqlConnection>();

    if (connection.State != ConnectionState.Open)
        connection.Open();

    var transaction = connection.BeginTransaction();
    transactionManager.SetCurrentTransaction(transaction);

    return transaction;
});

builder.Services.AddScoped<IUsuarioQuery, UserQuery>();
builder.Services.AddScoped<GetUsersBySearchValidator>();
builder.Services.AddScoped<GetUserPaginationRequestValidator>();
builder.Services.AddScoped<CreateUserRequestValidator>();
builder.Services.AddScoped<UpdateUserRequestValidator>();
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

builder.Services.AddScoped<IUserRepository, UserRepositiry>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenericTransaction, GenericTransaction>();
builder.Services.AddScoped<TransactionManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureEndpoints();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
