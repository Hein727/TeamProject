using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static StageLoading;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] float waitTime = 2.0f;

    void Start()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        if (!string.IsNullOrEmpty(StageLoader.NextStageName))
        {
            SceneManager.LoadScene(StageLoader.NextStageName);
        }
    }
}
