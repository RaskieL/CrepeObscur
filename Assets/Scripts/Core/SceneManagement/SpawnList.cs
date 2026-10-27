using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnList : MonoBehaviour
{
    [SerializeField] public List<TravelPoint> _spawnList = new();
    public static SpawnList Current { get; private set; }
    
    private void Awake()
    {
        if (_spawnList == null)
        {
            Debug.LogWarning("There is no set spawn point inside : " + gameObject.scene.name);
        }
    }

    private void OnEnable() 
    { 
        Current = this; 
    }

    private void OnDisable() 
    { 
        if (Current == this) Current = null; 
    }

    //private void OnEnable()
    //{
    //    Debug.Log("CACA PIPI");
    //    LevelManager.Instance.RegisterSpawnList(_spawnList);
    //    foreach (TravelPoint obj in _spawnList)
    //    {
    //        Debug.Log(obj.name);
    //    }
    //}

    //private void OnDisable()
    //{
    //    LevelManager.Instance.UnRegisterSpawnList(_spawnList);
    //}
}