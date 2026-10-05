using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    // PARAMS

    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private List<Rigidbody> characters;
    [SerializeField]
    private float stopDistance;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;
    [SerializeField]
    private float followStrength;

    // PRIVATE

    private List<float> characterSpeeds = new();

    // UNITY 

    private void Start()
    {
        int margin = 2;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.transform.position = new Vector3(transform.position.x + margin * (i + 1), transform.position.y, transform.position.z);
            characterSpeeds.Add(0f);
        }
    }

    // INTERNAL

    private void FixedUpdate()
    {
        Vector3 previousPosition = playerController.transform.position;

        for (int i = 0; i < characters.Count; i++)
        {
            Rigidbody rb = characters[i];

            Vector3 target = new Vector3(previousPosition.x, rb.position.y, previousPosition.z);

            Vector3 direction = target - rb.position;
            float distance = direction.magnitude;
            float speed = characterSpeeds[i];

            if (distance <= stopDistance) speed = Mathf.MoveTowards(speed, 0f, deceleration * Time.fixedDeltaTime);
            else
            {
                float targetSpeed = Mathf.Min(playerController.Speed, (distance - stopDistance) * followStrength);
                float accelerationRate = targetSpeed > speed ? acceleration : deceleration;
                speed = Mathf.MoveTowards(speed, targetSpeed, accelerationRate * Time.fixedDeltaTime);

                Vector3 movement = direction.normalized * speed * Time.fixedDeltaTime;
                movement = Vector3.ClampMagnitude(movement, distance - stopDistance);

                if (movement.sqrMagnitude > 0.001f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(movement);
                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
                }

                rb.MovePosition(rb.position + movement);
            }

            characterSpeeds[i] = speed;
            previousPosition = rb.position;
        }
    }

}
