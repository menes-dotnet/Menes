# Allowing implicit object type

## Status

Accepted.

## Context

In real-world OpenAPI schema, we have discovered that people sometimes omit the `type: object` from their object definitions. We believe that this *is* valid Open API schema.

```yaml
Pet:
    required:
    - id
    - name
    properties:
    id:
        type: integer
        format: int64
    name:
        type: string
    tag:
        type: string
```

However, there are other scenarios where you are *not* expected to supply the `type` property. Specifically, the `anyOf`, `oneOf`, `allOf` cases.

```yaml
someEntity: 
  anyOf:
    - type: string
    - type: object
    - type: array
    - type: boolean
    - type: integer
    - type: number
```
## Decision

Menes will support these semantics. We have updated our schema validation to support this by translating the missing `type` element into the internal schema type `None`, rather than translating to `Object`.

## Consequences

There should be no impact on existing code.