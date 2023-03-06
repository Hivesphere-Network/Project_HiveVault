using DataAccess.Contracts;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["serverID"] = Guid.NewGuid().ToString();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ISqlQueryHandler, SqlQueryHandler>();
builder.Services.AddSingleton<INoSqlQueryHandler, NoSqlQueryHandler>();
builder.Services.AddSingleton<IGraphQueryHandler, GraphQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();
