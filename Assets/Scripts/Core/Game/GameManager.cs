using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public GameStateManager GameStateManager { get; private set; }
    [field: SerializeField] public PartyManager PartyManager { get; private set; }
    [field: SerializeField] public UIManager UIManager { get; private set; }

    private void Start()
    {
        GameStateManager.Initialize(this);
    }

    private void Update()
    {
        //
    }
}