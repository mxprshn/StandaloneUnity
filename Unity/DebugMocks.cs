namespace UnityEngine;

internal class Debug
{
    public static void Log(string s)
    {
    }

    public static void LogError(string s)
    {
    }

    public static void LogWarning(string s)
    {
    }

    public static void Assert(bool b, string s = "")
    {
        System.Diagnostics.Debug.Assert(b);
    }

    public static void LogErrorFormat(string s1, string s2, string? s3)
    {
    }

    public static void LogErrorFormat(string s1, object o1, object o2)
    {
    }

    public static void LogErrorFormat(string s1)
    {
    }

    public static void LogException(Exception exception)
    {
    }
}
