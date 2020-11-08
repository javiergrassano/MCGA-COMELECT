using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace mcga.tools
{
    public static class Cryptog
    {

        #region  Encriptacion MD5

        /// <summary>
        /// Encriptacion unidireccionar en MD5
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Devuelve el texto encriptado</returns>
        public static string EncriptarMD5(string texto)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(texto));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();
        }

        #endregion

        #region Encriptar

        /// <summary>
        /// Encriptacion Rijndael basica sin parametros
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Devolucion de texto encriptado</returns>
        public static string Encriptar(string texto)
        {
            return Encriptar(texto, "p4ssw0rd@sio11", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }

        /// <summary>
        /// Encriptacion Rijndael basica con parametros
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <param name="passBase">Contraseña de encriptacion</param>
        /// <param name="saltValue">Valor de salto</param>
        /// <param name="hashAlgorithm">Algoritmo de encriptacion Ej: SHA1 o MD5</param>
        /// <param name="passwordIterations">Valor de interaccion</param>
        /// <param name="initVector">Vector de interaccion tiene que ser 16bytes</param>
        /// <param name="keySize">Bits de encriptacion Ej 128, 192, 256</param>
        /// <returns></returns>
        public static string Encriptar(string texto, string passBase,
              string saltValue, string hashAlgorithm,
              int passwordIterations, string initVector, int keySize)
        {

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);

            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(texto);


            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();


            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();



            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();

            cryptoStream.Close();


            string cipherText = System.Convert.ToBase64String(cipherTextBytes);

            return cipherText;

        }

        #endregion

        #region Desencriptar

        /// <summary>
        /// Desencripta texto Rijndael basica sin parametros
        /// </summary>
        /// <param name="texto">Texto encriptado</param>
        /// <returns>Devolucion de texto desencriptado</returns>
        public static string Desencriptar(string texto)
        {
            return Desencriptar(texto, "p4ssw0rd@sio11", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }
        /// <summary>
        /// Desencriptacion Rijndael basica con parametros
        /// </summary>
        /// <param name="texto">Texto encriptado</param>
        /// <param name="passBase">Contraseña de encriptacion</param>
        /// <param name="saltValue">Valor de salto</param>
        /// <param name="hashAlgorithm">Algoritmo de encriptacion Ej: SHA1 o MD5</param>
        /// <param name="passwordIterations">Valor de interaccion</param>
        /// <param name="initVector">Vector de interaccion tiene que ser 16bytes</param>
        /// <param name="keySize">Bits de encriptacion Ej 128, 192, 256</param>
        /// <returns>Texto desencriptado</returns> 

        public static string Desencriptar(string textoEncriptado, string passBase,
          string saltValue, string hashAlgorithm, int passwordIterations,
          string initVector, int keySize)
        {

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);

            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] cipherTextBytes = System.Convert.FromBase64String(textoEncriptado);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);



            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };


            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);


            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);


            memoryStream.Close();

            cryptoStream.Close();



            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);


            return plainText;

        }

        #endregion

        public static string HashBytes(string valueToHash)
        {
            HashAlgorithm hasher = new MD5CryptoServiceProvider();
            Byte[] valueToHashAsByte = Encoding.UTF8.GetBytes(valueToHash);
            Byte[] returnBytes = hasher.ComputeHash(valueToHashAsByte);
            StringBuilder hex = new StringBuilder(returnBytes.Length * 2);
            foreach (byte b in returnBytes) hex.AppendFormat("{0:x2}", b);
            return hex.ToString().ToUpper();
        }
    }

} 


