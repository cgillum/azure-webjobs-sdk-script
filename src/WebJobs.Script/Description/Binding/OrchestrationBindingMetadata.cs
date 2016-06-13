// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Script.Description
{
    /// <summary>
    /// Represents metadata for a Durable Task Framework function binding. 
    /// </summary>
    public class OrchestrationBindingMetadata : BindingMetadata
    {
        /// <summary>
        /// Gets or sets the name of the task hub in which the orchestration runs.
        /// </summary>
        public string TaskHub { get; set; }

        /// <summary>
        /// Gets or sets the name of the orchestration.
        /// </summary>
        public string Orchestration { get; set; }

        /// <summary>
        /// Gets or sets the version of the orchestration.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the Azure Storage connection string name used for
        /// persisting execution history.
        /// </summary>
        public string StorageConnection { get; set; }

        /// <summary>
        /// Gets or sets the Service Bus connection string used for communicating
        /// with the task hub.
        /// </summary>
        public string ServiceBusConnection { get; set; }
    }
}
