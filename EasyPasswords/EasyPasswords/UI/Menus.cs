/******************************************************************************
** PROGRAMME  Menus.cs                                                       **
**            Tous les gestionnaires de menus : connexion,                   **
**            accueil, paramètres                                            **           
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EasyPasswords_Augusto.Core;
using EasyPasswords_Augusto.Helpers;
using EasyPasswords_Augusto.Language;
using EasyPasswords_Augusto.UI;

namespace EasyPasswords_Augusto.UI
{
    /// <summary>
    /// Contient tous les menus de l'application.
    /// Chaque méthode gère un écran et retourne un MenuResult.
    /// </summary>
    internal static class Menus
    {
        public enum MenuResult { Restart, Quit, LoggedIn }

        public static Dictionary<string, string> Textes { get; set; }
        public static string ProgramName { get; set; }

        // ── Connexion ──────────────────────────────────────────────────────────

        public static MenuResult ShowLoginMenu(Dictionary<string, string> data)
        {
            while (true)
            {
                ConsoleUI.PrintConnectTitle(ProgramName, Textes["loginTitle"]);
                Console.WriteLine();
                ConsoleUI.PrintCentered(Textes["loginMenuChoice"]);
                ConsoleUI.PrintCentered(Textes["loginMenuChoice2"]);

                int choice = ConsoleUI.AskInt(Textes["loginMenuPrompt"], 0, 3, Textes["loginMenuError"]);

                switch (choice)
                {
                    case 0: return MenuResult.Quit;
                    case 1:
                        if (HandleLogin(data)) return MenuResult.LoggedIn;
                        break;
                    case 2:
                        if (HandleForgotPassword(data)) return MenuResult.Restart;
                        break;
                    case 3:
                        ShowAbout();
                        break;
                }
            }
        }

        // ── Accueil ────────────────────────────────────────────────────────────

        public static MenuResult ShowHomeMenu(Dictionary<string, string> data)
        {
            ConsoleUI.PrintHomeTitle(ProgramName, Textes["homeTitle"]);
            Console.WriteLine();
            ConsoleUI.PrintCentered(Textes["homeMenuChoice1"]);
            ConsoleUI.PrintCentered(Textes["homeMenuChoice2"]);
            ConsoleUI.PrintCentered(Textes["homeMenuChoice3"]);

            int choice = ConsoleUI.AskInt(Textes["homeMenuPrompt"], 0, 5, Textes["homeMenuError"]);

            switch (choice)
            {
                case 0: return MenuResult.Quit;
                case 1: return HandleCreatePassword(data);
                case 2: return HandleListPasswords(data);
                case 3: return HandleManagePasswords(data);
                case 4: return HandleTestPassword();
                case 5: return HandleSettings(data);
                default: return MenuResult.Restart;
            }
        }

        // ── Création de compte ─────────────────────────────────────────────────

        public static MenuResult ShowCreateAccount()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            // Choix de la langue
            string lang = AskLanguage();
            Textes = lang.Equals("fr", StringComparison.OrdinalIgnoreCase) ? FR.Textes : EN.Textes;

            // Message d'introduction
            ConsoleUI.TypeWriter(Textes["introductionMessage"], 30);
            Console.ReadKey(true);
            Console.Clear();

            // Création du fichier de données
            var data = new Dictionary<string, string>();
            data[AccountManager.KEY_LANGUAGE] = lang;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            Console.WriteLine(Textes["titleCreatQuestion"]);

            // Nom d'utilisateur
            string username = ConsoleUI.AskInput(
                Textes["usernameQuestion"],
                AccountManager.IsValidUsername,
                Textes["usernameError"]
            );

            // Mot de passe
            string password = AskNewPasswordWithConfirm();

            // Clé de récupération
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Textes["recoveryKeyWarning"]);
            Console.ResetColor();
            Console.Write(Textes["recoveryKeyMessage"]);
            Console.ReadKey(true);

            string recoveryKey = AccountManager.CreateAccount(data, username, password, lang);

            Console.WriteLine(Textes["recoveryKeyDisplay"]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("  > " + recoveryKey);
            Console.ResetColor();

            ConsoleUI.PressAnyKey(Textes["pressToContinue"]);
            Console.Clear();

            return MenuResult.LoggedIn;
        }

        // ── Handlers privés ────────────────────────────────────────────────────

        private static bool HandleLogin(Dictionary<string, string> data)
        {
            while (true)
            {
                Console.Clear();
                ConsoleUI.PrintConnectTitle(ProgramName, Textes["loginTitle"]);
                data = PasswordManager.Load();

                Console.WriteLine(Textes["loginUsernamePrompt"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("   > ");
                string user = Console.ReadLine();
                Console.ResetColor();

                if (user == "0") return false;

                Console.WriteLine(Textes["loginPasswordPrompt"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("   > ");
                string pass = ConsoleUI.ReadHiddenPassword();
                Console.ResetColor();

                if (pass == "0") return false;

                if (!AccountManager.ValidateLogin(data, user, pass))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["loginError"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Textes["loginSuccess"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return true;
                }
            }
        }

        private static bool HandleForgotPassword(Dictionary<string, string> data)
        {
            Console.Clear();
            ConsoleUI.PrintConnectTitle(ProgramName, Textes["loginTitle"]);

            Console.WriteLine(Textes["forgotPasswordPrompt"]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("   > ");
            string key = Console.ReadLine();
            Console.ResetColor();

            if (key == "0") return false;

            if (!AccountManager.ValidateRecoveryKey(data, key))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Textes["forgotPasswordError"]);
                Console.ResetColor();
                Thread.Sleep(1500);
                return false;
            }

            string newPassword = AskNewPasswordWithConfirm();
            AccountManager.SetPassword(data, newPassword);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Textes["forgotPasswordSuccess"]);
            Console.ResetColor();
            Thread.Sleep(1500);
            return true;
        }

        private static MenuResult HandleCreatePassword(Dictionary<string, string> data)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            Console.WriteLine(Textes["createPasswordTitle"]);

            // Longueur
            int length = ConsoleUI.AskInt(
                Textes["createPasswordLengthPrompt"],
                4, 48,
                Textes["createPasswordLengthErrorRange"]
            );

            // Options
            bool letters = AskYesNo(Textes["createPasswordLettersPrompt"], Textes["createPasswordOptionError"]);
            bool numbers = AskYesNo(Textes["createPasswordNumbersPrompt"], Textes["createPasswordOptionError"]);
            bool specials = AskYesNo(Textes["createPasswordSpecialPrompt"], Textes["createPasswordOptionError"]);

            // Titre
            string title = ConsoleUI.AskInput(
                Textes["createPasswordTitlePrompt"],
                AccountManager.IsValidTitle,
                Textes["createPasswordTitleError"]
            );

            // Génération
            string generated = PasswordGenerator.Generate(length, letters, numbers, specials);
            Thread.Sleep(20);

            Console.Write(Textes["showGeneratePassword"]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" " + generated);
            Console.ResetColor();

            // Confirmation sauvegarde
            while (true)
            {
                Console.WriteLine(Textes["ConfirmedGeneratePassword"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.ResetColor();

                if (choice == 'y' || choice == 'Y' || choice == 'o' || choice == 'O')
                {
                    PasswordManager.SaveEntry(data, PasswordManager.NewEntryKey(), title, generated);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Textes["passwordSaved"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
                }
                else if (choice == 'n' || choice == 'N')
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["invalideOption"]);
                    Console.ResetColor();
                }
            }

            return MenuResult.Restart;
        }

        private static MenuResult HandleListPasswords(Dictionary<string, string> data)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            var entries = PasswordManager.GetEntries(data);

            if (entries.Count == 0)
            {
                Console.WriteLine(Textes["passwordListEmpty"]);
            }
            else
            {
                Console.WriteLine(Textes["passwordListTitle"]);

                foreach (PasswordEntry e in entries)
                {
                    Console.WriteLine(Textes["passwordListItem"]);
                    Console.Write(Textes["passwordListTitleLabel"]);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(e.Title);
                    Console.ResetColor();
                    Console.Write(Textes["passwordListValueLabel"]);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(e.Value);
                    Console.ResetColor();
                    Console.WriteLine(Textes["passwordListItem"]);
                    Console.WriteLine();
                }
            }

            Console.Write(Textes["passwordListReturn"]);
            Console.ReadKey(true);
            return MenuResult.Restart;
        }

        private static MenuResult HandleManagePasswords(Dictionary<string, string> data)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                ConsoleUI.PrintCentered(ProgramName);
                Console.ResetColor();

                data = PasswordManager.Load();
                var entries = PasswordManager.GetEntries(data);

                Console.WriteLine(Textes["managePasswordTitle"]);
                Console.WriteLine();

                if (entries.Count == 0)
                {
                    Console.WriteLine(Textes["managePasswordEmpty"]);
                }
                else
                {
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.Write(string.Format("    [{0}] ", i + 1));
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(entries[i].Title.PadRight(26));
                        Console.ResetColor();
                        Console.Write(" | ");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(entries[i].Value);
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
                Console.WriteLine(Textes["managePasswordAddPrompt"]);
                Console.WriteLine(Textes["managePasswordSelectPrompt"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (input == null) input = "";
                input = input.Trim();

                if (input == "0")
                {
                    return MenuResult.Restart;
                }

                if (input.ToLower() == "a")
                {
                    HandleAddManualPassword(data);
                    continue;
                }

                int idx;
                if (!int.TryParse(input, out idx) || idx < 1 || idx > entries.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["managePasswordSelectError"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    continue;
                }

                bool deleted = HandlePasswordActions(data, entries[idx - 1]);
                if (deleted) continue;
            }
        }

        private static void HandleAddManualPassword(Dictionary<string, string> data)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            Console.WriteLine(Textes["managePasswordAddTitle"]);

            string title = ConsoleUI.AskInput(
                Textes["managePasswordAddTitlePrompt"],
                AccountManager.IsValidTitle,
                Textes["managePasswordAddTitleError"]
            );

            string value = ConsoleUI.AskInput(
                Textes["managePasswordAddValuePrompt"],
                delegate (string s) { return s != null && s.Length > 0; },
                Textes["managePasswordAddValueError"],
                true
            );

            PasswordManager.SaveEntry(data, PasswordManager.NewEntryKey(), title, value);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Textes["managePasswordAddSuccess"]);
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        private static bool HandlePasswordActions(Dictionary<string, string> data, PasswordEntry entry)
        {
            string currentTitle = entry.Title;
            string currentValue = entry.Value;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                ConsoleUI.PrintCentered(ProgramName);
                Console.ResetColor();

                ConsoleUI.PrintPasswordBox(currentTitle, currentValue);

                Console.WriteLine(Textes["managePasswordActionTitle"]);
                Console.WriteLine(Textes["managePasswordAction1"]);
                Console.WriteLine(Textes["managePasswordAction2"]);
                Console.WriteLine(Textes["managePasswordAction3"]);
                Console.WriteLine(Textes["managePasswordAction0"]);

                int action = ConsoleUI.AskInt(
                    Textes["managePasswordActionPrompt"],
                    0, 3,
                    Textes["managePasswordActionError"]
                );

                switch (action)
                {
                    case 0:
                        return false;

                    case 1:
                        string newTitle = ConsoleUI.AskInput(
                            Textes["managePasswordNewTitlePrompt"],
                            AccountManager.IsValidTitle,
                            Textes["managePasswordNewTitleError"]
                        );
                        data[entry.Key + "_title"] = newTitle;
                        currentTitle = newTitle;
                        PasswordManager.Save(data);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Textes["managePasswordTitleUpdated"]);
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;

                    case 2:
                        string newValue = ConsoleUI.AskInput(
                            Textes["managePasswordNewValuePrompt"],
                            delegate (string s) { return s != null && s.Length > 0; },
                            Textes["managePasswordNewValueError"],
                            true
                        );
                        data[entry.Key + "_value"] = newValue;
                        currentValue = newValue;
                        PasswordManager.Save(data);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Textes["managePasswordValueUpdated"]);
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;

                    case 3:
                        if (ConfirmDelete(data, entry))
                            return true;
                        break;
                }
            }
        }

        private static bool ConfirmDelete(Dictionary<string, string> data, PasswordEntry entry)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Textes["managePasswordDeleteConfirm"]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                string answer = Console.ReadLine();
                Console.ResetColor();

                if (answer == null) answer = "";
                answer = answer.ToLower();

                if (answer == "o" || answer == "y")
                {
                    PasswordManager.DeleteEntry(data, entry.Key);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Textes["managePasswordDeleted"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return true;
                }
                if (answer == "n") return false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Textes["managePasswordDeleteError"]);
                Console.ResetColor();
            }
        }

        private static MenuResult HandleTestPassword()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            Console.WriteLine(Textes["testPasswordTitle"]);
            string pwd = ConsoleUI.AskInput(
                Textes["testPasswordPrompt"],
                delegate (string s) { return s != null && s.Length >= 4; },
                Textes["testPasswordLengthError"]
            );

            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();
            Console.WriteLine();

            Console.CursorVisible = false;
            double elapsed = BruteForceDemo(pwd);
            Console.CursorVisible = true;

            int score = PasswordScorer.Calculate(pwd, elapsed);

            Console.Write(Textes["testPasswordFound"]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(pwd);
            Console.ResetColor();

            Console.Write(Textes["testPasswordTime"]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(elapsed.ToString("F4") + Textes["testPasswordSeconds"]);
            Console.ResetColor();

            Console.Write(Textes["testPasswordScore"]);
            Console.ForegroundColor = score >= 7 ? ConsoleColor.Green
                                    : score >= 4 ? ConsoleColor.DarkYellow
                                    : ConsoleColor.Red;
            Console.WriteLine(Textes["testPasswordScore" + score]);
            Console.ResetColor();

            Console.WriteLine(Textes["testPasswordReturn"]);
            Console.ReadKey(true);
            return MenuResult.Restart;
        }

        private static MenuResult HandleSettings(Dictionary<string, string> data)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            ConsoleUI.PrintSettingsTitle(ProgramName, Textes["settingsTitle"]);
            Console.WriteLine();
            ConsoleUI.PrintCentered(Textes["settingsMenuChoice1"]);
            ConsoleUI.PrintCentered(Textes["settingsMenuChoice2"]);
            ConsoleUI.PrintCentered(Textes["settingsMenuChoice3"]);

            int choice = ConsoleUI.AskInt(Textes["settingsMenuPrompt"], 0, 5, Textes["settingsMenuError"]);

            switch (choice)
            {
                case 0:
                    return MenuResult.Restart;

                case 1:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    ConsoleUI.PrintCentered(ProgramName);
                    Console.ResetColor();
                    string newUser = ConsoleUI.AskInput(
                        Textes["usernameQuestion"],
                        AccountManager.IsValidUsername,
                        Textes["usernameError"]
                    );
                    AccountManager.SetUsername(data, newUser);
                    return MenuResult.Restart;

                case 2:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    ConsoleUI.PrintCentered(ProgramName);
                    Console.ResetColor();

                    Console.WriteLine(Textes["changePasswordCurrentPrompt"]);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("  > ");
                    string current = ConsoleUI.ReadHiddenPassword();
                    Console.ResetColor();

                    if (!AccountManager.ValidateCurrentPassword(data, current))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Textes["forgotPasswordMatchError"]);
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        return MenuResult.Restart;
                    }
                    string updated = AskNewPasswordWithConfirm();
                    AccountManager.SetPassword(data, updated);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Textes["forgotPasswordSuccess"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return MenuResult.Restart;

                case 3:
                    ShowAbout();
                    return MenuResult.Restart;

                case 4:
                    return HandleDeleteAccount(data);

                case 5:
                    ToggleLanguage(data);
                    return MenuResult.Restart;

                default:
                    return MenuResult.Restart;
            }
        }

        private static MenuResult HandleDeleteAccount(Dictionary<string, string> data)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            ConsoleUI.PrintCentered(ProgramName);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Textes["deleteAccountConfirmPrompt"]);
            Console.ResetColor();

            while (true)
            {
                Console.Write(Textes["settingsMenuPrompt"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                string answer = Console.ReadLine();
                Console.ResetColor();

                if (answer == null) answer = "";

                if (answer == "o" || answer == "O" || answer == "y" || answer == "Y")
                {
                    PasswordManager.DeleteDataFile();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["confirmeDeletAccount"]);
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return MenuResult.Quit;
                }
                if (answer == "n" || answer == "N")
                {
                    return MenuResult.Restart;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Textes["suppMenuError"]);
                Console.ResetColor();
            }
        }

        private static void ShowAbout()
        {
            ConsoleUI.PrintInformationTitle(ProgramName, Textes["informationTitle"]);
            Console.WriteLine(Textes["aboutInformation"]);
            Console.Write(Textes["pressToContinue"]);
            Console.ReadKey(true);
        }

        private static void ToggleLanguage(Dictionary<string, string> data)
        {
            string current = "";
            data.TryGetValue(AccountManager.KEY_LANGUAGE, out current);
            if (current == null) current = "";

            bool isFr = current.Equals("fr", StringComparison.OrdinalIgnoreCase);
            string newLang = isFr ? "EN" : "FR";

            AccountManager.SetLanguage(data, newLang);
            Textes = isFr ? EN.Textes : FR.Textes;
        }

        // ── Helpers saisie ─────────────────────────────────────────────────────

        private static string AskLanguage()
        {
            while (true)
            {
                Console.Write("\n\n Language (FR/EN) : ");
                string lang = Console.ReadLine();
                if (AccountManager.IsValidLanguage(lang)) return lang;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n [ERREUR] FR or EN\n");
                Console.ResetColor();
            }
        }

        private static string AskNewPasswordWithConfirm()
        {
            while (true)
            {
                Console.Write(Textes["forgotPasswordNewPrompt"]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("   > ");
                string pwd = ConsoleUI.ReadHiddenPassword();
                Console.ResetColor();

                if (!AccountManager.IsValidPassword(pwd))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["forgotPasswordLengthError"]);
                    Console.ResetColor();
                    continue;
                }

                while (true)
                {
                    Console.Write(Textes["forgotPasswordConfirmPrompt"]);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("   > ");
                    string confirm = ConsoleUI.ReadHiddenPassword();
                    Console.ResetColor();

                    if (confirm == pwd)
                        return pwd;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Textes["forgotPasswordMatchError"]);
                    Console.ResetColor();
                }
            }
        }

        private static bool AskYesNo(string prompt, string errorMsg)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  > ");
                char c = Console.ReadKey().KeyChar;
                Console.ResetColor();
                Console.WriteLine();

                if (c == 'o' || c == 'O' || c == 'y' || c == 'Y') return true;
                if (c == 'n' || c == 'N') return false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Console.ResetColor();
            }
        }

        // ── Brute-force de démonstration ───────────────────────────────────────

        private static double BruteForceDemo(string target)
        {
            const string POOL = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()-_=+[]{};:,.<>?";
            char[] pool = POOL.ToCharArray();
            int poolSize = pool.Length;
            int targetLen = target.Length;
            char[] targetArr = target.ToCharArray();

            int foundFlag = 0;
            string displayCur = "";
            int spinIdx = 0;

            int rowAttack = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Textes["testPasswordAttack"] + "  ");
            Console.ResetColor();
            Console.WriteLine();
            int rowAttempt = Console.CursorTop;
            Console.WriteLine(new string(' ', 80));

            int spinCol = Textes["testPasswordAttack"].Length + 2;
            string[] spinner = { "/", "-", "\\", "|" };

            CancellationTokenSource cts = new CancellationTokenSource();
            Task displayTask = Task.Run(delegate ()
            {
                while (!cts.IsCancellationRequested)
                {
                    try
                    {
                        Console.SetCursorPosition(spinCol, rowAttack);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(spinner[Interlocked.Increment(ref spinIdx) % 4]);
                        Console.ResetColor();
                        Console.SetCursorPosition(0, rowAttempt);
                        Console.Write("  Tentatives : " + Volatile.Read(ref displayCur).PadRight(60));
                    }
                    catch { }
                    Thread.Sleep(8);
                }
            });

            Stopwatch sw = Stopwatch.StartNew();

            for (int len = 1; len <= targetLen && Volatile.Read(ref foundFlag) == 0; len++)
            {
                int capturedLen = len;

                Parallel.For(0, poolSize, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, delegate (int firstIdx)
                {
                    if (Volatile.Read(ref foundFlag) != 0) return;

                    int[] indices = new int[capturedLen];
                    char[] candidate = new char[capturedLen];

                    indices[0] = firstIdx;
                    candidate[0] = pool[firstIdx];
                    for (int i = 1; i < capturedLen; i++) { indices[i] = 0; candidate[i] = pool[0]; }

                    long iter = 0;

                    while (true)
                    {
                        if (Volatile.Read(ref foundFlag) != 0) return;
                        if ((iter & 0xFFFF) == 0) Volatile.Write(ref displayCur, new string(candidate));

                        if (capturedLen == targetLen)
                        {
                            bool match = true;
                            for (int i = 0; i < capturedLen; i++)
                                if (candidate[i] != targetArr[i]) { match = false; break; }

                            if (match && Interlocked.CompareExchange(ref foundFlag, 1, 0) == 0)
                                return;
                        }

                        if (capturedLen == 1) return;

                        int pos = capturedLen - 1;
                        while (pos >= 1)
                        {
                            if (++indices[pos] < poolSize) { candidate[pos] = pool[indices[pos]]; break; }
                            indices[pos] = 0; candidate[pos] = pool[0]; pos--;
                        }
                        if (pos < 1) return;
                        iter++;
                    }
                });
            }

            sw.Stop();
            cts.Cancel();
            displayTask.Wait();

            Console.SetCursorPosition(0, rowAttack);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(0, rowAttempt);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(0, rowAttack);

            return sw.Elapsed.TotalSeconds;
        }
    }
}