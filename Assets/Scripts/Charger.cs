using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    bool cd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameplayManager.instance.SetChargerUI(true);

            if (!cd)
            {
                UIManager.instance.SpawnNotifText("Tekan tombol Charger untuk mengisi Baterai");
                cd = true;
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    yield return new WaitForSeconds(3);
                    cd = false;

                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameplayManager.instance.SetChargerUI(false);
        }
    }
}
