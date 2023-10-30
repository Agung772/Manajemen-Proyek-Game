using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStatic : MonoBehaviour
{
    public static DataStatic instance;

    public ScoreIngame[] scoreIngameLevel;
}
[System.Serializable]
public class ScoreIngame
{
    public float[] stars;
}