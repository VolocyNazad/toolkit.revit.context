# Revit.Context

[![Revit 2021-2027](https://img.shields.io/badge/Revit-2021–2027-green.svg)](https://autodesk.com/revit)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![VolocyNazad](https://img.shields.io/badge/VolocyNazad-blue.svg)](https://github.com/VolocyNazad)

> Реализация паттерна Context Object для удобного доступа к объектам контекста Revit API.

Revit.Context — это набор сервисов доступа к контексту Revit API с поддержкой DI-контейнеризации.

## Возможности

- `IRevitContext` — интерфейс для доступа к объектам контекста Revit API: `UIControlledApplication`, `ControlledApplication`, `Application`, `UIApplication`, `ActiveUIDocument`, `ActiveDocument`.
- `IRevitContextInitializer` — интерфейс инициализации контекста на этапе запуска надстройки (`OnStartup`).
- `RevitContext` — единственная реализация обоих интерфейсов; отслеживает событие `ApplicationInitialized`, чтобы `Application` и производные от него свойства (`UIApplication`, `ActiveUIDocument`, `ActiveDocument`) стали доступны сразу после запуска Revit, а не только после открытия документа.
- Регистрация в DI одной строкой через `AddRevitContext()`.

## Установка

```
dotnet add package VolocyNazad.Revit.Context
```

## Использование

Регистрация сервисов в контейнере DI:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Revit.Context.DI;

services.AddRevitContext();
```

Инициализация в `IExternalApplication.OnStartup`:

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

Использование контекста в любом сервисе:

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

## Поддерживаемые версии Revit

Пакет собирается под версии Revit 2021–2027 (см. конфигурации в `Revit.Context.csproj`), таргетируя `net48` для версий до 2025 и `net8.0-windows` для 2025+.

## Требования

- .NET SDK 10.0.103+ (см. `global.json`)
- Revit API (пакет `Revit_All_Main_Versions_API_x64`)

## Лицензия

MIT, см. [LICENSE.md](LICENSE.md).
