using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiTidur : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Handheld.Vibrate();
            Player.instance.StartRem(1);
        }
    }
}
