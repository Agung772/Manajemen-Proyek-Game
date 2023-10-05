using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public float gameTime;

    UIGameplay uiGameplay;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uiGameplay = UIGameplay.instance;
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
        uiGameplay.gameTimeText.text = "Waktu : " + string.Format("{0:00}:{1:00}", menit, detik);
    }

}
