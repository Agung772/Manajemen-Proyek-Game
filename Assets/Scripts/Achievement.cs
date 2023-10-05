using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable", menuName = "Scriptable Object/Achievement")]
public class Achievement : ScriptableObject
{
    public string namaAchievement;
    public int maxValue;
}
