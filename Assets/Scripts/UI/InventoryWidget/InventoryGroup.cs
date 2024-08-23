using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGroup : MonoBehaviour
{
    [SerializeField] private EItemType _itemType;
    [SerializeField] private Image _inventoryIconImage;
    [SerializeField] private TMP_Text _inventoryAmountText;

    public EItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }

    public void SetGroupValues(EItemType itemType, int amount)
    {
        ItemType = itemType;
        _inventoryIconImage.sprite = GameConfigManager.Instance.GetItemTypeToSprite(itemType);
        _inventoryAmountText.text = amount.ToString();
    }

    public void SetInventoryAmount(int amount)
    {
        _inventoryAmountText.text = amount.ToString();
    }
}
