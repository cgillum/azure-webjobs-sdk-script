// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Script.Description
{
    /// <summary>
    /// Represents metadata for a Durable Task Framework orchestration client binding. 
    /// </summary>
    public class OrchestrationClientBindingMetadata : BindingMetadata
    {
        /// <summary>
        /// Gets or sets the name of the task hub associated with the orchestration client.
        /// </summary>
        public string TaskHub { get; set; }
    }
}
