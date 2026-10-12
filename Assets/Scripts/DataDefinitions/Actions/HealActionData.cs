using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrepeObscur/Combat/Actions/Heal Action")]
public class HealActionData : ActionData
{
    public override bool Execute(Combatant caster, List<IDamageable> targets)
    {
        if (!caster.TryUseMana(manaCost))
        {
            return false;
        }
        
        int healPower = (basePower * caster.MagicAttackStat) / 3;

        foreach (Combatant target in targets)
        {
            target.Heal(healPower);
        }

        return true;
    }
}
