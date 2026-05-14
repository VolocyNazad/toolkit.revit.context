using Autodesk.Revit.UI;

namespace Revit.Context.Abstractions.Services;

public interface IRevitContextInitializer
{
    void Initialize(UIControlledApplication uIControlledApplication);
}

