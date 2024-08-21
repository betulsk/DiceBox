using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameConfig",
   menuName = "GameConfig/Create a GameConfig",
   order = 1)]
public class GameConfig : ScriptableObject
{
    public bool IsDebug;
    public int TargetFrame;

    [Header("BOARD")]
    [SerializeField] private int _boardLength;
    public int BoardLength => _boardLength;

    [SerializeField] private int _boardMaxValue;
    public int BoardMaxValue => _boardMaxValue;

    [SerializeField] public SerializableDictionary<EItemType, Sprite> ItemTypesToImages;

}
