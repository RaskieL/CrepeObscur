using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // PARAMS 

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float _zOffset;

    // UNITY 

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.transform.position.z - _zOffset);
    }
}