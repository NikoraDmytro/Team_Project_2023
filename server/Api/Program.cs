using Api.Extensions;

using BLL.Extensions;
using DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureBusinessLayerServices(builder.Configuration);
builder.Services.ConfigureDataAccessLayer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services
    .AddAuthentication();/*
    .AddGoogle("Google", googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? string.Empty;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? string.Empty;
    });*/

builder.Services.ConfigureIdentity();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseExceptionHandlingMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.MigrateDatabase();
app.Run();