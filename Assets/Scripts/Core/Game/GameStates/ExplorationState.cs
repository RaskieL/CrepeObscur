using UnityEngine;
using UnityEngine.InputSystem;
public class ExplorationState : BaseGameState
{
    private string _stateDescription = "Exploration (press esc to pause)";
    protected PlayerInputs _playerInputs;
    public ExplorationState(GameStateManager stateManager, GameManager gameManager) : base(stateManager, gameManager) {}

    public override void Enter()
    {
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        _playerInputs = Object.FindAnyObjectByType<PlayerInputs>();
        _playerInputs.EnableInputs();
        Debug.Log("Entering ExploreState");
    }

    public override void Exit()
    {
        _playerInputs.DisableInputs();
        Debug.Log("Exiting ExploreState");
    }

    public override void UpdateState()
    {
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
          _stateManager.PushState(new PauseState(_stateManager, _gameManager));
        }
    }

    public override void Pause()
    {
        _playerInputs.DisableInputs();
        Debug.Log("Pausing ExploreState");
    }

    public override void Resume()
    {
        _playerInputs.EnableInputs();
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming ExploreState");
    }
}
