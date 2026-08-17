#region ensamblado RealPlaza.Observability, Version=1.1.7.0, Culture=neutral, PublicKeyToken=null
// C:\Users\USUARIO\.nuget\packages\realplaza.observability\1.1.7\lib\net8.0\RealPlaza.Observability.dll
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using System.Collections.Generic;

namespace RealPlaza.Observability.Instrumentation;

public interface IInstrumentation
{
    void Record(string metricName, long value = 1L);

    void Record(string metricName, string tagKey, object tagValue, long value = 1L);

    void Record(string metricName, long value = 1L, params KeyValuePair<string, object>[] tags);
}
#if false // Registro de descompilación
"376" elementos en caché
------------------
Resolver: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Runtime.dll"
------------------
Resolver: "Serilog, Version=4.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog, Version=4.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog\4.0.0\lib\net8.0\Serilog.dll"
------------------
Resolver: "System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Se encontró un solo ensamblado: "System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Diagnostics.DiagnosticSource.dll"
------------------
Resolver: "Microsoft.Extensions.Hosting.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Hosting.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Hosting.Abstractions.dll"
------------------
Resolver: "Microsoft.Extensions.Configuration.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Configuration.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Configuration.Abstractions.dll"
------------------
Resolver: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.DependencyInjection.Abstractions.dll"
------------------
Resolver: "Microsoft.Extensions.DependencyInjection, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.DependencyInjection, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.DependencyInjection.dll"
------------------
Resolver: "Microsoft.AspNetCore.Http.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Http.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.AspNetCore.Http.Abstractions.dll"
------------------
Resolver: "Microsoft.Extensions.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Primitives.dll"
------------------
Resolver: "OpenTelemetry.Instrumentation.AspNetCore, Version=1.9.0.42, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Instrumentation.AspNetCore, Version=1.9.0.42, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.instrumentation.aspnetcore\1.9.0\lib\net8.0\OpenTelemetry.Instrumentation.AspNetCore.dll"
------------------
Resolver: "Microsoft.Extensions.Logging.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Logging.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Logging.Abstractions.dll"
------------------
Resolver: "OpenTelemetry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry\1.9.0\lib\net8.0\OpenTelemetry.dll"
------------------
Resolver: "OpenTelemetry.Exporter.OpenTelemetryProtocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Exporter.OpenTelemetryProtocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.exporter.opentelemetryprotocol\1.9.0\lib\net8.0\OpenTelemetry.Exporter.OpenTelemetryProtocol.dll"
------------------
Resolver: "Serilog.Sinks.OpenTelemetry, Version=3.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Sinks.OpenTelemetry, Version=3.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.sinks.opentelemetry\3.0.0\lib\net8.0\Serilog.Sinks.OpenTelemetry.dll"
------------------
Resolver: "OpenTelemetry.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.api\1.9.0\lib\net8.0\OpenTelemetry.Api.dll"
------------------
Resolver: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Collections.dll"
------------------
Resolver: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Threading.dll"
------------------
Resolver: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Collections.Concurrent.dll"
------------------
Resolver: "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.ComponentModel.dll"
------------------
Resolver: "Microsoft.AspNetCore.Mvc.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Mvc.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.AspNetCore.Mvc.Abstractions.dll"
------------------
Resolver: "Serilog.Extensions.Hosting, Version=7.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Extensions.Hosting, Version=7.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.extensions.hosting\8.0.0\lib\net8.0\Serilog.Extensions.Hosting.dll"
------------------
Resolver: "Serilog.Extensions.Logging, Version=7.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Extensions.Logging, Version=7.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.extensions.logging\8.0.0\lib\net8.0\Serilog.Extensions.Logging.dll"
------------------
Resolver: "Microsoft.Extensions.Logging, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Logging, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Logging.dll"
------------------
Resolver: "Serilog.Settings.Configuration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Settings.Configuration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.settings.configuration\8.0.0\lib\net8.0\Serilog.Settings.Configuration.dll"
------------------
Resolver: "Serilog.Enrichers.Thread, Version=4.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Enrichers.Thread, Version=4.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.enrichers.thread\4.0.0\lib\net8.0\Serilog.Enrichers.Thread.dll"
------------------
Resolver: "Serilog.Enrichers.Environment, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null"
Se encontró un solo ensamblado: "Serilog.Enrichers.Environment, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.enrichers.environment\3.0.0\lib\net8.0\Serilog.Enrichers.Environment.dll"
------------------
Resolver: "Serilog.Sinks.Console, Version=5.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Se encontró un solo ensamblado: "Serilog.Sinks.Console, Version=5.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\serilog.sinks.console\5.0.0\lib\net7.0\Serilog.Sinks.Console.dll"
------------------
Resolver: "OpenTelemetry.Extensions.Hosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Extensions.Hosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.extensions.hosting\1.9.0\lib\net8.0\OpenTelemetry.Extensions.Hosting.dll"
------------------
Resolver: "Microsoft.AspNetCore.Http.Features, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Http.Features, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.AspNetCore.Http.Features.dll"
------------------
Resolver: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Linq.dll"
------------------
Resolver: "Microsoft.AspNetCore.Mvc.Core, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Mvc.Core, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.AspNetCore.Mvc.Core.dll"
------------------
Resolver: "Microsoft.AspNetCore.Routing.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Routing.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.AspNetCore.Routing.Abstractions.dll"
------------------
Resolver: "Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Se encontró un solo ensamblado: "Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\newtonsoft.json\13.0.3\lib\net6.0\Newtonsoft.Json.dll"
------------------
Resolver: "OpenTelemetry.Instrumentation.Http, Version=1.9.0.41, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Instrumentation.Http, Version=1.9.0.41, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.instrumentation.http\1.9.0\lib\net8.0\OpenTelemetry.Instrumentation.Http.dll"
------------------
Resolver: "OpenTelemetry.Instrumentation.Runtime, Version=1.8.1.5, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Instrumentation.Runtime, Version=1.8.1.5, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.instrumentation.runtime\1.8.1\lib\net6.0\OpenTelemetry.Instrumentation.Runtime.dll"
------------------
Resolver: "OpenTelemetry.Instrumentation.Process, Version=0.5.0.5, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Se encontró un solo ensamblado: "OpenTelemetry.Instrumentation.Process, Version=0.5.0.5, Culture=neutral, PublicKeyToken=7bd6737fe5b67e3c"
Cargar desde: "C:\Users\USUARIO\.nuget\packages\opentelemetry.instrumentation.process\0.5.0-beta.5\lib\netstandard2.0\OpenTelemetry.Instrumentation.Process.dll"
------------------
Resolver: "Microsoft.Extensions.Features, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Features, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\8.0.28\ref\net8.0\Microsoft.Extensions.Features.dll"
------------------
Resolver: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null"
Se encontró un solo ensamblado: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Runtime.InteropServices.dll"
------------------
Resolver: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null"
Se encontró un solo ensamblado: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.28\ref\net8.0\System.Runtime.CompilerServices.Unsafe.dll"
#endif
