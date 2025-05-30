using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectLoader : MonoBehaviour
{
    public void LoadStage1()
    {
        PlayerPrefs.SetString("NextStageName", "Stage1");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadStage2()
    {
        PlayerPrefs.SetString("NextStageName", "Stage2");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadStage3()
    {
        PlayerPrefs.SetString("NextStageName", "Stage3");
        SceneManager.LoadScene("LoadingScene");
    }
}