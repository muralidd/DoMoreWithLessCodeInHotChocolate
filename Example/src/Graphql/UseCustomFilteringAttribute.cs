﻿using Example.Abstractions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Graphql
{
    public class UseCustomFilteringAttribute : ObjectFieldDescriptorAttribute
    {
        public UseCustomFilteringAttribute([CallerLineNumber] int order = 0)
        {
            this.Order = order;
        }
        public override void OnConfigure(
                IDescriptorContext context,
                IObjectFieldDescriptor descriptor,
                MemberInfo member)
        {
            var methodInfo = member as MethodInfo;
            if(methodInfo != null){
                var type = methodInfo.ReturnType.GenericTypeArguments[0];
                descriptor.UseFiltering(type);                
            }

            descriptor
            .Extend()
            .OnBeforeCreate(
                (c, definition) => {
                    ArgumentDefinition foundArg = null;
                    foreach (var arg in definition.Arguments)
                    {
                        if (arg.Name.Value == "where")
                        {
                            foundArg = arg;
                            break;
                        }
                    }
                    if (foundArg != null)
                    {
                        definition.Arguments.Remove(foundArg);
                    }
                });
        }
    }

    
}
