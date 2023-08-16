namespace UnityEngine
{
    public class Object
    {
        public static implicit operator bool(Object exists)
        {
            return true;
        }
    }

    public struct LazyLoadReference<T> where T : Object
    {
    }

    public class ScriptableObject : Object
    {
    }
}
