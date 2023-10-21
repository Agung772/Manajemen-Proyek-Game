using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;


    public TextMeshProUGUI gameTimeText;

    [Header("SpeedometerUI")]
    public TextMeshProUGUI speedText;
    public Image indikatorImage;
    public Image bateraiImage;

    public TextMeshProUGUI jarakTempuhText;

    public GameObject pauseUI;
    private void Awake()
    {
        instance = this;
    }

    public void SetAchievementUI(bool value)
    {
        UIManager.instance.SetAchievementUI(value);
    }

    public void PindahScene(string value)
    {
        UIManager.instance.PindahScene(value);

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }

    public void Pause(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }
}
