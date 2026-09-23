/******************************************************************************
** PROGRAMME  FileEncryption.cs                                              **
**            Chiffrement et déchiffrement AES-256 des fichiers de données   **                                   
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System.IO;
using System.Security.Cryptography;

namespace EasyPasswords_Augusto.Core
{
    /// <summary>
    /// Chiffre et déchiffre un fichier avec AES-256.
    /// Clé et IV sont fixes et codés en dur (usage local uniquement).
    /// </summary>
    internal static class FileEncryption
    {
        private static readonly byte[] Key = new byte[]
        {
            0x4B, 0x3A, 0x7F, 0x2C, 0x9E, 0x15, 0xD8, 0x6A,
            0xF3, 0x01, 0xBC, 0x47, 0x8D, 0x5E, 0x29, 0x73,
            0xA6, 0xC2, 0x0F, 0x94, 0x3B, 0x68, 0xE7, 0x1D,
            0x52, 0xAF, 0x86, 0x3C, 0x70, 0x4E, 0x19, 0xD5
        };

        private static readonly byte[] IV = new byte[]
        {
            0x7E, 0x2B, 0x91, 0x4F, 0xC3, 0x68, 0xA5, 0x0D,
            0xF9, 0x36, 0x5C, 0xB8, 0x12, 0xE4, 0x7A, 0x2F
        };

        /// <summary>Chiffre inputFile et écrit le résultat dans outputFile.</summary>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream cs = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    fsIn.CopyTo(cs);
                }
            }
        }

        /// <summary>Déchiffre inputFile et écrit le résultat dans outputFile.</summary>
        public static void DecryptFile(string inputFile, string outputFile)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream cs = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.CopyTo(fsOut);
                }
            }
        }
    }
}