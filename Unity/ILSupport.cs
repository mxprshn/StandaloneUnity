namespace Unity.Collections.Externs;
using CSUnsafe = System.Runtime.CompilerServices.Unsafe;

public class ILSupport
{
    public static unsafe void* AddressOf<T>(in T value) where T : unmanaged
    {
        throw new NotImplementedException(); //return CSUnsafe.AsPointer(in value);
    }

    public static ref T AsRef<T>(in T value) where T : unmanaged
    {
        return ref CSUnsafe.AsRef(value);
    }
}
