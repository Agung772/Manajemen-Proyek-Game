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

    public TextMeshProUGUI jarakTempuhText;
    private void Awake()
    {
        instance = this;
    }
    public void RemPlayer(bool value)
    {
        Player.instance.Rem(value);
    }

    public void SetAchievementUI(bool value)
    {
        UIManager.instance.SetAchievementUI(value);
    }
}
