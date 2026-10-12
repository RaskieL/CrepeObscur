using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrepeObscur/Combat/Actions/Damage Action")]
public class DamageActionData : ActionData
{
    public bool isMagic;

    public override bool Execute(Combatant caster, List<IDamageable> targets)
    {
        if (!caster.TryUseMana(manaCost))
        {
            return false;
        }

        int atk = isMagic ? caster.MagicAttackStat : caster.PhysicalAttackStat;

        foreach (Combatant target in targets)
        {
            int def = isMagic ? target.MagicDefenseStat : target.DefenseStat;
            
            float mitigation = (float)atk / (atk + def);
            int damage = Mathf.Max(1, Mathf.RoundToInt(basePower * mitigation));

            target.TakeDamage(damage);
        }

        return true;
    }
}