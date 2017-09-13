using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    class Cipher
    {

        public static String Decrypt(String input, String pass)
        {
            System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string decrypted = "";
            try
            {
                byte[] hash = new byte[32];
                byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESDecrypter = AES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(input);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return decrypted;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
