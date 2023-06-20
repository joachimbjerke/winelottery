using Api.Config;
using Api.DataContext;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Startup
{
    public static partial class ServiceInitializer
    {
        
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7071");
                        policy.WithOrigins("https://winelottery-blazor.azurewebsites.net");
                        policy.AllowAnyHeader().AllowAnyMethod();

                    });
            });

            services.RegisterCustomServices();

            var connectionString = configuration["ConnectionStrings:LotteryDbConnection"];
            DbMigration.MigrateDatabase(connectionString);
            services.RegisterDbContext(connectionString);



            return services;
        }

        private static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ILotteryService, LotteryService>();

            return services;
        }

        private static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LotteryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
