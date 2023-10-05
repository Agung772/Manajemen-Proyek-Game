using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;


    public TextMeshProUGUI gameTimeText;

    //
    public TextMeshProUGUI speedText;
    public RectTransform arrowRectT;
    private void Awake()
    {
        instance = this;
    }
    public void RemPlayer(bool value)
    {
        Player.instance.Rem(value);
    }
}
