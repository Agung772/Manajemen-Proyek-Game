using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AchievementUI : MonoBehaviour
{
    public GameObject achievementUIPrefab;
    [SerializeField] Transform content;

    public AchievementPrefab[] achievementPrefabs;
    public void Add(Achievement[] achievements)
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        achievementPrefabs = new AchievementPrefab[achievements.Length];
        for (int i = 0; i < achievements.Length; i++)
        {
            GameObject achievementGameobject = Instantiate(achievementUIPrefab, content);

            achievementPrefabs[i] = achievementGameobject.GetComponent<AchievementPrefab>();
            achievementPrefabs[i].achievement = achievements[i];
            achievementPrefabs[i].UpdateAchievement();
        }
    }
}
