/******************************************************************************
** PROGRAMME  ConsoleUI.cs                                                   **
**            Helpers d'affichage console : couleurs,                        **
**            saisie, titres, typewriter                                     **                       
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System;
using System.Threading;

namespace EasyPasswords_Augusto.UI
{
    /// <summary>
    /// Centralise tous les utilitaires d'affichage et de saisie console.
    /// Élimine la répétition des blocs ForegroundColor / ResetColor.
    /// </summary>
    internal static class ConsoleUI
    {
        // ── Écriture colorée ───────────────────────────────────────────────────

        public static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void WriteSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void WriteInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void WriteWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        // ── Centrage (identique à l'original) ─────────────────────────────────

        /// <summary>Centre chaque ligne du texte dans la fenêtre console.</summary>
        public static void PrintCentered(string text)
        {
            string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int consoleWidth = Console.WindowWidth;

            foreach (string line in lines)
            {
                int spaces = (consoleWidth - line.Length) / 2;
                if (spaces < 0) spaces = 0;
                Console.WriteLine(new string(' ', spaces) + line);
            }
        }

        // ── Titres de pages (fidèles à l'original) ─────────────────────────────

        /// <summary>Affiche le titre de la page de connexion.</summary>
        public static void PrintConnectTitle(string programName, string loginTitle)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintCentered(programName);
            Console.ResetColor();

            Console.WriteLine();
            PrintCentered(" ╔══════════════════════════════════════════╗");
            PrintCentered(" ║                                          ║");
            PrintCentered(loginTitle);
            PrintCentered(" ║                                          ║");
            PrintCentered(" ╚══════════════════════════════════════════╝");
        }

        /// <summary>Affiche le titre du menu d'accueil.</summary>
        public static void PrintHomeTitle(string programName, string homeTitle)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintCentered(programName);
            Console.ResetColor();

            Console.WriteLine();
            PrintCentered(" ╔══════════════════════════════════════════╗");
            PrintCentered(" ║                                          ║");
            PrintCentered(homeTitle);
            PrintCentered(" ║                                          ║");
            PrintCentered(" ╚══════════════════════════════════════════╝");
        }

        /// <summary>Affiche le titre des paramètres.</summary>
        public static void PrintSettingsTitle(string programName, string settingsTitle)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintCentered(programName);
            Console.ResetColor();

            Console.WriteLine();
            PrintCentered(" ╔══════════════════════════════════════════╗");
            PrintCentered(" ║                                          ║");
            PrintCentered(settingsTitle);
            PrintCentered(" ║                                          ║");
            PrintCentered(" ╚══════════════════════════════════════════╝");
        }

        /// <summary>Affiche le titre de la page d'informations.</summary>
        public static void PrintInformationTitle(string programName, string infoTitle)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintCentered(programName);
            Console.ResetColor();

            Console.WriteLine();
            PrintCentered(" ╔══════════════════════════════════════════╗");
            PrintCentered(" ║                                          ║");
            PrintCentered(infoTitle);
            PrintCentered(" ║                                          ║");
            PrintCentered(" ╚══════════════════════════════════════════╝");
        }

        /// <summary>
        /// Affiche uniquement le grand titre ASCII en DarkBlue (sans encadré).
        /// Utilisé pour la création de compte et les sous-pages.
        /// </summary>
        public static void PrintProgramTitle(string programName)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintCentered(programName);
            Console.ResetColor();
        }

        // ── Saisie générique ───────────────────────────────────────────────────

        /// <summary>
        /// Affiche prompt, lit la saisie et la valide. Boucle jusqu'à saisie valide.
        /// Reproduit exactement le style original : Console.Write(prompt) + "> " en bleu.
        /// </summary>
        public static string AskInput(string prompt, Func<string, bool> validator,
                                      string errorMsg, bool hidden = false)
        {
            while (true)
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                string input = hidden ? ReadHiddenPassword() : Console.ReadLine();
                Console.ResetColor();

                if (validator(input)) return input;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Lit un entier entre min et max. Boucle jusqu'à saisie valide.
        /// </summary>
        public static int AskInt(string prompt, int min, int max, string errorMsg)
        {
            while (true)
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                string raw = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(raw, out int val) && val >= min && val <= max)
                    return val;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Lit un seul caractère parmi ceux autorisés. Boucle jusqu'à saisie valide.
        /// </summary>
        public static char AskChar(string prompt, string allowed, string errorMsg)
        {
            while (true)
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                char c = Console.ReadKey().KeyChar;
                Console.ResetColor();
                Console.WriteLine();

                if (allowed.IndexOf(c) >= 0)
                    return char.ToLower(c);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Console.ResetColor();
            }
        }

        // ── Saisie sécurisée (identique à l'original) ─────────────────────────

        /// <summary>
        /// Lit un mot de passe sans afficher les caractères (remplacés par '*').
        /// </summary>
        public static string ReadHiddenPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            return password;
        }

        // ── Effets visuels ─────────────────────────────────────────────────────

        /// <summary>Affiche le texte lettre par lettre avec un délai entre chaque caractère.</summary>
        public static void TypeWriter(string text, int delayMs = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
        }

        /// <summary>Pause le programme et attend une touche.</summary>
        public static void PressAnyKey(string prompt = "")
        {
            if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
            Console.ReadKey(true);
        }

        // ── Boîte mot de passe (copie exacte de l'original) ───────────────────

        /// <summary>
        /// Affiche une entrée de mot de passe dans un cadre console.
        /// Labels et calcul de padding identiques à l'original.
        /// </summary>
        public static void PrintPasswordBox(string title, string value)
        {
            int boxWidth = 42;

            string titleLabel = "  Titre      : ";
            string passLabel = "  Mot de passe : ";

            int titleContentWidth = boxWidth - titleLabel.Length;
            int passContentWidth = boxWidth - passLabel.Length;

            string titlePadding = new string(' ', Math.Max(0, titleContentWidth - title.Length));
            string passPadding = new string(' ', Math.Max(0, passContentWidth - value.Length));

            Console.WriteLine();
            Console.WriteLine("  ╔══════════════════════════════════════════╗");

            Console.Write("  ║");
            Console.Write(titleLabel);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(title);
            Console.ResetColor();
            Console.WriteLine(titlePadding + "║");

            Console.Write("  ║");
            Console.Write(passLabel);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(value);
            Console.ResetColor();
            Console.WriteLine(passPadding + "║");

            Console.WriteLine("  ╚══════════════════════════════════════════╝");
        }

        // ── Feedback temporaire ────────────────────────────────────────────────

        public static void ShowSuccessAndWait(string msg, int ms = 1500)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
            Thread.Sleep(ms);
        }

        public static void ShowErrorAndWait(string msg, int ms = 1500)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Thread.Sleep(ms);
        }
    }
}