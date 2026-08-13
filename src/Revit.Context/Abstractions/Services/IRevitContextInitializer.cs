using Autodesk.Revit.UI;

namespace Revit.Context.Abstractions.Services;

/// <summary>
/// Initializes the Revit context. Should be called once, during add-in startup (<c>IExternalApplication.OnStartup</c>).
/// </summary>
public interface IRevitContextInitializer
{
    /// <summary>
    /// Initializes the context with the given <see cref="Autodesk.Revit.UI.UIControlledApplication"/> and subscribes
    /// to the events required to populate the remaining context properties.
    /// </summary>
    /// <param name="uIControlledApplication">The controlled application instance received in <c>OnStartup</c>.</param>
    void Initialize(UIControlledApplication uIControlledApplication);
}
