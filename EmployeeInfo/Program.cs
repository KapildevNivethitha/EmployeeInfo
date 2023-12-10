using EmployeeInfo.Controllers;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AWS.Logger.AspNetCore;
using AWS.Logger.SeriLog;
using AWS.Logger;
using Serilog;
using EmployeeInfo.AWS_SecretManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Logging.AddAWSProvider();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(AWSSecretManager.createconnectionstring());
});
builder.Services.AddScoped<IEmployeeRepo , EmployeeRepo>();

builder.Services.AddCors();

AWSLoggerConfig configuration = new AWSLoggerConfig("SeriLog.DemoLogGroup");
configuration.Region = "us-east-1";

var logger = new LoggerConfiguration().WriteTo.AWSSeriLog(configuration)
.CreateLogger();

builder.Services.AddSingleton<Serilog.ILogger>(logger);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x=>x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin=>true).AllowCredentials());
app.UseAuthorization();

app.MapControllers();

app.Run();
