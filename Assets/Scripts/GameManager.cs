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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            achievementManager.AddValue("Tabrak jalan berlubang", 1);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            achievementManager.AddValue("Capai kecepatan 50 km/h", 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.SetAchievementUI(true);
        }
    }

    private void OnApplicationQuit()
    {
        SaveData.instance.Save();
        AchievementManager.instance.Save();
    }

    private void OnApplicationPause()
    {
        SaveData.instance.Save();
        AchievementManager.instance.Save();
    }
}
