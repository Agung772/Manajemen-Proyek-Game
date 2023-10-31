using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Polisi : MonoBehaviour
{
    public bool active;
    [SerializeField] NavMeshAgent agent;

    Player player;

    public GameObject lampuPolisi;
    private void Start()
    {
        player = Player.instance;
        active = true;
        lampuPolisi.SetActive(true);
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
            player = Player.instance;
            player.active = false;
            active = false;

            GameplayManager.instance.SetFinish(0);
            AudioManager.instance.SetLoopSfx(AudioManager.instance.polisiSfx.name, false);
        }
    }
}
