using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserInventoryManager : Singleton<UserInventoryManager>
{
    private string _filePath;

    [SerializeField] private UserInventoryTrackableData _userInventoryTrackableData;
    public Action OnInventoryDataLoaded;
    public Action<EItemType, List<UserInventoryTrackData>> OnInventoryDataUpdated;

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
                _userInventoryTrackableData.UpsertItemCountByType(itemTypes[i], 0, _filePath);
            }
            OnInventoryDataLoaded?.Invoke();
        }
        else
        {
            _userInventoryTrackableData.UserInventoryDatas = JSONDataIO.Instance.ReadFromJson<UserInventoryTrackData>(_filePath);
            OnInventoryDataLoaded?.Invoke();
        }
    }

    public void UpdateInventoryData(EItemType itemType, int count)
    {
        _userInventoryTrackableData.UpdateInventoryData(itemType, count, _filePath);
        OnInventoryDataUpdated?.Invoke(itemType, _userInventoryTrackableData.UserInventoryDatas);
    }

    public bool TryUpgrade(EItemType itemType)
    {
        if(itemType == EItemType.None)
        {
            return false;
        }
        return true;
    }

    public List<UserInventoryTrackData> GetInventoryDatas()
    {
        return _userInventoryTrackableData.UserInventoryDatas;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            _userInventoryTrackableData.UpdateInventoryData(EItemType.Apple, 8, _filePath);
        }
    }
}
