using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] UIManager uiManager;
    [SerializeField] SaveData saveData;
    [SerializeField] AudioManager audioManager;

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

            saveData.Load();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        sprites = Resources.LoadAll<Sprite>("Item/");
        
    }
}
