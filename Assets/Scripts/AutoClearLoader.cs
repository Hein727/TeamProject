using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoClearLoader : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 3f;  // 待ち時間（秒）

    [SerializeField]
    private string clearSceneName = "GameClearScene"; // 実際のクリアシーン名に合わせてね！

    void Start()
    {
        StartCoroutine(LoadClearSceneAfterDelay());
    }

    IEnumerator LoadClearSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetString("LastStage", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(clearSceneName);
    }
}