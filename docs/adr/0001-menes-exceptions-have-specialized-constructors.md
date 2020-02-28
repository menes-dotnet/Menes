# Menes exceptions have specialized constructors

## Status

Accepted.


## Context

Switching on the C# 8.0 nullable references feature for Menes has revealed some ambiguities around whether certain properties of exceptions are meant to be nullable.

In many cases, the only reason for ambiguity is that we have followed a pattern of defining various "standard constructors", such as default constructors, exception-message-only constructors, and deserializing constructors.


## Decision

Menes exceptions will not have any of these standard exceptions except in cases where there are no required properties (e.g., the exception's type tells you everything you need to know).

Properties that always have non-null values in practice will declare this formally by having non-nullable types.

We will remove all deserializing constructors, and remove the `[Serializable]` attribute from all exceptions that have them. This has been motivated by the use of nullable references, because deserializing constructors cause some challenges there, but this is a distinct issue. Menes exceptions are all designed for use within a Menes-based service. Menes is designed to implement service boundaries, and by definition, if we ever attempt to throw a Menes-defined exception across a process boundary, we've made a mistake.


## Consequences

Properties on exceptions can accurately reflect whether they can be relied upon to be present by using non-nullable or nullable types. By removing unused "standard" constructors, we avoid having to work around warnings the compiler would generate complaining that non-nullable properties have not been initialized.