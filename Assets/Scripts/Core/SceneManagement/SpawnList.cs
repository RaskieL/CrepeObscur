using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnList : MonoBehaviour
{
    [SerializeField] public List<TravelPoint> _spawnList;

    private void Awake()
    {
        if (_spawnList == null)
        {
            Debug.LogWarning("There is no set spawn point inside : " + gameObject.scene.name);
        }
    }

    private void OnEnable()
    {
        LevelManager.Instance.RegisterSpawnList(_spawnList);
    }

    private void OnDisable()
    {
        LevelManager.Instance.UnRegisterSpawnList(_spawnList);
    }
}
