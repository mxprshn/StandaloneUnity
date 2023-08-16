// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System.Globalization;
using System.Runtime.InteropServices;
using CSUnsafe = System.Runtime.CompilerServices.Unsafe;

namespace Unity.Collections.LowLevel.Unsafe
{
    public static partial class UnsafeUtility
    {
        [ThreadSafe(ThrowsException = true)]
        public static unsafe void* MallocTracked(long size, int alignment, Allocator allocator,
            int callstacksToSkip)
        {
            return NativeMemory.AlignedAlloc(new nuint((ulong)size), new nuint((uint)alignment));
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void FreeTracked(void* memory, Allocator allocator)
        {
            NativeMemory.Free(memory);
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void MemCpy(void* destination, void* source, long size)
        {
            Buffer.MemoryCopy(source, destination, size, size);
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void MemCpyReplicate(void* destination, void* source, int size, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Buffer.MemoryCopy(source, destination, size, size);
                destination = nint.Add(new nint(destination), size).ToPointer();
            }
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void MemCpyStride(void* destination, int destinationStride, void* source,
            int sourceStride, int elementSize, int count)
        {
            for (var i = 0; i != count; i++)
            {
                MemCpy(destination, source, elementSize);
                destination = nint.Add(new nint(destination), destinationStride).ToPointer();
                source = nint.Add(new nint(source), sourceStride).ToPointer();
            }
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void MemMove(void* destination, void* source, long size)
        {
            MemCpy(destination, source, size);
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe void MemSet(void* destination, byte value, long size)
        {
            var nPtr = new nint(destination);

            for (var i = 0; i < size; i++)
            {
                Marshal.WriteByte(nPtr, value);
                nPtr++;
            }
        }

        public static unsafe void MemClear(void* destination, long size)
        {
            MemSet(destination, 0, size);
        }

        [ThreadSafe(ThrowsException = true)]
        public static unsafe int MemCmp(void* ptr1, void* ptr2, long size)
        {
            var nPtr1 = new nint(ptr1);
            var nPtr2 = new nint(ptr2);

            for (var i = 0; i < size; i++)
            {
                var one = Marshal.ReadByte(nPtr1, i);
                var another = Marshal.ReadByte(nPtr2, i);
                if (one != another)
                {
                    return one.CompareTo(another);
                }
            }

            return 0;
        }
    }
}
