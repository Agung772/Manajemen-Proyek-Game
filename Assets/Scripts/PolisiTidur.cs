using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiTidur : MonoBehaviour
{
    public bool jalanberlobang;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Handheld.Vibrate();
            Player.instance.StartRem(1);

            if (jalanberlobang)
            {
                AchievementManager.instance.AddValue("Tabrak jalan berlubang", 1);
            }
            else
            {
                AchievementManager.instance.AddValue("Lewatin polisi tidur", 1);
            }
        }
    }
}
