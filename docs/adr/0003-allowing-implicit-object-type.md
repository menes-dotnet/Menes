# Allowing implicit object type

## Status

Proposed.

## Context

In real-world OpenAPI schema, we have discovered that people frequently omit the `type: object` from their object definitions. THIS IS NOT VALID Open API schema.

```
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

```
someEntity: 
  anyOf:
    - type: string
    - type: object
    - type: array
    - type: boolean
    - type: integer
    - type: number
```

We need to distinguish between these two scenarios.

## Decision

Menes will continue to support "implied object", despite it being an OpenAPI schema violation. We have updated our schema validation to support this.

## Consequences

We support all valid Open API schema, plus this common invalid case where the intention can be inferred. It is a true superset of valid schema.