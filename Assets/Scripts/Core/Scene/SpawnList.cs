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

    private void Start()
    {
        LevelManager.Instance.RegisterSpawnList(_spawnList);
        Debug.Log("SPAWNLIST : " + _spawnList.Count);
        foreach (TravelPoint obj in _spawnList)
        {
            Debug.Log(obj.name);
        }
    }

    private void OnDisable()
    {
        LevelManager.Instance.UnRegisterSpawnList(_spawnList);
    }
}
