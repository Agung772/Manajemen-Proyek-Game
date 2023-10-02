using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementData achievementData;

    public Achievement[] achievements;

    [SerializeField] AchievementUI achievementUI;
    private void Start()
    {
        achievements = new Achievement[1];
        achievements = Resources.LoadAll<Achievement>("Achievement/");

        achievementUI.Add(achievements);


        achievementData.Add(achievements.Length);
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0);
            for (int i = 0; i < achievements.Length; i++)
            {
                achievementData.achievementsSave[i].namaAchievement = achievements[i].namaAchievement;
                achievementData.achievementsSave[i].value = achievements[i].value;
            }
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddValue("Tabrak jalan berlubang", 1);
        }        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddValue("Capai kecepatan 60 km/h", 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
    }
    public void AddValue(string achievement, int value)
    {
        for (int i = 0; i < achievementUI.achievementPrefabs.Length; i++)
        {
            if (achievementUI.achievementPrefabs[i].achievement.namaAchievement == achievement)
            {
                achievementUI.achievementPrefabs[i].achievement.value += value;
                achievementUI.achievementPrefabs[i].UpdateAchievement();
                break;
            }
            if (i == achievementUI.achievementPrefabs.Length - 1)
            {
                if (achievementUI.achievementPrefabs[i].achievement.namaAchievement != achievement)
                {
                    Debug.LogWarning("Nama Achievement-nya typo mungkin");
                }
            }
        }
    }

    public void Save()
    {
        string filePath = Application.persistentDataPath + "/AchievementData.jhon";
        string data = JsonUtility.ToJson(achievementData);
        System.IO.File.WriteAllText(filePath, data);
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/AchievementData.jhon";
        string data = System.IO.File.ReadAllText(filePath);
        achievementData = JsonUtility.FromJson<AchievementData>(data);
    }
}

[System.Serializable]
public class AchievementData
{
    public Achievements[] achievementsSave;

    public void Add(int value)
    {
        achievementsSave = new Achievements[value];
    }
}
[System.Serializable]
public class Achievements
{
    public string namaAchievement;
    public float value;
}