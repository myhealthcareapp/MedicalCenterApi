
using Application.Services.Authentication;
using MedicalCenterApi.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Infrastructure.Services;

using Microsoft.AspNetCore.Mvc.Infrastructure;

using MedicalCenterApi;
using Application;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/doctorLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();
// Add services to the container.


builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<ApplicationDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});*/
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
    );
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseSerilogRequestLogging();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
