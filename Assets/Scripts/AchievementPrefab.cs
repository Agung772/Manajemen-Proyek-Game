using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPrefab : MonoBehaviour
{
    public Achievement achievement;

    public Sprite bgSelesai;
    public Sprite bgBelumSelesai;

    public Image bgImage;
    public Image logoImage;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI valueText;

    bool start;
    public void UpdateAchievement()
    {
        titleText.text = achievement.namaAchievement;
        valueText.text = achievement.value + "/" + achievement.maxValue;

        //Cek selesai
        if (achievement.selesai == 0 && achievement.value >= achievement.maxValue)
        {
            achievement.selesai = 1;
            SetChild();
        }

        if (!start)
        {
            start = true;
            SetChild();

        }
        void SetChild()
        {
            if (achievement.selesai == 1)
            {
                bgImage.sprite = bgSelesai;
                transform.SetAsFirstSibling();
            }
            else
            {
                bgImage.sprite = bgBelumSelesai;
                transform.SetAsLastSibling();
            }
        }

    }
}
