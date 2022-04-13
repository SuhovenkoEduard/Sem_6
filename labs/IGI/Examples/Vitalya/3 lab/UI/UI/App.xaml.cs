using System;
using System.IO;
using System.Windows;
using Bll;
using Dal.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public  void OnStartup(object sender, StartupEventArgs e)
        {
            var connectionString = Config.DbConfig();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, connectionString);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services, string connectionString)
        {
          
            services.ConfigurationBllManagers(connectionString);

            services.AddSingleton(typeof(MainWindow));
        }

        
    }
}
