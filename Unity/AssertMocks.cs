namespace UnityEngine.Assertions;

internal class Assert
{
    public static void IsTrue(bool condition, string s = "")
    {
        System.Diagnostics.Debug.Assert(condition);
    }

    public static void IsNotNull(object obj, string msg = "")
    {
        System.Diagnostics.Debug.Assert(obj is not null);
    }

    public static void AreEqual(int v1, int v2)
    {
        System.Diagnostics.Debug.Assert(v1 == v2);
    }

    public static void IsFalse(bool condition, string s)
    {
        System.Diagnostics.Debug.Assert(!condition);
    }
}
