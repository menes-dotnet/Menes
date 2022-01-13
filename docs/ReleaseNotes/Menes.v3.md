# Release notes for Menes v3.

## v3.1

### `OpenApiWebHostManager` now supports passing `IConfiguration` to functions

We did not previously support the `FunctionsHostBuilderContext` mechanism through which `Microsoft.Azure.Functions.Extensions` enables Azure Functions to retrieve the `IConfiguration` during DI initialization.

This is now supported through additional overloads of `OpenApiWebHostManager.StartInProcessFunctionsHostAsync` that accept an `IConfiguration` argument. The startup class for these overloads is required to implement `IWebJobsStartup2`. Any type deriving from `FunctionsStartup` will implement this. Functions using this mechanism are likely to have startup classes that derive from `FunctionsStartup`. (In any event, they will need to supply an implementation of `IWebJobsStartup2` to be able to get hold of the `IConfiguration` during initialization, so this test helper isn't imposing any requirements beyond what functions that want this will already need to do.)