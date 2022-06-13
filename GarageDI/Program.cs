using ConsoleUI;
using GarageDI.Entities;
using GarageDI.Handler;
using GarageDI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using VehicleCollection;

namespace GarageDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<GarageManager>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = GetConfig();

            ISettings garageSettings = new Settings();
            configuration.Bind("Garage:Settings", garageSettings);

            services.Configure<Settings>(configuration.GetSection("Garage:Settings").Bind);
            services.AddSingleton(configuration);
            services.AddSingleton(garageSettings);
            services.AddTransient<GarageManager>();
            services.AddTransient<IGarage<IVehicle>, InMemoryGarage<IVehicle>>();
            services.AddTransient<IGarageHandler, GarageHandler>();
            services.AddTransient<IUI, ConsoleUI.ConsoleUI>();
            services.AddSingleton<IUtil, Util>();
        }

        private static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
