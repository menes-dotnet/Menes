# Release notes for Menes v5.

## v5.0

Replaces `Tavis.UriTemplates` with `Corvus.UriTemplates`.

This version is source-level compatible with v4.x. It requires a new major version because some public types expose the `UriTemplate` type. In all cases, `Tavis.UriTemplates.UriTemplate` has been replaced with `Corvus.UriTemplates.TavisApi.UriTemplate` which is a binary breaking change.

This affects the following members:

* `IOpenApiDocumentProvider.GetUriTemplateForOperation`
* `OpenApiPathTemplate.UriTemplate`

There are no substantial changes to Menes itself in this version.