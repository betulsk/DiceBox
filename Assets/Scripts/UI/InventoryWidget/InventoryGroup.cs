using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGroup : MonoBehaviour
{
    private Transform _initTransform;
    private Coroutine _punchRoutine;
    [SerializeField] private EItemType _itemType;
    [SerializeField] private Image _inventoryIconImage;
    [SerializeField] private TMP_Text _inventoryAmountText;
    [SerializeField] private Animator _animator;

    public EItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }

    private void OnEnable()
    {
        _initTransform = transform;
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
        _animator.enabled = true;
        StartCoroutine(this.WaitForSeconds(.4f, () =>
        {
            _animator.enabled = false;
            transform.localScale = Vector3.one;
        }));
    }
}
