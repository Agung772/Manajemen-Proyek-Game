using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihLevelUI : MonoBehaviour
{
    public string level;

    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.instance;
    }

    public void PindahScene(string value)
    {
        uiManager.PindahScene(value);
    }
}
