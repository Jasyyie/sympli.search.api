using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using Simply.Search.Api.Handlers;
using Simply.Search.Services;

namespace Simply.Search.Api
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
            services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Sympli Search API",
            Description = "Find out Search position in google search",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Jasmine Kaur",
                Email = "Jaskhundal@gmail.com",

            },
            License = new OpenApiLicense
            {
                //Name = "Use under LICX",
                //Url = new Uri("https://example.com/license"),
            }
        });
    });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:3000", "http://localhost:5001")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            services.AddMemoryCache();
            services.AddTransient<IGoogleService, GoogleService>();
            services.AddHttpClient();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(SearchHandler).Assembly);

            //services.AddTransient<IGoogleSearchMediatorService, GoogleSearchMediatorService>();
            //services.AddScoped<Simply.Search.Api.Models.IBillPayer, Simply.Search.Api.Models.BillPayer>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsApi");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();


        }
    }
}
