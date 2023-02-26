using System.Text.RegularExpressions;
using DataAccess.Graph;
using DataAccess.NoSql;
using DataAccess.Sql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISqlQueryHandler, SqlQueryHandler>();
builder.Services.AddSingleton<INoSqlQueryHandler, NoSqlQueryHandler>();
builder.Services.AddSingleton<IGraphQueryHandler, GraphQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.Run();
