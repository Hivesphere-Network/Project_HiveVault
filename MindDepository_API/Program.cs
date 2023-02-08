using DataAccessLayer.NoSql;
using DataAccessLayer.Sql;
using MindDepository_API.API;

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

app.Run();
