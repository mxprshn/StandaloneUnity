// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Collections.LowLevel.Unsafe;
using static Unity.Collections.LowLevel.Unsafe.BurstLike;
using Unity.Burst;
using System.Diagnostics;

namespace Unity.Jobs
{
    public interface IJobParallelFor
    {
        void Execute(int index);
    }

    public static class IJobParallelForExtensions
    {
        internal struct ParallelForJobStruct<T> where T : struct, IJobParallelFor
        {
        }

        public static JobHandle Schedule<T>(this T jobData, int arrayLength, int innerloopBatchCount,
            JobHandle dependsOn) where T : struct, IJobParallelFor => dependsOn;
    }
}
