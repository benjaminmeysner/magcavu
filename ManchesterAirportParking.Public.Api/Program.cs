using ManchesterAirportParking.Repository.Domain;
using ManchesterAirportParking.Repository.Services;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Serialization.JsonNet;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddControllers()
       .AddNewtonsoftJson(x => x.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
