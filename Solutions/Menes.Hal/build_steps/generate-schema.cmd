REM Requires https://www.nuget.org/packages/Corvus.Json.JsonSchema.TypeGeneratorTool
REM Install with
REM dotnet tool install --global Corvus.Json.JsonSchema.TypeGeneratorTool
generatejsonschematypes --rootNamespace Menes.Hal --rootPath "#/$defs/Resource" %1/Menes.Hal/Internal/resources.json