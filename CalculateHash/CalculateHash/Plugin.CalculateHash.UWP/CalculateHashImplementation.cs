using Plugin.CalculateHash.Abstractions;
using System;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace Plugin.CalculateHash
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class CalculateHashImplementation : ICalculateHash
    {
        public string CalculateHash(string str, HashType type)
        {
            var data = Encoding.UTF8.GetBytes(str);

            switch (type)
            {
                case HashType.md5:
                    return CalclateMD5(data);
                case HashType.sha1:
                    return CalclateSha1(data);
                case HashType.sha256:
                    return CalclateSha256(data);
                case HashType.sha512:
                    return CalclateSha512(data);
                default:
                    return null;
            }
        }

        private string CalclateMD5(byte[] data)
        {
            // MD5のプロバイダーを作成
            var md5 = new MD5CryptoServiceProvider();
            // ハッシュ値を計算
            var hashedBytes = md5.ComputeHash(data);
            // リソース開放
            md5.Clear();
            // ハッシュ値をテキストに戻す
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha1(byte[] data)
        {
            // SHA1のプロバイダーを作成
            var sha1 = new SHA1CryptoServiceProvider();
            // ハッシュ値を計算
            var hashedBytes = sha1.ComputeHash(data);
            // リソース開放
            sha1.Clear();
            // ハッシュ値をテキストに戻す
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha256(byte[] data)
        {
            // SHA256のプロバイダーを作成
            var sha256 = new SHA256CryptoServiceProvider();
            // ハッシュ値を計算
            var hashedBytes = sha256.ComputeHash(data);
            // リソース開放
            sha256.Clear();
            // ハッシュ値をテキストに戻す
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha512(byte[] data)
        {
            // SHA512のプロバイダーを作成
            var sha512 = new SHA512CryptoServiceProvider();
            // ハッシュ値を計算
            var hashedBytes = sha512.ComputeHash(data);
            // リソース開放
            sha512.Clear();
            // ハッシュ値をテキストに戻す
            return GetTextFromHash(hashedBytes);
        }

        private string GetTextFromHash(byte[] bytes)
        {
            var result = new StringBuilder();
            foreach (byte b in bytes)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }
    }
}