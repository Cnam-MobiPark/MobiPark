using Microsoft.EntityFrameworkCore;
using MobiPark.App;
using MobiPark.Domain.Services;
using MobiPark.Domain.Interfaces;
using MobiPark.Infra;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IParkingService, ParkingService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IParkingRepository, ParkingRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();