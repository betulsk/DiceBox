using System.IO;
using UnityEngine;

public class UserInventoryManager : Singleton<UserInventoryManager>
{
    private string _filePath;

    [SerializeField] private UserInventoryTrackableData _userInventoryTrackableData;
    [SerializeField] private UserInventoryTrackData _userInventoryTrackData;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        if(!_userInventoryTrackableData.TryLoad(_filePath))
        {
            var itemTypes = GameConfigManager.Instance.GetItemTypes();
            for(int i = 0; i < itemTypes.Count; i++)
            {
                _userInventoryTrackableData.UpsertItemCountByType(_userInventoryTrackData, itemTypes[i], 0, _filePath);
            }
        }
    }
}
