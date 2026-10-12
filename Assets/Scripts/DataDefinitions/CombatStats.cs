using System;
using UnityEngine;

[Serializable]
public struct CombatStats
{
    [Min(1)] public int maxHealth;
    [Min(0)] public int maxMana; // ou PC ? (Point Crêpe / Point Compétence)
    
    [Min(1)] public int physAttack;
    [Min(1)] public int magicAttack;
    
    [Min(0)] public int physDefense;
    [Min(0)] public int magicDefense;
    
    [Min(1)] public int speed;
}