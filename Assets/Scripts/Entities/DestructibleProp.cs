using System;
using UnityEngine;

namespace Entities
{
    // TODO: Si jamais on veut des objets destructibles...
    // TODO: Mais rendre compatible CombatManager pour ça...
    public class DestructibleProp : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHP;
        [SerializeField] private int _defense;
        [SerializeField] private int _magicDefense;
        public int CurrentHP { get; protected set;  }
        public int MaxHP => _maxHP;
        public int DefenseStat => _defense;
        public int MagicDefenseStat => _magicDefense;

        public event Action<int, int> OnHealthChanged;

        public void Awake() => CurrentHP = _maxHP;

        public void TakeDamage(int amount)
        {
            CurrentHP = Math.Min(CurrentHP - amount, 0);
            OnHealthChanged?.Invoke(CurrentHP, MaxHP);

            if (IsDead())
            {
                // animation.. explosion.. kaboom..
                Destroy(gameObject);
            }
        }

        public void Heal(int amount)
        {
            CurrentHP = Math.Min(CurrentHP + amount, MaxHP);
            OnHealthChanged?.Invoke(CurrentHP, MaxHP);
        }

        public bool IsDead()
        {
            return CurrentHP <= 0;
        }
    }
}