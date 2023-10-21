using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Achievement")]
    [SerializeField] GameObject achievementUI;

    [SerializeField] Transform parentSpawnAct;
    [SerializeField] GameObject NotifAct;

    [Header("Transisi")]
    [SerializeField] Animator transisiAnimator;
    bool cdPindahScene;


    public void PindahScene(string value)
    {
        Time.timeScale = 1;

        if (cdPindahScene) return;
        cdPindahScene = true;
        StartCoroutine(SceneCoroutine());
        IEnumerator SceneCoroutine()
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.Play("Start");

            yield return new WaitForSeconds(0.5f);

            var loadScene = SceneManager.LoadSceneAsync(value);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                float loading = loadScene.progress / 0.9f;

                //loadingBar.fillAmount = loading;
                //loadingText.text = (loading * 100).ToString("F0") + "%";
                if (loading >= 1)
                {
                    yield return new WaitForSeconds(0.5f);
                    loadScene.allowSceneActivation = true;

                    transisiAnimator.Play("Exit");

                    cdPindahScene = false;
                    print("Selesai pindah scene");

                    yield return new WaitForSeconds(0.5f);
                    transisiAnimator.gameObject.SetActive(false);
                }
                yield return null;
            }
        }
    }

    public void QuitGame()
    {
        if (cdPindahScene) return;
        cdPindahScene = true;
        Time.timeScale = 1;
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.Play("Start");
            yield return new WaitForSeconds(0.5f);
            Application.Quit();

        }
    }
    public void SetAchievementUI(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
            achievementUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            achievementUI.SetActive(false);
        }

        AudioManager.instance.SetSFX(AudioManager.instance.buttonActSfx.name);
    }
    public void SpawnNotifAct(string body)
    {
        NotifAct sc = Instantiate(NotifAct, parentSpawnAct).GetComponent<NotifAct>();
        sc.Set(body);
    }
}
