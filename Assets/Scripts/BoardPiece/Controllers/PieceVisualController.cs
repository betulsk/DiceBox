using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PieceVisualController : MonoBehaviour
{
    private const string XSTR = "x";
    private const string SPACE = " ";
    [SerializeField] private Image _pieceItemImage;
    [SerializeField] private TMP_Text _pieceItemText;
    [SerializeField] private BoardPiece _boardPiece;

    private void Start()
    {
        _boardPiece.OnPieceValueSet += SetVisual;
    }

    private void OnDestroy()
    {
        _boardPiece.OnPieceValueSet -= SetVisual;
    }

    public void SetVisual()
    {
        if(_boardPiece.ItemType == EItemType.None)
        {
            _pieceItemImage.enabled = false;
            _pieceItemText.enabled = false;
        }

        _pieceItemImage.sprite = GameConfigManager.Instance.GetItemTypeToSprite(_boardPiece.ItemType);
        _pieceItemText.text = XSTR + _boardPiece.ItemCount + SPACE + _boardPiece.ItemType;
        _boardPiece.OnPieceCreated?.Invoke();
    }
}
