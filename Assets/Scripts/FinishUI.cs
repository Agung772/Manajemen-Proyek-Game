using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] Image[] starImage;

    [SerializeField] Sprite[] textTitles;
    [SerializeField] Image textImage;


    public void Set(int value)
    {
        starImage[1].gameObject.SetActive(false);
        starImage[2].gameObject.SetActive(false);
        starImage[3].gameObject.SetActive(false);

        switch (value)
        {
            case 0: 
                textImage.sprite = textTitles[0]; 
                break;
            case 1:
                textImage.sprite = textTitles[1];
                starImage[1].gameObject.SetActive(true);
                break;
            case 2:
                textImage.sprite = textTitles[2];
                starImage[1].gameObject.SetActive(true);
                starImage[2].gameObject.SetActive(true);
                break;
            case 3:
                textImage.sprite = textTitles[3];
                starImage[1].gameObject.SetActive(true);
                starImage[2].gameObject.SetActive(true);
                starImage[3].gameObject.SetActive(true);
                break;
        }
        Debug.Log("Jumlah bintang " + value);
    }
}
