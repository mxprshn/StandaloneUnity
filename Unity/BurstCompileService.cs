// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System.Runtime.InteropServices;
using UnityEngine;

namespace Unity.Burst.LowLevel
{
    internal static partial class BurstCompilerService
    {
        public static unsafe void* GetOrCreateSharedMemory(ref Hash128 key, uint size_of, uint alignment)
        {
            return NativeMemory.AlignedAlloc(new nuint(size_of), new nuint(alignment));
        }
    }
}
