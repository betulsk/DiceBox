using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInventoryManager : Singleton<UserInventoryManager>
{
    [SerializeField] private UserInventoryTrackableData _userInventoryTrackableData;
    [SerializeField] private UserInventoryTrackData _userInventoryTrackData;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach(var itemType in GameConfigManager.Instance.GetItemTypes())
        {
            if(!_userInventoryTrackableData.TryLoad(_userInventoryTrackData, itemType))
            {
                _userInventoryTrackableData.UpsertAccessoryCountByTypeAndLevel(_userInventoryTrackData, itemType, 0);
            }
        }
    }
}
