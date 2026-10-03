using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // PARAMS

    [SerializeField]
    private float _speed;
    public float Speed => _speed;
    public float groundDrag;
    public float playerHeight;
    public LayerMask groundLayer;
    public float airMultiplier = 0;

    // PRIVATE

    private Vector2 _moveInput;
    private Rigidbody _rb;
    private bool _isMoving;
    public bool IsMoving => _isMoving;

    private bool _isGrounded;
    

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

    private void FixedUpdate()
    {
        if (_isMoving) Move();
    }

    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, -Vector3.up,playerHeight * 0.5f + 0.2f, groundLayer);
        SpeedControl();

        if (_isGrounded)
        {
            _rb.linearDamping = groundDrag;
        }
        else
        {
            _rb.linearDamping = 0;
        }
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

        if (_isGrounded) // on the ground
        {
            _rb.AddForce(movement * _speed * Time.deltaTime, ForceMode.Impulse);
        }
        
        if (!_isGrounded) // in the air
        {
            _rb.AddForce(movement * _speed * Time.deltaTime * airMultiplier, ForceMode.Impulse);
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime); // Player looks smoothly into the direction it is going
    }

    private void StopMove()
    {
        _rb.angularVelocity = Vector3.zero; // Prevents the player from spining
        _isMoving = false;
    }

    /// <summary>
    /// Control the max velocity the player can reach, 
    /// if the current velocity is higher than the set speed 
    /// </summary>
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);

        if(flatVel.magnitude > _speed)
        {
            Vector3 maxVel = flatVel * _speed;
            _rb.linearVelocity = new Vector3(maxVel.x,_rb.linearVelocity.y, maxVel.z);
        }
    }
}