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

    [Header("Actions")] 
    public List<ActionData> availableActions;


    [Header("Base statistics")] 
    public CombatStats baseStats;
}
