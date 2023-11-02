using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectives;
    [SerializeField] int index;
    private void Start()
    {
        objectives = new GameObject[transform.childCount];
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i] = transform.GetChild(i).gameObject;

            if (i != 0)
            {
                objectives[i].SetActive(false);
            }

            objectives[i].GetComponent<Objective>().levelManager = this;

        }
    }

    public void SetIndex()
    {
        if (index == objectives.Length - 1)
        {
            Debug.Log("Finish");
            Player.instance.active = false;

            GameplayManager.instance.FinishUI();

            AudioManager.instance.SetLoopSfx(AudioManager.instance.polisiSfx.name, false);

            NonPlayer[] npcs = FindObjectsOfType<NonPlayer>();
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].nonActive = true;
            }
        }
        else
        {
            index++;
            objectives[index].SetActive(true);
            objectives[index - 1].SetActive(false);
        }
    }
}
