// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Unity.Collections.LowLevel.Unsafe
{
    public static partial class UnsafeUtility
    {
        // Since burst would fail to compile managed types anyway, we can default to unmanaged and
        // conditionally mark as managed in managed code paths
        // These flags must be kept in sync with kScriptingTypeXXX flags in Scripting.cpp
        const int kIsManaged = 0x01;
        const int kIsNativeContainer = 0x02;

        // Supports burst compatible invocation
        internal struct TypeFlagsCache<T>
        {
            internal static readonly int flags;
        }

        public static bool IsUnmanaged<T>()
        {
            return (TypeFlagsCache<T>.flags & kIsManaged) == 0;
        }

        public static bool IsNativeContainerType<T>()
        {
            return (TypeFlagsCache<T>.flags & kIsNativeContainer) != 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AlignOfHelper<T> where T : struct
        {
            public byte dummy;
            public T data;
        }

        // minimum alignment of a struct
        public static int AlignOf<T>() where T : struct
        {
            return SizeOf<AlignOfHelper<T>>() - SizeOf<T>();
        }
    }
}
