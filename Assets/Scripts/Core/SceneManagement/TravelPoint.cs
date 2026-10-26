using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour
{
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
        if (!_isExit)
        {
            Debug.LogWarning("Alert exit is set as true but no exit name was set for : " + gameObject.name);
        }

        if (_exitSceneName == null) {
            Debug.LogWarning("No exitSceneName found, please add the scene where this points lead");
        }

        _sceneName = gameObject.scene.name;

        _spawnPointName = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tp to : " + _exitName + "on scene :" + _sceneName);
        LevelManager.Instance.TeleportPlayer(_sceneName, _exitName, this);
    }
}
