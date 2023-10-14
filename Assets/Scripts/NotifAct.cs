using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotifAct : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bodyText;

    public void Set(string body)
    {
        bodyText.text = body;
        Destroy(gameObject, 3.5f);
    }
}
