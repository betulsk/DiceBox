using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardPieceSpawner : MonoBehaviour
{
    private float _zValue = 0;

    [SerializeField] private BoardPiece _piecePrefab;
    [SerializeField] private List<BoardPiece> _pieces;
    [SerializeField] private Transform _pieceParentTransform;

    [SerializeField] private float _pieceZOffset = 1f;

    public void Spawn(Action callBack = null)
    {
        for(int i = 0; i < GameConfigManager.Instance.GetBoardLength(); i++)
        {
            BoardPiece piece = Instantiate(_piecePrefab, new Vector3(0, 0, _zValue), Quaternion.identity, _pieceParentTransform);
            _zValue += _pieceZOffset;
            CreateRandomData(piece);
            _pieces.Add(piece);
            GameManager.Instance.BoardPieces.Add(piece);
        }
        callBack?.Invoke();
    }

    private void CreateRandomData(BoardPiece piece)
    {
        EItemType itemType = (EItemType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EItemType)).Length);
        int itemCount = UnityEngine.Random.Range(1, GameConfigManager.Instance.GetBoardPieceMaxValue());
        piece.SetPieceValues(itemType, itemCount);
    }
}
