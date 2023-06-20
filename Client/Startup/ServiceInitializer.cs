using Blazored.LocalStorage;
using Client.Services;
using Common.Models;

namespace Client.Startup
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBlazoredLocalStorage();
            services.AddScoped<LotteryModel>();
            services.AddScoped<UserModel>();
            var baseUri = configuration["ApiBaseUri"];
            services.AddHttpClient<ILotteryService, LotteryService>(client =>
            {
                client.BaseAddress = new Uri(baseUri);
            });

            return services;
        }
    }
}
