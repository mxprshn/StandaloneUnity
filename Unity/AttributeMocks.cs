namespace UnityEngine
{
    internal class HideInInspectorAttribute : Attribute
    {
    }

    public class RequiredMemberAttribute : Attribute
    {
    }

    public class RequireAttributeUsagesAttribute : Attribute
    {
    }

    internal class PreserveAttribute : Attribute
    {
    }

    internal class PublicAPIAttribute : Attribute
    {
    }

    internal class MovedFromAttribute : Attribute
    {
        public MovedFromAttribute(bool b, string v1, string v2)
        {
        }

        public MovedFromAttribute(string v1)
        {
        }
    }

    internal class FormerlySerializedAsAttribute : Attribute
    {
        public FormerlySerializedAsAttribute(string value)
        {
        }
    }

    public class NativeTypeAttribute : Attribute
    {
        public NativeTypeAttribute(string value)
        {
        }
    }

    public class NativeHeaderAttribute : Attribute
    {
        public NativeHeaderAttribute(string value)
        {
        }
    }

    public class NativeClassAttribute : Attribute
    {
        public NativeClassAttribute(string value1 = "", string value2 = "")
        {
        }
    }

    public class RequiredByNativeCodeAttribute : Attribute
    {
        public RequiredByNativeCodeAttribute(bool optional = false)
        {
            Optional = optional;
        }

        public bool Optional { get; set; }
        public bool GenerateProxy { get; set; }
    }

    public class VisibleToOtherModulesAttribute : Attribute
    {
        public VisibleToOtherModulesAttribute(string value)
        {
        }

        public VisibleToOtherModulesAttribute()
        {
        }
    }

    public class UsedByNativeCodeAttribute : Attribute
    {
    }

    internal class IgnoreAttribute : Attribute
    {
        public bool DoesNotContributeToSize { get; set; }
    }

    internal class NativeNameAttribute : Attribute
    {
        public NativeNameAttribute(string mData)
        {
            throw new NotImplementedException();
        }
    }
}

namespace UnityEngine.Internal
{
    public class ExcludeFromDocsAttribute : Attribute
    {
    }

    public class DefaultValueAttribute : Attribute
    {
        public DefaultValueAttribute(string value)
        {
        }
    }
}

namespace Unity.Collections.LowLevel.Unsafe
{
    internal class ThreadSafeAttribute : Attribute
    {
        public bool ThrowsException { get; set; }
    }
}

namespace Unity.Collections
{
    internal class NativeDisableUnsafePtrRestrictionAttribute : Attribute
    {
    }

    internal class NativeContainerAttribute : Attribute
    {
    }

    public class NativeContainerIsReadOnlyAttribute : Attribute
    {
    }

    public class NativeContainerIsAtomicWriteOnlyAttribute : Attribute
    {
    }

    internal class BurstCompileAttribute : Attribute
    {
    }

    public class ExcludeFromDocsAttribute : Attribute
    {
    }

    public class WriteAccessRequiredAttribute : Attribute
    {
    }

    internal class ThreadSafeAttribute : Attribute
    {
        public bool ThrowsException { get; set; }
    }

    public class BurstAuthorizedExternalMethodAttribute : Attribute
    {
    }

    internal class VisibleToOtherModulesAttribute : Attribute
    {
        public VisibleToOtherModulesAttribute(string module = "")
        {
        }
    }

    public class CreatePropertyAttribute : Attribute
    {
    }
}

namespace Unity.Jobs
{
    public class FreeFunctionAttribute : Attribute
    {
        public FreeFunctionAttribute(string val = "")
        {
        }

        public bool IsThreadSafe { get; set; }
        public bool ThrowsException { get; set; }
    }

    public class NativeMethodAttribute : Attribute
    {
        public bool IsFreeFunction { get; set; }
        public bool IsThreadSafe { get; set; }
    }
}
