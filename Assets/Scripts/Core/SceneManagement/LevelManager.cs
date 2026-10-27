using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private string _currentScene;

    public string lastTpPoint;
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
    /// Teleport the player to the specified point, will change the scene before doing so
    /// Will be called for example when a door get oppened
    /// </summary>
    /// <param name="previousTravelPoint"></param>
    public void TeleportPlayer(TravelPoint currentTravelPoint)
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

    // Change the current scene of the player
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


    // Make a Routine to wait for the scene to finish loading before doing anything else
    private IEnumerator LoadRoutine(string sceneName, string spawnPointName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        yield return op;

        MovePlayer(spawnPointName);
    }

    //Not really optimized
    private void MovePlayer(string spawnPointName)
    {
        TravelPoint _tpPoint;

        _tpPoint = SpawnList.Current._spawnList.Find(spawn => spawn != null && spawn.name == spawnPointName);
        if (_tpPoint == null)
        {
            Debug.LogError("The specified travel point name does not exist in the list (Did you add it inside the inspector ?)");
        }
        else
        {
            _player.transform.position = _tpPoint.transform.position;
        }

    }
}
