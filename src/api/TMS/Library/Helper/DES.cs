using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Helper
{
    public class DES
    {
        private static readonly String strDesKey = "tmstqooo";//加密所需8位密匙

        /// DES加密
        public static String Encrypt_DES(String str)
        {
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
            Byte[] inputByteArray = System.Text.Encoding.Default.GetBytes(str);
            des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(strDesKey);
            des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(strDesKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Byte b in ms.ToArray())
                sb.AppendFormat("{0:X2}", b);
            return sb.ToString();
        }

        ///

        /// DES解密
        public static String Decrypt_DES(String str)
        {
            try
            {
                if (string.IsNullOrEmpty(str)) return null;
                System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
                Int32 x;
                Byte[] inputByteArray = new Byte[str.Length / 2];
                for (x = 0; x < str.Length / 2; x++)
                    inputByteArray[x] = (Byte)(Convert.ToInt32(str.Substring(x * 2, 2), 16));
                des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(strDesKey);
                des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(strDesKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.StringBuilder ret = new System.Text.StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
