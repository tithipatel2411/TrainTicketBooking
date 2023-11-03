using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Model.MigrationSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectWebApi
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
            string ConnectionString = Configuration.GetSection("AppSetting:MigratorSetting:ConnectionString").Value;
            services.AddFluentMigratorCore()
              .ConfigureRunner(config =>
                  config.AddSqlServer()
                  .WithGlobalConnectionString(ConnectionString)
                  .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                  .AddLogging(config => config.AddFluentMigratorConsole());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            //MigrationSetting migrationSetting = new MigrationSetting();
            var migrationSetting = Configuration.GetSection("AppSetting:MigratorSetting").Get<MigrationSettings>();
            if (migrationSetting.Type == "Up")
            {
                migrator.MigrateUp();
            }
            else
            {
                migrator.MigrateDown(migrationSetting.VersionNo);
            }
        }
    }
}
