/******************************************************************************
** PROGRAMME  Program.cs                                                     **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

/******************************************************************************
** DESCRIPTION                                                               **
** EasyPasswords est un gestionnaire de mots de passe local développé en C# **
** en mode console. Il permet à un utilisateur unique de stocker et générer  **
** ses mots de passe personnels de manière sécurisée sur son ordinateur,     **
** sans connexion internet ni service externe. L'accès est protégé par un    **
** compte personnel composé d'un nom d'utilisateur, d'un mot de passe maître **
** et d'une clé de récupération. Toutes les données sont chiffrées avec      **
** AES-256 directement sur le disque.                                        **
******************************************************************************/

using System;
using System.Collections.Generic;
using EasyPasswords_Augusto.Core;
using EasyPasswords_Augusto.Language;
using EasyPasswords_Augusto.UI;

namespace EasyPasswords_Augusto
{
    internal class Program
    {
        private const string PROGRAM_NAME =
            "    ______                 ____                                          __    \r\n" +
            "   / ____/___ ________  __/ __ \\____ ____________      ______  _________/ /____\r\n" +
            "  / __/ / __ `/ ___/ / / / /_/ / __ `/ ___/ ___/ | /| / / __ \\/ ___/ __  / ___/\r\n" +
            " / /___/ /_/ (__  ) /_/ / ____/ /_/ (__  |__  )| |/ |/ / /_/ / /  / /_/ (__  ) \r\n" +
            "/_____/\\__,_/____/\\__, /_/    \\__,_/____/____/ |__/|__/\\____/_/   \\__,_/____/  \r\n" +
            "                 /____/                                                        ";

        static void Main(string[] args)
        {
            // ── Configuration de la fenêtre ────────────────────────────────────
            Console.Title = "Easypasswords      -      By Romain Augusto";
            Console.SetBufferSize(120, 300);

            // ── Injection des dépendances dans la page du Menus ──────────────────────────
            Menus.ProgramName = PROGRAM_NAME;
            Menus.Textes = EN.Textes;              // Langue par défaut

            bool loggedIn = false;

            // ── Boucle principale ──────────────────────────────────────────────
            bool running = true;
            while (running)
            {
                Dictionary<string, string> data = PasswordManager.Load();

                // Synchronise la langue depuis le fichier de données
                if (data.TryGetValue(AccountManager.KEY_LANGUAGE, out string lang))
                    Menus.Textes = lang.Equals("fr", StringComparison.OrdinalIgnoreCase)
                                 ? FR.Textes : EN.Textes;

                Menus.MenuResult result;

                if (!PasswordManager.DataFileExists() && !loggedIn)
                {
                    // Premier lancement → création de compte
                    result = Menus.ShowCreateAccount();
                    if (result == Menus.MenuResult.LoggedIn) loggedIn = true;
                }
                else if (!loggedIn)
                {
                    // Fichier qui existe → connexion
                    result = Menus.ShowLoginMenu(data);

                    switch (result)
                    {
                        case Menus.MenuResult.LoggedIn: loggedIn = true; break;
                        case Menus.MenuResult.Quit: running = false; break;
                    }
                }
                else
                {
                    // Connecté → menu d'accueil
                    result = Menus.ShowHomeMenu(data);

                    switch (result)
                    {
                        case Menus.MenuResult.Quit:
                            running = false;
                            break;
                        case Menus.MenuResult.Restart:
                            break;
                    }
                }
            }
        }
    }
}