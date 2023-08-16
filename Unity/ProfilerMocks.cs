namespace Unity.Profiling;

internal class ProfilerMarker : IDisposable
{
    public ProfilerMarker(string s)
    {
    }

    public IDisposable Auto()
    {
        return this;
    }

    public void Dispose()
    {
    }

    public void End()
    {
    }

    public void Begin()
    {
    }
}
