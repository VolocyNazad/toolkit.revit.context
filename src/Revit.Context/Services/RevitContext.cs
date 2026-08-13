using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Revit.Context.Abstractions.Services;

namespace Revit.Context.Services;

/// <summary>
/// Default implementation of <see cref="IRevitContext"/> and <see cref="IRevitContextInitializer"/>.
/// Subscribes to the <c>ApplicationInitialized</c> event so that <see cref="Application"/> and the properties
/// derived from it (<see cref="UIApplication"/>, <see cref="ActiveUIDocument"/>, <see cref="ActiveDocument"/>)
/// become available right after Revit finishes starting, not only after a document is opened.
/// </summary>
public sealed class RevitContext : IRevitContextInitializer, IRevitContext
{
    /// <inheritdoc />
    public void Initialize(UIControlledApplication uIControlledApplication)
    {
        UIControlledApplication = uIControlledApplication;
        uIControlledApplication.ControlledApplication.ApplicationInitialized += ControlledApplication_ApplicationInitialized;
    }

    /// <inheritdoc />
    public UIControlledApplication? UIControlledApplication { get; private set; }

    /// <inheritdoc />
    public ControlledApplication? ControlledApplication => UIControlledApplication?.ControlledApplication;

    /// <inheritdoc />
    public UIApplication? UIApplication => Application is null ? null : new UIApplication(Application);

    /// <inheritdoc />
    public Application? Application { get; private set; }

    /// <inheritdoc />
    public UIDocument? ActiveUIDocument => UIApplication?.ActiveUIDocument;

    /// <inheritdoc />
    public Document? ActiveDocument => ActiveUIDocument?.Document;

    /// <summary>
    /// Handles the <c>ApplicationInitialized</c> event and captures the <see cref="Application"/> instance.
    /// </summary>
    private void ControlledApplication_ApplicationInitialized(object? sender, ApplicationInitializedEventArgs args)
    {
        Application = (Application?)sender;
    }
}
