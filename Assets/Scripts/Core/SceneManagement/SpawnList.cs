using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour
{
    [SerializeField] public List<TravelPoint> _spawnList = new();
    public static SpawnList Current { get; private set; }
    
    private void Awake()
    {
        if (_spawnList == null)
        {
            Debug.LogWarning($"There is no set spawn point inside : {gameObject.scene.name}");
        }
    }

    private void OnEnable() 
    { 
        Current = this; 
    }

    // Remove the object when unloading the scene
    private void OnDisable() 
    {
        if (Current == this) { Current = null; } 
    }
}