using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoClearLoader : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 3f;

    [SerializeField]
    private string clearSceneName = "GameClearScene";

    private GameObject King;
    private BallSystem_S BS;
    private bool StageClear;
    private float timer = 0f;
    private bool sceneLoading = false;

    void Start()
    {
        StageClear = false;
        BS = GameObject.Find("BallSystem").GetComponent<BallSystem_S>();
    }

    void Update()
    {
        //DON'T TOUCH THIS PART
        bool EnemyExists = GameObject.FindGameObjectWithTag("Enemy") != null;

        if (EnemyExists)
        {
           King = GameObject.Find("E RANK11_0");
           StageClear = (King == null);
        }

        if ((BS.GameOver || StageClear) && !sceneLoading)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                sceneLoading = true;
                if(StageClear)
                {
                     PlayerPrefs.SetString("LastStage", SceneManager.GetActiveScene().name);
                     SceneManager.LoadScene(clearSceneName);
                }
                else
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }
    }
}