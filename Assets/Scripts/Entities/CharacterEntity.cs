using UnityEngine;

// TODO Abstract this with EnemyEntity using a CombatantEntity base class ?

// Character GameObject used in Unity
public class CharacterEntity : MonoBehaviour
{
    private Character _characterState;

    public void Initialize(Character characterState)
    {
        _characterState = characterState;
        
        Debug.Log($"Character {_characterState.BaseData.name} initialized.");

        // Subscribe to character events
        _characterState.OnHealthChanged += UpdateHealthBar;
        _characterState.OnManaChanged += UpdateManaBar;

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
        if (_characterState == null) return;
        
        // Unsubscribe from character events
        _characterState.OnHealthChanged -= UpdateHealthBar;
        _characterState.OnManaChanged -= UpdateManaBar;
    }
}
