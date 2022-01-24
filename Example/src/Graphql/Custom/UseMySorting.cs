using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Graphql.Custom
{
    public class UseMySortingAttribute : ObjectFieldDescriptorAttribute
    {
        public UseMySortingAttribute([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        public override void OnConfigure(IDescriptorContext context
            , IObjectFieldDescriptor descriptor
            , MemberInfo member)
        {
            descriptor.UseSorting();
        }
    }
}
