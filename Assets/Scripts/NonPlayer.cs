using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] int index;
    [SerializeField] Transform[] waypoints;
    private void Start()
    {
        int child = transform.GetChild(0).childCount;
        waypoints = new Transform[child];
        for (int i = 0; i < child; i++)
        {
            waypoints[i] = transform.GetChild(0).GetChild(i);
        }
        waypoints[0].transform.parent.parent = null;
        waypoints[0].transform.parent.name = waypoints[0].transform.parent.name + " / " + gameObject.name;

        SetWaypoint();
    }
    
    private void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            SetWaypoint();
        }
    }

    void SetWaypoint()
    {
        agent.SetDestination(waypoints[index].position);
        index++;
        if (index == waypoints.Length) index = 0;
    }
}
