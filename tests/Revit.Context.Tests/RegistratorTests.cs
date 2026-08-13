using Microsoft.Extensions.DependencyInjection;
using Revit.Context.Abstractions.Services;
using Revit.Context.DI;
using Revit.Context.Services;
using Xunit;

namespace Revit.Context.Tests;

public class RegistratorTests
{
    [Fact]
    public void AddRevitContext_RegistersRevitContextAsSingleton()
    {
        var services = new ServiceCollection();
        services.AddRevitContext();

        using var provider = services.BuildServiceProvider();

        var first = provider.GetRequiredService<RevitContext>();
        var second = provider.GetRequiredService<RevitContext>();

        Assert.Same(first, second);
    }

    [Fact]
    public void AddRevitContext_ResolvesSameInstanceForContextAndInitializer()
    {
        var services = new ServiceCollection();
        services.AddRevitContext();

        using var provider = services.BuildServiceProvider();

        var concrete = provider.GetRequiredService<RevitContext>();
        var context = provider.GetRequiredService<IRevitContext>();
        var initializer = provider.GetRequiredService<IRevitContextInitializer>();

        Assert.Same(concrete, context);
        Assert.Same(concrete, initializer);
    }

    [Fact]
    public void AddRevitContext_ReturnsSameServiceCollection_ForChaining()
    {
        var services = new ServiceCollection();

        var result = services.AddRevitContext();

        Assert.Same(services, result);
    }
}
