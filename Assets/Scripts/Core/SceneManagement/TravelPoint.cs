using UnityEngine;

public class TravelPoint : MonoBehaviour
{

    /*
    Do give different names for each points even throught different scene.
    */


    // INSPECTOR
    [SerializeField] private bool _isExit = false;
    [SerializeField] private string _exitName;
    public string ExitName => _exitName;
    [SerializeField] private string _exitSceneName;
    public string ExitSceneName => _exitSceneName;

    // PRIVATE
    private string _spawnPointName;
    public string SpawnPointName => _spawnPointName;
    private string _sceneName;
    public string SceneName => _sceneName;
    private Vector3 _boxColliderSize;
    public Vector3 BoxColliderSize => _boxColliderSize;


    // Unused for now, meant when a spawn point have a direction for the player to point into the set direction and even walk along a line
    public enum SpawnDirection
    {
        [InspectorName("No Direction")] NoDirection,
        [InspectorName("Up Direction")] Up,
        [InspectorName("Right Direction")] Right,
        [InspectorName("Down Direction")] Down,
        [InspectorName("Left Direction")] Left,
    }

    public SpawnDirection selected;

    private void Awake()
    {
        if (_isExit && string.IsNullOrEmpty(_exitName))
        {
            Debug.LogWarning("Alert exit is set as true but no exit name was set for : " + gameObject.name);
        }

        if (_exitSceneName == null) {
            Debug.LogWarning("No exitSceneName found, please add the scene to where this points lead");
        }

        _sceneName = gameObject.scene.name;

        _spawnPointName = gameObject.name;
        _boxColliderSize = GetComponent<BoxCollider>().size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isExit && LevelManager.Instance.lastTpPoint != _exitName)
        {
            Debug.Log("Tp to : " + _exitName + "on scene :" + _sceneName);

            LevelManager.Instance.lastTpPoint = _spawnPointName;
            LevelManager.Instance.TeleportPlayer(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LevelManager.Instance.lastTpPoint == _exitName)
        {
            LevelManager.Instance.lastTpPoint = "";
        }
    }
}