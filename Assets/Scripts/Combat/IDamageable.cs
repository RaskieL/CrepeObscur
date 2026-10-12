using UnityEngine;

public interface IDamageable
{
    int CurrentHP { get; }
    int MaxHP { get; }
    int DefenseStat { get; }
    int MagicDefenseStat { get; }
    
    void TakeDamage(int amount);
    void Heal(int amount);
    bool IsDead();
}
