using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotorUI : MonoBehaviour
{
    public int codeSkin;

    [SerializeField] Image buttonImage;
    [SerializeField] Sprite trueButton;
    [SerializeField] Sprite falseButton;
    public void Set()
    {
        PilihLevelUI.instance.codeSkin = codeSkin;
        PilihLevelUI.instance.UnsetMotorUI();
        buttonImage.sprite = trueButton;

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }

    public void Unset()
    {
        buttonImage.sprite = falseButton;
    }
}
