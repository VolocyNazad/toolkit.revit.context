using Revit.Context.Abstractions.Services;
using Revit.Context.Services;
using Xunit;

namespace Revit.Context.Tests;

public class RevitContextTests
{
    [Fact]
    public void RevitContext_ImplementsBothAbstractions()
    {
        var context = new RevitContext();

        Assert.IsAssignableFrom<IRevitContext>(context);
        Assert.IsAssignableFrom<IRevitContextInitializer>(context);
    }

    [Fact(Skip = "Требует установленного Revit: чтение Revit-типизированных свойств (UIControlledApplication и т.д.) " +
                 "заставляет CLR грузить RevitAPI/RevitAPIUI, а они не запускаются вне процесса/установки Revit.")]
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

    [Fact(Skip = "Требует установленного Revit: чтение Revit-типизированных свойств (UIApplication и т.д.) " +
                 "заставляет CLR грузить RevitAPI/RevitAPIUI, а они не запускаются вне процесса/установки Revit.")]
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
