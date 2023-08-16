// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System.Runtime.CompilerServices;
using CSUnsafe = System.Runtime.CompilerServices.Unsafe;

namespace Unity.Collections.LowLevel.Unsafe
{
    public static partial class UnsafeUtility
    {
        // Copies sizeof(T) bytes from ptr to output
        [MethodImpl(256)] // AggressiveInlining
        public static unsafe void CopyPtrToStructure<T>(void* ptr, out T output) where T : struct
        {
            if (ptr == null)
                throw new ArgumentNullException();
            InternalCopyPtrToStructure(ptr, out output);
        }

        static unsafe void InternalCopyPtrToStructure<T>(void* ptr, out T output) where T : struct
        {
            output = CSUnsafe.NullRef<T>();
            CSUnsafe.Copy(ref output, ptr);
        }

        // Copies sizeof(T) bytes from output to ptr
        [MethodImpl(256)] // AggressiveInlining
        public static unsafe void CopyStructureToPtr<T>(ref T input, void* ptr) where T : struct
        {
            if (ptr == null)
                throw new ArgumentNullException();
            InternalCopyStructureToPtr(ref input, ptr);
        }

        static unsafe void InternalCopyStructureToPtr<T>(ref T input, void* ptr) where T : struct
        {
            CSUnsafe.Copy(ptr, ref input);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ReadArrayElement<T>(void* source, int index)
        {
            return CSUnsafe.Read<T>(CSUnsafe.Add<T>(source, index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ReadArrayElementWithStride<T>(void* source, int index, int stride)
        {
            return ReadArrayElement<T>(source, index * stride);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteArrayElement<T>(void* destination, int index, T value)
        {
            CSUnsafe.Write(CSUnsafe.Add<T>(destination, index), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteArrayElementWithStride<T>(void* destination, int index, int stride, T value)
        {
            WriteArrayElement(destination, index * stride, value);
        }

        // The address of the memory where the struct resides in memory
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void* AddressOf<T>(ref T output) where T : struct
        {
            return CSUnsafe.AsPointer(ref output);
        }

        // The size of a struct
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>() where T : struct
        {
            return CSUnsafe.SizeOf<T>();
        }

        // Reinterprets reference as reference of different type.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T As<U, T>(ref U from)
        {
            return ref CSUnsafe.As<U, T>(ref from);
        }

        // The address of the memory where the struct resides in memory
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ref T AsRef<T>(void* ptr) where T : struct
        {
            return ref CSUnsafe.AsRef<T>(ptr);
        }

        // The address of the memory where the struct resides in memory
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ref T ArrayElementAsRef<T>(void* ptr, int index) where T : struct
        {
            return ref AsRef<T>(CSUnsafe.Add<T>(ptr, index));
        }
    }
}
