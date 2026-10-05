using UnityEngine;

// Enemy GameObject used in Unity
public class EnemyEntity : MonoBehaviour
{
    private Enemy _enemyState;

    public void Initialize(Enemy enemyState)
    {
        _enemyState = enemyState;
        
        Debug.Log($"Character {_enemyState.BaseData.name} initialized.");
        
        //TODO charger tout ce qui est UI etc... ?
        
        // Subscribe to character events
        _enemyState.OnHealthChanged += UpdateHealthBar;
        _enemyState.OnManaChanged += UpdateManaBar;

        //TODO charger tout ce qui est UI etc... ?
    }

    private void UpdateHealthBar(int currentHP, int maxHP)
    {
        // TODO 
    }

    private void UpdateManaBar(int currentMP, int maxMP)
    {
        // TODO
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     
    // }
    
    private void OnDestroy()
    {
        if (_enemyState == null) return;
        
        // Unsubscribe from character events
        _enemyState.OnHealthChanged -= UpdateHealthBar;
        _enemyState.OnManaChanged -= UpdateManaBar;
    }
}
