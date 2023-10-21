using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuUI : MonoBehaviour
{

    UIManager uiManager;
    private void Start()
    {
        uiManager = UIManager.instance;
    }

    public void PindahScene(string value)
    {
        uiManager.PindahScene(value);

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }
    public void SetAchievementUI(bool value)
    {
        UIManager.instance.SetAchievementUI(value);
    }

    public void QuitGame()
    {
        UIManager.instance.QuitGame();

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }
}
