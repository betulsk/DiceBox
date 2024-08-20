using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

    public string FilePath => _filePath;

    private void Awake()
    {
        //CreateUser();
    }

    public void CreateUser(TrackData<T> trackData, string fileName)
    {
        _filePath = Path.Combine(Application.persistentDataPath,  fileName);

        //Trackables.Add(trackData);
    }

    public void CreatePath()
    {

    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(typeof(T));
        File.WriteAllText(_filePath, json);
    }

    public T LoadData()
    {
        if(File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            T data = JsonUtility.FromJson<T>(json);
            return data;
        }
        return default;
    }
    public bool TryGetSingle(T trackID, out TrackData<T> trackable)
    {
        trackable = Trackables.FirstOrDefault(val => val.TrackID.Equals(trackID));

        return trackable != null;
    }
}
