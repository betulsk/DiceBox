using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataHandler : Singleton<DataHandler>
{
    public void SaveToJson<T>(List<T> saveList, string fileName)
    {
        string json = JsonHelper.ToJson<T>(saveList.ToArray());
        WriteFile(fileName, json);
    }

    public void ReadFromJson()
    {

    }

    private void WriteFile(string filePath, string content)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private void ReadFile()
    {

    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Itemsss;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Itemsss = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Itemsss = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Itemsss;
    }
}
