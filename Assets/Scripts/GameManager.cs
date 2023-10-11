using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] UIManager uiManager;
    [SerializeField] SaveData saveData;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AchievementManager achievementManager;

    public Sprite[] sprites;
    private void Awake()
    {
        if (instance == null)
        {
            Application.targetFrameRate = 60;

            instance = this;
            UIManager.instance = uiManager;
            SaveData.instance = saveData;
            AudioManager.instance = audioManager;
            AchievementManager.instance = achievementManager;

            saveData.Load();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.1f);

        }
    }

    private void OnApplicationQuit()
    {
        SaveData.instance.Save();
        AchievementManager.instance.Save();
    }
}
