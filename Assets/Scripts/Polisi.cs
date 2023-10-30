using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Polisi : MonoBehaviour
{
    public bool active;
    [SerializeField] NavMeshAgent agent;

    Player player;
    private void Start()
    {
        player = Player.instance;
        active = true;
    }
    private void Update()
    {
        if (active)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 10;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.active = false;
            active = false;
        }
    }
}
