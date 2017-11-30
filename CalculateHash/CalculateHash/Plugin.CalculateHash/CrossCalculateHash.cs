using Plugin.CalculateHash.Abstractions;
using System;

namespace Plugin.CalculateHash
{
  /// <summary>
  /// Cross platform CalculateHash implemenations
  /// </summary>
  public class CrossCalculateHash
  {
    static Lazy<ICalculateHash> Implementation = new Lazy<ICalculateHash>(() => CreateCalculateHash(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ICalculateHash Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ICalculateHash CreateCalculateHash()
    {
#if PORTABLE
        return null;
#else
        return new CalculateHashImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
