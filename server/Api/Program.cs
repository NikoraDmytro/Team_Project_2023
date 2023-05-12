using Api.Extensions;

using BLL;
using BLL.Extensions;
using DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureBusinessLayerServices();
builder.Services.ConfigureDataAccessLayer();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseExceptionHandlingMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.MigrateDatabase();
app.Run();