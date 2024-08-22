using UnityEngine;

public class CharacterInventoryController : MonoBehaviour
{
    private EItemType _itemType;
    private int _itemCount;
    [SerializeField] private Character _character;

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
        UserInventoryManager.Instance.UpdateInventoryData(_itemType, _itemCount);
    }

    private void FindInventoryDatas()
    {
        _itemType = GameManager.Instance.BoardPieces[_character.TileCount - 1].ItemType;
        _itemCount = GameManager.Instance.BoardPieces[_character.TileCount - 1].ItemCount;
    }
}
