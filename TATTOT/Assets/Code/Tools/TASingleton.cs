using System;

/// See https://www.codeproject.com/Articles/572263/A-Reusable-Base-Class-for-the-Singleton-Pattern-in
public abstract class TASingleton<T>
    where T : class
{
    /// <summary>
    /// Static instance. Needs to use lambda expression
    /// to construct an instance (since constructor is private).
    /// </summary>
    private static readonly Lazy<T> sInstance = new Lazy<T>(() => CreateInstanceOfT());

    /// <summary>
    /// Gets the instance of this singleton.
    /// </summary>
    public static T Shared { get { return sInstance.Value; } }

    /// <summary>
    /// Creates an instance of T via reflection since T's constructor is expected to be private.
    /// </summary>
    /// <returns></returns>
    private static T CreateInstanceOfT()
    {
        return Activator.CreateInstance(typeof(T), true) as T;
    }
}
