using System.Collections.Generic;
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
    

    [Header("Actions")] 
    public List<ActionData> availableActions;


    [Header("Base statistics")] 
    public CombatStats baseStats;
}
