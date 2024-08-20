using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserInventoryTrackableData : MonoBehaviour
{
    public bool TryLoad(TrackData<string> trackData,EItemType itemType)
    {
        if(File.Exists(trackData.FilePath))
        {
            //trackData.LoadData();
            Debug.Log("veriler y�klendi.");
            return true;
        }
        else
        {
            Debug.LogWarning("kaydedilmi� veri bulunamad�, yeni veri olu�turuluyor.");
            return false; // yeni veri olu�tur
        }
    }

    public void UpsertAccessoryCountByTypeAndLevel(TrackData<string> trackData, EItemType itemType, int count)
    {
        string trackId = itemType.ToString();

        UserInventoryTrackData userInventoryData =  new UserInventoryTrackData(trackId, count);
        trackData.CreateUser(userInventoryData, "UserInventoryData.json");
        trackData.SaveData();
    }
}
