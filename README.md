# Revit.Context

[![Revit 2021-2027](https://img.shields.io/badge/Revit-2021%20--%202027-green.svg)](https://autodesk.com/revit)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![VolocyNazad](https://img.shields.io/badge/VolocyNazad-blue.svg)](https://github.com/VolocyNazad)

> An implementation of the Context Object pattern for convenient access to Revit API context objects.

Revit.Context is a set of services for accessing the Revit API context with support for DI containerization.

## Features

- `IRevitContext` — an interface for accessing Revit API context objects: `UIControlledApplication`, `ControlledApplication`, `Application`, `UIApplication`, `ActiveUIDocument`, `ActiveDocument`.
- `IRevitContextInitializer` — an interface for initializing the context during add-in startup (`OnStartup`).
- `RevitContext` — the single implementation of both interfaces; it tracks the `ApplicationInitialized` event so that `Application` and its derived properties (`UIApplication`, `ActiveUIDocument`, `ActiveDocument`) become available right after Revit starts, not only after a document is opened.
- One-line DI registration via `AddRevitContext()`.

## Installation

```
dotnet add package VolocyNazad.Revit.Context
```

## Usage

Registering services in the DI container:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Revit.Context.DI;

services.AddRevitContext();
```

Initialization in `IExternalApplication.OnStartup`:

```csharp
using Autodesk.Revit.UI;
using Revit.Context.Abstractions.Services;

public Result OnStartup(UIControlledApplication application)
{
    var initializer = serviceProvider.GetRequiredService<IRevitContextInitializer>();
    initializer.Initialize(application);

    return Result.Succeeded;
}
```

Using the context in any service:

```csharp
using Revit.Context.Abstractions.Services;

public sealed class MyService(IRevitContext context)
{
    public void DoSomething()
    {
        var doc = context.ActiveDocument;
        var uiApp = context.UIApplication;
        // ...
    }
}
```

## Supported Revit versions

The package is built and tested for Revit 2021.1.9, 2022.1.0, 2023.0.0, 2024.2.0, 2025.0.0, 2026.4.10, and 2027.2.0. Revit 2021-2024 target net48; Revit 2025-2026 target net8.0-windows; Revit 2027 targets net10.0-windows.

## Requirements

- .NET SDK 10.0.103+ (see `global.json`)
- Revit API (packages `Nice3point.Revit.Api.RevitAPI` / `Nice3point.Revit.Api.RevitAPIUI`, floating `$(MajorRevitVersion).*`)

## License

MIT, see [LICENSE.md](LICENSE.md).

## Development documentation

- [Development policy](docs/policies/development.md)
- [Repository guide and technology stack](docs/repository.md)

## Contributing

Read [CONTRIBUTING.md](CONTRIBUTING.md) before submitting changes.
