using Revit.Context.Abstractions.Services;
using Revit.Context.Services;
using Xunit;

namespace Revit.Context.Tests;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Test names use underscores to separate scenario and expected result.")]
public class RevitContextTests
{
    [Fact]
    public void RevitContext_ImplementsBothAbstractions()
    {
        var context = new RevitContext();

        Assert.IsAssignableFrom<IRevitContext>(context);
        Assert.IsAssignableFrom<IRevitContextInitializer>(context);
    }

    [Fact(Skip = "Requires Revit to be installed: reading Revit-typed properties (UIControlledApplication, etc.) " +
                 "forces the CLR to load RevitAPI/RevitAPIUI, which will not run outside a Revit process/installation.")]
    public void NewInstance_HasNoContextUntilInitialized()
    {
        var context = new RevitContext();

        Assert.Null(context.UIControlledApplication);
        Assert.Null(context.ControlledApplication);
        Assert.Null(context.Application);
        Assert.Null(context.UIApplication);
        Assert.Null(context.ActiveUIDocument);
        Assert.Null(context.ActiveDocument);
    }

    [Fact(Skip = "Requires Revit to be installed: reading Revit-typed properties (UIApplication, etc.) " +
                 "forces the CLR to load RevitAPI/RevitAPIUI, which will not run outside a Revit process/installation.")]
    public void UIApplication_IsNull_WhenApplicationHasNotBeenInitializedYet()
    {
        var context = new RevitContext();

        Assert.Null(context.UIApplication);
        Assert.Null(context.ActiveUIDocument);
        Assert.Null(context.ActiveDocument);
    }

    [Fact(Skip = "Initialize() requires a real Autodesk.Revit.UI.UIControlledApplication, which Revit only " +
                 "constructs inside a running host process (no public constructor) — not unit-testable in isolation. " +
                 "Verify manually / via an in-Revit integration test.")]
    public void Initialize_SubscribesToApplicationInitialized()
    {
    }
}
