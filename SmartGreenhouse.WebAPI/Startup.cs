using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartGreenhouse.WebAPI.Data;
using SmartGreenhouse.WebAPI.Services;
using SmartGreenhouse.WebAPI.Services.Contracts;
using System;

namespace SmartGreenhouse.WebAPI
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
            // Environment Variables used by container
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "8881";
            var user = Configuration["DBUser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "Pa55w@rdIsN0tSeCReT";
            var database = Configuration["Database"] ?? "SmartGreenhouseDB";

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}"));

            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartGreenhouse.WebAPI", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Data services
            // move to: DataServicesCollectionExtension.cs <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< !!!!!!!!!!!!
            services.AddScoped<IPlantsDataService, PlantsDataService>();
            services.AddScoped<ISensorNodesDataService, SensorNodesDataService>();
            services.AddScoped<IConditionsReadingsDataService, ConditionsReadingsDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartGreenhouse.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Populate database (migrations, data seeding)
            AppDbPrep.Populate(app);
        }
    }
}
