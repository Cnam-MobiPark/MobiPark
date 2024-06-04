using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MobiPark.App.Helpers;
using MobiPark.App.Middlewares;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Services;
using MobiPark.Infra;
using MobiPark.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlite(connectionString); });

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IParkingService, ParkingService>();
builder.Services.AddTransient<IParkingRepository, ParkingRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IHash, ArgonHash>();
builder.Services.AddTransient<IClock, Clock>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthorizationMiddleware();
app.UseExceptionHandlerMiddleware();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();