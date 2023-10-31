using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public float gameTime;


    UIGameplay uiGameplay;
    [Header("Charger")]
    public GameObject chargerImage;

    [Header("Finish")]
    public GameObject finishUI;

    [Header("Levels")]
    public GameObject[] levels;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uiGameplay = UIGameplay.instance;
        SetChargerUI(false);

        if (SaveData.instance.gameData.level == 1)
        {
            levels[1].SetActive(true);
            levels[2].SetActive(false);
            levels[3].SetActive(false);
        }
        else if (SaveData.instance.gameData.level == 2)
        {
            levels[1].SetActive(false);
            levels[2].SetActive(true);
            levels[3].SetActive(false);
        }
        else if (SaveData.instance.gameData.level == 3)
        {
            levels[1].SetActive(false);
            levels[2].SetActive(false);
            levels[3].SetActive(true);
        }
    }
    private void Update()
    {
        GameTime();
    }

    void GameTime()
    {
        gameTime += Time.deltaTime;

        float menit = Mathf.FloorToInt(gameTime / 60);
        float detik = Mathf.FloorToInt(gameTime % 60);
        uiGameplay.gameTimeText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }
    bool callPolisi;
    public void CallPolice()
    {
        if (callPolisi) return;
        callPolisi = true;
        Debug.LogWarning("KEJAR PLAYER");
        Polisi[] poliss = FindObjectsOfType<Polisi>();
        for(int i = 0; i < poliss.Length; i++)
        {
            poliss[i].enabled = true;
            poliss[i].GetComponent<NonPlayer>().enabled = false;
        }

        AudioManager.instance.SetLoopSfx(AudioManager.instance.polisiSfx.name, true);
    }
    public void FinishUI()
    {
        var dataStatic = DataStatic.instance;
        var gameData = SaveData.instance.gameData;

        if (gameTime <= dataStatic.scoreIngameLevel[gameData.level].stars[3])
        {
            SetFinish(3);
        }
        else if (gameTime <= dataStatic.scoreIngameLevel[gameData.level].stars[2])
        {
            SetFinish(2);
        }
        else if (gameTime <= dataStatic.scoreIngameLevel[gameData.level].stars[1])
        {
            SetFinish(1);
        }

    }
    bool finish;
    public void SetFinish(int value)
    {
        if (finish) return;
        finish = true;

        var gameData = SaveData.instance.gameData;

        finishUI.SetActive(true);
        finishUI.GetComponent<FinishUI>().Set(value);

        saveTimeIngame();

        void saveTimeIngame()
        {
            if (gameTime < gameData.gameTimeLevel[gameData.level] || gameData.gameTimeLevel[gameData.level] == 0)
            {
                gameData.gameTimeLevel[gameData.level] = gameTime;
            }
        }
    }
    public void SetKlakson()
    {
        Player.instance.SetKlakson();
    }
    public void RemPlayer(bool value)
    {
        Player.instance.Rem(value);
    }
    public void SetChargerUI(bool value)
    {
        chargerImage.SetActive(value);
    }
    public void SetCharger(bool value)
    {
        Player.instance.bateraiCharger = value;
    }
}
