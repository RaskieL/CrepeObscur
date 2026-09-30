# Projet crêpes

## Présentation
CrêpeObscur est un projet loisir de jeu vidéo réalisé par des étudiants de Master 1 Informatique à l'Université Lumière Lyon 2. 
Les développeurs sont: 
- Orlana 
- Yanis 
- Oriel 
- Lynn 
- Maïken 

CrêpeObscur est un jeu de type RPG en tour par tour dungeon crawler. Le joueur compose son équipe parmi les personnages proposés et part à l'aventure pour vaincre monstres et Boss gardant précieusement la recette de crêpe ultime ! 

## Technologies
Unity 6.3 LTS 
Visual Studio 
JetBrains Rider 


## Convention de nommage
[Référence Unity](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)

Les nom des variables, fonctions, class, méthodes et des fichiers doivent être en ANGLAIS. 
Les commentaires peuvent être en français ou en anglais. 

Variables :         (camelCase) maVar 
Constante :         (MAJUSCULE) MACONST 
Enum :              (PascalCase) MonEnum 
Méthodes :          (PascalCase) MaMethode 
Class :             (PascalCase) MaClasse 
Class(interface) :  (I + PascalCase) IMonInterface 

Exemple :  
```csharp
public interface IMonInterface { 
    MonEnum isKaboom(); 
} 

public class MaClasse : IMonInterface { 
    private int maVar = 5; 
    protected const int MACONST = 1; 

    enum MonEnum { 
        Low, 
        Medium, 
        High 
    } 

    public int MaMethode() { 
        return maVar + MACONST; 
    } 

    public MonEnum isKaboom() { 
        return (MaMethode() > 5 ? MonEnum.High : MonEnum.Low); 
    } 
} 
```
Pour les commits git ajouter un préfix : 
    - [ADD] Ajout fonctionnalité 
    - [FIX] Réparation problème 
    - [DEL] Suppression 
    - [MODIF] Changement d'un fichier 
