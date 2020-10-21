// <copyright file="SchemaVisitor.SchemaProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Collections.Immutable;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit a schema node.
        /// </summary>
        /// <param name="schemaPropertiesToUpdate">The schemaProperties value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.SchemaProperties"/>.</returns>
        protected virtual async ValueTask<(bool, JsonSchema.SchemaProperties?)> VisitSchemaProperties(JsonSchema.SchemaProperties? schemaPropertiesToUpdate)
        {
            if (!(schemaPropertiesToUpdate is JsonSchema.SchemaProperties schemaProperties))
            {
                return (false, schemaPropertiesToUpdate);
            }

            bool wasUpdated = false;
            ImmutableArray<(string, JsonSchema.SchemaOrReference)>.Builder builder = ImmutableArray.CreateBuilder<(string, JsonSchema.SchemaOrReference)>();

            int index = 0;
            foreach (JsonPropertyReference<JsonSchema.SchemaOrReference> property in schemaProperties.JsonAdditionalProperties)
            {
                this.PushPointerElement($"{property.Name}");
                (bool updatedSchema, JsonSchema.SchemaOrReference? schemaOrReference) = await this.VisitSchemaOrReference(property.AsValue()).ConfigureAwait(false);

                if (updatedSchema)
                {
                    wasUpdated = true;
                }

                if (!(schemaOrReference is JsonSchema.SchemaOrReference sor))
                {
                    throw new JsonSchemaException("The SchemaOrReference cannot be null in a Schema.SchemaProperties. Override VisitSchemaProperties(Schema.SchemaProperties?) to manipulate the collection.");
                }

                builder.Add((property.Name, sor));

                this.PopPointerElement();
                ++index;
            }

            if (wasUpdated)
            {
                schemaProperties = builder.Count switch
                {
                    1 => new JsonSchema.SchemaProperties(builder[0]),
                    2 => new JsonSchema.SchemaProperties(builder[0], builder[1]),
                    3 => new JsonSchema.SchemaProperties(builder[0], builder[1], builder[2]),
                    4 => new JsonSchema.SchemaProperties(builder[0], builder[1], builder[2], builder[3]),
                    _ => new JsonSchema.SchemaProperties(builder.ToArray()),
                };
            }

            return (wasUpdated, schemaProperties);
        }
    }
}
