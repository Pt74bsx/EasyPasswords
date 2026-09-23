/******************************************************************************
** PROGRAMME  fr.cs                                                          **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Romain Augusto                                                **
** Date      : 16.01.2026  |  13.03.2026                                     **
**                                                                           **
******************************************************************************/

using System.Collections.Generic;
namespace EasyPasswords_Augusto.Language
{
    public static class FR
    {
        public static readonly Dictionary<string, string> Textes = new Dictionary<string, string>
        {
            // ============================
            // Création du compte
            // ============================
            ["introductionMessage"] = "\n Bonjour !\n\n Bienvenue dans Easy Passwords.\n" +
                                                      " Ce programme vous permet de gérer vos mots de passe en toute sécurité,\n" +
                                                      " de créer des mots de passes avec divers options, importer vos propres mot de passe, \n" +
                                                      " modifier vos mot de passe, consulter vos mots de passe et tester leur sécurité.\n\n" +
                                                      " Appuyez sur une touche pour commencer la création de votre compte ...",
            ["titleCreatQuestion"] = "\n Voici plusieurs questions auxquelles vous devez répondre afin de finaliser la création de votre compte.",

            ["usernameQuestion"] = "\n Quel nom d'utilisateur vous voulez mettre ?\n",
            ["usernameError"] = "\n [ERREUR] Votre pseudo doit faire entre 4 et 12 caractères\n",

            ["passwordQuestion"] = "\n Choisissez un mot de passe\n",
            ["passwordConfirmQuestion"] = "\n Re-tapez votre mot de passe\n",
            ["passwordError"] = "\n [ERREUR] Votre mot de passe doit faire entre 8 et 24 caractères\n",
            ["passwordConfirmError"] = "\n [ERREUR] Votre mot de passe ne correspond pas\n",

            ["recoveryKeyWarning"] = "\n [ATTENTION !] Génération de la clé de récupération.\n",
            ["recoveryKeyMessage"] = "\n NE PERDEZ ABSOLUMENT PAS CETTE CLÉ et ne la partagez sous aucun prétexte." +
                                                      "\n Elle est indispensable pour récupérer l'accès à votre compte en cas d'oubli." +
                                                      "\n\n Appuyez sur une touche pour générer la clé ...",
            ["recoveryKeyDisplay"] = "\n\n Voici votre clé de récupération",
            ["pressToContinue"] = "\n\n Appuyez sur une touche pour continuer ...",

            // ============================
            // Menu de connexion
            // ============================
            ["loginMenuChoice"] = "  [1] Connection    [2] Mot de passe oublié\n",
            ["loginMenuChoice2"] = "  [3] Informations  [0] Quitter            ",
            ["loginMenuPrompt"] = "\n  Votre choix > ",
            ["loginMenuError"] = "\n  [ERREUR] Veuillez entrer un chiffre entre 0 et 3.",

            ["loginUsernamePrompt"] = "\n  Nom d'utilisateur (0 = retour)",
            ["loginPasswordPrompt"] = "\n  Mot de passe (0 = retour)",
            ["loginError"] = "\n  [ERREUR] Nom d'utilisateur ou mot de passe incorrect.",
            ["loginSuccess"] = "\n  [Succès] Connexion accordée !",

            ["forgotPasswordPrompt"] = "\n  Entrez votre clée de récupération (0 = retour)",
            ["forgotPasswordError"] = "\n  [ERREUR] Clée incorrect",
            ["forgotPasswordNewPrompt"] = "\n  Choisissez un mot de passe\n",
            ["forgotPasswordConfirmPrompt"] = "\n  Re-tapez votre mot de passe\n",
            ["forgotPasswordSuccess"] = "\n   [Succès] Mot de passe changé !",
            ["forgotPasswordLengthError"] = "\n  [ERREUR] Votre mot de passe doit faire entre 8 et 24 caractères\n",
            ["forgotPasswordMatchError"] = "\n  [ERREUR] Votre mot de passe ne correspond pas\n",

            // ============================
            // Menu d'accueil
            // ============================
            ["homeMenuChoice1"] = "    [1] Créer un mot de passe    [2] Liste des mots de passe\n",
            ["homeMenuChoice2"] = "    [3] Gérer les mots de passe  [4] Tester un mot de passe \n",
            ["homeMenuChoice3"] = "    [5] Paramètre                [0] Quitter                  ",
            ["homeMenuPrompt"] = "\n  Votre choix > ",
            ["homeMenuError"] = "\n  [ERREUR] Veuillez entrer un chiffre entre 0 et 5.",

            // ============================
            // Menu paramètre
            // ============================
            ["settingsMenuChoice1"] = "    [1] Modifier son nom d'utilisateur      [2] Modifier son mot de passe\n",
            ["settingsMenuChoice2"] = "    [3] Informations                        [4] Supprimer son compte     \n",
            ["settingsMenuChoice3"] = "    [5] Modifier la langue                  [0] Quitter                  ",
            ["settingsMenuPrompt"] = "\n  Votre choix > ",
            ["settingsMenuError"] = "\n  [ERREUR] Veuillez entrer un chiffre entre 0 et 5.",

            // Supp
            ["suppMenuError"] = "\n  [ERREUR] Veuillez entrer o ou n.",
            ["confirmeDeletAccount"] = "\n  [Succès] Compte supprimé !",

            ["changePasswordCurrentPrompt"] = "\n  Entrez votre mot de passe actuel (r = retour)",
            ["deleteAccountConfirmPrompt"] = "\n  Êtes-vous sûr de vouloir supprimer votre compte ? (o/n)",

            // ============================
            // Création de mot de passe
            // ============================
            ["createPasswordTitle"] = "\n  Sélectionnez les options pour générer votre mot de passe.",

            ["createPasswordLengthPrompt"] = "\n  Combien de caractères doit contenir votre mot de passe ?",
            ["createPasswordLengthErrorNotNumber"] = "\n [ERREUR] Veuillez entrer un nombre valide.\n",
            ["createPasswordLengthErrorRange"] = "\n [ERREUR] Votre mot de passe doit faire entre 4 et 48 caractères.\n",

            ["createPasswordLettersPrompt"] = "\n  Voulez-vous inclure des lettres dans votre mot de passe ? (o/n)",
            ["createPasswordNumbersPrompt"] = "\n\n  Voulez-vous inclure des chiffres dans votre mot de passe ? (o/n)",
            ["createPasswordSpecialPrompt"] = "\n\n  Voulez-vous inclure des caractères spéciaux dans votre mot de passe ? (o/n)",
            ["createPasswordOptionError"] = "\n\n [ERREUR] Veuillez entrer 'o' pour valider ou 'n' pour ne pas valider.\n",

            ["createPasswordTitlePrompt"] = "\n\n  Quel titre voulez-vous donner à votre mot de passe ?\n",
            ["createPasswordTitleError"] = "\n\n  [ERREUR] Votre titre doit faire entre 4 et 24 caractères\n",

            ["showGeneratePassword"] = "\n\n  Mot de passe : ",
            ["ConfirmedGeneratePassword"] = "\n\n  Voulez-vous sauvegarder le mot de passe ? (o/n)",
            ["passwordSaved"] = "\n  Le mot de passe a été sauvegardé",

            ["invalideOption"] = "\n  [ERREUR] Entrée invalide",

            // ============================
            // Menu Informations
            // ============================
            ["aboutInformation"] = "\n Easy Passwords est un programme en mode console développé en C#\n" +
                       " permettant de gérer de manière sécurisée vos mots de passe personnels.\n\n" +
                       " Fonctionnalités :\n" +
                       "   • Créer un compte avec un nom d'utilisateur, un mot de passe maître\n" +
                       "     et une clé de récupération unique.\n" +
                       "   • Générer des mots de passe avec diverses options (lettres, chiffres,\n" +
                       "     caractères spéciaux).\n" +
                       "   • Consulter, modifier et tester la sécurité de vos mots de passe.\n" +
                       "   • Toutes les données sont stockées localement dans un fichier chiffré.\n\n" +
                       " Ce programme fonctionne entièrement en local, sans base de données\n" +
                       " externe ni service tiers. Il est destiné à un utilisateur unique.\n\n" +
                       " Auteur  : Romain Augusto\n" +
                       " Version : 1.0\n" +
                       " École   : ETML - section informatique\n",

            // ============================
            // Title
            // ============================
            ["loginTitle"] = " ║                  CONNEXION               ║",
            ["informationTitle"] = " ║               INFORMATIONS               ║",
            ["homeTitle"] = " ║                  ACCUEIL                 ║",
            ["settingsTitle"] = " ║                  PARAMÈTRE               ║",

            // ============================
            // Liste des mots de passe
            // ============================
            ["passwordListTitle"] = "\n  Voici tous vos mots de passe sauvegardés :\n",
            ["passwordListEmpty"] = "\n  Aucun mot de passe sauvegardé pour l'instant.\n",
            ["passwordListItem"] = "  ===================================",
            ["passwordListTitleLabel"] = "  Titre      : ",
            ["passwordListValueLabel"] = "  Mot de passe : ",
            ["passwordListReturn"] = "\n  Appuyez sur une touche pour retourner au menu...",

            // ============================
            // Gestion des mots de passe
            // ============================
            ["managePasswordTitle"] = "\n  Gestion des mots de passe",
            ["managePasswordEmpty"] = "\n  Aucun mot de passe sauvegardé pour l'instant.\n",
            ["managePasswordAddPrompt"] = "    [A] Ajouter un mot de passe manuellement",
            ["managePasswordSelectPrompt"] = "\n  Sélectionnez un mot de passe (numéro) ou [A] pour ajouter, [0] pour quitter",
            ["managePasswordSelectError"] = "\n  [ERREUR] Sélection invalide.",
            ["managePasswordActionTitle"] = "\n  Que voulez-vous faire ?",
            ["managePasswordAction1"] = "    [1] Modifier le titre",
            ["managePasswordAction2"] = "    [2] Modifier le mot de passe",
            ["managePasswordAction3"] = "    [3] Supprimer",
            ["managePasswordAction0"] = "    [0] Retour",
            ["managePasswordActionPrompt"] = "\n  Votre choix > ",
            ["managePasswordActionError"] = "\n  [ERREUR] Veuillez entrer 0, 1, 2 ou 3.",
            ["managePasswordNewTitlePrompt"] = "\n  Nouveau titre :\n",
            ["managePasswordNewTitleError"] = "\n  [ERREUR] Le titre doit faire entre 4 et 24 caractères.\n",
            ["managePasswordTitleUpdated"] = "\n  [Succès] Titre modifié !",
            ["managePasswordNewValuePrompt"] = "\n  Nouveau mot de passe :\n",
            ["managePasswordNewValueError"] = "\n  [ERREUR] Le mot de passe ne peut pas être vide.\n",
            ["managePasswordValueUpdated"] = "\n  [Succès] Mot de passe modifié !",
            ["managePasswordDeleteConfirm"] = "\n  Êtes-vous sûr de vouloir supprimer ce mot de passe ? (o/n)",
            ["managePasswordDeleteError"] = "\n  [ERREUR] Veuillez entrer o ou n.",
            ["managePasswordDeleted"] = "\n  [Succès] Mot de passe supprimé !",
            ["managePasswordAddTitle"] = "\n  Ajout manuel d'un mot de passe",
            ["managePasswordAddTitlePrompt"] = "\n  Titre du mot de passe :\n",
            ["managePasswordAddTitleError"] = "\n  [ERREUR] Le titre doit faire entre 4 et 24 caractères.\n",
            ["managePasswordAddValuePrompt"] = "\n  Mot de passe :\n",
            ["managePasswordAddValueError"] = "\n  [ERREUR] Le mot de passe ne peut pas être vide.\n",
            ["managePasswordAddSuccess"] = "\n  [Succès] Mot de passe ajouté !",

            // ============================
            // Test de mot de passe
            // ============================
            ["testPasswordTitle"] = "\n  Entrez un mot de passe pour tester sa sécurité",
            ["testPasswordPrompt"] = "\n  Mot de passe : ",
            ["testPasswordLengthError"] = "\n  [ERREUR] Votre mot de passe doit faire au moins 4 caractères\n",
            ["testPasswordAttack"] = "  ATTAQUE EN COURS",
            ["testPasswordAttempt"] = "  Tentative : ",
            ["testPasswordFound"] = "  Mot de passe trouvé : ",
            ["testPasswordTime"] = "  Temps écoulé        : ",
            ["testPasswordScore"] = "  Score de sécurité   : ",
            ["testPasswordSeconds"] = " secondes",
            ["testPasswordReturn"] = "\n  Appuyez sur une touche pour retourner au menu...",
            ["testPasswordScore1"] = "  1/10  Extrêmement faible — mot de passe simple",
            ["testPasswordScore2"] = "  2/10  Très faible — cracké en quelques secondes",
            ["testPasswordScore3"] = "  3/10  Faible — peu résistant",
            ["testPasswordScore4"] = "  4/10  Médiocre — améliorations nécessaires",
            ["testPasswordScore5"] = "  5/10  Passable — peut mieux faire",
            ["testPasswordScore6"] = "  6/10  Correct — résistance modérée",
            ["testPasswordScore7"] = "  7/10  Bon — assez robuste",
            ["testPasswordScore8"] = "  8/10  Très bon — bien sécurisé",
            ["testPasswordScore9"] = "  9/10  Excellent — très difficile à craquer",
            ["testPasswordScore10"] = "  10/10  Parfait — sécurité maximale",
        };
    }
}