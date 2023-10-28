using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilarangRambu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameplayManager.instance.CallPolice();
        }
    }
}
