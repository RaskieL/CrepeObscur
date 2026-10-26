using UnityEngine;
using UnityEngine.InputSystem;

public class PauseState : BaseGameState
{
    private string _stateDescription = "Pause (press esc to unpause)";
    public PauseState(GameStateManager stateManager, GameManager gameManager) : base(stateManager, gameManager)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("Entering PauseState");
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        Debug.Log("Exiting PauseState");
        Time.timeScale = 1;
    }

    public override void UpdateState()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _stateManager.PopState();
        }   
        
    }

    public override void Pause()
    {
        Debug.Log("Pausing PauseState");
    }

    public override void Resume()
    {
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming PauseState");
    }
}
