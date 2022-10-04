REM Requires https://www.nuget.org/packages/Corvus.Json.JsonSchema.TypeGeneratorTool
REM Install with
REM dotnet tool install --global Corvus.Json.JsonSchema.TypeGeneratorTool
REM This explicitly uses a specific draft of the OpenApi schema rather than the "latest" link from github, for build reproducibility
REM https://spec.openapis.org/oas/3.1/schema/2022-02-27
generatejsonschematypes --rootNamespace Menes.OpenApiSchema.V31 --outputPath %1\Menes.OpenApiSchema\V31 --outputRootTypeName Document https://spec.openapis.org/oas/3.1/schema/2022-02-27