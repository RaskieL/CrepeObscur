using UnityEngine;

// Character Runtime Data
[System.Serializable] // Permettra la sauvegarde dans un fichier JSON plus tard ?
public class Character : Combatant
{
    // TODO add stats unique to hero
    public string ClassName {get; private set;}

    public Character(CharacterData baseData) : base(baseData)
    {
        //TODO plus tard faire attention lorsqu'on récupèrera les données depuis une sauvegarde.
        ClassName = baseData.className;
    }
}
