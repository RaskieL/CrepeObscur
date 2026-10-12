using UnityEngine;
using System;

public abstract class Combatant : IDamageable
{
    public CombatantData BaseData { get; private set; }
    public int CurrentHP { get; protected set; }
    public int CurrentMP { get; protected set; }
    public int CurrentLevel { get; protected set; }
    
    // Characteristics
    public CombatStats Stats { get; protected set; }
    public int MaxHP => Stats.maxHealth;
    public int MaxMP => Stats.maxMana;
    public int PhysicalAttackStat => Stats.physAttack;
    public int MagicAttackStat => Stats.magicAttack;
    public int DefenseStat => Stats.physDefense;
    public int MagicDefenseStat => Stats.magicDefense;
    
    public int SpeedStat => Stats.speed;

    // Events
    public event Action<int, int> OnHealthChanged;
    public event Action<int, int> OnManaChanged;

    public Combatant(CombatantData baseData)
    {
        BaseData = baseData;
        Stats = baseData.baseStats;
        
        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
        CurrentLevel = 1;
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHP = Math.Max(CurrentHP - amount, 0);
        
        OnHealthChanged?.Invoke(CurrentHP, MaxHP);
    }

    public virtual void Heal(int amount)
    {
        CurrentHP = Math.Min(CurrentHP + amount, MaxHP);
        
        OnHealthChanged?.Invoke(CurrentHP, MaxHP);
    }

    public virtual bool HasEnoughMana(int amount) => CurrentMP >= amount;

    public virtual bool TryUseMana(int manaAmount)
    {
        if (!HasEnoughMana(manaAmount)) return false;

        CurrentMP = Math.Max(0, CurrentMP - manaAmount);
        OnManaChanged?.Invoke(CurrentMP, MaxMP);
        return true;
    }

    public virtual void GainMana(int manaAmount)
    {
        CurrentMP = Math.Min(CurrentMP + manaAmount, MaxMP);
        
        OnManaChanged?.Invoke(CurrentMP, MaxMP);
    }

    public virtual bool IsDead() => CurrentHP <= 0;
}
