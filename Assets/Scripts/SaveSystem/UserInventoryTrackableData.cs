using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserInventoryTrackableData : MonoBehaviour 
{
    public List<UserInventoryTrackData> UserInventoryDatas;

    public bool TryLoad(string filePath)
    {
        if(File.Exists(filePath))
        {
            Debug.Log("File is exist.");
            return true;
        }
        else
        {
            Debug.Log("File is not exist. Please create a new data file");
            return false;
        }
    }

    public void UpsertItemCountByType(EItemType itemType, int count, string filePath)
    {
        if(itemType == EItemType.None)
        {
            return;
        }

        string trackId = itemType.ToString();
        UserInventoryDatas.Add(new UserInventoryTrackData(trackId, count));
        JSONDataIO.Instance.SaveToJson(UserInventoryDatas, filePath);
    }

    public void UpdateInventoryData(EItemType itemType, int count, string filePath)
    {
        foreach (var item in UserInventoryDatas)
        {
            if(item.TrackId == itemType.ToString())
            {
                item.Count += count;
                JSONDataIO.Instance.SaveToJson(UserInventoryDatas, filePath);
            }
        }
    }
}
