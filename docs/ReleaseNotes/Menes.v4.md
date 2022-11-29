# Release notes for Menes v4.

## v4.0

Targets .NET 6.0.

Major version change in dependencies:

* `Corvus.Extensions.Newtonsoft.Json` 2.0.6 to 3.0.0, which in turn means:
  * `Corvus.Json.Abstractions` 2.0.6 -> 3.0.0
  * `Newtonsoft.Json` from 11.0.2 -> 13.0.1
* `Corvus.ContentHandling` 2.0.13 -> 3.0.0

There are no substantial changes to Menes itself in this version. However, nullability of some public members has changed (largely because .NET 6.0 adds numerous new nullability annotations to the runtime class library, as does `Newtonsoft.Json` v13.0.1). So in addition to the requirement for .NET 6.0 on this version, upgrading will likely entail some changes due to new nullability warnings.