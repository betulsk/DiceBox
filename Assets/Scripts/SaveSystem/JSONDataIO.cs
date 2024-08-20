using System.Collections.Generic;
using System.IO;
using System.Linq;

public class JSONDataIO : Singleton<JSONDataIO>
{
    public void SaveToJson<T>(List<T> saveList, string filePath)
    {
        string json = JSONDataHelper.ToJson<T>(saveList.ToArray());
        WriteFile(filePath, json);
    }

    public List<T> ReadFromJson<T>(string filePath)
    {
        string content = ReadFile(filePath);
        if(string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }
         
        return JSONDataHelper.FromJson<T>(content).ToList();
    }

    private void WriteFile(string filePath, string content)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private string ReadFile(string filePath)
    {
        if(File.Exists(filePath))
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}


