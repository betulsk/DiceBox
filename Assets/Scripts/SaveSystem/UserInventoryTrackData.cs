public class UserInventoryTrackData : TrackData<string>
{
    public const string COUNT = "Count";
    public int Count;

    public UserInventoryTrackData(string trackID, int count) : base(trackID)
    {
        Count = count;
    }
}
