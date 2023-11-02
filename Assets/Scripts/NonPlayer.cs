using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System;
public class NonPlayer : MonoBehaviour
{
    [SerializeField] string[] texts;
    [SerializeField] TextMeshProUGUI textNPC;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] int index;
    [SerializeField] Transform[] waypoints;

    [SerializeField] SpriteRenderer primary;

    float speed;
    public RaycastHit hit;

    bool detecPlayer;
    public bool nonActive;
    float idleTime;

    [SerializeField] Animator senAnimator;
    private void Start()
    {
        SetSen();


        if (primary != null)
        {
            primary.color = new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f));
        }



        speed = UnityEngine.Random.Range(4f, 6f);
        agent.speed = speed;

        int child = transform.GetChild(0).childCount;
        waypoints = new Transform[child];
        for (int i = 0; i < child; i++)
        {
            waypoints[i] = transform.GetChild(0).GetChild(i);


            //string outputString = "";
            //int outputInt = 0;
            //string input = waypoints[i].name;
            ////Mencari angka
            //for (int j = 0; j < input.Length; j++)
            //{
            //    if (Char.IsDigit(input[j]))
            //        outputString += input[j];
            //}
            ////Convert string ke int
            //int.TryParse(outputString, out outputInt);
            //waypoints[i].name = outputString;

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
        AINonPlayer();

        if (agent.speed == 0 && !detecPlayer)
        {
            idleTime += Time.deltaTime;
            if (idleTime > 5)
            {
                agent.speed = speed;
                nonActive = true;

                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    yield return new WaitForSeconds(2);
                    nonActive = false;
                    idleTime = 0;
                }
            }
        }
    }

    void SetSen()
    {
        if (senAnimator == null) return;

        int random = UnityEngine.Random.Range(0, 3);
        if (random == 0) senAnimator.Play("Default");
        else if (random == 1) senAnimator.Play("Kiri");
        else if (random == 2) senAnimator.Play("Kanan");
    }
    void AINonPlayer()
    {
        if (nonActive) return;

        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.GetComponent<Player>())
            {
                agent.speed = 0;
                detecPlayer = true;
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
            detecPlayer = false;
        }
    }

    public void ReportPolisi()
    {
        if (textNPC != null)
        {
            int random = UnityEngine.Random.Range(0, texts.Length);

            textNPC.text = texts[random];

            textNPC.transform.parent.gameObject.SetActive(true);
        }


        GameplayManager.instance.CallPolice();
    }


    void SetWaypoint()
    {
        agent.SetDestination(waypoints[index].position);
        index++;
        if (index == waypoints.Length) index = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && enabled)
        {
            ReportPolisi();
        }
    }
}
