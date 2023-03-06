using DataAccess.Contracts;
using DataAccess;
using HiveVaultService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["serverID"] = Guid.NewGuid().ToString();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGrpc();
builder.Services.AddSingleton<ISqlQueryHandler, SqlQueryHandler>();
builder.Services.AddSingleton<INoSqlQueryHandler, NoSqlQueryHandler>();
builder.Services.AddSingleton<IGraphQueryHandler, GraphQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGrpcService<HiveHandshakeService>();

app.Run();
