// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

// !MODIFIED
namespace UnityEngine
{
#pragma warning disable 414
    public struct Hash128
    {
        public Hash128(uint u32_0, uint u32_1, uint u32_2, uint u32_3)
        {
            u64_0 = ((ulong)u32_1) << 32 | u32_0;
            u64_1 = ((ulong)u32_3) << 32 | u32_2;
        }

        public Hash128(ulong u64_0, ulong u64_1)
        {
            this.u64_0 = u64_0;
            this.u64_1 = u64_1;
        }

        [VisibleToOtherModules("UnityEngine.GraphToolsFoundationModule")]
        internal ulong u64_0;

        [VisibleToOtherModules("UnityEngine.GraphToolsFoundationModule")]
        internal ulong u64_1;
    }
}
