using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour
{
    [SerializeField] private bool _isExit = false;
    [SerializeField] private string _exitName;

    private string _spawnPointName;
    public string sceneName;

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
        sceneName = gameObject.scene.name;

        _spawnPointName = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered the collision zone");

        LevelManager.Instance.TeleportPlayer(sceneName, _exitName, this);
    }
}
