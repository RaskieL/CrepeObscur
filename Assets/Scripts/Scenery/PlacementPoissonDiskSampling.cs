using System.Collections.Generic;
using UnityEngine;

public class PlacementPoissonDiskSampling : MonoBehaviour
{
    // PARAMS

    [SerializeField]
    private float width;
    [SerializeField]
    private float height;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private bool randomRotation;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform parent;

    // UNITY

    private void Start()
    {
        Placement();
    }

    // INTERNAL

    public void Placement()
    {
        List<Vector2> coordinates = GenerateCoordinates(width, height, minDistance);
        GameObject instanciatedObj;
        for (int i = 0; i < coordinates.Count; i++)
        {
            // Rotation
            Quaternion prefabRotation = prefab.transform.rotation;
            Quaternion rotation = Quaternion.Euler(prefabRotation.x, (randomRotation) ? Random.Range(0f, 360f) : prefabRotation.y, prefabRotation.z);
            // Position
            Vector3 position = new Vector3(coordinates[i].x - width / 2, prefab.transform.position.y, coordinates[i].y - height / 2);

            instanciatedObj = Instantiate(prefab, position, rotation);
            instanciatedObj.transform.parent = parent;
        }
    }

    public List<Vector2> GenerateCoordinates(float width, float height, float minDistance, int maxAttempts = 30, int seed = 1)
    {
        if (width <= 0 || height <= 0 || minDistance <= 0 || maxAttempts <= 0)
            throw new System.ArgumentException("A value is negative or equal to 0");

        Random.InitState(seed >= 0 ? seed : Random.Range(int.MinValue, int.MaxValue));

        var points = new List<Vector2>();
        var activePoints = new List<Vector2>();

        float cellSize = minDistance / Mathf.Sqrt(2f);

        int gridWidth = Mathf.CeilToInt(width / cellSize);
        int gridHeight = Mathf.CeilToInt(height / cellSize);

        int[,] grid = new int[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = -1;
            }
        }

        Vector2 firstPoint = new Vector2(Random.Range(0f, width), Random.Range(0f, height));

        AddPoint(firstPoint);

        while (activePoints.Count > 0)
        {
            int activeIndex = Random.Range(0, activePoints.Count);
            Vector2 point = activePoints[activeIndex];

            bool foundNewPoint = false;

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                float angle = Random.Range(0f, Mathf.PI * 2f);
                float distance = Random.Range(minDistance, minDistance * 2f);

                Vector2 candidate = point + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

                if (!IsInside(candidate))
                    continue;

                if (!IsValid(candidate))
                    continue;

                AddPoint(candidate);
                foundNewPoint = true;
                break;
            }

            if (!foundNewPoint)
            {
                activePoints.RemoveAt(activeIndex);
            }
        }

        return points;

        // Functions

        void AddPoint(Vector2 point)
        {
            int gridX = Mathf.FloorToInt(point.x / cellSize);
            int gridY = Mathf.FloorToInt(point.y / cellSize);

            grid[gridX, gridY] = points.Count;

            points.Add(point);
            activePoints.Add(point);
        }

        bool IsInside(Vector2 point)
        {
            return point.x >= 0f && point.x < width && point.y >= 0f && point.y < height;
        }

        bool IsValid(Vector2 candidate)
        {
            int cellX = Mathf.FloorToInt(candidate.x / cellSize);
            int cellY = Mathf.FloorToInt(candidate.y / cellSize);

            for (int x = Mathf.Max(0, cellX - 2); x <= Mathf.Min(gridWidth - 1, cellX + 2); x++)
            {
                for (int y = Mathf.Max(0, cellY - 2); y <= Mathf.Min(gridHeight - 1, cellY + 2); y++)
                {
                    int pointIndex = grid[x, y];

                    if (pointIndex == -1)
                        continue;

                    Vector2 existingPoint = points[pointIndex];

                    if ((candidate - existingPoint).sqrMagnitude < minDistance * minDistance)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

