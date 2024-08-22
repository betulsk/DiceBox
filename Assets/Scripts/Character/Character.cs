using System;
using UnityEngine;

public class Character : Singleton<Character>
{
    [SerializeField] private CharacterMovementBehaviour _movementBehaviour;
    [SerializeField] private CharacterInventoryController _characterInventoryController;
    
    public CharacterMovementBehaviour MovementBehaviour => _movementBehaviour;
    public CharacterInventoryController CharacterInventoryController => _characterInventoryController;

    public int TileCount = 0;

    public Action<int> OnMovementFinished;

    private void Start()
    {
        GameManager.Instance.OnDiceStopped += OnDiceStopped;
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnDiceStopped -= OnDiceStopped;
        }
    }

    private void OnDiceStopped()
    {
        MovementBehaviour.MoveCustomActions(GameManager.Instance.BoardPieces);
    }
}
