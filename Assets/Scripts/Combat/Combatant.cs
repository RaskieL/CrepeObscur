using UnityEngine;
using System;

public abstract class Combatant : IDamageable
{
    public CombatantData BaseData { get; private set; }
    public int CurrentHP { get; protected set; }
    public int MaxHP { get; protected set; }
    public int CurrentMP { get; protected set; }
    public int MaxMP { get; protected set; }
    public int CurrentLevel { get; protected set; }

    // Events
    public event Action<int, int> OnHealthChanged;
    public event Action<int, int> OnManaChanged;

    public Combatant(CombatantData baseData)
    {
        BaseData = baseData;
        CurrentLevel = 1;

        CurrentHP = BaseData.baseConstitution * 10;
        MaxHP = CurrentHP;
        CurrentMP = BaseData.baseIntelligence * 10;
        MaxMP = CurrentMP;
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
        }
        
        OnHealthChanged?.Invoke(CurrentHP, MaxHP);
    }

    public virtual void Heal(int amount)
    {
        CurrentHP += amount;
        if(CurrentHP > MaxHP) 
        {
            CurrentHP = MaxHP;
        }
        
        OnHealthChanged?.Invoke(CurrentHP, MaxHP);
    }

    public virtual void UseMana(int manaAmount)
    {
        CurrentMP -= manaAmount;
        
        OnManaChanged?.Invoke(CurrentMP, MaxMP);
    }

    public virtual void GainMana(int manaAmount)
    {
        CurrentMP += manaAmount;
        
        OnManaChanged?.Invoke(CurrentMP, MaxMP);
    }

    public virtual bool IsDead() => CurrentHP <= 0;
}
