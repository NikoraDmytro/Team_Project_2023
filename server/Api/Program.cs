using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")}" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                          $"User Id={Environment.GetEnvironmentVariable("USER_ID")};" +
                          $"Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                          "Encrypt=False";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
    {
        try 
        {
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            var count = pendingMigrations.Count();
            
            if (count != 0)
            {
                Console.WriteLine($"You have {count} pending migrations to apply.");
                Console.WriteLine("Applying pending migrations now");
                await context.Database.MigrateAsync();
            }

            var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
            var lastAppliedMigration = appliedMigrations.Last();

            Console.WriteLine($"You're on schema version: {lastAppliedMigration}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to apply pending migrations!");
            Console.WriteLine(ex);
        }
    }
}

// Configure the HTTP request pipeline.
/* if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();