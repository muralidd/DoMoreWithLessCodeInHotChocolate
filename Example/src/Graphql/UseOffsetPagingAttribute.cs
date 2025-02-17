﻿using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Graphql
{
    public class UseOffsetPagingAttribute : ObjectFieldDescriptorAttribute
    {
        public UseOffsetPagingAttribute([CallerLineNumber] int order = 0)
        {
            this.Order = order;
        }
        public override void OnConfigure(
                IDescriptorContext context,
                IObjectFieldDescriptor descriptor,
                MemberInfo member)
        {
            descriptor.UseOffsetPaging();
        }
    }
}
