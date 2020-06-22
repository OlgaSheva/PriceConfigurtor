using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerseusLibS.Workflow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Autofac;

using DaataAccessDependencyRegistrationModule = PriceConfigurator.DataAccess.DependencyRegistrationModule;
using ServicesDependencyRegistrationModule = PriceConfigurator.Services.DependencyRegistrationModule;

namespace PriceConfigurator.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DaataAccessDependencyRegistrationModule>();
            builder.RegisterModule<ServicesDependencyRegistrationModule>();
            builder.RegisterType<MainWindow>().AsSelf();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.Show();
            }
        }
    }
}
