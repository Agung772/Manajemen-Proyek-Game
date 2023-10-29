using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [HideInInspector]
    public LevelManager levelManager;
    [SerializeField] ParticleSystem enterPart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (enterPart != null)
            {
                Destroy(enterPart, 3);
                enterPart.Play();
                enterPart.transform.parent = null;
            }

            levelManager.SetIndex();
        }
    }
}
