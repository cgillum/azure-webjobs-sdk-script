// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Script.Description;

namespace Microsoft.Azure.WebJobs.Script.Binding
{
    public class OrchestrationActivityBinding : FunctionBinding, IResultProcessingBinding
    {
        public OrchestrationActivityBinding(ScriptHostConfiguration config, BindingMetadata metadata, FileAccess access)
            : base(config, metadata, access)
        {
        }

        public override Collection<CustomAttributeBuilder> GetCustomAttributes(Type parameterType)
        {
            return null;
        }

        public override Task BindAsync(BindingContext context)
        {
            return Task.CompletedTask;
        }

        public bool CanProcessResult(object result)
        {
            return result != null;
        }

        public void ProcessResult(
            IDictionary<string, object> functionArguments,
            object[] systemArguments,
            string triggerInputName,
            object result)
        {
            if (result == null)
            {
                return;
            }

            object argValue;
            if (functionArguments.TryGetValue(triggerInputName, out argValue))
            {
                ActivityInstanceContext context = argValue as ActivityInstanceContext;
                if (context != null)
                {
                    ((IActivityReturnValue)context).SetReturnValue(result);
                }
            }
        }
    }
}
