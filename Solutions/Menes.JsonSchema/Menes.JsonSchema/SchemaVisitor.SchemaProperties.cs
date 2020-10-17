// <copyright file="SchemaVisitor.SchemaProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
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
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.SchemaProperties"/>.</returns>
        protected virtual async ValueTask<(bool, Schema.SchemaProperties?)> VisitSchemaProperties(Schema.SchemaProperties? schemaPropertiesToUpdate)
        {
            if (!(schemaPropertiesToUpdate is Schema.SchemaProperties schemaProperties))
            {
                return (false, schemaPropertiesToUpdate);
            }

            bool wasUpdated = false;
            ImmutableArray<(string, Schema.SchemaOrReference)>.Builder builder = ImmutableArray.CreateBuilder<(string, Schema.SchemaOrReference)>();

            int index = 0;
            foreach (JsonPropertyReference<Schema.SchemaOrReference> property in schemaProperties.JsonAdditionalProperties)
            {
                this.PushPointerElement($"[{index}]");
                (bool updatedSchema, Schema.SchemaOrReference? schemaOrReference) = await this.VisitSchemaOrReference(property.AsValue()).ConfigureAwait(false);

                if (updatedSchema)
                {
                    wasUpdated = true;
                }

                if (!(schemaOrReference is Schema.SchemaOrReference sor))
                {
                    throw new JsonSchemaException("The SchemaOrReference cannot be null in a Schema.SchemaProperties. Override VisitSchemaProperties(Schema.SchemaProperties?) to manipulate the collection.");
                }

                builder.Add((property.Name, sor));

                this.PopPointerElement();
                ++index;
            }

            if (wasUpdated)
            {
                switch (builder.Count)
                {
                    case 1:
                        schemaProperties = new Schema.SchemaProperties(builder[0]);
                        break;
                    case 2:
                        schemaProperties = new Schema.SchemaProperties(builder[0], builder[1]);
                        break;
                    case 3:
                        schemaProperties = new Schema.SchemaProperties(builder[0], builder[1], builder[2]);
                        break;
                    case 4:
                        schemaProperties = new Schema.SchemaProperties(builder[0], builder[1], builder[2], builder[3]);
                        break;
                    default:
                        schemaProperties = new Schema.SchemaProperties(builder.ToArray());
                        break;
                }
            }

            return (wasUpdated, schemaProperties);
        }
    }
}
