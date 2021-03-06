using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sidekick.Application;
using Sidekick.Infrastructure;
using Sidekick.Logging;
using Sidekick.Mapper;
using Sidekick.Mediator;
using Sidekick.Persistence;
using Sidekick.Platform;

namespace Sidekick.Presentation.Wpf
{
    public static class Startup
    {
        public static ServiceProvider InitializeServices(App application)
        {
            var services = new ServiceCollection()

                // Building blocks
                .AddSidekickLogging()
                .AddSidekickMapper(
                    Assembly.Load("Sidekick.Infrastructure"),
                    Assembly.Load("Sidekick.Persistence"))
                .AddSidekickMediator(
                    Assembly.Load("Sidekick.Application"),
                    Assembly.Load("Sidekick.Domain"),
                    Assembly.Load("Sidekick.Infrastructure"),
                    Assembly.Load("Sidekick.Persistence"),
                    Assembly.Load("Sidekick.Platform"),
                    Assembly.Load("Sidekick.Presentation"),
                    Assembly.Load("Sidekick"))

                // Layers
                .AddSidekickApplication()
                .AddSidekickInfrastructure()
                .AddSidekickPersistence()
                .AddSidekickPlatform()
                .AddSidekickPresentation()
                .AddSidekickPresentationWpf();

            services.AddSingleton(application);
            services.AddSingleton(application.Dispatcher);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.UseSidekickMapper();

            return serviceProvider;
        }
    }
}
