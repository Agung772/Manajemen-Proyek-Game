using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCollider : MonoBehaviour
{
    [SerializeField] Collider collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                collider.enabled = false;
                yield return new WaitForSeconds(2);
                collider.enabled = true;
            }
        }
    }
}
