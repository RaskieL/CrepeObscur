using UnityEngine;
using UnityEngine.InputSystem;
public class MenuState : BaseGameState
{
    private string _stateDescription = "Menu (press enter to play) OUI ÇA MARCHE PLUS BAH PROUT HEIN!->need new scene for main menu";
    protected PlayerInputs _playerInputs;
    public MenuState(GameStateManager stateManager, GameManager gameManager) : base(stateManager, gameManager) {}
    public override void Enter()
    {
        _playerInputs = Object.FindAnyObjectByType<PlayerInputs>();
        _playerInputs.DisableInputs();
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
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
             _stateManager.ChangeState(new ExplorationState(_stateManager, _gameManager));
        }   
    }

    public override void Pause()
    {
        Debug.Log("Pausing MenuState");
    }

    public override void Resume()
    {
        _gameManager.UIManager.DisplayStateInfo(_stateDescription);
        Debug.Log("Resuming MenuState");
    }
}
