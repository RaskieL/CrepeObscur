using UnityEngine;
using UnityEngine.InputSystem;
public class ExplorationState : BaseGameState
{
    private string _stateDescription = "Exploration (press esc to pause)";
    public ExplorationState(GameStateManager manager) : base(manager) {}

    public override void Enter()
    {
        _player.enabled = true;
        _manager.UI.DisplayStateInfo(_stateDescription);
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
          _manager.PushState(new PauseState(_manager));
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
        _manager.UI.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming ExploreState");
    }
}
