using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public void ExecuteAction(Combatant attacker, IDamageable target)
    {
        int damage = attacker.BaseData.baseStrength; // calcul simple pour le début
        
        //TODO mettre en place le système de combat utilisant des actions (template définit dans ActionData.cs)
        
        target.TakeDamage(damage); // kaboom !
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
