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
            // MD5�̃v���o�C�_�[���쐬
            var md5 = new MD5CryptoServiceProvider();
            // �n�b�V���l���v�Z
            var hashedBytes = md5.ComputeHash(data);
            // ���\�[�X�J��
            md5.Clear();
            // �n�b�V���l���e�L�X�g�ɖ߂�
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha1(byte[] data)
        {
            // SHA1�̃v���o�C�_�[���쐬
            var sha1 = new SHA1CryptoServiceProvider();
            // �n�b�V���l���v�Z
            var hashedBytes = sha1.ComputeHash(data);
            // ���\�[�X�J��
            sha1.Clear();
            // �n�b�V���l���e�L�X�g�ɖ߂�
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha256(byte[] data)
        {
            // SHA256�̃v���o�C�_�[���쐬
            var sha256 = new SHA256CryptoServiceProvider();
            // �n�b�V���l���v�Z
            var hashedBytes = sha256.ComputeHash(data);
            // ���\�[�X�J��
            sha256.Clear();
            // �n�b�V���l���e�L�X�g�ɖ߂�
            return GetTextFromHash(hashedBytes);
        }

        private string CalclateSha512(byte[] data)
        {
            // SHA512�̃v���o�C�_�[���쐬
            var sha512 = new SHA512CryptoServiceProvider();
            // �n�b�V���l���v�Z
            var hashedBytes = sha512.ComputeHash(data);
            // ���\�[�X�J��
            sha512.Clear();
            // �n�b�V���l���e�L�X�g�ɖ߂�
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