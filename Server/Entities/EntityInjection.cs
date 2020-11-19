using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadFastAssessment.Server.Entities
{
    public static class EntityInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region SQLServer
            services.AddDbContext<TimeSheetContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
                    //b => b.MigrationsAssembly(typeof(TimeSheetContext).Assembly.FullName)));
            #endregion

            #region MySQL Server
            //Copied over incase need to migrate to MySql

            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            //string InAppSqlConnection = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb");
            //if (InAppSqlConnection != null)
            //{
            //    string dbhost = Regex.Match(InAppSqlConnection, @"Data Source=(.+?);").Groups[1].Value;
            //    string server = dbhost.Split(':')[0].ToString();
            //    string port = dbhost.Split(':')[1].ToString();
            //    string dbname = Regex.Match(InAppSqlConnection, @"Database=(.+?);").Groups[1].Value;
            //    string dbusername = Regex.Match(InAppSqlConnection, @"User Id=(.+?);").Groups[1].Value;
            //    string dbpassword = Regex.Match(InAppSqlConnection, @"Password=(.+?)$").Groups[1].Value;
            //    connectionString = $@"server={server};userid={dbusername};password={dbpassword};database={dbname};port={port};pooling = false; convert zero datetime=True;";
            //}

            //services.AddDbContext<TimeSheetContext>(options =>
            //    options.UseMySql(connectionString));
            #endregion

            //services.AddScoped(provider => provider.GetService<TimeSheetContext>());



            return services;
        }

        public static void RunStartupMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<TimeSheetContext>().Database.Migrate();
            }
        }
    }
}
