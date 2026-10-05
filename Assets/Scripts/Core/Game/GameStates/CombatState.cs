using UnityEngine;

public class CombatState : BaseGameState
{

    public CombatState(GameStateManager manager) : base(manager)
    {
        
    }
    
    public override void Enter()
    {
        Debug.Log("Entering CombatState");
    }

    public override void Exit()
    {
        Debug.Log("Exiting CombatState");
    }

    public override void UpdateState()
    {
        //
    }

    public override void Pause()
    {
        Debug.Log("Pausing CombatState");
    }

    public override void Resume()
    {
        Debug.Log("Resuming CombatState");
    }
}
