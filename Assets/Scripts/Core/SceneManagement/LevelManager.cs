using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private string _currentScene;
    private CharacterFollow _characterFollow;

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

        _characterFollow = _player.GetComponent<CharacterFollow>();
    }

    /// <summary>
    /// Teleport the player to the specified point, will change the scene before doing so.
    /// Will also be called for example when a door get oppened
    /// </summary>
    /// <param name="currentTravelPoint">The current travel point object reference</param>
    public void TeleportPlayer(TravelPoint currentTravelPoint)
    {
        if (_currentScene == null) 
        {
            Debug.LogError("No current scene detected");
        }

        if (currentTravelPoint.SceneName == currentTravelPoint.ExitSceneName)
        {
            // start animation
            MovePlayer(currentTravelPoint.ExitName);
        }
        else
        {
            // start animation
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

    // TP player and characters follow
    // Add a switch case with travel point enum to change the direction in which character follow and players should look and be positioned 
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
            //End animation
            _player.transform.position = _tpPoint.transform.position + new Vector3(0,_tpPoint.BoxColliderSize.y,0);

            // TP each character to the player position 
            foreach (Rigidbody r in _characterFollow.characters)
            {
                r.transform.position = _tpPoint.transform.position + new Vector3(0, _tpPoint.BoxColliderSize.y, 0);
            }
        }
    }
}
