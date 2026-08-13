using Microsoft.Extensions.DependencyInjection;
using Revit.Context.Abstractions.Services;
using Revit.Context.Services;

namespace Revit.Context.DI;

/// <summary>
/// Provides dependency injection registration extensions for the Revit context services.
/// </summary>
public static class Registrator
{
	extension(IServiceCollection services)
	{
        /// <summary>
        /// Registers <see cref="RevitContext"/> as a singleton and exposes it as both
        /// <see cref="IRevitContext"/> and <see cref="IRevitContextInitializer"/>.
        /// </summary>
        /// <returns>The same <see cref="IServiceCollection"/> instance for chaining.</returns>
        public IServiceCollection AddRevitContext() => services
            .AddSingleton<RevitContext>()
            .AddSingleton<IRevitContext>(i => i.GetRequiredService<RevitContext>())
            .AddSingleton<IRevitContextInitializer>(i => i.GetRequiredService<RevitContext>())
       ;
    }
}
