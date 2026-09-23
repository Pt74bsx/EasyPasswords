/******************************************************************************
** PROGRAMME  PasswordManager.cs                                             **
**            Lecture, sauvegarde et gestion des entrées de mots de passe    **                                   
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EasyPasswords_Augusto.Core;

namespace EasyPasswords_Augusto.Core
{
    /// <summary>Représente une entrée de mot de passe sauvegardée.</summary>
    internal class PasswordEntry
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// Gère la persistance chiffrée des données (lecture/écriture fichier)
    /// et les opérations CRUD sur les mots de passe.
    /// </summary>
    internal static class PasswordManager
    {
        private const string DATA_FILE = "securedata.db";
        private const string TEMP_FILE = "temp.db";

        // ── Fichier ────────────────────────────────────────────────────────────

        /// <summary>
        /// Lit le fichier chiffré et retourne un dictionnaire clé/valeur.
        /// Retourne un dictionnaire vide si le fichier est absent ou corrompu.
        /// </summary>
        public static Dictionary<string, string> Load()
        {
            var data = new Dictionary<string, string>();
            if (!File.Exists(DATA_FILE)) return data;

            try
            {
                FileEncryption.DecryptFile(DATA_FILE, TEMP_FILE);

                foreach (string line in File.ReadAllLines(TEMP_FILE))
                {
                    if (!line.Contains("=")) continue;
                    var parts = line.Split(new char[] { '=' }, 2);
                    data[parts[0]] = parts[1];
                }
            }
            catch { /* fichier corrompu ou vide → dictionnaire vide */ }
            finally { TryDelete(TEMP_FILE); }

            return data;
        }

        /// <summary>Sérialise le dictionnaire et chiffre le résultat sur disque.</summary>
        public static void Save(Dictionary<string, string> data)
        {
            try
            {
                File.WriteAllLines(TEMP_FILE, data.Select(kv => $"{kv.Key}={kv.Value}"));
                FileEncryption.EncryptFile(TEMP_FILE, DATA_FILE);
            }
            finally { TryDelete(TEMP_FILE); }
        }

        /// <summary>Indique si le fichier de données existe déjà.</summary>
        public static bool DataFileExists() => File.Exists(DATA_FILE);

        /// <summary>Supprime le fichier de données (suppression de compte).</summary>
        public static void DeleteDataFile() => TryDelete(DATA_FILE);

        // ── Entrées de mots de passe ───────────────────────────────────────────

        /// <summary>Retourne toutes les entrées de mots de passe sauvegardées.</summary>
        public static List<PasswordEntry> GetEntries(Dictionary<string, string> data)
            => data.Keys
                   .Where(k => k.EndsWith("_title"))
                   .Select(k => k.Replace("_title", ""))
                   .Select(k => new PasswordEntry
                   {
                       Key = k,
                       Title = data.ContainsKey(k + "_title") ? data[k + "_title"] : "?",
                       Value = data.ContainsKey(k + "_value") ? data[k + "_value"] : "?"
                   })
                   .ToList();

        /// <summary>Ajoute ou met à jour une entrée dans le dictionnaire et sauvegarde.</summary>
        public static void SaveEntry(Dictionary<string, string> data, string key, string title, string value)
        {
            data[key + "_title"] = title;
            data[key + "_value"] = value;
            Save(data);
        }

        /// <summary>Supprime une entrée du dictionnaire et sauvegarde.</summary>
        public static void DeleteEntry(Dictionary<string, string> data, string key)
        {
            data.Remove(key + "_title");
            data.Remove(key + "_value");
            Save(data);
        }

        /// <summary>Génère une clé unique horodatée pour un nouveau mot de passe.</summary>
        public static string NewEntryKey() => "PWD_" + DateTime.Now.ToString("yyyyMMddHHmmss");

        // ── Utilitaire privé ───────────────────────────────────────────────────

        private static void TryDelete(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}