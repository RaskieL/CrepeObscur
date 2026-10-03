using UnityEngine;

public abstract class CombatantData : ScriptableObject
{
    [Header("Identity")] 
    public string entityName;
    [TextArea(3, 5)] 
    public string description;
    public Sprite portrait;
    //[TODO] add sprites later

    /*
    [TODO] implémenter un système de caractéristiques plus complexe (force, dextérité, constitution etc.)
    [TODO] ne pas oublier de mettre à jour les personnages/ennemis déjà créés;
    */
    [Header("Base character stats")] 
    public int baseStrength = 10;
    public int baseDexterity = 10;
    public int baseConstitution = 10;
    public int baseWisdom = 10;
    public int baseIntelligence = 10;
    public int baseCharisma = 10;
    
    
    // [Header("Base statistics")] 
    // public int baseHealth = 100; -> constitution * 10 ?
    // public int baseMana = 100; -> intelligence * 10 ?
}
