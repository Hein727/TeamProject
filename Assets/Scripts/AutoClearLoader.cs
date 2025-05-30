using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoClearLoader : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 3f;

    [SerializeField]
    private string clearSceneName = "GameClearScene";

    GameObject King;
    private bool StageClear = false;
    private float timer = 0f;
    private bool sceneLoading = false;

    void Start()
    {
        StageClear = false;
    }

    void Update()
    {
        King = GameObject.Find("EnemyRank11");
        if (King != null)
        {
            return;
        }
        else if (King == null)
        {
            StageClear = true;
        }

        if (StageClear && !sceneLoading)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                sceneLoading = true;
                PlayerPrefs.SetString("LastStage", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(clearSceneName);
            }
        }
    }
}