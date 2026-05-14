using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

namespace Revit.Context.Abstractions.Services;

public interface IRevitContext
{
    UIControlledApplication? UIControlledApplication { get; }
    ControlledApplication? ControlledApplication { get; }
    Application? Application { get; }
    UIApplication? UIApplication { get; }
    UIDocument? ActiveUIDocument { get; }
    Document? ActiveDocument { get; }
}
