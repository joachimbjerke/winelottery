using Blazored.LocalStorage;
using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Common.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LotteryModel>();
builder.Services.AddScoped<UserModel>();
//builder.Services.AddSingleton<ILotteryService, LotteryService>();
var baseUri = builder.Configuration["ApiBaseUri"];
builder.Services.AddHttpClient<ILotteryService, LotteryService>(client =>
{
    client.BaseAddress = new Uri(baseUri);
});



await builder.Build().RunAsync();
