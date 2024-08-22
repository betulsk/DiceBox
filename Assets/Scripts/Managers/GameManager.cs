using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public DiceDatas DiceDatas = new DiceDatas();
    [SerializeField] public List<BoardPiece> BoardPieces;
    public Action OnDiceDataSet;
    public Action OnDiceStopped;
}
