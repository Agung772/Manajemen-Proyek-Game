using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihLevelUI : MonoBehaviour
{
    public static PilihLevelUI instance;

    public int level;
    public int codeSkin;

    [SerializeField] Transform parentMotor;

    UIManager uiManager;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uiManager = UIManager.instance;

        UnsetMotorUI();
        parentMotor.GetChild(0).GetComponent<MotorUI>().Set();

        AudioManager.instance.SetBGM(AudioManager.instance.mainmenuBgm.name);
    }

    public void PindahScene(string value)
    {
        SaveData.instance.gameData.level = level;
        SaveData.instance.gameData.codeSkinPlayer = codeSkin;

        uiManager.PindahScene(value);

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }

    public void UnsetMotorUI()
    {
        for (int i = 0; i < parentMotor.childCount; i++)
        {
            parentMotor.GetChild(i).GetComponent<MotorUI>().Unset();
        }
    }
}
