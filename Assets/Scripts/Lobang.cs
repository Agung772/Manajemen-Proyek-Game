using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobang : MonoBehaviour
{
    
    private void Start()
    {
        float random = Random.Range(1, 1.5f);
        transform.localScale = new Vector3(random, random, random);

        float randomRot = Random.Range(0, 180);
        transform.eulerAngles = new Vector3(0, randomRot, 0);
    }
}
