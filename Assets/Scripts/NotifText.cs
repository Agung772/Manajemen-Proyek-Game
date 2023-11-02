using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotifText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void Set(string value)
    {
        text.text = value;
        Destroy(gameObject, 3.5f);
    }
}
