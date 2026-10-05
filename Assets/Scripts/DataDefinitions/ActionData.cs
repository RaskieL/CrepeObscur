using UnityEngine;

public enum ActionType { Attack, Heal, Skill }
public enum TargetType { SingleEnemy, AllEnemies, SingleAlly, AllAllies, All, Self }

[CreateAssetMenu(menuName = "CrepeObscur/Combat/Action")]
public class ActionData : ScriptableObject
{
    public string actionName;
    [TextArea] public string description;
    
    public ActionType actionType;
    public TargetType targetType;

    public int basePower;
    public int manaCost;

    public bool isMagicAttack; // TODO pour séparer les attaques physiques des attaques magiques plus tard...
}
