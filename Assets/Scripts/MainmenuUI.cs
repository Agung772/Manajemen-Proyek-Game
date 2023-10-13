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
    }
}
