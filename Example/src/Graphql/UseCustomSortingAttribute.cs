using Example.Abstractions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Graphql
{
    public class UseCustomSortingAttribute : ObjectFieldDescriptorAttribute
    {
        public UseCustomSortingAttribute([CallerLineNumber] int order = 0)
        { 

        }
        public override void OnConfigure(
                IDescriptorContext context,
                IObjectFieldDescriptor descriptor,
                MemberInfo member)
        {
            descriptor.UseSorting(typeof(User));
        }
    }
}
