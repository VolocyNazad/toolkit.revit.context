using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

namespace Revit.Context.Abstractions.Services;

/// <summary>
/// Provides read access to Revit API context objects (application, UI application, active document, etc.).
/// </summary>
public interface IRevitContext
{
    /// <summary>
    /// Gets the <see cref="Autodesk.Revit.UI.UIControlledApplication"/> instance provided on add-in startup.
    /// </summary>
    UIControlledApplication? UIControlledApplication { get; }

    /// <summary>
    /// Gets the <see cref="Autodesk.Revit.ApplicationServices.ControlledApplication"/> associated with the current session.
    /// </summary>
    ControlledApplication? ControlledApplication { get; }

    /// <summary>
    /// Gets the Revit <see cref="Autodesk.Revit.ApplicationServices.Application"/> instance, available once Revit has finished initializing.
    /// </summary>
    Application? Application { get; }

    /// <summary>
    /// Gets the <see cref="Autodesk.Revit.UI.UIApplication"/> instance, available once Revit has finished initializing.
    /// </summary>
    UIApplication? UIApplication { get; }

    /// <summary>
    /// Gets the currently active <see cref="Autodesk.Revit.UI.UIDocument"/>, if any.
    /// </summary>
    UIDocument? ActiveUIDocument { get; }

    /// <summary>
    /// Gets the currently active <see cref="Autodesk.Revit.DB.Document"/>, if any.
    /// </summary>
    Document? ActiveDocument { get; }
}
