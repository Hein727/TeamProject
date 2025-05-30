using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneContoroller : MonoBehaviour
{
    void Start()
    {
        string nextStage = PlayerPrefs.GetString("NextStageName", "");

        if (!string.IsNullOrEmpty(nextStage))
        {
            Debug.Log("次のステージを読み込みます: " + nextStage);
            SceneManager.LoadScene(nextStage);
        }
        else
        {
            Debug.LogWarning("NextStageName が設定されていません！");
        }
    }
}

