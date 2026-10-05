using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private string _spawnPointName;
    [SerializeField] private float _distance = 0f;

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
}
