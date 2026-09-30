using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // PARAMS 

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float _zOffset;
    [SerializeField] private float _yOffset;

    // UNITY 

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - _yOffset, playerTransform.transform.position.z - _zOffset);
    }
}