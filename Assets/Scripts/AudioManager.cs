using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceBgm;
    public AudioSource audioSourceSfx;

    [Header("BGM")]
    public AudioClip mainmenuBgm;
    public AudioClip gameplayBgm;

    [Header("SFX")]
    public AudioClip klaksonSfx;
    public AudioClip motorEmakSfx;
    public AudioClip notifActSfx;
    public AudioClip buttonActSfx;
    public AudioClip remSfx;
    public AudioClip polisiSfx;

    public void SetBGM(string value)
    {
        if (value == mainmenuBgm.name)
        {
            audioSourceBgm.clip = mainmenuBgm;
            audioSourceBgm.Play();
        }
        else if (value == gameplayBgm.name)
        {
            audioSourceBgm.clip = gameplayBgm;
            audioSourceBgm.Play();
        }
    }

    public void SetSFX(string value)
    {
        if (value == buttonActSfx.name)
        {
            audioSourceSfx.PlayOneShot(buttonActSfx);
        }
        else if (value == buttonActSfx.name)
        {
            audioSourceSfx.PlayOneShot(buttonActSfx);
        }
        else if (value == klaksonSfx.name)
        {
            audioSourceSfx.PlayOneShot(klaksonSfx);
        }
    }

    AudioSource audioSourceremSfx;
    AudioSource audioSourceklaksonSfx;
    AudioSource audioSourcePolisiSfx;
    public void SetLoopSfx(string value, bool condition)
    {
        if (value == remSfx.name)
        {
            if (audioSourceremSfx == null) audioSourceremSfx = Instantiate(audioSourceBgm, transform);
            audioSourceremSfx.name = "AudioSource " + value;
            if (condition)
            {
                audioSourceremSfx.clip = remSfx;
                audioSourceremSfx.Play();
            }
            else
            {
                audioSourceremSfx.Stop();
            }
        }
        else if (value == klaksonSfx.name)
        {
            if (audioSourceklaksonSfx == null) audioSourceklaksonSfx = Instantiate(audioSourceBgm, transform);
            audioSourceklaksonSfx.name = "AudioSource " + value;
            if (condition)
            {
                audioSourceklaksonSfx.clip = klaksonSfx;
                audioSourceklaksonSfx.Play();
            }
            else
            {
                audioSourceklaksonSfx.Stop();
            }
        }
        else if (value == polisiSfx.name)
        {
            if (audioSourcePolisiSfx == null) audioSourcePolisiSfx = Instantiate(audioSourceBgm, transform);
            audioSourcePolisiSfx.name = "AudioSource " + value;
            if (condition)
            {
                audioSourcePolisiSfx.clip = polisiSfx;
                audioSourcePolisiSfx.Play();
            }
            else
            {
                audioSourcePolisiSfx.Stop();
            }
        }
    }
}
