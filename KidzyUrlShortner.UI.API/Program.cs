using KidzyUrlShortner.Application.Interfaces;
using KidzyUrlShortner.Application.Services;
using KidzyUrlShortner.DAL.Dapper.Interfaces;
using KidzyUrlShortner.DAL.Dapper.Repositories;
using KidzyUrlShortner.DAL.EfCore.Contexts;
using KidzyUrlShortner.DAL.EfCore.Interfaces;
using KidzyUrlShortner.DAL.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Init Web Application");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<UrlDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("KidzyUrlShortnerLocalDatabase")));
    builder.Services.AddScoped<IDapperUrlRepository>(x => new DapperUrlRepository(builder.Configuration.GetConnectionString("KidzyUrlShortnerLocalDatabase")));
    builder.Services.AddScoped<IEfUrlRepository, EfUrlRepository>();
    builder.Services.AddScoped<IUrlServices, UrlServices>();

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}