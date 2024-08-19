using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;
    public GameConfig GameConfig => _gameConfig;

    private void Awake()
    {
        if(GameConfig.IsDebug)
        {
            Application.targetFrameRate = GameConfig.TargetFrame;
        }
    }
}
