using System;

[Serializable]
public class UserInventoryTrackData
{
    public const string COUNT = "Count";
    public string TrackId;
    public int Count;

    public UserInventoryTrackData(string trackID, int count)
    {
        TrackId = trackID;
        Count = count;
    }
}
