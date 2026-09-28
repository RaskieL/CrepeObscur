using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // PARAMS

    [SerializeField]
    private float _speed;
    public float Speed => _speed;

    // PRIVATE

    private Vector2 _moveInput;
    private Rigidbody _rb;
    private bool _isMoving;
    public bool IsMoving => _isMoving;

    // UNITY

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        PlayerInputs.instance.onMove += GetMoveInfo;
        PlayerInputs.instance.onStopMove += StopMove;
    }

    private void OnDisable()
    {
        PlayerInputs.instance.onMove -= GetMoveInfo;
        PlayerInputs.instance.onStopMove -= StopMove;
    }

    private void Update()
    {
        if (_isMoving) Move();
    }

    // INTERNAL

    private void GetMoveInfo(Vector2 moveInput)
    {
        if (!_isMoving)
        {
            _isMoving = true;
        }
        _moveInput = moveInput;
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y);
        _rb.AddForce(movement * _speed * Time.deltaTime, ForceMode.Impulse);

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime); // Player looks smoothly into the direction it is going
    }

    private void StopMove()
    {
        _rb.angularVelocity = Vector3.zero; // Prevents the player from spining
        _isMoving = false;
    }
}