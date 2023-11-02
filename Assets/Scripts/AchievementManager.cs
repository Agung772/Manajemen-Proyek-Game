using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    public Achievement[] achievements;
    public AchievementUI achievementUI;
    private void Start()
    {
        achievements = new Achievement[0];
        achievements = Resources.LoadAll<Achievement>("Achievement/");

        achievementUI.Add(achievements);
    }
    public void SetValue(string achievement, int value)
    {
        for (int i = 0; i < achievementUI.achievementPrefabs.Length; i++)
        {
            if (achievementUI.achievementPrefabs[i].achievement.namaAchievement == achievement)
            {
                achievementUI.achievementPrefabs[i].achievementData.value = value;
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
    public void AddValue(string achievement, int value)
    {
        for (int i = 0; i < achievementUI.achievementPrefabs.Length; i++)
        {
            if (achievementUI.achievementPrefabs[i].achievement.namaAchievement == achievement)
            {
                achievementUI.achievementPrefabs[i].achievementData.value += value;
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
        for (int i = 0; i < achievementUI.achievementPrefabs.Length; i++)
        {
            achievementUI.achievementPrefabs[i].Save();
        }
    }

}

