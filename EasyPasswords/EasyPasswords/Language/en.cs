/******************************************************************************
** PROGRAMME  en.cs                                                          **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System.Collections.Generic;
namespace EasyPasswords_Augusto.Language
{
    public static class EN
    {
        public static readonly Dictionary<string, string> Textes = new Dictionary<string, string>
        {
            // ============================
            // Account Creation
            // ============================
            ["introductionMessage"] = "\n Hello!\n\n Welcome to Easy Passwords.\n" +
                                              " This program allows you to manage your passwords securely,\n" +
                                              " create passwords with various options, import your own passwords,\n" +
                                              " modify your passwords, view your passwords and test their security.\n\n" +
                                              " Press any key to start creating your account...",
            ["titleCreatQuestion"] = "\n Here are several questions you must answer to finalize the creation of your account.",

            ["usernameQuestion"] = "\n What username would you like to use?\n",
            ["usernameError"] = "\n [ERROR] Your username must be between 4 and 12 characters\n",

            ["passwordQuestion"] = "\n Choose a password\n",
            ["passwordConfirmQuestion"] = "\n Re-enter your password\n",
            ["passwordError"] = "\n [ERROR] Your password must be between 8 and 24 characters\n",
            ["passwordConfirmError"] = "\n [ERROR] Your passwords do not match\n",

            ["recoveryKeyWarning"] = "\n [WARNING!] Generating your recovery key.\n",
            ["recoveryKeyMessage"] = "\n DO NOT LOSE THIS KEY under any circumstances and never share it." +
                                              "\n It is essential for recovering access to your account if you forget your password." +
                                              "\n\n Press any key to generate the key...",
            ["recoveryKeyDisplay"] = "\n\n Here is your recovery key",
            ["pressToContinue"] = "\n\n Press any key to continue...",

            // ============================
            // Login Menu
            // ============================
            ["loginMenuChoice"] = "  [1] Login         [2] Forgot password\n",
            ["loginMenuChoice2"] = "  [3] Information   [0] Quit            ",
            ["loginMenuPrompt"] = "\n  Your choice > ",
            ["loginMenuError"] = "\n  [ERROR] Please enter a number between 0 and 3.",

            ["loginUsernamePrompt"] = "\n  Username (0 = back)",
            ["loginPasswordPrompt"] = "\n  Password (0 = back)",
            ["loginError"] = "\n  [ERROR] Incorrect username or password.",
            ["loginSuccess"] = "\n  [Success] Access granted!",

            ["forgotPasswordPrompt"] = "\n  Enter your recovery key (0 = back)",
            ["forgotPasswordError"] = "\n  [ERROR] Incorrect key",
            ["forgotPasswordNewPrompt"] = "\n  Choose a new password\n",
            ["forgotPasswordConfirmPrompt"] = "\n  Re-enter your password\n",
            ["forgotPasswordSuccess"] = "\n   [Success] Password changed!",
            ["forgotPasswordLengthError"] = "\n  [ERROR] Your password must be between 8 and 24 characters\n",
            ["forgotPasswordMatchError"] = "\n  [ERROR] Your passwords do not match\n",

            // ============================
            // Home Menu
            // ============================
            ["homeMenuChoice1"] = "    [1] Create a password       [2] Password list  \n",
            ["homeMenuChoice2"] = "    [3] Manage passwords        [4] Test a password\n",
            ["homeMenuChoice3"] = "    [5] Settings                [0] Quit           ",
            ["homeMenuPrompt"] = "\n  Your choice > ",
            ["homeMenuError"] = "\n  [ERROR] Please enter a number between 0 and 5.",

            // ============================
            // Settings Menu
            // ============================
            ["settingsMenuChoice1"] = "    [1] Change username                     [2] Change password         \n",
            ["settingsMenuChoice2"] = "    [3] Information                         [4] Delete account          \n",
            ["settingsMenuChoice3"] = "   [5] Change language                     [0] Quit                    ",
            ["settingsMenuPrompt"] = "\n  Your choice > ",
            ["settingsMenuError"] = "\n  [ERROR] Please enter a number between 0 and 5.",

            // Delete
            ["suppMenuError"] = "\n  [ERROR] Please enter y or n.",
            ["confirmeDeletAccount"] = "\n  [Success] Account deleted!",

            ["changePasswordCurrentPrompt"] = "\n  Enter your current password (r = back)",
            ["deleteAccountConfirmPrompt"] = "\n  Are you sure you want to delete your account? (y/n)",

            // ============================
            // Password Creation
            // ============================
            ["createPasswordTitle"] = "\n  Select options to generate your password.",

            ["createPasswordLengthPrompt"] = "\n  How many characters should your password contain?",
            ["createPasswordLengthErrorNotNumber"] = "\n [ERROR] Please enter a valid number.\n",
            ["createPasswordLengthErrorRange"] = "\n [ERROR] Your password must be between 4 and 48 characters.\n",

            ["createPasswordLettersPrompt"] = "\n  Do you want to include letters in your password? (y/n)",
            ["createPasswordNumbersPrompt"] = "\n\n  Do you want to include numbers in your password? (y/n)",
            ["createPasswordSpecialPrompt"] = "\n\n  Do you want to include special characters in your password? (y/n)",
            ["createPasswordOptionError"] = "\n\n [ERROR] Please enter 'y' to confirm or 'n' to decline.\n",

            ["createPasswordTitlePrompt"] = "\n\n  What title do you want to give your password?\n",
            ["createPasswordTitleError"] = "\n\n  [ERROR] Your title must be between 4 and 24 characters\n",

            ["showGeneratePassword"] = "\n\n  Password: ",
            ["ConfirmedGeneratePassword"] = "\n\n  Do you want to save the password? (y/n)",
            ["passwordSaved"] = "\n  Password saved",

            ["invalideOption"] = "\n  [ERROR] Invalid input",

            // ============================
            // Information Menu
            // ============================
            ["aboutInformation"] = "\n Easy Passwords is a console-based program developed in C#\n" +
               " that allows you to securely manage your personal passwords.\n\n" +
               " Features:\n" +
               "   • Create an account with a username, a master password\n" +
               "     and a unique recovery key.\n" +
               "   • Generate passwords with various options (letters, numbers,\n" +
               "     special characters).\n" +
               "   • View, edit and test the security of your passwords.\n" +
               "   • All data is stored locally in an encrypted file.\n\n" +
               " This program runs entirely locally, with no external database\n" +
               " or third-party service. It is intended for a single user.\n\n" +
               " Author  : Romain Augusto\n" +
               " Version : 1.0\n" +
               " School  : ETML - computer science department\n",

            // ============================
            // Titles
            // ============================
            ["loginTitle"] = " ║                  LOGIN                   ║",
            ["informationTitle"] = "║                 INFORMATION              ║",
            ["homeTitle"] = "║                    HOME                  ║",
            ["settingsTitle"] =    "║                  SETTINGS                ║",

            // ============================
            // Password List
            // ============================
            ["passwordListTitle"] = "\n  Here are all your saved passwords:\n",
            ["passwordListEmpty"] = "\n  No passwords saved yet.\n",
            ["passwordListItem"] = "  ===================================",
            ["passwordListTitleLabel"] = "  Title       : ",
            ["passwordListValueLabel"] = "  Password    : ",
            ["passwordListReturn"] = "\n  Press any key to return to the menu...",

            // ============================
            // Password Management
            // ============================
            ["managePasswordTitle"] = "\n  Password management",
            ["managePasswordEmpty"] = "\n  No passwords saved yet.\n",
            ["managePasswordAddPrompt"] = "    [A] Add a password manually",
            ["managePasswordSelectPrompt"] = "\n  Select a password (number) or [A] to add, [0] to quit",
            ["managePasswordSelectError"] = "\n  [ERROR] Invalid selection.",
            ["managePasswordActionTitle"] = "\n  What would you like to do?",
            ["managePasswordAction1"] = "    [1] Edit title",
            ["managePasswordAction2"] = "    [2] Edit password",
            ["managePasswordAction3"] = "    [3] Delete",
            ["managePasswordAction0"] = "    [0] Back",
            ["managePasswordActionPrompt"] = "\n  Your choice > ",
            ["managePasswordActionError"] = "\n  [ERROR] Please enter 0, 1, 2 or 3.",
            ["managePasswordNewTitlePrompt"] = "\n  New title:\n",
            ["managePasswordNewTitleError"] = "\n  [ERROR] Title must be between 4 and 24 characters.\n",
            ["managePasswordTitleUpdated"] = "\n  [Success] Title updated!",
            ["managePasswordNewValuePrompt"] = "\n  New password:\n",
            ["managePasswordNewValueError"] = "\n  [ERROR] Password cannot be empty.\n",
            ["managePasswordValueUpdated"] = "\n  [Success] Password updated!",
            ["managePasswordDeleteConfirm"] = "\n  Are you sure you want to delete this password? (y/n)",
            ["managePasswordDeleteError"] = "\n  [ERROR] Please enter y or n.",
            ["managePasswordDeleted"] = "\n  [Success] Password deleted!",
            ["managePasswordAddTitle"] = "\n  Manual password entry",
            ["managePasswordAddTitlePrompt"] = "\n  Password title:\n",
            ["managePasswordAddTitleError"] = "\n  [ERROR] Title must be between 4 and 24 characters.\n",
            ["managePasswordAddValuePrompt"] = "\n  Password:\n",
            ["managePasswordAddValueError"] = "\n  [ERROR] Password cannot be empty.\n",
            ["managePasswordAddSuccess"] = "\n  [Success] Password added!",

            // ============================
            // Password Test
            // ============================
            ["testPasswordTitle"] = "\n  Enter a password to test its security",
            ["testPasswordPrompt"] = "\n  Password: ",
            ["testPasswordLengthError"] = "\n  [ERROR] Your password must be at least 4 characters\n",
            ["testPasswordAttack"] = "  ATTACK IN PROGRESS",
            ["testPasswordAttempt"] = "  Attempt: ",
            ["testPasswordFound"] = "  Password found: ",
            ["testPasswordTime"] = "  Time elapsed   : ",
            ["testPasswordScore"] = "  Security score : ",
            ["testPasswordSeconds"] = " seconds",
            ["testPasswordReturn"] = "\n  Press any key to return to the menu...",
            ["testPasswordScore1"] = "  1/10  Extremely weak — simple password",
            ["testPasswordScore2"] = "  2/10  Very weak — cracked in seconds",
            ["testPasswordScore3"] = "  3/10  Weak — low resistance",
            ["testPasswordScore4"] = "  4/10  Poor — improvements needed",
            ["testPasswordScore5"] = "  5/10  Passable — could be better",
            ["testPasswordScore6"] = "  6/10  Fair — moderate resistance",
            ["testPasswordScore7"] = "  7/10  Good — fairly strong",
            ["testPasswordScore8"] = "  8/10  Very good — well secured",
            ["testPasswordScore9"] = "  9/10  Excellent — very hard to crack",
            ["testPasswordScore10"] = "  10/10  Perfect — maximum security",
        };
    }
}
