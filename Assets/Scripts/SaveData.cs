using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public GameData gameData;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            Load();
        }
    }
    public void Save()
    {
        string filePath = Application.persistentDataPath + "/GameData.jhon";
        string data = JsonUtility.ToJson(gameData);
        System.IO.File.WriteAllText(filePath, data);


        print(filePath);
        print(Application.dataPath);

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

    public float volumeBGM;
    public float volumeSFX;
}
