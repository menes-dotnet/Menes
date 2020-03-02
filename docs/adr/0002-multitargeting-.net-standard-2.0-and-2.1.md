# Multitargeting .NET Standard 2.0 and 2.1

## Status

Accepted.

## Context

Menes supports C# 8.0's nullable references feature. In most cases, libraries need to use some of the attributes from the `System.Diagnostics.CodeAnalysis` namespace that enable to you provide sufficient information for the compiler's null analysis to do a good job.

These attributes are not available in `netstandard2.0`. However, there is a standard workaround: define your own copies of these attributes and use those. We are using the `Nullable` NuGet package to do this for us. This works nicely, enabling applications targeting older runtimes still to enable nullable references.

The problem is that you don't want to use this workaround unless you have to. Newer versions of .NET Core and .NET Standard have these attributes, so it's just a waste of space to define your own.

## Decision

Menes will target both .NET Standard 2.0 and .NET Standard 2.1. The .NET Standard 2.0 version brings its own copies of the attributes, the .NET Standard 2.1 version relies on the ones built into the framework.

## Consequences

This enables most of the benefits of the nullable references feature to be enjoyed by applications that target older versions of .NET. (They just need to set the language version to C# 8.0 or later, and set `<Nullable>enabled</Nullable>` in their `.csproj` files.) Applications on the latest versions of .NET will not have to pay for the duplicated attributes that enable this because they can use the .NET Standard 2.1 version of the library, which just uses the built-in attributes.

The build of Menes itself benefits from multi-targeting, instead of just targeting .NET Standard 2.0. If we only built for .NET Standard 2.0 (which would work), we would never be building against a version of the .NET libraries that include the full nullable annotations. But because we also target .NET Standard 2.1, we will be built against a version of the libraries that are fully annotated. This may enable the compiler to detect null-related anomalies that would otherwise have been missed.

The downside of this decision is that multi-targeting adds friction. For example, all the tests run twice up on the build server, once for each target, but annoyingly, Visual Studio won't run both sets locally. So if there are scenarios in which a test fails on only one target you might not discover this until after pushing changes. Also, when you multi-target, Visual Studio starts showing two of various things. Everything shows up twice in search results, for example. Also, multi-targeting hits a completely different set of paths through the SDK build infrastructure, which can often cause things to break in unexpected ways. So for these reasons it's generally preferable not to multi-target if you can avoid it.