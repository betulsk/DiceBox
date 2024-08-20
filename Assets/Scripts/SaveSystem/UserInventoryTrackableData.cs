using System;
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

    public void UpsertItemCountByType(UserInventoryTrackData trackData, EItemType itemType, int count, string filePath)
    {
        string trackId = itemType.ToString();
        UserInventoryDatas.Add(new UserInventoryTrackData(trackId, count));
        DataHandler.Instance.SaveToJson(UserInventoryDatas, filePath);
        //Wrapper wrapper = new Wrapper();
        //wrapper.Item = UserInventoryDatas;
        //Debug.Log("Here it");
        //string data = JsonUtility.ToJson(wrapper);
        //File.WriteAllText(filePath, data);
    }

    [Serializable]
    private class Wrapper
    {
        public List<UserInventoryTrackData> Item;
    }
}
