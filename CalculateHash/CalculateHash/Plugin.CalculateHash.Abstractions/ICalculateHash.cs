using System;

namespace Plugin.CalculateHash.Abstractions
{
    /// <summary>
    /// Interface for CalculateHash
    /// </summary>
    public interface ICalculateHash
    {
        string CalculateHash(string str, HashType type);
    }

    public enum HashType
    {
        md5,
        sha1,
        sha256,
        sha512
    }
}
