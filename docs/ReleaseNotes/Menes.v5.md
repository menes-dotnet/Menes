# Release notes for Menes v5.

## v5.0

Replaces `Tavis.UriTemplates` with `Corvus.UriTemplates`.

This version is source-level compatible with v4.x. It requires a new major version because some public types expose the `UriTemplate` type. In all cases, `Tavis.UriTemplates.UriTemplate` has been replaced with `Corvus.UriTemplates.TavisApi.UriTemplate` which is a binary breaking change.

This affects the following members:

* `IOpenApiDocumentProvider.GetUriTemplateForOperation`
* `OpenApiPathTemplate.UriTemplate`

There are no substantial changes to Menes itself in this version.

## v5.0.1

* Ensure string values in headers are not quoted.

## v5.0.2

* Further changes to `StringConverter` to ensure special characters are properly escaped.

## v5.0.3

* Bump `Corvus.Testing.SpecFlow.NUnit` from `2.0.0` to `2.0.1`. 