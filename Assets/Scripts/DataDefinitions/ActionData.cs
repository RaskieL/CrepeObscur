using System.Collections.Generic;
using UnityEngine;

public enum TargetType { SingleEnemy, AllEnemies, SingleAlly, AllAllies, All, Self }
public abstract class ActionData : ScriptableObject
{
    public string actionName;
    [TextArea] public string description;
    public TargetType targetType;

    public int basePower;
    public int manaCost;
    
    public abstract bool Execute(Combatant caster, List<IDamageable> targets);
}
