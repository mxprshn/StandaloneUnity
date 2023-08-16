// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License


using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Unity.Collections;

namespace Unity.Jobs.LowLevel.Unsafe
{
    public static class JobsUtility
    {
        /// <summary>
        /// The maximum number of job threads that can ever be created by the job system.
        /// </summary>
        /// <remarks>This maximum is the theoretical max the job system supports. In practice, the maximum number of job worker threads
        /// created by the job system will be lower as the job system will prevent creating more job worker threads than logical
        /// CPU cores on the target hardware. This value is useful for compile time constants, however when used for creating buffers
        /// it may be larger than required. For allocating a buffer that can be subdivided evenly between job worker threads, prefer
        /// the runtime constant returned by <seealso cref="JobsUtility.ThreadIndexCount"/>.
        /// </remarks>
        public const int MaxJobThreadCount = 128;
        public const int CacheLineSize = 64;
    }
}
