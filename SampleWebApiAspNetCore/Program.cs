using DigitalWorldOnline.Commons.Interfaces;
using DigitalWorldOnline.Infrastructure;
using DigitalWorldOnline.Infrastructure.Repositories.Account;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using SampleWebApiAspNetCore;
using SampleWebApiAspNetCore.Extensions;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.MappingProfiles;
using SampleWebApiAspNetCore.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomCors("AllowAllOrigins");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=localhost;Database=LPR;User Id=sa;Password=servidor!@1122;TrustServerCertificate=True"));
builder.Services.AddScoped<AccountQueriesRepository>();
builder.Services.AddTransient<Mediator>();
builder.Services.AddSingleton<ISender, ScopedSender<Mediator>>();
builder.Services.AddMediatR(typeof(MediatorApplicationHandlerExtension).GetTypeInfo().Assembly);
builder.Services.AddScoped<IAccountQueriesRepository, AccountQueriesRepository>();

builder.Services.AddScoped(typeof(ILinkService<>), typeof(LinkService<>));
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddVersioning();

builder.Services.AddAutoMapper(typeof(AccountProfile));

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });

    app.SeedData();
}
else
{
    app.AddProductionExceptionHandling(loggerFactory);
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
