using System.Collections.Generic;
using UnityEngine;

public class TrackData<T> : MonoBehaviour
{
    [SerializeField] private T _trackID = default;

    public T TrackID
    {
        get => _trackID;
        set => _trackID = value;
    }

    protected const string TRACK_ID_KEY = "TrackID";
    private string _filePath;

    public List<TrackData<T>> Trackables { get; set; }
           = new List<TrackData<T>>();

    public TrackData(T trackID)
    {
        TrackID = trackID;
    }
}
