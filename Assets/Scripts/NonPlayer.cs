using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    int index;
    [SerializeField] Transform transformO;
    private void Start()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        agent.SetDestination(transformO.GetChild(index).transform.position);
        index++;
        //agent.SetDestination(new Vector3(Random.Range(x - 10, x + 10), 0, Random.Range(z - 10, z + 10)));
    }
    private void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            //float x = transform.position.x;
            //float z = transform.position.z;
            //agent.SetDestination(new Vector3(Random.Range(x - 10, x + 10), 0, Random.Range(z - 10, z + 10)));

            agent.SetDestination(transformO.GetChild(index).transform.position);
            index++;
            if (index == 2) index = 0;
            else index = 1;
        }
    }
}
