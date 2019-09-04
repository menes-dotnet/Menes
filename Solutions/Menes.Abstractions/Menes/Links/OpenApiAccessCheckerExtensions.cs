// <copyright file="OpenApiAccessCheckerExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Menes.Hal;

    /// <summary>
    /// Link-related extension methods on <see cref="IOpenApiAccessChecker"/>.
    /// </summary>
    public static class OpenApiAccessCheckerExtensions
    {
        /// <summary>
        /// Searches through a <see cref="HalDocument"/> and removes any links that the current
        /// principal does not have access to.
        /// </summary>
        /// <typeparam name="TTenant">The type of the tenant.</typeparam>
        /// <param name="that">
        /// The <see cref="IOpenApiAccessChecker"/> that will be used to check the individual links.
        /// </param>
        /// <param name="target">
        /// The <see cref="HalDocument"/> to check.
        /// </param>
        /// <param name="context">
        /// The <see cref="IOpenApiContext"/> used to get information about the current principal.
        /// </param>
        /// <param name="options">
        /// The <see cref="HalDocumentLinkRemovalOptions"/> to apply when checking links.
        /// </param>
        /// <returns>A task that completes when all links have been checked.</returns>
        public static async Task RemoveForbiddenLinksAsync<TTenant>(this IOpenApiAccessChecker that, HalDocument target, IOpenApiContext context, HalDocumentLinkRemovalOptions options = default)
        {
            // First, we need to build a collection of all the links. For each one we need:
            // 1. The link itself.
            // 2. The HalDocument(s) to which it belongs - it is possible that we may encounter the same link twice and we need to be able to deal with that
            // 3. The link relation name.
            var linkMap = new Dictionary<OpenApiWebLink, List<HalDocument>>();

            AddHalDocumentLinksToMap(
                target,
                linkMap,
                !options.HasFlag(HalDocumentLinkRemovalOptions.NonRecursive),
                options.HasFlag(HalDocumentLinkRemovalOptions.Unsafe));

            // Build a second map of operation descriptors (needed to invoke the access policy check) to our OpenApiWebLinks.
            var operationDescriptorMap = linkMap
                .Keys
                .Select(link => (Descriptor: new AccessCheckOperationDescriptor(link.Href, link.OperationId, link.OperationType.ToString().ToLowerInvariant()), Link: link))
                .GroupBy(x => x.Descriptor)
                .ToDictionary(descriptor => descriptor.Key, descriptor => descriptor.Select(link => link.Link).ToArray());

            AccessCheckOperationDescriptor[] operationDescriptors = operationDescriptorMap.Keys.ToArray();

            // Perform the access policy check.
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> accessCheckResults = await that.CheckAccessPoliciesAsync(context, operationDescriptors).ConfigureAwait(false);

            // Now use the results of the access policy check to remove links/documents that don't belong because the access policy denies them.
            foreach (KeyValuePair<AccessCheckOperationDescriptor, AccessControlPolicyResult> accessCheckResult in accessCheckResults.Where(result => !result.Value.Allow))
            {
                foreach (OpenApiWebLink link in operationDescriptorMap[accessCheckResult.Key])
                {
                    foreach (HalDocument document in linkMap[link])
                    {
                        document.RemoveLink(link);

                        // Also remove from embedded resources if present.
                        document.RemoveEmbeddedResource(link);
                    }
                }
            }
        }

        private static void AddHalDocumentLinksToMap(HalDocument target, Dictionary<OpenApiWebLink, List<HalDocument>> linkMap, bool recursive, bool unsafeChecking)
        {
            foreach (OpenApiWebLink current in target.Links.OfType<OpenApiWebLink>())
            {
                if (unsafeChecking && ShouldSkipInUnsafeMode(current, target))
                {
                    continue;
                }

                if (!linkMap.TryGetValue(current, out List<HalDocument> documents))
                {
                    documents = new List<HalDocument>();
                    linkMap.Add(current, documents);
                }

                documents.Add(target);
            }

            if (recursive)
            {
                target.EmbeddedResources.ForEach(embeddedDocument => AddHalDocumentLinksToMap(embeddedDocument, linkMap, recursive, unsafeChecking));
            }
        }

        private static bool ShouldSkipInUnsafeMode(WebLink link, HalDocument target)
        {
            return (link.Rel == "self") || (target?.HasEmbeddedResourceForLink(link) ?? false);
        }
    }
}
