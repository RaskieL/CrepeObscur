using System;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInputs : MonoBehaviour
{
    // PARAMS

    [SerializeField]
    private PlayerControls _playerControls;

    // PRIVATE

    private static PlayerInputs _instance;
    public static PlayerInputs instance => _instance;

    // ACTIONS

    public Action<Vector2> onMove;
    public Action onStopMove;
    public Action onInteract;
    public Action onClick;

    // UNITY

    private void Awake()
    {
        if (_instance != null)
            return;

        _playerControls = new PlayerControls();
        _instance = this;
    }

    private void OnEnable()
    {
        _playerControls.Player.Enable();
        _playerControls.Player.Move.performed += context => onMove?.Invoke(_playerControls.Player.Move.ReadValue<Vector2>());
        _playerControls.Player.Move.canceled += context => onStopMove?.Invoke();
        _playerControls.Player.Interact.started += context => onInteract?.Invoke();
        _playerControls.Player.Click.performed += context => onClick?.Invoke();
    }

    private void OnDisable()
    {
        _playerControls.Player.Move.performed -= context => onMove?.Invoke(_playerControls.Player.Move.ReadValue<Vector2>());
        _playerControls.Player.Move.canceled -= context => onStopMove?.Invoke();
        _playerControls.Player.Interact.started -= context => onInteract?.Invoke();
        _playerControls.Player.Click.performed -= context => onClick?.Invoke();
        _playerControls.Player.Disable();
    }

    public void EnableInputs()
    {
        _playerControls.Player.Enable();
    }

    public void DisableInputs()
    {
        _playerControls.Player.Disable();
    }
}
