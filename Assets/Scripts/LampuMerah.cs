using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMerah : MonoBehaviour
{
    [SerializeField] float delay;

    bool merah;

    [SerializeField] Color dasarColor;
    [SerializeField] Color hijauColor;
    [SerializeField] Color kuningColor;
    [SerializeField] Color merahColor;

    [SerializeField] SpriteRenderer hijauSprite;
    [SerializeField] SpriteRenderer kuningSprite;
    [SerializeField] SpriteRenderer merahSprite;

    private void OnEnable()
    {
        StartSistem();
    }


    public void StartSistem()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            merah = true;

            hijauSprite.color = dasarColor;
            kuningSprite.color = dasarColor;
            merahSprite.color = merahColor;

            yield return new WaitForSeconds(delay);
            hijauSprite.color = dasarColor;
            kuningSprite.color = kuningColor;
            merahSprite.color = merahColor;

            yield return new WaitForSeconds(1);

            merah = false;
            hijauSprite.color = hijauColor;
            kuningSprite.color = dasarColor;
            merahSprite.color = dasarColor;

            yield return new WaitForSeconds(delay);

            hijauSprite.color = dasarColor;
            kuningSprite.color = kuningColor;
            merahSprite.color = dasarColor;

            yield return new WaitForSeconds(1);
            StartSistem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (merah)
            {
                Debug.LogWarning("Player menerobos lampu merah");
                Handheld.Vibrate();
            }
        }
    }
}
