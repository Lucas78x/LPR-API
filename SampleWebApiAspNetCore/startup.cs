
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleWebApiAspNetCore.Extensions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;

namespace SampleWebApiAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["Database:Connection"]));
            services.AddTransient<Mediator>();
            services.AddSingleton<ISender, ScopedSender<Mediator>>();
            services.AddMediatR(typeof(MediatorApplicationHandlerExtension).GetTypeInfo().Assembly);
            services.AddMemoryCache();
            services.AddControllers();
           
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Digital.Nexus.Adventure.Api",
                    Description = "Digital Nexus Adventure API",
                    Version = "v1"
                });

                c.DescribeAllParametersInCamelCase();
            })
            .AddRouting(options => options.LowercaseUrls = true);

 
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
        
        }

   
    }
}
