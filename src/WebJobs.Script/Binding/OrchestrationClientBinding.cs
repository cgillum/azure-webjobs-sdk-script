// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.DurableTasks;
using Microsoft.Azure.WebJobs.Script.Description;

namespace Microsoft.Azure.WebJobs.Script.Binding
{
    internal class OrchestrationClientBinding : FunctionBinding
    {
        private readonly OrchestrationClientBindingMetadata metadata;

        public OrchestrationClientBinding(ScriptHostConfiguration config, OrchestrationClientBindingMetadata metadata, FileAccess access)
            : base(config, metadata, access)
        {
            this.metadata = metadata;
        }

        public override Collection<CustomAttributeBuilder> GetCustomAttributes(Type parameterType)
        {
            var attributes = new Collection<CustomAttributeBuilder>();

            var constructorTypes = new Type[] { typeof(string) };
            var constructorArguments = new object[] { this.metadata.TaskHub };

            attributes.Add(
                new CustomAttributeBuilder(
                    typeof(OrchestrationClientAttribute).GetConstructor(constructorTypes),
                    constructorArguments));

            if (!string.IsNullOrEmpty(this.Metadata.Connection))
            {
                AddStorageAccountAttribute(attributes, this.Metadata.Connection);
            }

            return attributes;
        }

        public override Task BindAsync(BindingContext context)
        {
            return Task.CompletedTask;
        }
    }
}
