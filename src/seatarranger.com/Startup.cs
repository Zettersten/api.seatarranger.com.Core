using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using seatarranger.com.Core.Configurations;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Repositories;
using seatarranger.com.Core.Repositories.InMemoryRepository;
using seatarranger.com.Core.Services.ArrangerService;
using seatarranger.com.Core.Services.PartyService;
using seatarranger.com.Core.Services.TableService;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace seatarranger.com
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
            /*
             *  Repositories
             */
            services.AddSingleton<IRepository<string, PartyEntity>, PartyRepository>();
            services.AddSingleton<IRepository<char, TableEntity>, TableRepository>();

            /*
             *  Services
             */
            services.AddSingleton<IPartyService, PartyService>();
            services.AddSingleton<ITableService, TableService>();
            services.AddSingleton<IArrangerService, ArrangerService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services
                .AddCors(options =>
                {
                    options.AddPolicy("AllowAll", builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                        builder.AllowCredentials();
                    });
                })
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    var settings = JsonConfiguration.GetSerializerSettings();

                    foreach (var converter in settings.Converters)
                    {
                        options.SerializerSettings.Converters.Add(converter);
                    }

                    options.SerializerSettings.DateFormatHandling = settings.DateFormatHandling;
                    options.SerializerSettings.NullValueHandling = settings.NullValueHandling;
                    options.SerializerSettings.Formatting = settings.Formatting;

                    options.SerializerSettings.ContractResolver = settings.ContractResolver;
                });

            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Seat Arranger",
                    Description = "A code demonstration for ByteCubed",

                    License = new License
                    {
                        Name = "The Unlicense",
                        Url = "http://bytecubed.com/"
                    },
                    Contact = new Contact
                    {
                        Name = "Erik Zettersten",
                        Email = "erik@zettersten.com",
                        Url = "http://bytecubed.com/"
                    }
                });

                //Set the comments path for the swagger json and ui.
                var xmlPath = Path.Combine("wwwroot", "seatarranger.com.xml");

                c.IncludeXmlComments(xmlPath);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Seat Arranger");
                c.RoutePrefix = "api/swagger";

                c.InjectStylesheet("../../bytecubed.css");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}