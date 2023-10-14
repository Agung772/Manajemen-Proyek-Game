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

    bool cdPindahScene;


    public void PindahScene(string value)
    {
        if (cdPindahScene) return;
        cdPindahScene = true;
        StartCoroutine(SceneCoroutine());
        IEnumerator SceneCoroutine()
        {
            yield return new WaitForSeconds(1);

            if (value == "Quit") { Application.Quit();}

            var loadScene = SceneManager.LoadSceneAsync(value);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                float loading = loadScene.progress / 0.9f;
                //loadingBar.fillAmount = loading;
                //loadingText.text = (loading * 100).ToString("F0") + "%";
                if (loading >= 1)
                {
                    yield return new WaitForSeconds(1);
                    loadScene.allowSceneActivation = true;
                    //loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                    cdPindahScene = false;
                    print("Selesai pindah scene");


                }
                yield return null;
            }
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

    }
    public void SpawnNotifAct(string body)
    {
        NotifAct sc = Instantiate(NotifAct, parentSpawnAct).GetComponent<NotifAct>();
        sc.Set(body);
    }
}
