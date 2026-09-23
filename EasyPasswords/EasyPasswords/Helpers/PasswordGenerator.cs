/******************************************************************************
** PROGRAMME  PasswordGenerator.cs                                           **
**            Génération sécurisée de mots de passe via                      **
**            RandomNumberGenerator**                                        **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EasyPasswords_Augusto.Helpers
{
    /// <summary>
    /// Génère des mots de passe aléatoires et cryptographiquement sûrs
    /// selon les options choisies par l'utilisateur.
    /// </summary>
    internal static class PasswordGenerator
    {
        private const string LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "0123456789";
        private const string SPECIALS = "!@#$%^&*()-_=+[]{};:,.<>?";

        /// <summary>
        /// Génère un mot de passe de longueur <paramref name="length"/> selon les options activées.
        /// Garantit au moins un caractère de chaque catégorie sélectionnée.
        /// Retourne une chaîne vide si aucune option n'est sélectionnée.
        /// </summary>
        public static string Generate(int length, bool useLetters, bool useNumbers, bool useSpecials)
        {
            // Construire le pool et la liste des sets obligatoires
            var pool = new StringBuilder();
            var requiredSets = new List<string>();

            if (useLetters) { pool.Append(LETTERS); requiredSets.Add(LETTERS); }
            if (useNumbers) { pool.Append(NUMBERS); requiredSets.Add(NUMBERS); }
            if (useSpecials) { pool.Append(SPECIALS); requiredSets.Add(SPECIALS); }

            if (pool.Length == 0) return string.Empty;

            string poolStr = pool.ToString();
            var result = new StringBuilder(length);

            using (var rng = RandomNumberGenerator.Create())
            {
                // Garantir au moins un caractère par catégorie activée
                foreach (string set in requiredSets)
                    result.Append(set[GetRandomIndex(rng, set.Length)]);

                // Remplir le reste
                int remaining = length - result.Length;
                if (remaining > 0)
                {
                    byte[] fill = new byte[remaining];
                    rng.GetBytes(fill);
                    foreach (byte b in fill)
                        result.Append(poolStr[b % poolStr.Length]);
                }

                // Mélanger (Fisher-Yates)
                return Shuffle(result.ToString(), rng);
            }
        }

        // ── Privé ──────────────────────────────────────────────────────────────

        private static int GetRandomIndex(RandomNumberGenerator rng, int max)
        {
            byte[] buf = new byte[1];
            rng.GetBytes(buf);
            return buf[0] % max;
        }

        private static string Shuffle(string input, RandomNumberGenerator rng)
        {
            char[] chars = input.ToCharArray();
            byte[] buf = new byte[chars.Length];
            rng.GetBytes(buf);

            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = buf[i] % (i + 1);
                char tmp = chars[i];
                chars[i] = chars[j];
                chars[j] = tmp;
            }
            return new string(chars);
        }
    }
}