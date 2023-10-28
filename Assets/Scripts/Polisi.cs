using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Polisi : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    Player player;
    private void Start()
    {
        player = Player.instance;
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 10;
    }
}
