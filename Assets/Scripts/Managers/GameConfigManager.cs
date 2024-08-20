using System;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;
    public GameConfig GameConfig => _gameConfig;

    internal List<EItemType> GetItemTypes()
    {
        return GameConfig.ItemTypes;
    }

    private void Awake()
    {
        if(GameConfig.IsDebug)
        {
            Application.targetFrameRate = GameConfig.TargetFrame;
        }
    }
}
