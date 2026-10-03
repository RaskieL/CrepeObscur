using UnityEngine;
using UnityEngine.InputSystem;
public class MenuState : BaseGameState
{
    private string _stateDescription = "Menu (press enter to play)";
    public MenuState(GameStateManager manager) : base(manager) {}
    public override void Enter()
    {
        _player.enabled = false;
        _manager.UI.DisplayStateInfo(_stateDescription);
        Debug.Log("Entering MenuState");
    }

    public override void Exit()
    {
        Debug.Log("Exiting MenuState");
    }

    public override void UpdateState()
    {
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
             _manager.ChangeState(new ExplorationState(_manager));
        }   
    }

    public override void Pause()
    {
        Debug.Log("Pausing MenuState");
    }

    public override void Resume()
    {
        _manager.UI.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming MenuState");
    }
}
