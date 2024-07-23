using CryptocurrencieApp.Models;
using CryptocurrencieApp.Services;
using CryptocurrencieApp.ViewModels;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;

using System.Configuration;
using System.Data;
using System.Text.Json;
using System.Windows;

namespace CryptocurrencieApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost Host { get; private set; }

        public App()
        {
            Host = new HostBuilder()
                        .ConfigureAppConfiguration((hostContext, builder) =>
                        {
                            builder
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                        })
                        .ConfigureServices(services =>
                        {
                            var jsonOptions = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true,
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
                            };

                            services.AddSingleton(jsonOptions);
                            services.AddSingleton<MainViewModel>();
                            services.AddSingleton<ICryptocurrencieService, CryptocurrencieService>();
                            services.AddOptions<CryptocurrencieOptions>()
                                    .BindConfiguration("CryptocurrencieOptions");

                            services.AddHttpClient<CryptocurrencieService>();

                            services.AddSingleton<Cryptocurrencie>();
                            services.AddTransient<DetailViewModel>();
                            services.AddSingleton<ConvertViewModel>();
                        })
                        .Build();
        }
    }

}
