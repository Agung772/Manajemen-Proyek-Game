using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUI : MonoBehaviour
{
    public int levelIndex;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject[] stars;
    private void Start()
    {
        Set();
    }
    public void Set()
    {
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        stars[3].SetActive(false);

        var dataStatic = DataStatic.instance;
        var gameData = SaveData.instance.gameData;
        float loadTime = SaveData.instance.gameData.gameTimeLevel[levelIndex];

        timeText.text = loadTime.ToString("F1");

        if (loadTime == 0) return;
        if (loadTime <= dataStatic.scoreIngameLevel[gameData.level].stars[3])
        {
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
        }
        else if (loadTime <= dataStatic.scoreIngameLevel[gameData.level].stars[2])
        {
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (loadTime <= dataStatic.scoreIngameLevel[gameData.level].stars[1])
        {
            stars[1].SetActive(true);
        }
    }
}
