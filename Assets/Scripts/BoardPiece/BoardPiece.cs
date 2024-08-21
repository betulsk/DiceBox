using System;
using UnityEngine;

public class BoardPiece : MonoBehaviour
{
    private EItemType _itemType;
    private int _itemCount;
    [SerializeField] private PieceVisualController _pieceVisualController;

    #region Getter/Setters
    public EItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }

    public int ItemCount
    {
        get { return _itemCount; }
        set { _itemCount = value; }
    }
    #endregion

    public Action OnPieceCreated;
    public Action OnPieceValueSet;

    public void SetPieceValues(EItemType itemType, int itemCount)
    {
        ItemType = itemType;
        ItemCount = itemCount;
        _pieceVisualController.SetVisual();
        OnPieceValueSet?.Invoke();
    }
}
