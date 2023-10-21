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
}
