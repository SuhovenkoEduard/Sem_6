using BLL;
using ConsoleApp;
using DAL.Configs;
using Microsoft.Extensions.DependencyInjection;

var connectionString = Config.DbConfig();
var serviceCollection = new ServiceCollection();
serviceCollection.ConfigurationBllManagers(connectionString);
serviceCollection.AddSingleton(typeof(OutputModule));

var serviceProvider = serviceCollection.BuildServiceProvider();
var outputModule = serviceProvider.GetRequiredService<OutputModule>();
outputModule.Run();