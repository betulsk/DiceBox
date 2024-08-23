using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public DiceDatas DiceDatas = new DiceDatas();
    [SerializeField] public List<BoardPiece> BoardPieces;

    public List<int> DiceDataList;

    public Action OnDiceDataSet;
    public Action OnDiceStopped;
    public Action OnMovementCompleted;

    public void ResetDiceData()
    {
        DiceDatas = new DiceDatas();
        DiceDataList.Clear();
    }
}
