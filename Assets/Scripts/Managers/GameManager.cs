using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public DiceDatas DiceDatas = new DiceDatas();
    public Action OnDiceDataSet;

    private void Awake()
    {
        
    }
}
