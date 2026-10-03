using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{
    private Stack<BaseGameState> stateStack = new Stack<BaseGameState>();
    [field: SerializeField] public UIManager UI { get; private set; }

    public BaseGameState CurrentGameState
    {
        get
        {
            return stateStack.Peek();
        } 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ChangeState(new MenuState(this));
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