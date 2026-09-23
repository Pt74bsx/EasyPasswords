<div align="center">

# 🔑 EasyPasswords

### Gestionnaire de mots de passe en console développé en C#

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Security](https://img.shields.io/badge/thème-cybersécurité-success?style=for-the-badge)

</div>

## 📖 Présentation

**EasyPasswords** est une application console permettant de gérer des comptes et leurs mots de passe depuis une interface textuelle structurée. Le projet réunit la génération de mots de passe, l'évaluation de leur robustesse, la gestion des données et leur protection dans des fichiers.

L'objectif principal est d'appliquer la programmation orientée objet à un cas concret lié à la cybersécurité, tout en séparant clairement la logique métier, l'interface et les fonctions utilitaires.

> Ce projet est pédagogique. Avant toute utilisation avec des secrets réels, le modèle de sécurité, le stockage et le chiffrement doivent faire l'objet d'un audit approfondi.

## ✨ Fonctionnalités

- gestion d'entrées de comptes ;
- ajout, consultation, modification et suppression de données ;
- génération de mots de passe ;
- analyse de la robustesse d'un mot de passe ;
- protection des données enregistrées ;
- menus interactifs en console ;
- messages disponibles dans une structure dédiée aux langues ;
- organisation modulaire facilitant la maintenance.

## 🧱 Architecture

Le projet sépare les responsabilités dans plusieurs dossiers :

| Dossier | Responsabilité |
|---|---|
| `Core` | Logique principale de gestion et de persistance |
| `Helpers` | Génération et évaluation des mots de passe |
| `UI` | Affichage, menus et interactions avec l'utilisateur |
| `Language` | Textes et ressources linguistiques |
| `Properties` | Configuration et métadonnées du projet |

### Classes principales

- **AccountManager** : orchestre la gestion des comptes ;
- **FileEncryption** : prend en charge la protection des fichiers ;
- **PasswordManager** : gère les opérations liées aux mots de passe ;
- **PasswordGenerator** : construit de nouveaux mots de passe ;
- **PasswordScorer** : attribue un niveau de robustesse ;
- **ConsoleUI** : centralise les interactions avec la console ;
- **Menus** : organise la navigation dans l'application.

## 🛠️ Technologies

- C# ;
- .NET ;
- application console ;
- Visual Studio ;
- programmation orientée objet ;
- gestion de fichiers ;
- mécanismes de chiffrement et de protection des données.

## 🗂️ Structure du dépôt

```text
EasyPasswords/
├── EasyPasswords/
│   ├── EasyPasswords.sln
│   └── EasyPasswords/
│       ├── Core/
│       │   ├── AccountManager.cs
│       │   ├── FileEncryption.cs
│       │   └── PasswordManager.cs
│       ├── Helpers/
│       │   ├── PasswordGenerator.cs
│       │   └── PasswordScorer.cs
│       ├── Language/
│       ├── UI/
│       │   ├── ConsoleUI.cs
│       │   └── Menus.cs
│       └── Program.cs
├── doc/
└── README.md
```

## 🚀 Installation et lancement

### Prérequis

- Windows ;
- Visual Studio avec les outils de développement .NET ;
- Git, facultatif si tu télécharges le projet en ZIP.

### Installation

1. Clone le dépôt :

   ```bash
   git clone https://github.com/Pt74bsx/EasyPasswords.git
   ```

2. Ouvre `EasyPasswords/EasyPasswords.sln` dans Visual Studio.
3. Vérifie que le projet `EasyPasswords` est défini comme projet de démarrage.
4. Compile la solution.
5. Lance l'application avec **F5** ou **Ctrl+F5**.

## 🖥️ Utilisation

L'application se contrôle depuis les menus affichés dans la console :

1. démarre le programme ;
2. sélectionne une action dans le menu ;
3. crée ou consulte une entrée ;
4. génère un mot de passe ou évalue un mot de passe existant ;
5. enregistre les changements ;
6. quitte proprement l'application afin de finaliser la sauvegarde.

Les intitulés précis peuvent évoluer avec le développement du projet.

## 🛡️ Bonnes pratiques de sécurité

- n'ajoute jamais de véritables identifiants dans les commits ;
- ne publie pas les fichiers de données générés localement ;
- utilise un mot de passe principal long et unique si cette fonction est activée ;
- conserve des sauvegardes chiffrées dans un emplacement sûr ;
- n'affiche pas les mots de passe dans des captures d'écran ;
- vérifie le comportement du chiffrement avant toute utilisation réelle ;
- évite de synchroniser automatiquement les données sensibles.

## 🧠 Compétences travaillées

- conception orientée objet ;
- séparation des responsabilités ;
- manipulation et persistance de fichiers ;
- validation des entrées ;
- création d'une interface console ;
- génération aléatoire ;
- évaluation de la qualité des mots de passe ;
- sensibilisation aux contraintes de sécurité.

## ⚠️ Limites actuelles

- application pédagogique non auditée ;
- interface uniquement en console ;
- compatibilité principalement pensée pour Windows et Visual Studio ;
- absence de tests automatisés visibles dans le dépôt ;
- format de stockage susceptible d'évoluer.

## 🔭 Améliorations possibles

- ajouter des tests unitaires ;
- documenter précisément le format de stockage ;
- renforcer la dérivation de clé et la gestion des secrets ;
- ajouter un verrouillage automatique ;
- permettre l'importation et l'exportation ;
- créer une interface graphique ;
- ajouter une recherche et des catégories ;
- publier des versions exécutables signées.

## 📚 Documentation

Le dossier `doc` contient le cahier du projet, le rapport et le journal de travail.

## 🎓 Contexte

Projet réalisé à l'ETML pour approfondir la programmation orientée objet et la sécurité applicative.

## 📄 Licence

Le code source original est distribué sous licence MIT. Consulte le fichier [LICENSE](LICENSE).

---

<div align="center">
Développé par <a href="https://github.com/Pt74bsx">Romain-Augusto</a>.
</div>
