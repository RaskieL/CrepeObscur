using UnityEngine;

public interface IDamageable
{
    int CurrentHP { get; }
    int MaxHP { get; }
    int CurrentMP { get; }
    int MaxMP { get; }
    int CurrentLevel { get; }
    void TakeDamage(int amount);
    void Heal(int amount);
    bool IsDead();
}
