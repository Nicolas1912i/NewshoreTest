using Microsoft.EntityFrameworkCore;
using Newshore.TechnicalTest.Domain.Domain;
using Newshore.TechnicalTest.Domain.Interfaces;
using Newshore.TechnicalTest.Infrastructure;
using Newshore.TechnicalTest.Infrastructure.Interfaces;
using Newshore.TechnicalTest.Infrastructure.Repository;
using Serilog;
using Serilog.Events;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.Dev.json", optional: true);
builder.Configuration.AddEnvironmentVariables();

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
);

builder.Services.AddSingleton<IFlightCommandsRepository, FlightCommandsRepository>();
builder.Services.AddSingleton<IFlightQueriesRepository, FlightQueriesRepository>();
builder.Services.AddSingleton<IJourneyCommandsRepository, JourneyCommandsRepository>();
builder.Services.AddSingleton<IJourneyQueriesRepository, JourneyQueriesRepository>();
builder.Services.AddSingleton<IJourneyFlightCommandsRepository, JourneyFlightCommandsRepository>();
builder.Services.AddSingleton<ITransportCommandsRepository, TransportCommandsRepository>();
builder.Services.AddSingleton<ITransportQueriesRepository, TransportQueriesRepository>();
builder.Services.AddSingleton<IJourneyFlightCommandsRepository, JourneyFlightCommandsRepository>();
builder.Services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IJourneyManagerDomain, JourneyManagerDomain>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), AppDomain.CurrentDomain.Load("Newshore.TechnicalTest.Domain"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
