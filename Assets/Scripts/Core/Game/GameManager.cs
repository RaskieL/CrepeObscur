using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] private GameStateManager _gameStateManager;
    [field: SerializeField] private PartyManager _partyManager;
    [field: SerializeField] private UIManager _UIManager;
    
    public GameStateManager GameStateManager { get => _gameStateManager; private set => _gameStateManager = value; }
    public PartyManager PartyManager { get => _partyManager; private set => _partyManager = value; }
    public UIManager UIManager { get => _UIManager; private set => _UIManager = value; }
    

    private void Start()
    {
        _gameStateManager.Initialize(this);
    }

    private void Update()
    {
        //
    }
}