using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public void InitializeCombat(List<Character> playerParty, List<Combatant> enemyParty)
    {
        // TODO
    }
    
    public void ExecuteAction(Combatant attacker, List<IDamageable> targets, ActionData action)
    {
        bool result = action.Execute(attacker, targets); // retourne true ou false si l'action a réussi ou échoué TODO: Handle return value
        if (result)
        {
            Debug.Log($"{attacker.BaseData.entityName} a réussi son action woooo");
        }
        else
        {
            Debug.Log($"{attacker.BaseData.entityName} n'a pas réussi son action boooo");
        }
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
