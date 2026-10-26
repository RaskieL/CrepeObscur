using System.Collections.Generic;
using UnityEngine;

public class CombatState : BaseGameState
{

    private CombatManager _combatManager;
    public CombatState(GameStateManager stateManager, GameManager gameManager) : base(stateManager, gameManager)
    {
        
    }
    
    public override void Enter()
    {
        _combatManager = UnityEngine.Object.FindAnyObjectByType<CombatManager>();
        _combatManager.InitializeCombat(_gameManager.PartyManager.ActiveParty, new List<Combatant>(){/* PLACEHOLDER */});
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
