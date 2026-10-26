using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    /// <param name="spawnPointName">Where we want the player to spawn (which travel Point)</param>
    /// <param name="previousTravelPoint"></param>
    public void TeleportPlayer(string nextSceneName, string spawnPointName, TravelPoint currentTravelPoint)
    {
        if (_currentScene == null) 
        {
            Debug.LogError("No current scene detected");
        }

        if (currentTravelPoint.SceneName == currentTravelPoint.ExitSceneName)
        {
            MovePlayer(currentTravelPoint.ExitName);
        }
        else
        {
            Debug.Log("Change to scene : " + currentTravelPoint.ExitSceneName + " previous scene was : " + currentTravelPoint.SceneName);
            ChangeScene(currentTravelPoint.ExitSceneName, currentTravelPoint.ExitName);
        }
    }

    // Register a new spawnList
    public void RegisterSpawnList(List<TravelPoint> list) 
    {
        Debug.Log("Registered new spawnList : ");
        CurrentSpawnList = list;
    }

    // Unregister the current spawnList
    public void UnRegisterSpawnList(List<TravelPoint> list)
    {
        if (Instance != null)
        {
            Debug.Log("Unregistered the spawnList : ");
            if (list == Instance.CurrentSpawnList) { CurrentSpawnList = null; }
        }
    }

    //Not really optimized
    private void MovePlayer(string spawnPointName)
    {
        TravelPoint _tpPoint;

        Debug.Log("TEST " + spawnPointName);
        Debug.Log("Taille : ");
        foreach (var x in CurrentSpawnList)
        {
            Debug.Log("Graaaaah !!!!" + x.ToString());
        }
        _tpPoint = CurrentSpawnList.Find(spawn => spawn.name == spawnPointName);
        if (_tpPoint == null)
        {
            Debug.LogError("The specified travel point name does not exist in the list (Did you add it inside the inspector ?)");
        }
        else
        {
            Debug.Log("Tp point to : " + _tpPoint.SpawnPointName);
            _player.transform.position = _tpPoint.transform.position;
        }
    }

    private IEnumerator LoadRoutine(string sceneName, string spawnPointName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        yield return op;

        MovePlayer(spawnPointName);
    }

    /*
    Change the current scene of the player
    */
    private void ChangeScene(string sceneName, string spawnPointName)
    {
        if (SceneUtility.GetBuildIndexByScenePath(sceneName) == -1)
        {
            Debug.LogError($"The scene name : {sceneName}, doesn't exist in the tree, please add it");
        }
        else
        {
            //Async load scene
            StartCoroutine(LoadRoutine(sceneName, spawnPointName));
        }
    }
}
