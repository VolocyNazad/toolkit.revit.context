using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Revit.Context.Abstractions.Services;

namespace Revit.Context.Services;

public sealed class RevitContext : IRevitContextInitializer, IRevitContext
{
    public void Initialize(UIControlledApplication uIControlledApplication)
    {
        UIControlledApplication = uIControlledApplication; 
        uIControlledApplication.ControlledApplication.ApplicationInitialized += ControlledApplication_ApplicationInitialized;
    }

    public UIControlledApplication? UIControlledApplication { get; private set; }
    public ControlledApplication? ControlledApplication => UIControlledApplication?.ControlledApplication;
    public UIApplication? UIApplication => Application is null ? null : new UIApplication(Application);
    public Application? Application { get; private set; }
    public UIDocument? ActiveUIDocument => UIApplication?.ActiveUIDocument;
    public Document? ActiveDocument => ActiveUIDocument?.Document;

    private void ControlledApplication_ApplicationInitialized(object? sender, ApplicationInitializedEventArgs args)
    {
        Application = (Application?)sender;
    }
}