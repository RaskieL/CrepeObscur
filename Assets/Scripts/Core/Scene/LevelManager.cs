using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private string _currentScene;
    private List<TravelPoint> CurrentSpawnList; // Current spawn list object

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _currentScene = gameObject.scene.name;

        Debug.Log("Current instance of levelManager : " + Instance);
    }

    /// <summary>
    /// Teleport the player to the specified point, will change his scene before doing so
    /// </summary>
    /// <param name="scene">Scene to be teleported to</param>
    /// <param name="spawnPointName"></param>
    /// <param name="previousTravelPoint"></param>
    public void TeleportPlayer(string scene, string spawnPointName, TravelPoint previousTravelPoint)
    {
        if (_currentScene == null) 
        {
            Debug.LogError("No current scene detected");
        }

        if (previousTravelPoint.sceneName == scene)
        {
            MovePlayer(spawnPointName);
        }
        else
        {
            Debug.Log("Change to scene : " + scene + " previous scene was : " + _currentScene);
            // change player scene and teleport it to the set point
        }
    }

    // Register a new spawnList
    public void RegisterSpawnList(List<TravelPoint> list) { CurrentSpawnList = list; }

    // Unregister the current spawnList
    public void UnRegisterSpawnList(List<TravelPoint> list)
    {
        if (Instance != null)
        {
            if(list == Instance.CurrentSpawnList) { CurrentSpawnList = null; }
        }
    }

    //Not really optimized
    private void MovePlayer(string spawnPointName)
    {
        TravelPoint _tpPoint;
        _tpPoint = CurrentSpawnList.Find(spawn => spawn.name == spawnPointName);

        _player.transform.position = _tpPoint.transform.position;
    }
}
