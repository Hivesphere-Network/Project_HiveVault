using DataAccessLayer.NoSql;
using DataAccessLayer.Sql;
using HiveVault_API.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISqlQueryHandler, SqlQueryHandler>();
builder.Services.AddSingleton<INoSqlQueryHandler, NoSqlQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureGraphApi();
app.ConfigureApi();

app.UseHttpsRedirection();
app.UseAuthentication();

app.Run();
