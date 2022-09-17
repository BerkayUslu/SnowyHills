using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReadWrite
{
    private static string path = Application.persistentDataPath + "/HighScore.mbu"; 
    
    public static void SaveScore(List<ScoreData> scoreDataList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, scoreDataList);
        stream.Close();
    }

    public static bool IsThereSaveFile()
    {
        return File.Exists(path);
    }

    public static List<ScoreData> GetScoreData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<ScoreData> scoreDataList = formatter.Deserialize(stream) as List<ScoreData>;
            stream.Close();
            return scoreDataList;
        }
        else
        {
            Debug.Log("No Score Data Files Found");
            return null;
        }
    }

    public static void DeleteFile()
    {
        File.Delete(path);
    }
    
 
}
