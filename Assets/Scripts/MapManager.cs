using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public GameObject mapAngleFrd;
    public GameObject mapAngleBk;
    public GameObject mapAngleRt;
    public GameObject mapAngleLt;
    private void Awake()
    {
        instance = this;
    }
    public void AngleMap(string value)
    {
        mapAngleFrd.SetActive(false);
        mapAngleBk.SetActive(false);
        mapAngleLt.SetActive(false);
        mapAngleRt.SetActive(false);

        if (value == "Forward") mapAngleFrd.SetActive(true);
        else if (value == "Back") mapAngleBk.SetActive(true);
        else if (value == "Right") mapAngleRt.SetActive(true);
        else if (value == "Left") mapAngleLt.SetActive(true);
    }
}
