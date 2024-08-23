using UnityEngine;

public class CharacterInventoryController : MonoBehaviour
{
    private EItemType _itemType;
    private int _itemCount;

    [SerializeField] private Character _character;
    [SerializeField] private ParticleSystem _starParticle;

    private void Start()
    {
        _character.MovementBehaviour.OnMovementStop += OnMovementStop;
    }

    private void OnDestroy()
    {
        _character.MovementBehaviour.OnMovementStop -= OnMovementStop;
    }

    private void OnMovementStop()
    {
        FindInventoryDatas();
        if(UserInventoryManager.Instance.TryUpgrade(_itemType))
        {
            UserInventoryManager.Instance.UpdateInventoryData(_itemType, _itemCount);
            _starParticle.Play();
        }
    }

    private void FindInventoryDatas()
    {
        _itemType = GameManager.Instance.BoardPieces[_character.CurrentBoardIndex].ItemType;
        _itemCount = GameManager.Instance.BoardPieces[_character.CurrentBoardIndex].ItemCount;
    }
}
