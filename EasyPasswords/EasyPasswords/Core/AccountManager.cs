/******************************************************************************
** PROGRAMME  AccountManager.cs                                              **
**            Gestion du compte utilisateur : création,                      **
**            connexion, modification                                        **                                   
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

namespace EasyPasswords_Augusto.Core
{
    /// <summary>
    /// Gère les opérations liées au compte utilisateur :
    /// création, vérification des identifiants, modification du mot de passe
    /// et génération de la clé de récupération.
    /// </summary>
    internal static class AccountManager
    {
        // Clés utilisées dans le dictionnaire de données
        public const string KEY_USERNAME = "UserName";
        public const string KEY_PASSWORD = "Password";
        public const string KEY_SECRETKEY = "SecretKeay";   
        public const string KEY_LANGUAGE = "Language";

        private const string RECOVERY_PREFIX = "EasyPasswords-";
        private const string RECOVERY_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+";
        private const int RECOVERY_LENGTH = 32;

        // ── Vérifications ──────────────────────────────────────────────────────

        /// <summary>Vérifie que le nom d'utilisateur et le mot de passe correspondent.</summary>
        public static bool ValidateLogin(Dictionary<string, string> data, string username, string password)
            => data.TryGetValue(KEY_USERNAME, out string savedUser)
            && data.TryGetValue(KEY_PASSWORD, out string savedPass)
            && username == savedUser
            && password == savedPass;

        /// <summary>Vérifie que la clé de récupération correspond.</summary>
        public static bool ValidateRecoveryKey(Dictionary<string, string> data, string key)
            => data.TryGetValue(KEY_SECRETKEY, out string saved) && key == saved;

        /// <summary>Vérifie que le mot de passe actuel est correct.</summary>
        public static bool ValidateCurrentPassword(Dictionary<string, string> data, string password)
            => data.TryGetValue(KEY_PASSWORD, out string saved) && password == saved;

        // ── Contraintes de saisie ──────────────────────────────────────────────

        public static bool IsValidUsername(string s) => s != null && s.Length >= 4 && s.Length <= 12;
        public static bool IsValidPassword(string s) => s != null && s.Length >= 8 && s.Length <= 24;
        public static bool IsValidTitle(string s) => s != null && s.Length >= 4 && s.Length <= 24;
        public static bool IsValidLanguage(string s) => s != null &&
            (s.Equals("fr", StringComparison.OrdinalIgnoreCase) ||
             s.Equals("en", StringComparison.OrdinalIgnoreCase));

        // ── Modification ───────────────────────────────────────────────────────

        /// <summary>Enregistre un nouveau nom d'utilisateur dans le dictionnaire et sauvegarde.</summary>
        public static void SetUsername(Dictionary<string, string> data, string username)
        {
            data[KEY_USERNAME] = username;
            PasswordManager.Save(data);
        }

        /// <summary>Enregistre un nouveau mot de passe dans le dictionnaire et sauvegarde.</summary>
        public static void SetPassword(Dictionary<string, string> data, string password)
        {
            data[KEY_PASSWORD] = password;
            PasswordManager.Save(data);
        }

        /// <summary>Enregistre la langue dans le dictionnaire et sauvegarde.</summary>
        public static void SetLanguage(Dictionary<string, string> data, string language)
        {
            data[KEY_LANGUAGE] = language;
            PasswordManager.Save(data);
        }

        // ── Génération ─────────────────────────────────────────────────────────

        /// <summary>Génère une clé de récupération cryptographiquement sûre.</summary>
        public static string GenerateRecoveryKey()
        {
            var result = new StringBuilder(RECOVERY_PREFIX);
            byte[] buffer = new byte[RECOVERY_LENGTH];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);

                for (int i = 0; i < RECOVERY_LENGTH; i++)
                    result.Append(RECOVERY_CHARS[buffer[i] % RECOVERY_CHARS.Length]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Crée le compte initial : enregistre tous les champs et sauvegarde.
        /// Retourne la clé de récupération générée.
        /// </summary>
        public static string CreateAccount(Dictionary<string, string> data,
                                           string username, string password, string language)
        {
            string recoveryKey = GenerateRecoveryKey();

            data[KEY_USERNAME] = username;
            data[KEY_PASSWORD] = password;
            data[KEY_SECRETKEY] = recoveryKey;
            data[KEY_LANGUAGE] = language;

            PasswordManager.Save(data);
            return recoveryKey;
        }
    }
}