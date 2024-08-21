using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;
    public GameConfig GameConfig => _gameConfig;

    internal List<EItemType> GetItemTypes()
    {
        return GameConfig.ItemTypesToImages.Dictionary.Keys.ToList();
    }

    private void Awake()
    {
        if(GameConfig.IsDebug)
        {
            Application.targetFrameRate = GameConfig.TargetFrame;
        }
    }

    public int GetBoardLength()
    {
        return GameConfig.BoardLength;
    }

    public int GetBoardPieceMaxValue()
    {
        return GameConfig.BoardMaxValue;
    }

    public Sprite GetItemTypeToSprite(EItemType itemType)
    {
        return GameConfig.ItemTypesToImages.Dictionary[itemType];
    }
}
