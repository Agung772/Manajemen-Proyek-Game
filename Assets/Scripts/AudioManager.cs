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
    public AudioClip misiSfx;

    public void SetBGM(string value)
    {
        if (audioSourceBgm.clip.name == value) return;

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
        else if (value == misiSfx.name)
        {
            audioSourceSfx.PlayOneShot(misiSfx);
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
                audioSourceremSfx.volume = 0.4f;
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
                audioSourcePolisiSfx.volume = 0.5f;
            }
            else
            {
                audioSourcePolisiSfx.Stop();
            }
        }
    }
}
