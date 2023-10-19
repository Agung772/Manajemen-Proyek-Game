using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] int index;
    [SerializeField] Transform[] waypoints;

    float speed;
    public RaycastHit hit;
    private void Start()
    {
        speed = Random.RandomRange(4, 6);
        agent.speed = speed;

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

        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.GetComponent<Player>())
            {
                agent.speed = 0;
            }
            if (hit.collider.GetComponent<LampuMerah>())
            {
                if (hit.collider.GetComponent<LampuMerah>().merah)
                {
                    agent.speed = 0;
                }
                else
                {
                    agent.speed = speed;
                }
            }
            if (hit.collider.GetComponent<NonPlayer>())
            {
                agent.speed = 0;
            }
        }
        else
        {
            agent.speed = speed;
        }
    }

    void SetWaypoint()
    {
        agent.SetDestination(waypoints[index].position);
        index++;
        if (index == waypoints.Length) index = 0;
    }
}
