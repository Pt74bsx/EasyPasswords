/******************************************************************************
** PROGRAMME  PasswordScorer.cs                                              **
**            Calcul du score de sécurité d'un mot de passe (1–10)           **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System;
using System.Linq;

namespace EasyPasswords_Augusto.Helpers
{
    /// <summary>
    /// Calcule un score de sécurité entre 1 et 10 en fonction de :
    ///  - la longueur du mot de passe        (0–3 pts)
    ///  - la diversité des caractères        (0–4 pts)
    ///  - le temps de crack mesuré en live   (0–3 pts)
    /// </summary>
    internal static class PasswordScorer
    {
        private const string SPECIAL_CHARS = "!@#$%^&*()-_=+[]{};:,.<>?";

        /// <summary>
        /// Retourne un score entre 1 et 10.
        /// <paramref name="secondsToCrack"/> est le temps réel mesuré par le brute-force intégré.
        /// </summary>
        public static int Calculate(string password, double secondsToCrack)
        {
            int score = 0;

            score += LengthScore(password.Length);
            score += DiversityScore(password);
            score += CrackTimeScore(secondsToCrack);

            if (score < 1) score = 1;
            if (score > 10) score = 10;

            return score;
        }

        // ── Composantes du score ───────────────────────────────────────────────

        private static int LengthScore(int length)
        {
            if (length >= 16) return 3;
            if (length >= 12) return 2;
            if (length >= 8) return 1;
            return 0;
        }

        private static int DiversityScore(string password)
        {
            int pts = 0;
            if (password.Any(char.IsLower)) pts++;
            if (password.Any(char.IsUpper)) pts++;
            if (password.Any(char.IsDigit)) pts++;
            if (password.Any(c => SPECIAL_CHARS.Contains(c))) pts++;
            return pts;
        }

        private static int CrackTimeScore(double seconds)
        {
            if (seconds > 60) return 3;
            if (seconds > 10) return 2;
            if (seconds > 1) return 1;
            return 0;
        }
    }
}