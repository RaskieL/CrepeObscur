using UnityEngine;

public abstract class BaseGameState
{
    protected readonly GameStateManager _stateManager;
    protected readonly GameManager _gameManager;

    protected BaseGameState(GameStateManager stateManager, GameManager gameManager)
    {
        _gameManager = gameManager;
        _stateManager = stateManager;
    }
    public abstract void Enter(); // quand l'état est ajouté à la pile
    public abstract void Exit(); // quand l'état est retiré de la pile
    public abstract void UpdateState(); // à chaque frame quand état au sommet de la pile
    public abstract void Pause(); // quand un nouvel état est empilé au dessus de celui-ci
    public abstract void Resume(); //  quand cet état est retiré et que celui-ci redevient actif
}
