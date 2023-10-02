using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    bool cdPindahScene;
    public void PindahScene(string value)
    {
        if (cdPindahScene) return;
        cdPindahScene = true;
        StartCoroutine(SceneCoroutine());
        IEnumerator SceneCoroutine()
        {
            yield return new WaitForSeconds(2);

            var loadScene = SceneManager.LoadSceneAsync(value);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                float loading = loadScene.progress / 0.9f;
                //loadingBar.fillAmount = loading;
                //loadingText.text = (loading * 100).ToString("F0") + "%";

                if (loading >= 1)
                {
                    yield return new WaitForSeconds(4);
                    loadScene.allowSceneActivation = true;
                    //loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                    cdPindahScene = false;
                    print("Selesai pindah scene");


                }
                yield return null;
            }
        }
    }
}
