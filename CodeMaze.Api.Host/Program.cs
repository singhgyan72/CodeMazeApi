using CodeMaze.Api.Host.Extensions;
using CodeMaze.Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureValidationFilter();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
//builder.Services.ConfigureOutputCaching();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwagger();

//we are suppressing a default model state validation that is implemented due to
//the existence of the [ApiController] attribute in all API controllers.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//Enable the server to format the XML response when the client tries negotiating for it.
//We must tell a server to respect the Accept header.
//After that, we just add the AddXmlDataContractSerializerFormatters method to support XML formatters.
//We added the ReturnHttpNotAcceptable = true option, which tells the server that if the client tries
//to negotiate for the media type the server doesn’t support,
//it should return the 406 Not Acceptable status code.
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
}).AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(CodeMaze.Api.Controllers.AssemblyReference).Assembly);

var app = builder.Build();

//extract the ILoggerManager service after the var app = builder.Build() code line
//because the Build method builds the WebApplication and
//registers all the services added with IOC.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

//Below will add middleware for using HSTS, which adds the Strict-Transport-Security header.
if (app.Environment.IsProduction())
    app.UseHsts();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Configure the HTTP request pipeline.

//Below is used to add the middleware for the redirection from HTTP to HTTPS.
app.UseHttpsRedirection();

app.UseStaticFiles();

//Below will forward proxy headers to the current request. This will help us during application deployment.
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
app.UseCors("CorsPolicy");
app.UseResponseCaching();
//app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Maze API v1");
    s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code Maze API v2");
});

app.MapControllers();

app.Run();
