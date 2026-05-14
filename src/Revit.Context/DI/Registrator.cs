using Microsoft.Extensions.DependencyInjection;
using Revit.Context.Abstractions.Services;
using Revit.Context.Services;

namespace Revit.Context.DI;

public static class Registrator
{
	extension(IServiceCollection services)
	{
        public IServiceCollection AddRevitContext() => services
            .AddSingleton<RevitContext>()
            .AddSingleton<IRevitContext>(i => i.GetRequiredService<RevitContext>())
            .AddSingleton<IRevitContextInitializer>(i => i.GetRequiredService<RevitContext>())
       ;
    }
}
