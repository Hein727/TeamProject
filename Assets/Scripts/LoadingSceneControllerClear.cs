using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneControllerClear : MonoBehaviour
{
    void Start()
    {
        string nextScene = PlayerPrefs.GetString("NextStageName", "");
        if (!string.IsNullOrEmpty(nextScene))
        {
            StartCoroutine(LoadNext(nextScene));
        }
    }

    IEnumerator LoadNext(string sceneName)
    {
        yield return new WaitForSeconds(2.0f); // ローディング演出時間
        SceneManager.LoadScene(sceneName);
    }
}