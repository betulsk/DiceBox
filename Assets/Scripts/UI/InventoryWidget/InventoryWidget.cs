using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWidget : MonoBehaviour
{
    private Dictionary<EItemType, InventoryGroup> _itemTypeToInventoryGroups = new Dictionary<EItemType, InventoryGroup>();
    [SerializeField] private InventoryGroup _inventoryGroup;
    [SerializeField] private Transform _groupParentTransform;

    private void Start()
    {
        UserInventoryManager.Instance.OnInventoryDataLoaded += OnDataLoaded;
        UserInventoryManager.Instance.OnInventoryDataUpdated += OnDataUpdated;
    }

    private void OnDestroy()
    {
        UserInventoryManager.Instance.OnInventoryDataLoaded -= OnDataLoaded;
        UserInventoryManager.Instance.OnInventoryDataUpdated -= OnDataUpdated;
    }

    private void OnDataLoaded()
    {
        var inventoryDatas = UserInventoryManager.Instance.GetInventoryDatas();
        foreach(var inventoryData in inventoryDatas)
        {
            InventoryGroup inventoryGroup = Instantiate(_inventoryGroup, _groupParentTransform);
            EItemType itemType = (EItemType)Enum.Parse(typeof(EItemType), inventoryData.TrackId);
            inventoryGroup.SetGroupValues(itemType, inventoryData.Count);
            _itemTypeToInventoryGroups.Add(itemType, inventoryGroup);
        }
    }

    private void OnDataUpdated(EItemType type, List<UserInventoryTrackData> trackDatas)
    {
        for(int i = 0; i < trackDatas.Count; i++)
        {
            if(trackDatas[i].TrackId == type.ToString())
            {
                _itemTypeToInventoryGroups[type].SetInventoryAmount(trackDatas[i].Count);
            }
        } 
    }
}
