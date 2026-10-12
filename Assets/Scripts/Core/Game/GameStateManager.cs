using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{
    private readonly Stack<BaseGameState> stateStack = new Stack<BaseGameState>();
    public BaseGameState CurrentGameState
    {
        get
        {
            return stateStack.Peek();
        } 
    }

    public void Initialize(GameManager gameManager)
    {
        ChangeState(new MenuState(this, gameManager));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //
    }

    // Update is called once per frame
    private void Update()
    {
        if (stateStack.Count > 0)
        {
            CurrentGameState.UpdateState();
        }
    }

    public void PushState(BaseGameState state)
    {
        if (stateStack.Count > 0)
        {
            CurrentGameState.Pause();
        }
        
        stateStack.Push(state);
        state.Enter();
    }

    public void PopState()
    {
        if (stateStack.Count > 0)
        {
            BaseGameState state = stateStack.Pop();
            state.Exit();

            if (stateStack.Count > 0)
            {
                CurrentGameState.Resume();
            }
        }
    }

    public void ChangeState(BaseGameState state)
    {
        if (stateStack.Count > 0)
        {
            BaseGameState oldState = stateStack.Pop();
            oldState.Exit();
        }
        
        stateStack.Push(state);
        state.Enter();
    }
}