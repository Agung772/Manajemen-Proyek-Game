using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRem : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Dinding>())
        {
            Player.instance.m_speedMove = 0;
        }
    }
}
