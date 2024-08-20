using UnityEngine;

public interface IData
{
    
}

public class Data<T> : IData
{
    public void SaveData(T obje) //AppleTrackableData
    {

        string a = JsonUtility.ToJson(typeof(T));
        //TODO: Save data to json (a)

    }
    public void LoadData() { }
    public void UpdateData() { }
}


