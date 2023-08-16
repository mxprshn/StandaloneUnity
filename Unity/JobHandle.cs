// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Jobs
{
    public struct JobHandle : IEquatable<JobHandle>
    {
        internal ulong jobGroup;
        internal int   version; // maps to isManual internally. Remove in 2023

        internal int    debugVersion;

        public bool Equals(JobHandle other)
        {
            return jobGroup == other.jobGroup;
        }

        public override bool Equals(Object obj)
        {
            return obj is JobHandle && this == (JobHandle)obj;
        }

        public static bool operator ==(JobHandle a, JobHandle b)
        {
            return a.jobGroup == b.jobGroup;
        }

        public static bool operator !=(JobHandle a, JobHandle b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return jobGroup.GetHashCode();
        }
    }
}
