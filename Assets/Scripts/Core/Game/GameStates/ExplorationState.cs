using UnityEngine;
using UnityEngine.InputSystem;
public class ExplorationState : BaseGameState
{
    private string _stateDescription = "Exploration (press esc to pause)";
    protected PlayerController _player;
    public ExplorationState(GameStateManager stateManager, GameManager gameManager) : base(stateManager, gameManager) {}

    public override void Enter()
    {
        _player.enabled = true;
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        _player = Object.FindAnyObjectByType<PlayerController>();
        Debug.Log("Entering ExploreState");
    }

    public override void Exit()
    {
        _player.enabled = false;
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
        _player.enabled = false;
        Debug.Log("Pausing ExploreState");
    }

    public override void Resume()
    {
        _player.enabled = true;
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming ExploreState");
    }
}
