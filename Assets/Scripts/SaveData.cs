using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public GameData gameData;
    public void Save()
    {
        string filePath = Application.persistentDataPath + "/GameData.jhon";
        string data = JsonUtility.ToJson(gameData);
        System.IO.File.WriteAllText(filePath, data);


        print("Data berhasil di simpan di : " + filePath);

    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/GameData.jhon";
        string data = System.IO.File.ReadAllText(filePath);

        gameData = JsonUtility.FromJson<GameData>(data);
    }
}

[System.Serializable]
public class GameData
{
    public float score;

    public float jarakTempuh;

    public int codeSkinPlayer = 1;
    public int level = 1;

    public float gameTimaLevel1;
    public float gameTimaLevel2;
    public float gameTimaLevel3;
}
