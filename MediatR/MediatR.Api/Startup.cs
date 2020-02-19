using FluentValidation;
using MediatR.Api.Extensions;
using MediatR.Logic;
using MediatR.Logic.PipelineBehaviors;
using MediatR.Logic.Repositories;
using MediatR.Logic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MediatR.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // register mediatr handlers
            var logicAssembly = Assembly.Load("MediatR.Logic");
            services.AddMediatR(logicAssembly);

            //register mediatr service
            services.AddTransient<INotifierMediatorService, NotifierMediatorService>();
            services.AddTransient<ICommandBusMediatorService, CommandBusMediatorService>();
            services.AddTransient<IQueryBusMediatorService, QueryBusMediatorService>();

            //register repositories
            services.AddScoped<IStudentRegistrationRepository, StudentRegistrationRepository>();

            // register validation pipeline for every request:<,> and every response:<,> 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //register validators
            services.AddValidatorsFromAssembly(logicAssembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // use a custom exception handler for api
            app.UseFluentValidationExceptonHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
