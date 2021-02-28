using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Sidekick.Domain.Platforms;
using Sidekick.Platform.Clipboard;
using Sidekick.Platform.Windows.Keyboards;
using Sidekick.Platform.Windows.Mouse;
using Sidekick.Platform.Windows.Processes;
using Sidekick.Platform.Windows.Screen;
using Sidekick.Platform.Windows.Scroll;

namespace Sidekick.Platform
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddSidekickPlatform(this IServiceCollection services)
        {
            services.AddTransient<IClipboardProvider, ClipboardProvider>();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddSingleton<IProcessProvider, ProcessProvider>();
                services.AddSingleton<IKeyboardProvider, KeyboardProvider>();
                services.AddSingleton<IScrollProvider, ScrollProvider>();
                services.AddSingleton<IMouseProvider, MouseProvider>();
                services.AddSingleton<IScreenProvider, ScreenProvider>();
            }

            return services;
        }
    }
}
