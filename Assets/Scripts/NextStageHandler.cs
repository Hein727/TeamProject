using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageHandler : MonoBehaviour
{
    [SerializeField] string congratulationsScene = "CongratulationsScene"; // 最終クリア時のシーン名
    [SerializeField] string loadingScene = "LoadingScene"; // ロード画面用

    public void OnNextStageButton()
    {
        string lastStage = PlayerPrefs.GetString("LastStage","");

        if (lastStage.StartsWith("Stage"))
        {
            string numberPart = lastStage.Substring("Stage".Length);
            if (int.TryParse(numberPart, out int currentNumber))
            {
                int nextNumber = currentNumber + 1;
                string nextStage = "Stage" + nextNumber;
                Debug.Log("Trying to load scene: " + nextStage);

                if (IsSceneInBuild(nextStage))
                {
                    PlayerPrefs.SetString("NextStageName", nextStage);
                    SceneManager.LoadScene(loadingScene);
                }
                else
                {
                    SceneManager.LoadScene(congratulationsScene);
                }
            }
        }
    }

    bool IsSceneInBuild(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
                return true;
        }
        return false;
    }
}