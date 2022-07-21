global using FastEndpoints;
global using FluentValidation;
using Colossus.Infrastructure.Api.Config.Middleware;
using Colossus.Infrastructure.Data;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(); //add this
builder.Services.AddDbContext<IDbContext, ColossusContext>(
       options => options.UseSqlite("Data Source=Database.db"));
builder.Services.AddScoped(typeof(Colossus.Domain.Gateway.IRepository<>), typeof(Colossus.Infrastructure.Data.Repository.Repository<>));
builder.Services.AddScoped(typeof(Colossus.Domain.Service.IService<>), typeof(Colossus.Domain.Service.Service<>));

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse(failures.Select(y => y.ErrorMessage).ToList());
        
    };
});

//app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<IDbContext>();
    await DatabaseInitializer.InitializeAsync(db);
}

app.Run();


public readonly record struct ValidationFailureResponse(List<string> Errors);