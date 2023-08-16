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
    internal static class JobValidationInternal
    {
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void CheckReflectionDataCorrect<T>(IntPtr reflectionData)
        {
            bool burstCompiled = true;
            CheckReflectionDataCorrectInternal<T>(reflectionData, ref burstCompiled);
            if (burstCompiled && reflectionData == IntPtr.Zero)
                throw new InvalidOperationException("Reflection data was not set up by an Initialize() call. Support for burst compiled calls to Schedule depends on the Collections package.\n\nFor generic job types, please include [assembly: RegisterGenericJobType(typeof(MyJob<MyJobSpecialization>))] in your source file.");
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        static void CheckReflectionDataCorrectInternal<T>(IntPtr reflectionData, ref bool burstCompiled)
        {
            if (reflectionData == IntPtr.Zero)
                throw new InvalidOperationException($"Reflection data was not set up by an Initialize() call. Support for burst compiled calls to Schedule depends on the Collections package.\n\nFor generic job types, please include [assembly: RegisterGenericJobType(typeof({typeof(T)}))] in your source file.");
            burstCompiled = false;
        }
    }

    public interface IJob
    {
        void Execute();
    }

    public static class IJobExtensions
    {
        public static JobHandle Schedule<T>(this T jobData, JobHandle dependsOn)
            where T : struct, IJob => dependsOn;
    }
}
